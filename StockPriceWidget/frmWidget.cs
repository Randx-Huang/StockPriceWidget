using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockPriceWidget
{
    public partial class frmWidget : DevExpress.XtraEditors.XtraForm
    {
        static string _SettingFilePath = @".\setting.json"; //已儲存的設定檔
        static string _FileName = @".\Python\main.py";//python進入點
        static Dictionary<string, DockPanel> _StockCollection;//已加入的股票Collection
        static object _Obj = new object();//lock obejct
        System.Timers.Timer _ProgressTimer = new System.Timers.Timer();//更新資訊
        CallPython _CP = new CallPython();//CallPython物件

        /// <summary>
        /// 
        /// </summary>
        public frmWidget()
        {
            InitializeComponent();
            _StockCollection = new Dictionary<string, DockPanel>();

            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 0);
            this.Height = Screen.PrimaryScreen.Bounds.Height - 40;

            progressBarControl1.Properties.Maximum = 60000 / 1000;
            progressBarControl1.Properties.Minimum = 1;

            _ProgressTimer.Interval = 1000;
            _ProgressTimer.Elapsed += ProgressTimer_Elapsed;

            _CP.ReceivedData += Cp_ReceivedData;

        }

        /// <summary>
        /// 讀取原目錄中的設定檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            SettingEnabled(false);
            this.lbSetting.Enabled = false;

            if (_StockCollection.Count == 0 && !File.Exists(_SettingFilePath))
            {
                AddStock("StockQ_TWSE.index", null, this.dpFirstInfo);
            }
            else
            {
                var settingJson = File.ReadAllText(_SettingFilePath);
                var settingInfo = JsonConvert.DeserializeObject<SettingInfo>(settingJson);
                var index = 0;
                foreach (var key in settingInfo.ProductNo)
                {
                    var (exchange, stock, market) = DiscomposeKey(key);
                    var field = new ucStockInfo.DataField()
                    {
                        StockName = settingInfo.ProductName[index],
                        Exchange = exchange,
                        Market = market,
                        StockNo = stock
                    };
                    if (index == 0)
                    {
                        var stockInfo = this.FindStockUIControl(this.dpFirstInfo);
                        stockInfo.Field = field;
                        AddStock(key, null, this.dpFirstInfo);
                    }
                    else
                    {
                        AddStock(key, field);
                    }
                    ++index;
                }
            }
            await GetPrice();
        }

        /// <summary>
        /// 顯示Winform視窗時，Timer啟動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            this._ProgressTimer.Enabled = true;
        }

        /// <summary>
        /// 寫入目前的設定資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var priceRequestCollection = _StockCollection.Select(x => new { Keys = x.Key, Names = FindStockUIControl(x.Value).Field.StockName });

            var si = new SettingInfo();
            si.ProductNo.AddRange(priceRequestCollection.Select(x => x.Keys));
            si.ProductName.AddRange(priceRequestCollection.Select(x => x.Names));
            si.TimerInterval = this.progressBarControl1.Properties.Maximum;

            var json = JsonConvert.SerializeObject(si);
            File.WriteAllText(_SettingFilePath, json);

            this._ProgressTimer.Dispose();
        }
        #region ProgressTimer & ProgressBar

        /// <summary>
        /// 更新ProgressBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ProgressTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!this.progressBarControl1.IsDisposed)
            {
                await UpdateProgress();
            }
        }

        /// <summary>
        /// 更新Progress內容
        /// </summary>
        /// <param name="updateRightNow">是否立即更新股價</param>
        /// <returns></returns>
        private async Task UpdateProgress(bool updateRightNow = false)
        {
            this._ProgressTimer.Stop();

            if (this.progressBarControl1.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(async delegate { await UpdateProgress(); }));
            }
            else
            {
                if (updateRightNow || this.progressBarControl1.Position >= this.progressBarControl1.Properties.Maximum)
                {
                    this.progressBarControl1.Position = 0;
                    await GetPrice();
                }
                else
                {
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
            }

            this._ProgressTimer.Start();
        }
        #endregion

        /// <summary>
        /// 取得股價
        /// </summary>
        /// <returns></returns>
        private async Task GetPrice()
        {
            var stock = string.Join("|", _StockCollection.Keys);
            Debug.WriteLine($"{_FileName} 1 {stock} {DateTime.Now.ToString("yyyyMMddHHmmssfff")}");
            await _CP.Execute(_FileName.Contains(".py") ? CallPython.ExecuteType.PyFile : CallPython.ExecuteType.Exe
                , _FileName, "1", stock, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }

        /// <summary>
        /// 收到訊息的處理
        /// </summary>
        /// <param name="receivedData"></param>
        private void Cp_ReceivedData(string receivedData)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedData))
                {
                    var data = JsonConvert.DeserializeObject<List<RealPrice>>(receivedData);
                    DataChange(data);
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 資料變更
        /// </summary>
        /// <param name="priceData"></param>
        public void DataChange(List<RealPrice> priceData)
        {
            SettingEnabled(false);
            var key = "";
            foreach (var d in priceData)
            {
                key = ComposeStockKey(d.Exchange, d.StockNoWithMarket);
                if (_StockCollection.ContainsKey(key))
                {
                    var dockPanel = _StockCollection[key];
                    var si = FindStockUIControl(dockPanel);
                    si.OnDataChange(new ucStockInfo.DataField()
                    {
                        StockNo = d.StockNo,
                        StockName = d.StockName,
                        ClosingPrice = d.ClosingPrice,
                        Change = d.Change,
                        Exchange = d.Exchange,
                        Market = d.StockNoWithMarket.Split('.')[1],
                        Point = d.Point
                    });
                }
            }
            SettingEnabled(true);
        }

        /// <summary>
        /// 設定Label啟用/關閉
        /// </summary>
        /// <param name="enabled"></param>
        private void SettingEnabled(bool enabled)
        {
            if (this.lbSetting.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { SettingEnabled(enabled); }));
            }
            else
            {
                this.lbSetting.Enabled = enabled;
            }
        }

        /// <summary>
        /// 關閉Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ClosedPanel(object sender, DockPanelEventArgs e)
        {
            var si = FindStockUIControl(e.Panel);
            var key = ComposeStockKey(si.Field.Exchange, si.Field.StockNo, si.Field.Market);
            DeleteStock(key);
            await UpdateProgress(true);
        }

        #region 【新增、修改、刪除更新資料】
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="key"></param>
        /// <param name="existsDockPanel"></param>
        /// <returns></returns>
        private void AddStock(string key, ucStockInfo.DataField field, DockPanel existsDockPanel = null)
        {
            if (existsDockPanel == null && field == null)
            {
                XtraMessageBox.Show(this.LookAndFeel, "建立新的商品時，發生錯誤");
                return;
            }

            if (!_StockCollection.ContainsKey(key))
            {
                var newPanel = existsDockPanel ?? CreateNewDockPanel(new ucStockInfo(field));
                lock (_Obj)
                {
                    _StockCollection.Add(key, newPanel);
                }
            }
        }
        /// <summary>
        /// 刪除商品
        /// </summary>
        /// <param name="key"></param>
        private void DeleteStock(string key)
        {
            if (_StockCollection.ContainsKey(key))
            {
                lock (_Obj)
                {
                    _StockCollection.Remove(key);
                }

            }
        }
        /// <summary>
        /// 更新所有商品資料
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private async Task UpdateAllStock(List<ucStockInfo.DataField> fields)
        {
            //Delete Stock
            foreach (var key in _StockCollection.Keys)
            {
                var keyElements = DiscomposeKey(key);
                var field = fields.Where(f => f.Exchange == keyElements.exchange
                                      && f.StockNo == keyElements.stock
                                      && f.Market == keyElements.market)
                                       .FirstOrDefault();
                if (field == null)
                {
                    DeleteStock(key);
                }
            }

            //AddStock
            var composeKey = "";
            foreach (var field in fields)
            {
                composeKey = ComposeStockKey(field.Exchange, field.StockNo, field.Market);
                AddStock(composeKey, field);
            }
            await UpdateProgress(true);
        }

        /// <summary>
        /// 建立新的DockPanel
        /// </summary>
        /// <param name="si"></param>
        /// <returns></returns>
        private DockPanel CreateNewDockPanel(ucStockInfo si)
        {
            var newDockPanel = this.dockManager1.AddPanel(DockingStyle.Bottom);
            newDockPanel.Size = new System.Drawing.Size(154, 150);
            newDockPanel.Controls.Add(si);
            newDockPanel.Text = "";
            newDockPanel.ClosedPanel += ClosedPanel;
            return newDockPanel;
        }
        /// <summary>
        /// 尋找DockPanel中的Stock UserControl
        /// </summary>
        /// <param name="targetDockPanel"></param>
        /// <returns></returns>
        private ucStockInfo FindStockUIControl(DockPanel targetDockPanel)
        {
            for (int j = 0; j < targetDockPanel.ControlContainer.Controls.Count; j++)
            {
                if (targetDockPanel.ControlContainer.Controls[j] is ucStockInfo)
                {
                    return targetDockPanel.ControlContainer.Controls[j] as ucStockInfo;
                }
            }
            return null;
        }

        /// <summary>
        /// 組成Key值
        /// </summary>
        /// <param name="exchange">交易所 tse/otc/stockQ</param>
        /// <param name="stock">商品代碼</param>
        /// <param name="market">市場 tw/index</param>
        /// <returns></returns>
        private string ComposeStockKey(string exchange, string stock, string market = "")
            => $"{exchange}_{stock}{(string.IsNullOrEmpty(market) ? "" : $".{market}")}";

        /// <summary>
        /// 解構Key值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private (string exchange, string stock, string market) DiscomposeKey(string key)
        {
            var keysElements = key.Split(new char[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (keysElements != null && keysElements.Length > 0)
            {
                return (keysElements[0], keysElements[1], keysElements[2]);
            }
            else
            {
                return default;
            }
        }

        #endregion

        /// <summary>
        /// 開啟設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lbSetting_Click(object sender, EventArgs e)
        {
            var displayStockInfo = new List<ucStockInfo.DataField>();
            foreach (var kp in _StockCollection)
            {
                var si = FindStockUIControl(kp.Value);
                displayStockInfo.Add(si.Field);
            }

            var frmSetting = new frmSetting(displayStockInfo, _FileName);
            var result = frmSetting.ShowDialog();

            if (result == DialogResult.OK)
            {
                await UpdateAllStock(frmSetting.StockCollection);
                this.progressBarControl1.Properties.Maximum = frmSetting.TimerInterval;
            }
        }
    }
}

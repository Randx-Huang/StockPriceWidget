using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPriceWidget
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        CallPython _CP = new CallPython();
        static string _FileName = "";
        public static int TimerInterval = 60;
        /// <summary>
        /// 設定後的資料
        /// </summary>
        public List<ucStockInfo.DataField> StockCollection { get; private set; }

        public frmSetting()
        {
            InitializeComponent();
            _CP.ReceivedData += Cp_ReceivedData;
        }

        /// <summary>
        /// 傳入目前設定的資料以及python的程式進入點
        /// </summary>
        /// <param name="stockNoCollection">目前設定的資料</param>
        /// <param name="pythonFileName">python的程式進入點</param>
        public frmSetting(List<ucStockInfo.DataField> stockNoCollection, string pythonFileName)
        {
            InitializeComponent();
            StockCollection = stockNoCollection;
            this.memoEdit1.Lines = StockCollection
                .Select(data => $"{data.StockNo} {data.StockName} {data.Market} {data.Exchange}")
                .ToArray();
            _CP.ReceivedData += Cp_ReceivedData;
            _FileName = pythonFileName;
        }

        /// <summary>
        /// 收到更新後的商品基本資料
        /// </summary>
        /// <param name="receivedData"></param>
        private void Cp_ReceivedData(string receivedData)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedData))
                {
                    var productInfo = JsonConvert.DeserializeObject<List<ProductInfo>>(receivedData);
                    LoadProduct(productInfo);
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 設定商品基本資料的顯示
        /// </summary>
        /// <param name="pData"></param>
        private void LoadProduct(List<ProductInfo> pData)
        {
            if (pData == null || (string.IsNullOrEmpty(pData[0].StockNo) && string.IsNullOrEmpty(pData[0].StockName))) return;

            if (this.searchLookUpEdit1.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { LoadProduct(pData); }));
            }
            else
            {
                this.searchLookUpEdit1.SuspendLayout();
                this.searchLookUpEdit1.Properties.DataSource = null;
                List<ucStockInfo.DataField> fields = new List<ucStockInfo.DataField>();
                foreach (var p in pData)
                {
                    fields.Add(new ucStockInfo.DataField()
                    {
                        StockNo = p.StockNo,
                        Exchange = p.Exchange,
                        StockName = p.StockName,
                        Market = p.Exchange.ToLower() == "stockQ" ? "Index" : "TW"
                    });
                }
                this.searchLookUpEdit1.Properties.DataSource = fields;

                this.searchLookUpEdit1.Properties.PopulateViewColumns();
                this.searchLookUpEdit1.Properties.View.Columns["StockNo"].Caption = "股票代碼";
                this.searchLookUpEdit1.Properties.View.Columns["StockName"].Caption = "股票代碼";
                this.searchLookUpEdit1.Properties.View.Columns["Market"].Visible = false;

                this.searchLookUpEdit1.Properties.View.Columns["Exchange"].Visible = false;
                this.searchLookUpEdit1.Properties.View.Columns["Change"].Visible = false;
                this.searchLookUpEdit1.Properties.View.Columns["ClosingPrice"].Visible = false;
                this.searchLookUpEdit1.Properties.DisplayMember = "StockName";

                this.searchLookUpEdit1.ResumeLayout();
            }
        }
       
        /// <summary>
        /// Winform顯示設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmSetting_Shown(object sender, EventArgs e)
        {
            var exch = this.cbxExch.EditValue.ToString();
            var marketType = GetMarketType(exch);
            await ExecutePython(marketType);
        }

        /// <summary>
        /// 取得目前MarketType
        /// </summary>
        /// <param name="exch"></param>
        /// <returns></returns>
        private static string GetMarketType(string exch)
        {
            switch (exch)
            {
                case "TW":
                    return "2,4";
                case "Index":
                    return "Q";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 執行Python
        /// </summary>
        /// <param name="marketType"></param>
        /// <returns></returns>
        public async Task ExecutePython(string marketType)
        {
            await _CP.Execute(_FileName.Contains(".py") ? CallPython.ExecuteType.PyFile : CallPython.ExecuteType.Exe
                , _FileName, "0", marketType);
        }

        /// <summary>
        /// 新增商品資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAdd_Click(object sender, EventArgs e)
        {
            if (!(this.searchLookUpEdit1.GetSelectedDataRow() is ucStockInfo.DataField si))
            {
                XtraMessageBox.Show(this.LookAndFeel, "請選擇股票");
                return;
            }

            var market = this.cbxExch.EditValue.ToString();
            if (string.IsNullOrEmpty(market))
            {
                XtraMessageBox.Show(this.LookAndFeel, "請選擇市場");
                return;
            }

            var displayStockInfo = $"{si.StockNo} {si.StockName} {market.ToLower()} {si.Exchange}";
            if (this.memoEdit1.Text.Contains(displayStockInfo))
            {
                XtraMessageBox.Show(this.LookAndFeel, "股票重複");
                return;
            }
            this.memoEdit1.Text += $"{Environment.NewLine}{displayStockInfo}";
        }

        /// <summary>
        /// 確認相關設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            int.TryParse(this.txtTimerInterval.EditValue?.ToString(), out int ti);
            TimerInterval = ti;

            foreach (var addedStock in this.memoEdit1.Lines)
            {
                var stock = addedStock.Split(new char[] { ' ' });

                if (stock.Length > 3)
                {
                    CollectionAdd(stock[0], stock[1], stock[3], stock[2]);
                }
                else
                {
                    CollectionAdd(stock[0], stock[1], "StockQ" , stock[2]);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 取消設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 清除目前資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                this.searchLookUpEdit1.EditValue = "";
            }
        }

        /// <summary>
        /// 資料變動時,顯示/不顯示ClearButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var btn = this.searchLookUpEdit1.Properties.Buttons.Where(
                x => x.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear).FirstOrDefault();
            btn.Visible = (!string.IsNullOrEmpty(searchLookUpEdit1.EditValue?.ToString())) ? true : false;
        }

        /// <summary>
        /// 將目前設定的商品資料設定至Collection
        /// </summary>
        /// <param name="stockNo">股票代碼</param>
        /// <param name="stockName">股票名稱</param>
        /// <param name="exchange">交易所</param>
        public void CollectionAdd(string stockNo, string stockName, string exchange, string market )
        {
            this.StockCollection.Add(new ucStockInfo.DataField()
            {
                StockNo = stockNo,
                Exchange = exchange ,
                StockName = stockName,
                Market = market
            });
        }

        /// <summary>
        /// 市場變更時，載入商品資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cbxExch_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ExecutePython(GetMarketType(this.cbxExch.SelectedText));
        }

        /// <summary>
        /// 檢查更新秒數
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTimerInterval_EditValueChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtTimerInterval.EditValue?.ToString(), out int timerInterval);
            if (timerInterval < 30)
            {
                XtraMessageBox.Show(this.LookAndFeel, "請設定30秒以上(含)");
            }
        }
    }
}
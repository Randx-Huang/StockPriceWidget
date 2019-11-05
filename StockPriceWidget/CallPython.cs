using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StockPriceWidget
{
    public class CallPython
    {
        public delegate void ReceivedDataHandler(string receivedData);
        public event ReceivedDataHandler ReceivedData;

        public enum ExecuteType
        {
            /// <summary>
            /// Python檔案
            /// </summary>
            PyFile,
            /// <summary>
            /// 打包成Exe
            /// </summary>
            Exe
        }

        /// <summary>
        /// 執行Python
        /// 目前只有執行pyFile 因為Exe會非常慢
        /// </summary>
        /// <param name="exeType"></param>
        /// <param name="executePythonName"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        public async Task Execute(ExecuteType exeType, string executePythonName, params string[] @params)
        {
            var p = new Process();
            p.StartInfo.FileName = "python.exe";
            //XtraMessageBox.Show($"{executePythonName} {string.Join(" ", @params)}");
            p.StartInfo.Arguments = $"{executePythonName} {string.Join(" ", @params)}";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            if (exeType == ExecuteType.Exe)
            {
                p.Start();
                var output = await p.StandardOutput.ReadToEndAsync();
                this.ReceivedData?.Invoke(output);
                p.WaitForExit();
            }
            else
            {
                await Task.Run(() =>
                {
                    p.Start();
                    p.BeginOutputReadLine();
                    p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                    p.WaitForExit();
                });
            }
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.ReceivedData?.Invoke(e.Data);
        }
    }
}

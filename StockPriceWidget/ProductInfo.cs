using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceWidget
{
    public class ProductInfo
    {
        public string StockNo { get; set; }

        public string StockName { get; set; }

        public string Exchange { get; set; }
    }

    public class SettingInfo
    {

        /// <summary>
        /// 設定的商品代碼
        /// </summary>
        public List<string> ProductNo { get; set; } = new List<string>();

        /// <summary>
        /// 設定的商品名稱
        /// </summary>
        public List<string> ProductName { get; set; } = new List<string>();
        /// <summary>
        /// Internal的設定時間
        /// </summary>
        public int TimerInterval { get; set; }
    }
}

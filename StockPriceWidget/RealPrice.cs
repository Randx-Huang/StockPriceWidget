using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceWidget
{
    public class RealPrice
    {
        /// <summary>
        /// 交易所
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        /// 股票代碼
        /// </summary>
        public string StockNo { get; set; }

        /// <summary>
        /// 股票名稱
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// 股票名稱(含市場)
        /// </summary>
        public string StockNoWithMarket { get; set; }

        /// <summary>
        /// 收盤價
        /// </summary>
        public decimal ClosingPrice { get; set; }

        /// <summary>
        /// 漲幅
        /// </summary>
        public decimal Change { get; set; }


        /// <summary>
        /// 漲跌點數
        /// </summary>
        public decimal Point { get; set; }


    }
}

using System;
using System.Drawing;

namespace StockPriceWidget
{
    public partial class ucStockInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void UpdateUIDisplay();

        public DataField Field = new DataField();

        public class DataField
        {
            public string StockNo { get; set; }

            public string StockName { get; set; }

            public decimal Point { get; set; }

            public decimal? Change { get; set; }

            public decimal? ClosingPrice { get; set; }

            public string Exchange { get; set; }

            public string Market { get; set; }
        }

        public ucStockInfo()
        {
            InitializeComponent();
        }

        public ucStockInfo(DataField field)
        {
            Field = field;

            InitializeComponent();
          
            Start();
        }

        public void OnDataChange(DataField changeField)
        {
            Field = changeField;

            if (this.InvokeRequired)
                this.Invoke(new UpdateUIDisplay(Start));
            else
                Start();
        }

        public void Start()
        {
            Init();

            this.lbStockNo.Text = $"{Field.StockNo} {Field.StockName}";
            this.lbClosingPrice.Text = !Field.ClosingPrice.HasValue || Field.ClosingPrice.Value == 0 ? "--" : Field.ClosingPrice.ToString();
            this.lbPoint.Text = Field.Point.ToString();
            if (!Field.Change.HasValue ||Field.Change.Value >= 0)
            {
                this.lbSymbol.Text = "p";
                this.lbSymbol.Appearance.ForeColor = Color.Red;
                this.lbClosingPrice.Appearance.ForeColor = Color.Red;
                this.lbChange.Appearance.ForeColor = Color.Red;
                this.lbPoint.Appearance.ForeColor = Color.Red;
            }
            else
            {
                this.lbSymbol.Text = "q";
                this.lbSymbol.Appearance.ForeColor = Color.Green;
                this.lbClosingPrice.Appearance.ForeColor = Color.Green;
                this.lbChange.Appearance.ForeColor = Color.Green;
                this.lbPoint.Appearance.ForeColor = Color.Green;
            }
            this.lbChange.Text = !Field.Change.HasValue ? "0%" : $"{Math.Abs(Field.Change.Value).ToString()}%";
        }

        public void Init()
        {
            this.lbStockNo.Text = "";
            this.lbChange.Text = "0%";
            this.lbClosingPrice.Text = "";
        }
    }
}


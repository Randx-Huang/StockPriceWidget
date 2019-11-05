namespace StockPriceWidget
{
    partial class ucStockInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lbPoint = new DevExpress.XtraEditors.LabelControl();
            this.lbChange = new DevExpress.XtraEditors.LabelControl();
            this.lbSymbol = new DevExpress.XtraEditors.LabelControl();
            this.lbClosingPrice = new DevExpress.XtraEditors.LabelControl();
            this.lbStockNo = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.lbPoint);
            this.layoutControl1.Controls.Add(this.lbChange);
            this.layoutControl1.Controls.Add(this.lbSymbol);
            this.layoutControl1.Controls.Add(this.lbClosingPrice);
            this.layoutControl1.Controls.Add(this.lbStockNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(706, 206, 450, 400);
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(148, 115);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lbPoint
            // 
            this.lbPoint.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPoint.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbPoint.Appearance.Options.UseFont = true;
            this.lbPoint.Appearance.Options.UseForeColor = true;
            this.lbPoint.Appearance.Options.UseTextOptions = true;
            this.lbPoint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbPoint.Location = new System.Drawing.Point(4, 85);
            this.lbPoint.Name = "lbPoint";
            this.lbPoint.Size = new System.Drawing.Size(67, 26);
            this.lbPoint.StyleController = this.layoutControl1;
            this.lbPoint.TabIndex = 9;
            this.lbPoint.Text = "0.0";
            // 
            // lbChange
            // 
            this.lbChange.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChange.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbChange.Appearance.Options.UseFont = true;
            this.lbChange.Appearance.Options.UseForeColor = true;
            this.lbChange.Location = new System.Drawing.Point(100, 85);
            this.lbChange.Name = "lbChange";
            this.lbChange.Size = new System.Drawing.Size(44, 26);
            this.lbChange.StyleController = this.layoutControl1;
            this.lbChange.TabIndex = 8;
            this.lbChange.Text = "0%";
            // 
            // lbSymbol
            // 
            this.lbSymbol.Appearance.Font = new System.Drawing.Font("Wingdings 3", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lbSymbol.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbSymbol.Appearance.Options.UseFont = true;
            this.lbSymbol.Appearance.Options.UseForeColor = true;
            this.lbSymbol.Location = new System.Drawing.Point(75, 85);
            this.lbSymbol.Name = "lbSymbol";
            this.lbSymbol.Size = new System.Drawing.Size(21, 26);
            this.lbSymbol.StyleController = this.layoutControl1;
            this.lbSymbol.TabIndex = 7;
            this.lbSymbol.Text = "p";
            // 
            // lbClosingPrice
            // 
            this.lbClosingPrice.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClosingPrice.Appearance.Options.UseFont = true;
            this.lbClosingPrice.Appearance.Options.UseTextOptions = true;
            this.lbClosingPrice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbClosingPrice.Location = new System.Drawing.Point(4, 34);
            this.lbClosingPrice.Name = "lbClosingPrice";
            this.lbClosingPrice.Size = new System.Drawing.Size(140, 47);
            this.lbClosingPrice.StyleController = this.layoutControl1;
            this.lbClosingPrice.TabIndex = 6;
            this.lbClosingPrice.Text = "--";
            // 
            // lbStockNo
            // 
            this.lbStockNo.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbStockNo.Appearance.Options.UseFont = true;
            this.lbStockNo.Appearance.Options.UseTextOptions = true;
            this.lbStockNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbStockNo.Location = new System.Drawing.Point(4, 4);
            this.lbStockNo.Name = "lbStockNo";
            this.lbStockNo.Size = new System.Drawing.Size(140, 26);
            this.lbStockNo.StyleController = this.layoutControl1;
            this.lbStockNo.TabIndex = 4;
            this.lbStockNo.Text = "TWSE 台灣加權";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(148, 115);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lbStockNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(44, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(144, 30);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lbClosingPrice;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 51);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(51, 51);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(144, 51);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lbSymbol;
            this.layoutControlItem4.Location = new System.Drawing.Point(71, 81);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(25, 29);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(25, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lbChange;
            this.layoutControlItem5.Location = new System.Drawing.Point(96, 81);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(48, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lbPoint;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 81);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(24, 23);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(71, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ucStockInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucStockInfo";
            this.Size = new System.Drawing.Size(148, 115);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl lbStockNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lbClosingPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lbSymbol;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl lbChange;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl lbPoint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}

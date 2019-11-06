namespace StockPriceWidget
{
    partial class frmWidget
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWidget));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbSetting = new DevExpress.XtraEditors.LabelControl();
            this.lbDisplaySetting = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucStockInfo1 = new StockPriceWidget.ucStockInfo();
            this.dpFirstInfo = new DevExpress.XtraBars.Docking.DockPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dpFirstInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraEditors.PanelControl"});
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Office 2016 Black";
            this.barAndDockingController1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lbSetting);
            this.panelControl1.Controls.Add(this.lbDisplaySetting);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(154, 32);
            this.panelControl1.TabIndex = 2;
            // 
            // lbSetting
            // 
            this.lbSetting.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbSetting.Appearance.Image")));
            this.lbSetting.Appearance.Options.UseImage = true;
            this.lbSetting.Location = new System.Drawing.Point(126, 10);
            this.lbSetting.Name = "lbSetting";
            this.lbSetting.Size = new System.Drawing.Size(16, 16);
            this.lbSetting.TabIndex = 1;
            this.lbSetting.Click += new System.EventHandler(this.lbSetting_Click);
            // 
            // lbDisplaySetting
            // 
            this.lbDisplaySetting.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbDisplaySetting.Appearance.Image")));
            this.lbDisplaySetting.Appearance.Options.UseImage = true;
            this.lbDisplaySetting.Location = new System.Drawing.Point(104, 11);
            this.lbDisplaySetting.Name = "lbDisplaySetting";
            this.lbDisplaySetting.Size = new System.Drawing.Size(16, 16);
            this.lbDisplaySetting.TabIndex = 0;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarControl1.EditValue = 1;
            this.progressBarControl1.Location = new System.Drawing.Point(0, 32);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Minimum = 1;
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(154, 10);
            this.progressBarControl1.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.controlContainer1);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("f6e84c33-e01e-4c4d-bb6c-d0621e04998e");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(154, 652);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(5, 40);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(145, 607);
            this.controlContainer1.TabIndex = 0;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucStockInfo1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 41);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(146, 118);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucStockInfo1
            // 
            this.ucStockInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStockInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucStockInfo1.Name = "ucStockInfo1";
            this.ucStockInfo1.Size = new System.Drawing.Size(146, 118);
            this.ucStockInfo1.TabIndex = 0;
            // 
            // dpFirstInfo
            // 
            this.dpFirstInfo.Controls.Add(this.dockPanel1_Container);
            this.dpFirstInfo.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpFirstInfo.FloatVertical = true;
            this.dpFirstInfo.ID = new System.Guid("23cea9e3-09c0-400a-9afa-b567db5e7105");
            this.dpFirstInfo.Location = new System.Drawing.Point(0, 564);
            this.dpFirstInfo.Name = "dpFirstInfo";
            this.dpFirstInfo.OriginalSize = new System.Drawing.Size(154, 163);
            this.dpFirstInfo.Size = new System.Drawing.Size(154, 163);
            this.dpFirstInfo.TabStop = false;
            this.dpFirstInfo.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.ClosedPanel);
            // 
            // frmWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 727);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.dpFirstInfo);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1024, 0);
            this.LookAndFeel.SkinName = "Office 2016 Black";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "frmWidget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dpFirstInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.LabelControl lbSetting;
        private DevExpress.XtraEditors.LabelControl lbDisplaySetting;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpFirstInfo;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private ucStockInfo ucStockInfo1;
    }
}


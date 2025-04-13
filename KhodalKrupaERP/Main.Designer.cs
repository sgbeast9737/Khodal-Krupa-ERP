namespace KhodalKrupaERP
{
    partial class Main
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
            this.toolBar = new Syncfusion.Windows.Forms.Tools.XPMenus.XPToolBar();
            this.pbiMaster = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.biCustomer = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.biService = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.pbiBills = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.biChallan = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.pbiReports = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.biMonthlyBillReport = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.tabControlMain = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            // 
            // 
            // 
            this.toolBar.Bar.BarName = "";
            this.toolBar.Bar.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.pbiMaster,
            this.pbiBills,
            this.pbiReports});
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1181, 38);
            this.toolBar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "Tool Bar";
            this.toolBar.ThemeName = "Office2016Colorful";
            // 
            // pbiMaster
            // 
            this.pbiMaster.BarName = "pbiMaster";
            this.pbiMaster.CustomTextFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbiMaster.ID = "Masters";
            this.pbiMaster.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.biCustomer,
            this.biService});
            this.pbiMaster.Manager = null;
            this.pbiMaster.MetroColor = System.Drawing.Color.LightSkyBlue;
            this.pbiMaster.ShowToolTipInPopUp = false;
            this.pbiMaster.SizeToFit = true;
            this.pbiMaster.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            this.pbiMaster.Text = "Masters";
            this.pbiMaster.WrapLength = 20;
            // 
            // biCustomer
            // 
            this.biCustomer.BarName = "biCustomer";
            this.biCustomer.ID = "Customer";
            this.biCustomer.ShowToolTipInPopUp = false;
            this.biCustomer.SizeToFit = true;
            this.biCustomer.Text = "Customers";
            this.biCustomer.Click += new System.EventHandler(this.biCustomer_Click);
            // 
            // biService
            // 
            this.biService.BarName = "biService";
            this.biService.ID = "Services";
            this.biService.ShowToolTipInPopUp = false;
            this.biService.SizeToFit = true;
            this.biService.Text = "Services";
            this.biService.Click += new System.EventHandler(this.biService_Click);
            // 
            // pbiBills
            // 
            this.pbiBills.BarName = "pbiBills";
            this.pbiBills.CustomTextFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbiBills.ID = "Bills";
            this.pbiBills.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.biChallan});
            this.pbiBills.Manager = null;
            this.pbiBills.MetroColor = System.Drawing.Color.LightSkyBlue;
            this.pbiBills.ShowToolTipInPopUp = false;
            this.pbiBills.SizeToFit = true;
            this.pbiBills.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            this.pbiBills.Text = "Bills";
            this.pbiBills.WrapLength = 20;
            // 
            // biChallan
            // 
            this.biChallan.BarName = "biChallan";
            this.biChallan.ID = "Challan";
            this.biChallan.ShowToolTipInPopUp = false;
            this.biChallan.SizeToFit = true;
            this.biChallan.Text = "Challan";
            this.biChallan.Click += new System.EventHandler(this.biChallan_Click);
            // 
            // pbiReports
            // 
            this.pbiReports.BarName = "pbiReports";
            this.pbiReports.CustomTextFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbiReports.ID = "Reports";
            this.pbiReports.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.biMonthlyBillReport});
            this.pbiReports.Manager = null;
            this.pbiReports.MetroColor = System.Drawing.Color.LightSkyBlue;
            this.pbiReports.ShowToolTipInPopUp = false;
            this.pbiReports.SizeToFit = true;
            this.pbiReports.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            this.pbiReports.Text = "Reports";
            this.pbiReports.WrapLength = 20;
            // 
            // biMonthlyBillReport
            // 
            this.biMonthlyBillReport.BarName = "biMonthlyBillReport";
            this.biMonthlyBillReport.ID = "Monthly Bill Report";
            this.biMonthlyBillReport.ShowToolTipInPopUp = false;
            this.biMonthlyBillReport.SizeToFit = true;
            this.biMonthlyBillReport.Text = "Monthly Bill Report";
            this.biMonthlyBillReport.Click += new System.EventHandler(this.biMonthlyBillReport_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.ActiveTabColor = System.Drawing.Color.White;
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(2, 44);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.ShowCloseButtonHighLightBackColor = true;
            this.tabControlMain.ShowTabCloseButton = true;
            this.tabControlMain.Size = new System.Drawing.Size(1176, 625);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 670);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolBar);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(1010, 670);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khodal Krupa ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.XPMenus.XPToolBar toolBar;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem pbiMaster;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem biCustomer;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem pbiBills;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem biChallan;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem pbiReports;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem biMonthlyBillReport;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem biService;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlMain;
    }
}


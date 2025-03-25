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
            this.pbiMaster});
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1055, 30);
            this.toolBar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "xpToolBar1";
            this.toolBar.ThemeName = "Office2016Colorful";
            // 
            // pbiMaster
            // 
            this.pbiMaster.BarName = "pbiMaster";
            this.pbiMaster.ID = "Masters";
            this.pbiMaster.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.biCustomer});
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
            this.biCustomer.Text = "Customer";
            this.biCustomer.Click += new System.EventHandler(this.biCustomer_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.ActiveTabColor = System.Drawing.Color.White;
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(2, 34);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.ShowCloseButtonHighLightBackColor = true;
            this.tabControlMain.ShowTabCloseButton = true;
            this.tabControlMain.Size = new System.Drawing.Size(1050, 600);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 635);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolBar);
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
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlMain;
    }
}


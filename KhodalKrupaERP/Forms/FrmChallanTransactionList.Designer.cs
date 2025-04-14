namespace KhodalKrupaERP.Forms
{
    partial class FrmChallanTransactionList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChallanDateTo = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dteChallanDateTo = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblChallanDateFrom = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dteChallanDateFrom = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblCustomer = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cbCustomer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.lblChallanDateTo);
            this.panel1.Controls.Add(this.dteChallanDateTo);
            this.panel1.Controls.Add(this.lblChallanDateFrom);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Controls.Add(this.dteChallanDateFrom);
            this.panel1.Controls.Add(this.cbCustomer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 127);
            this.panel1.TabIndex = 3;
            // 
            // lblChallanDateTo
            // 
            this.lblChallanDateTo.DX = -36;
            this.lblChallanDateTo.DY = 3;
            this.lblChallanDateTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallanDateTo.LabeledControl = this.dteChallanDateTo;
            this.lblChallanDateTo.Location = new System.Drawing.Point(400, 24);
            this.lblChallanDateTo.Name = "lblChallanDateTo";
            this.lblChallanDateTo.Size = new System.Drawing.Size(32, 28);
            this.lblChallanDateTo.TabIndex = 13;
            this.lblChallanDateTo.Text = "To";
            // 
            // dteChallanDateTo
            // 
            this.dteChallanDateTo.AllowValueChangeOnMouseWheel = true;
            this.dteChallanDateTo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dteChallanDateTo.DateTimeIcon = null;
            this.dteChallanDateTo.Location = new System.Drawing.Point(436, 21);
            this.dteChallanDateTo.Name = "dteChallanDateTo";
            this.dteChallanDateTo.Size = new System.Drawing.Size(192, 35);
            this.dteChallanDateTo.TabIndex = 12;
            this.dteChallanDateTo.ToolTipText = "";
            this.dteChallanDateTo.Value = new System.DateTime(2025, 4, 1, 0, 0, 0, 0);
            // 
            // lblChallanDateFrom
            // 
            this.lblChallanDateFrom.DX = -177;
            this.lblChallanDateFrom.DY = 3;
            this.lblChallanDateFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallanDateFrom.LabeledControl = this.dteChallanDateFrom;
            this.lblChallanDateFrom.Location = new System.Drawing.Point(24, 24);
            this.lblChallanDateFrom.Name = "lblChallanDateFrom";
            this.lblChallanDateFrom.Size = new System.Drawing.Size(173, 28);
            this.lblChallanDateFrom.TabIndex = 11;
            this.lblChallanDateFrom.Text = "Challan Date From";
            // 
            // dteChallanDateFrom
            // 
            this.dteChallanDateFrom.AllowValueChangeOnMouseWheel = true;
            this.dteChallanDateFrom.DateTimeIcon = null;
            this.dteChallanDateFrom.Location = new System.Drawing.Point(201, 21);
            this.dteChallanDateFrom.Name = "dteChallanDateFrom";
            this.dteChallanDateFrom.Size = new System.Drawing.Size(192, 35);
            this.dteChallanDateFrom.TabIndex = 1;
            this.dteChallanDateFrom.ToolTipText = "";
            this.dteChallanDateFrom.Value = new System.DateTime(2025, 4, 1, 0, 0, 0, 0);
            // 
            // lblCustomer
            // 
            this.lblCustomer.DX = -100;
            this.lblCustomer.DY = 3;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.LabeledControl = this.cbCustomer;
            this.lblCustomer.Location = new System.Drawing.Point(822, 21);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(96, 28);
            this.lblCustomer.TabIndex = 10;
            this.lblCustomer.Text = "Customer";
            // 
            // cbCustomer
            // 
            this.cbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCustomer.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cbCustomer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Location = new System.Drawing.Point(922, 18);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(239, 35);
            this.cbCustomer.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cbCustomer.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbCustomer.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.TabIndex = 2;
            this.cbCustomer.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.BackColor = System.Drawing.Color.LightBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(17, 74);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 43);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.BackColor = System.Drawing.Color.LightBlue;
            this.btnGet.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.ForeColor = System.Drawing.Color.White;
            this.btnGet.Location = new System.Drawing.Point(1058, 74);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(103, 43);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = false;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.DetailsViewPadding = new System.Windows.Forms.Padding(0);
            this.sfDataGrid1.Location = new System.Drawing.Point(2, 133);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.PreviewRowHeight = 35;
            this.sfDataGrid1.Size = new System.Drawing.Size(1181, 519);
            this.sfDataGrid1.TabIndex = 2;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.sfDataGrid1_CellDoubleClick);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.BackColor = System.Drawing.Color.LightBlue;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(922, 74);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(103, 43);
            this.btnReport.TabIndex = 14;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // FrmChallanTransactionList
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 654);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfDataGrid1);
            this.MinimumSize = new System.Drawing.Size(1203, 701);
            this.Name = "FrmChallanTransactionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Challan Transaction List";
            this.Load += new System.EventHandler(this.FrmChallanTransactionList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.WinForms.ListView.SfComboBox cbCustomer;
        private System.Windows.Forms.Button btnGet;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dteChallanDateFrom;
        private System.Windows.Forms.Button btnRefresh;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCustomer;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblChallanDateFrom;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dteChallanDateTo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblChallanDateTo;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Button btnReport;
    }
}
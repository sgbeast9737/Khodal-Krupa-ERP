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
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChallanDate = new System.Windows.Forms.Label();
            this.dteChallanDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cbCustomer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).BeginInit();
            this.SuspendLayout();
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
            this.sfDataGrid1.Size = new System.Drawing.Size(921, 450);
            this.sfDataGrid1.TabIndex = 2;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.sfDataGrid1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblChallanDate);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Controls.Add(this.dteChallanDate);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Controls.Add(this.cbCustomer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 127);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblChallanDate
            // 
            this.lblChallanDate.AutoSize = true;
            this.lblChallanDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallanDate.Location = new System.Drawing.Point(12, 32);
            this.lblChallanDate.Name = "lblChallanDate";
            this.lblChallanDate.Size = new System.Drawing.Size(122, 28);
            this.lblChallanDate.TabIndex = 9;
            this.lblChallanDate.Text = "Challan Date";
            // 
            // dteChallanDate
            // 
            this.dteChallanDate.AllowValueChangeOnMouseWheel = true;
            this.dteChallanDate.DateTimeIcon = null;
            this.dteChallanDate.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.YearMonth;
            this.dteChallanDate.Location = new System.Drawing.Point(150, 25);
            this.dteChallanDate.Name = "dteChallanDate";
            this.dteChallanDate.Size = new System.Drawing.Size(239, 35);
            this.dteChallanDate.TabIndex = 1;
            this.dteChallanDate.ToolTipText = "";
            this.dteChallanDate.Value = new System.DateTime(2025, 4, 1, 0, 0, 0, 0);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(549, 32);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(96, 28);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Customer";
            // 
            // cbCustomer
            // 
            this.cbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCustomer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Location = new System.Drawing.Point(660, 25);
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
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(29, 74);
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
            this.btnGet.BackColor = System.Drawing.Color.LightGray;
            this.btnGet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(782, 74);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(117, 43);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = false;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // FrmChallanTransactionList
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 585);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfDataGrid1);
            this.Name = "FrmChallanTransactionList";
            this.Text = "FrmChallanTransactionList";
            this.Load += new System.EventHandler(this.FrmChallanTransactionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCustomer;
        private Syncfusion.WinForms.ListView.SfComboBox cbCustomer;
        private System.Windows.Forms.Button btnGet;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dteChallanDate;
        private System.Windows.Forms.Label lblChallanDate;
        private System.Windows.Forms.Button btnRefresh;
    }
}
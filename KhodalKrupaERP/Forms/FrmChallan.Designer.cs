namespace KhodalKrupaERP.Forms
{
    partial class FrmChallan
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
            this.inputPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblChallanDate = new System.Windows.Forms.Label();
            this.cbCustomer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.dtChallanDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lblCust = new System.Windows.Forms.Label();
            this.inputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.lblCust);
            this.inputPanel.Controls.Add(this.btnSave);
            this.inputPanel.Controls.Add(this.lblCustomer);
            this.inputPanel.Controls.Add(this.lblChallanDate);
            this.inputPanel.Controls.Add(this.cbCustomer);
            this.inputPanel.Controls.Add(this.dtChallanDate);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPanel.Location = new System.Drawing.Point(0, 0);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(958, 116);
            this.inputPanel.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(829, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 42);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(532, 21);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(96, 28);
            this.lblCustomer.TabIndex = 6;
            this.lblCustomer.Text = "Customer";
            // 
            // lblChallanDate
            // 
            this.lblChallanDate.AutoSize = true;
            this.lblChallanDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallanDate.Location = new System.Drawing.Point(532, 67);
            this.lblChallanDate.Name = "lblChallanDate";
            this.lblChallanDate.Size = new System.Drawing.Size(127, 28);
            this.lblChallanDate.TabIndex = 5;
            this.lblChallanDate.Text = "Challan Date ";
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Location = new System.Drawing.Point(224, 21);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(239, 30);
            this.cbCustomer.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cbCustomer.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbCustomer.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.TabIndex = 2;
            this.cbCustomer.TabStop = false;
            // 
            // dtChallanDate
            // 
            this.dtChallanDate.DateTimeIcon = null;
            this.dtChallanDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtChallanDate.Location = new System.Drawing.Point(224, 68);
            this.dtChallanDate.Name = "dtChallanDate";
            this.dtChallanDate.Size = new System.Drawing.Size(239, 30);
            this.dtChallanDate.TabIndex = 3;
            this.dtChallanDate.ToolTipText = "";
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfDataGrid1.Location = new System.Drawing.Point(0, 116);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.PreviewRowHeight = 35;
            this.sfDataGrid1.Size = new System.Drawing.Size(958, 496);
            this.sfDataGrid1.TabIndex = 4;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.RowValidating += new Syncfusion.WinForms.DataGrid.Events.RowValidatingEventHandler(this.sfDataGrid1_RowValidating);
            this.sfDataGrid1.RecordDeleting += new Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventHandler(this.sfDataGrid1_RecordDeleting);
            // 
            // lblCust
            // 
            this.lblCust.AutoSize = true;
            this.lblCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCust.Location = new System.Drawing.Point(686, 37);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(97, 25);
            this.lblCust.TabIndex = 7;
            this.lblCust.Text = "Customer";
            // 
            // FrmChallan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 612);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.inputPanel);
            this.Name = "FrmChallan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChallan";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmChallan_KeyDown);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inputPanel;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblChallanDate;
        private Syncfusion.WinForms.ListView.SfComboBox cbCustomer;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dtChallanDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCust;
    }
}
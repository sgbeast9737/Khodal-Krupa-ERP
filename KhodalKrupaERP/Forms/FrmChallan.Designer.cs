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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblChallanDate = new System.Windows.Forms.Label();
            this.lblDesignNo = new System.Windows.Forms.Label();
            this.cbCustomer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.dtChallanDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDesignNo = new System.Windows.Forms.TextBox();
            this.inputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.txtDesignNo);
            this.inputPanel.Controls.Add(this.lblCustomer);
            this.inputPanel.Controls.Add(this.lblChallanDate);
            this.inputPanel.Controls.Add(this.lblDesignNo);
            this.inputPanel.Controls.Add(this.cbCustomer);
            this.inputPanel.Controls.Add(this.dtChallanDate);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPanel.Location = new System.Drawing.Point(0, 0);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(969, 133);
            this.inputPanel.TabIndex = 0;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(556, 23);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(96, 28);
            this.lblCustomer.TabIndex = 6;
            this.lblCustomer.Text = "Customer";
            // 
            // lblChallanDate
            // 
            this.lblChallanDate.AutoSize = true;
            this.lblChallanDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallanDate.Location = new System.Drawing.Point(25, 85);
            this.lblChallanDate.Name = "lblChallanDate";
            this.lblChallanDate.Size = new System.Drawing.Size(127, 28);
            this.lblChallanDate.TabIndex = 5;
            this.lblChallanDate.Text = "Challan Date ";
            // 
            // lblDesignNo
            // 
            this.lblDesignNo.AutoSize = true;
            this.lblDesignNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignNo.Location = new System.Drawing.Point(25, 23);
            this.lblDesignNo.Name = "lblDesignNo";
            this.lblDesignNo.Size = new System.Drawing.Size(104, 28);
            this.lblDesignNo.TabIndex = 4;
            this.lblDesignNo.Text = "Design No";
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Location = new System.Drawing.Point(695, 20);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(239, 31);
            this.cbCustomer.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cbCustomer.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbCustomer.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.TabIndex = 1;
            this.cbCustomer.TabStop = false;
            // 
            // dtChallanDate
            // 
            this.dtChallanDate.DateTimeIcon = null;
            this.dtChallanDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtChallanDate.Location = new System.Drawing.Point(194, 77);
            this.dtChallanDate.Name = "dtChallanDate";
            this.dtChallanDate.Size = new System.Drawing.Size(232, 36);
            this.dtChallanDate.TabIndex = 3;
            this.dtChallanDate.ToolTipText = "";
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.Location = new System.Drawing.Point(0, 138);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.PreviewRowHeight = 35;
            this.sfDataGrid1.Size = new System.Drawing.Size(968, 342);
            this.sfDataGrid1.TabIndex = 0;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.RowValidating += new Syncfusion.WinForms.DataGrid.Events.RowValidatingEventHandler(this.sfDataGrid1_RowValidating);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(842, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 46);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 62);
            this.panel1.TabIndex = 1;
            // 
            // txtDesignNo
            // 
            this.txtDesignNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignNo.Location = new System.Drawing.Point(194, 20);
            this.txtDesignNo.Name = "txtDesignNo";
            this.txtDesignNo.Size = new System.Drawing.Size(232, 34);
            this.txtDesignNo.TabIndex = 7;
            // 
            // FrmChallan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.inputPanel);
            this.Name = "FrmChallan";
            this.Text = "FrmChallan";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmChallan_KeyDown);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inputPanel;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblChallanDate;
        private System.Windows.Forms.Label lblDesignNo;
        private Syncfusion.WinForms.ListView.SfComboBox cbCustomer;
        private Syncfusion.WinForms.Input.SfDateTimeEdit dtChallanDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDesignNo;
    }
}
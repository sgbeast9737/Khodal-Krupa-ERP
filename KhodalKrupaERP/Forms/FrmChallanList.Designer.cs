namespace KhodalKrupaERP.Forms
{
    partial class FrmChallanList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddChallan = new System.Windows.Forms.Button();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupDataByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnChooserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerReportGeneration = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddChallan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnAddChallan
            // 
            this.btnAddChallan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddChallan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChallan.Location = new System.Drawing.Point(12, 19);
            this.btnAddChallan.Name = "btnAddChallan";
            this.btnAddChallan.Size = new System.Drawing.Size(121, 43);
            this.btnAddChallan.TabIndex = 1;
            this.btnAddChallan.Text = "Add Challan";
            this.btnAddChallan.UseVisualStyleBackColor = false;
            this.btnAddChallan.Click += new System.EventHandler(this.btnAddChallan_Click);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.Location = new System.Drawing.Point(2, 4);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.PreviewRowHeight = 35;
            this.sfDataGrid1.Size = new System.Drawing.Size(794, 368);
            this.sfDataGrid1.TabIndex = 1;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.sfDataGrid1_CellDoubleClick);
            this.sfDataGrid1.RecordDeleting += new Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventHandler(this.sfDataGrid1_RecordDeleting);
            this.sfDataGrid1.CellButtonClick += new Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventHandler(this.sfDataGrid1_CellButtonClick);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearGroupingToolStripMenuItem,
            this.groupDataByToolStripMenuItem,
            this.expandeAllToolStripMenuItem,
            this.collapseAllToolStripMenuItem,
            this.columnChooserToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(186, 124);
            // 
            // clearGroupingToolStripMenuItem
            // 
            this.clearGroupingToolStripMenuItem.Name = "clearGroupingToolStripMenuItem";
            this.clearGroupingToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.clearGroupingToolStripMenuItem.Text = "Clear grouping";
            this.clearGroupingToolStripMenuItem.Click += new System.EventHandler(this.clearGroupingToolStripMenuItem_Click);
            // 
            // groupDataByToolStripMenuItem
            // 
            this.groupDataByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.groupDataByToolStripMenuItem.Name = "groupDataByToolStripMenuItem";
            this.groupDataByToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.groupDataByToolStripMenuItem.Text = "Group data by";
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.dateToolStripMenuItem.Text = "Date";
            this.dateToolStripMenuItem.Click += new System.EventHandler(this.dateToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // expandeAllToolStripMenuItem
            // 
            this.expandeAllToolStripMenuItem.Name = "expandeAllToolStripMenuItem";
            this.expandeAllToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.expandeAllToolStripMenuItem.Text = "Expande all";
            this.expandeAllToolStripMenuItem.Click += new System.EventHandler(this.expandeAllToolStripMenuItem_Click);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.collapseAllToolStripMenuItem.Text = "Collapse all";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // columnChooserToolStripMenuItem
            // 
            this.columnChooserToolStripMenuItem.Name = "columnChooserToolStripMenuItem";
            this.columnChooserToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.columnChooserToolStripMenuItem.Text = "Column chooser";
            this.columnChooserToolStripMenuItem.Click += new System.EventHandler(this.columnChooserToolStripMenuItem_Click);
            // 
            // backgroundWorkerReportGeneration
            // 
            this.backgroundWorkerReportGeneration.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReportGeneration_DoWork);
            this.backgroundWorkerReportGeneration.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReportGeneration_RunWorkerCompleted);
            // 
            // FrmChallanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStripGrid;
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmChallanList";
            this.Text = "FrmChallanList";
            this.Load += new System.EventHandler(this.FrmChallanList_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddChallan;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem groupDataByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearGroupingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnChooserToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReportGeneration;
    }
}
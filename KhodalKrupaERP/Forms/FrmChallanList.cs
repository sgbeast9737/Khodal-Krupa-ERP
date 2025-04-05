using FastReport;
using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using Syncfusion.Data;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport.Export.PdfSimple;
using KhodalKrupaERP.Reports;

namespace KhodalKrupaERP.Forms
{

    public partial class FrmChallanList : Form
    {
        private ColumnChooserPopup columnChooser;
        string[] columnsToHide = new string[] { "ChallanId", "Year", "Month", "PhoneNo" };

        public FrmChallanList()
        {
            InitializeComponent();
            columnChooser = new ColumnChooserPopup(this.sfDataGrid1);
        }

        private void FrmChallanList_Load(object sender, EventArgs e)
        {
            sfDataGrid1.DataSource = ChallanController.GetInfoOfAllChallans();

            Helper.setAnalysisConfig(sfDataGrid1, true);
            sfDataGrid1.AllowDeleting = true;

            Helper.hideColumn(sfDataGrid1, columnsToHide);

            //add button column 
            this.sfDataGrid1.Columns.Add(new GridButtonColumn()
            {
                MappingName = "PhoneNo",
                HeaderText = "Send to Whatsapp",
                Image = SystemIcons.Information.ToBitmap(),
                ImageSize = new Size(16, 16),
                TextImageRelation = TextImageRelation.ImageBeforeText,
            });

            this.sfDataGrid1.Style.ButtonStyle.BackColor = Color.Green;
            this.sfDataGrid1.Style.ButtonStyle.TextColor = Color.White;

            summaryConfig();
        }

        private void summaryConfig()
        {
            Helper.addSummary(sfDataGrid1, "Total");
            Helper.addGroupSummary(sfDataGrid1, "Total");
        }

        private void btnAddChallan_Click(object sender, EventArgs e)
        {
            Program.AddFormToTab(new FrmChallan(), "Add Challan");
        }

        private void sfDataGrid1_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowData is ChallanInfo challanInfo && this.ParentForm is Main mainForm)
            {
                Program.AddFormToTab(new FrmChallan(challanInfo.ChallanId), "Edit Challan");
            }
        }

        private void sfDataGrid1_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are sure you want to delete this challan ?", "Delete challan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ChallanInfo challan in e.Items)
                    {
                        ChallanController.DeleteChallan(challan.ChallanId);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error while deleting record \nError : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.addGrouping(sfDataGrid1, "Year", "Month");
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.addGrouping(sfDataGrid1, "CustomerId", "Year", "Month");
        }

        private void expandeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sfDataGrid1.ExpandAllGroup();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sfDataGrid1.CollapseAllGroup();
        }

        private void clearGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sfDataGrid1.ClearGrouping();
        }

        private void columnChooserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columnChooser.Show();
        }

        //send info to whatsapp
        private void sfDataGrid1_CellButtonClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            if (e.Record is Syncfusion.WinForms.DataGrid.DataRow dataRow)
            {
                if (dataRow.RowData is ChallanInfo challanInfo)
                {
                    if (!backgroundWorkerReportGeneration.IsBusy)
                    {
                        backgroundWorkerReportGeneration.RunWorkerAsync(challanInfo);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Report generation task is still running wait while running task is complete", "Report generation Task running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void backgroundWorkerReportGeneration_DoWork(object sender, DoWorkEventArgs e)
        {
            ChallanInfo challanInfo = (ChallanInfo)e.Argument;

            try
            {
                ChallanReport report = new ChallanReport(challanInfo);
                //ShowLoadingAnimation();
                report.savePdf();
                //HideLoadingAnimation();

                MessageBox.Show("invoice saved successfully", "PDF Saved Succcessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error occured while generating report \nError Message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorkerReportGeneration_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
        }
    }
}
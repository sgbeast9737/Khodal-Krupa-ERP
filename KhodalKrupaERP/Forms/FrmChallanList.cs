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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhodalKrupaERP.Forms
{

    public partial class FrmChallanList : Form
    {
        private ColumnChooserPopup columnChooser;
        string[] columnsToHide = new string[] { "ChallanId", "Year", "Month" };

        public FrmChallanList()
        {
            InitializeComponent();
            columnChooser = new ColumnChooserPopup(this.sfDataGrid1);
        }

        private void FrmChallanList_Load(object sender, EventArgs e)
        {
            sfDataGrid1.DataSource = ChallanController.GetInfoOfAllChallans();

            Helper.setDefaultConfig(sfDataGrid1, true);
            Helper.hideColumn(sfDataGrid1, columnsToHide);
           
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

                foreach (Challan challan in e.Items)
                {
                    if(result == DialogResult.Yes)
                    {
                        ChallanController.DeleteChallan(challan.ChallanId);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error while deleting record \nError : " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
    }
}

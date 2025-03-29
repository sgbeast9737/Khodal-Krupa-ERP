using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Models;
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
        public FrmChallanList()
        {
            InitializeComponent();
            sfDataGrid1.AllowDeleting = true;
        }

        private void FrmChallanList_Load(object sender, EventArgs e)
        {
            sfDataGrid1.DataSource = ChallanController.GetInfoOfAllChallans();
        }

        private void btnAddChallan_Click(object sender, EventArgs e)
        {
            if(this.ParentForm is Main mainForm)
            {
                mainForm.AddFormToTab(new FrmChallan(), "Add Challan");
            }
        }

        private void sfDataGrid1_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {

            //if (rowData != null)
            //{
            //    // Access ChallanId dynamically (reflection)
            //    var challanId = rowData.GetType().GetProperty("ChallanId")?.GetValue(rowData, null);
            //    MessageBox.Show("Challan ID: " + challanId);
            //}
            //e.DataRow['id'];
            //if(e.DataRow.RowData != null && this.ParentForm is Main mainForm)
            //{
            //    mainForm.AddFormToTab(new FrmChallan((int)e.DataRow["ChallanId"]), "Edit Challan");
            //}
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
    }
}

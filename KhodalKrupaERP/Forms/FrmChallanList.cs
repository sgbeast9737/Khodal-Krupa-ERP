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

            Helper.setAnalysisConfig(sfDataGrid1, true);
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

        //send info to whatsapp
        private void sfDataGrid1_CellButtonClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            if(e.Record is Syncfusion.WinForms.DataGrid.DataRow dataRow)
            {
                if(dataRow.RowData is ChallanInfo challanInfo)
                {
                    Report report = new Report();
                    report.Load(@"C:\dot-net-projects\@Test Reports\Challan_Report2.frx"); // Load your designed invoice

                    string query = @"SELECT
                                    C.ChallanId,
                                    C.DesignNo,
                                    C2.Name,
                                    C2.PhoneNo,
                                    C1.Diamond,
                                    C1.ChallanId,
                                    C1.Rate,
                                    C1.Paper,
                                    C1.Total
                                FROM
                                    `Challans` C,
                                    `ChallanTransactions` C1,
                                    `Customers` C2
                                where
                                    C.`ChallanId` = 1";

                    string connectionString = @"Data Source=C:\dot-net-projects\KhodalKrupaERP\KhodalKrupaERP\bin\Debug\Database\KhodalKrupaDB.sqlite;Version=3;";

                    DataTable data = new DataTable();
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connectionString))
                    {
                        dataAdapter.Fill(data);
                    }
                    //FastReport.Config.CompilerSettings.Language = "CSharp";

                    report.RegisterData(data, "Challan"); // Ensure the name matches the FastReport data source
                    report.GetDataSource("Challan").Enabled = true; // Enable the dataset

                    // Prepare and Export PDF
                    report.Prepare();

                    string storagePath = $@"{Application.StartupPath}\Invoices\Invoice_1234.pdf";
                    report.Export(new FastReport.Export.ExportBase(), storagePath);
                }
            }
        }
    }
}

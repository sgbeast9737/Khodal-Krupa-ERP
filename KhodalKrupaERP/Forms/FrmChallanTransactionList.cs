using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Support;
using KhodalKrupaERP.Models;
using KhodalKrupaERP.Models.Analysis;
using KhodalKrupaERP.Reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KhodalKrupaERP.Forms
{
    public partial class FrmChallanTransactionList : Form
    {
        private FrmSearchBox findForm;

        public FrmChallanTransactionList()
        {
            InitializeComponent();
            Helper.setAnalysisConfig(sfDataGrid1);

            Helper.addSummary(sfDataGrid1, "Total");
            Helper.addGroupSummary(sfDataGrid1, "Total");
        }

        private void refreshGrid()
        {
            try
            {
                this.sfDataGrid1.SearchController.Search("r");
                sfDataGrid1.DataSource = ChallanTransactionController.GetInfoOfAllChallanTransactions();
                hideColumns();

                Helper.addGrouping(sfDataGrid1, "CustomerId");
                sfDataGrid1.ExpandAllGroup();

                cbCustomer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message : " + ex.Message);
            }
        }

        private void hideColumns() => Helper.hideColumn(sfDataGrid1, "CustomerId", "Month", "Year", "ChallanTransactionId", "ChallanId", "UpdatedAt");

        private void FrmChallanTransactionList_Load(object sender, EventArgs e)
        {
            setCustomerDropDown(CustomerController.GetAllCustomers());
            refreshGrid();

            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            dteChallanDateFrom.Value = startDate;
            dteChallanDateTo.Value = endDate;

            dteChallanDateFrom.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            dteChallanDateFrom.Format = "dd / MM / yyyy";

            dteChallanDateTo.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            dteChallanDateTo.Format = "dd / MM / yyyy";

            lblChallanDateFrom.ForeColor = Color.Black;
            lblChallanDateTo.ForeColor = Color.Black;
            lblCustomer.ForeColor = Color.Black;
        }

        private void setCustomerDropDown(List<Customer> customers)
        {
            cbCustomer.DataSource = customers;

            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "CustomerId";
            cbCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private bool isValid()
        {
            if (cbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Plese select customer", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (!isValid()) return;

            try
            {
                sfDataGrid1.DataSource = ChallanTransactionController.GetInfoOfAllChallanTransactions((int)cbCustomer.SelectedValue, dteChallanDateFrom.Value,dteChallanDateTo.Value);
                hideColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message : " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void sfDataGrid1_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowData is ChallanTransactionInfo challanTransactionInfo)
            {
                Program.AddFormToTab(new FrmChallan(challanTransactionInfo.ChallanId), "Edit Challan");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValid()) return;
                CustomerChallanTransactionReport report = new CustomerChallanTransactionReport((int)cbCustomer.SelectedValue, dteChallanDateFrom.Value.Value, dteChallanDateTo.Value.Value);
                //ShowLoadingAnimation();
                report.savePdf();
                //HideLoadingAnimation();

                MessageBox.Show("invoice saved successfully", "PDF Saved Succcessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while generating report \nError Message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmChallanTransactionList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.F)
            {
                if (findForm == null || findForm.IsDisposed)
                {
                    findForm = new FrmSearchBox();
                    findForm.OnSearch = (searchText) =>
                    {
                        sfDataGrid1.SearchController.Search(searchText);
                    };
                }
            }

            findForm.Location = new Point(this.Location.X + 100, this.Location.Y + 100); // adjust as needed
            findForm.Show();
            findForm.BringToFront();
        }

        private void sfDataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                if (findForm == null || findForm.IsDisposed)
                {
                    findForm = new FrmSearchBox();
                    findForm.OnSearch = (searchText) =>
                    {
                        sfDataGrid1.SearchController.Search(searchText);
                    };
                }
            }
        }
    }
}
using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Models;
using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
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
    public partial class FrmChallan : Form
    {
        private BindingList<ChallanTransaction> challanTransactions = new BindingList<ChallanTransaction>();

        public FrmChallan()
        {
            InitializeComponent();
            dtChallanDate.Value = DateTime.UtcNow;

            //customer popup config
            cbCustomer.DataSource = CustomerController.GetAllCustomers();
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "CustomerId";
            cbCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;

            //grid config
            sfDataGrid1.DataSource = challanTransactions;
            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.AllowDeleting = true;
            sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDataGrid1.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Bottom;

            hideColumn("ChallanTransactionId");
            hideColumn("ChallanId");
            hideColumn("UpdatedAt");

            sfDataGrid1.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                ShowSummaryInRow = false,
                Title = "Grand Total: {Sum}",
                SummaryColumns = { new GridSummaryColumn()
                {
                    MappingName = "Total",
                    Name = "TotalSum",
                    Format = "{Sum:C}", // Format as currency
                    SummaryType = SummaryType.DoubleAggregate
                }}
            });

        }

        private void hideColumn(string text)
        {
            GridColumn column = sfDataGrid1.Columns[text];

            if (column != null)
                column.Visible = false;
        }

        private void addColumnToGrid(string text)
        {
            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                MappingName = text,
                HeaderText = text,
                AllowEditing = true
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbCustomer.SelectedValue.ToString());
        }

        private void FrmChallan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.S)
                btnSave.PerformClick();
        }
    }
}

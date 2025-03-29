using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
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
        private Challan challan = null;

        public FrmChallan(int? challanId = null)
        {
            if(challanId != null)
            {
                 this.challan = ChallanController.GetChallanById((int)challanId);
            }

            InitializeComponent();

            List<Customer> customers = CustomerController.GetAllCustomers();
            if (customers.Count == 0)
            {
                MessageBox.Show("Please first add customers to create challan","Invalid operation",MessageBoxButtons.OK,MessageBoxIcon.Information);

                if(this.Parent is Main main)
                {
                    main.AddFormToTab(new FrmCustomer(),"Customer Management");
                }
                this.Close();
            }
            else
            {
                cbCustomer.DataSource = customers;
            }


            dtChallanDate.Format = "dd-MM-yyyy";

            if (this.challan != null)
                dtChallanDate.Value = this.challan.ChallanDate;
            else
                dtChallanDate.Value = DateTime.Now;

            //customer popup config
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "CustomerId";
            cbCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;

            cbCustomer.Validating += (cbSender, cbE) =>
            {
                if (!customers.Contains(cbCustomer.SelectedItem))
                {
                    MessageBox.Show("Select valid customer");
                    cbE.Cancel = true;
                }
            };

            if (this.challan != null)
            {
                cbCustomer.SelectedValue = this.challan.CustomerId;
                nupDesignNo.Value = this.challan.DesignNo;

                this.btnSave.Text = "Update";
            }

            //grid config
            if (this.challan != null)
                challanTransactions = new BindingList<ChallanTransaction>(this.challan.ChallanTransactions.ToList());

            sfDataGrid1.DataSource = challanTransactions;

            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.AllowDeleting = true;
            sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDataGrid1.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Bottom;

            hideColumn("ChallanTransactionId");
            hideColumn("ChallanId");
            hideColumn("UpdatedAt");

            var groupSummaryColumn = new GridTableSummaryRow()
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
            };

            sfDataGrid1.TableSummaryRows.Add(groupSummaryColumn);
        }

        private void hideColumn(string text)
        {
            GridColumn column = sfDataGrid1.Columns[text];

            if (column != null)
                column.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbCustomer.SelectedValue == null)
                MessageBox.Show("Plese select customer", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.challan != null) // update 
                        {
                            ChallanController.UpdateChallan(context,challan.ChallanId, (int)cbCustomer.SelectedValue, (int)nupDesignNo.Value, dtChallanDate.Value ?? DateTime.Now);

                            foreach (var val in challanTransactions)
                            {
                                ChallanTransactionController.UpdateChallanTransaction(context,val);
                            }

                            //delete challan transaction but first compare which challan transaction need to delete
                            if(challan.ChallanTransactions.Count != challanTransactions.Count)
                            {
                                foreach (var item in challan.ChallanTransactions)
                                {
                                    if (!challanTransactions.Contains(item))
                                    {
                                        ChallanTransactionController.DeleteChallanTransaction(context,item.ChallanTransactionId);
                                    }
                                }
                            }
                        }
                        else // insert 
                        {
                            int challanId = ChallanController.AddChallan(context, dtChallanDate.Value ?? DateTime.Now, (int)nupDesignNo.Value, (int)cbCustomer.SelectedValue);

                            foreach (var val in challanTransactions)
                            {
                                ChallanTransactionController.AddChallanTransaction(context, challanId, val.Diamond, val.Rate, val.Paper);
                            }
                        }

                        // Commit if everything is successful
                        transaction.Commit();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // Rollback in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"Transaction failed: {ex.Message}");
                    }
                }
            }
        }

        //TODO : short cut for saving challan (Ctrl + s) not working 
        private void FrmChallan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.S)
                btnSave.PerformClick();
        }

        private void sfDataGrid1_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            bool IsValid = true;

            if (e.DataRow.RowData is ChallanTransaction transaction)
            {
                if (transaction.Diamond < 0)
                {
                    IsValid = false;
                    e.ErrorMessage = "Diamond must be greater than 0!";
                }
                else if (transaction.Rate < 0)
                {
                    IsValid = false;
                    e.ErrorMessage = "Rate must be greater than 0!";
                }
                else if (transaction.Paper < 0)
                {
                    IsValid = false;
                    e.ErrorMessage = "Paper must be greater than 0!";
                }

                if (!IsValid) {
                    MessageBox.Show(e.ErrorMessage, "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.IsValid = false;
                }
            }
        }
    }
}

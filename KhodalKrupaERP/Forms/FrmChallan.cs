using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.ListView.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.WinForms.Controls;
using System.Windows.Forms;

namespace KhodalKrupaERP.Forms
{
    public partial class FrmChallan : Form
    {
        private BindingList<ChallanTransaction> challanTransactions = new BindingList<ChallanTransaction>();
        private Challan challan = null;

        public FrmChallan(int? challanId = null)
        {
            try
            {
                if (challanId != null) // meaning it is update challan
                {
                    this.challan = ChallanController.GetChallanById((int)challanId);
                }

                List<Customer> customers = CustomerController.GetAllCustomers();
                if (customers.Count == 0)
                {
                    MessageBox.Show("Please first add customers to create challan", "Invalid operation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.AddFormToTab(new FrmCustomer(), "Customer Management");

                    this.Close();
                    return;
                }

                List<Service> services = ServiceController.GetAllServices();
                if (services.Count == 0)
                {
                    MessageBox.Show("Please first add Services to create challan", "Invalid operation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.AddFormToTab(new FrmService(), "Service Management");

                    this.Close();
                    return;
                }

                InitializeComponent();

                //customer popup config
                setCustomerDropDown(customers);

                //service column combobox config
                setServiceDropDown(services);

                //Date configuration
                dtChallanDate.Format = "dd-MM-yyyy";
                if (this.challan != null)
                    dtChallanDate.Value = this.challan.ChallanDate;
                else
                    dtChallanDate.Value = DateTime.Now;

                if (this.challan != null)
                {
                    cbCustomer.SelectedValue = this.challan.CustomerId;

                    this.btnSave.Text = "Update";
                }

                //grid config
                if (this.challan != null)
                    challanTransactions = new BindingList<ChallanTransaction>(this.challan.ChallanTransactions.ToList());

                sfDataGrid1.DataSource = challanTransactions;

                Helper.setDataInputConfig(sfDataGrid1);
                Helper.hideColumn(sfDataGrid1, "ChallanTransactionId", "ChallanId", "UpdatedAt");

                Helper.addSummary(sfDataGrid1, "Total");

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message : " + ex.Message);
            }
        }

        private void setCustomerDropDown(List<Customer> customers)
        {
            cbCustomer.DataSource = customers;

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
        }

        private void setServiceDropDown(List<Service> services)
        {
            // Create a new GridComboBoxColumn and set the DataSource for combo box column.
            GridComboBoxColumn gridComboBoxColumn = new GridComboBoxColumn();
            gridComboBoxColumn.MappingName = "ServiceId";
            gridComboBoxColumn.HeaderText = "Service";
            gridComboBoxColumn.ValueMember = "ServiceId";
            gridComboBoxColumn.DisplayMember = "Name";
            gridComboBoxColumn.DropDownStyle = DropDownStyle.DropDownList;
            gridComboBoxColumn.DataSource = services;

            this.sfDataGrid1.Columns.Add(gridComboBoxColumn);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isValid()) return;

            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.challan != null) // update 
                        {
                            ChallanController.UpdateChallan(context,challan.ChallanId, (int)cbCustomer.SelectedValue, dtChallanDate.Value ?? DateTime.Now);

                            foreach (var val in challanTransactions)
                            {
                                if(val.ChallanId == 0)
                                {
                                    ChallanTransactionController.AddChallanTransaction(context, challan.ChallanId, val.DesignNo, val.ServiceId, val.Diamond, val.Rate, val.Paper);
                                }
                                else
                                {
                                    ChallanTransactionController.UpdateChallanTransaction(context,val);
                                }
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
                            int challanId = ChallanController.AddChallan(context, (int)cbCustomer.SelectedValue, dtChallanDate.Value ?? DateTime.Now);

                            foreach (var val in challanTransactions)
                            {
                                ChallanTransactionController.AddChallanTransaction(context, challanId, val.DesignNo, val.ServiceId, val.Diamond, val.Rate, val.Paper);
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

        private void sfDataGrid1_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are sure you want to delete this challan transaction ?", "Delete challan transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ChallanTransaction challanTransaction in e.Items)
                    {
                        ChallanTransactionController.DeleteChallanTransaction(challanTransaction.ChallanTransactionId);
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
    }
}

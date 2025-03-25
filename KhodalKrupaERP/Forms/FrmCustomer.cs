using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
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
    public partial class FrmCustomer : Form
    {
        private BindingList<Customer> customerBindingList;
        public FrmCustomer()
        {
            InitializeComponent();
            customerBindingList = CustomerController.GetAllBindableCustomers();
            sfDataGrid1.DataSource = customerBindingList;

            sfDataGrid1.AllowDeleting = true;
            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Bottom;
            sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
        }

        private void sfDataGrid1_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            if (e.DataRow.RowData is Customer customer)
            {
                // Example: Validate Name field
                if (string.IsNullOrWhiteSpace(customer.Name))
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Customer name is required!";
                }

                // Example: Validate PhoneNo field
                if (string.IsNullOrWhiteSpace(customer.PhoneNo) || customer.PhoneNo.Length < 10)
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Valid phone number is required!";
                }

                if (!e.IsValid)
                    MessageBox.Show("Invalid","Invalid value please correct it",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void sfDataGrid1_RowValidated(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatedEventArgs e)
        {
            if (e.DataRow.RowData is Customer customer)
            {
                try
                {
                    if (customer.CustomerId == 0) // INSERT CASE
                    {
                        CustomerController.AddCustomer(customer.Name, customer.PhoneNo);
                    }
                    else // UPDATE CASE
                    {
                        CustomerController.UpdateCustomer(customer); // Pass whole object
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured", "Error while adding or updating record : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void sfDataGrid1_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            try
            {
                foreach (Customer customer in e.Items)
                {
                    CustomerController.DeleteCustomer(customer.CustomerId);
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error occured", "Error while deleting record : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

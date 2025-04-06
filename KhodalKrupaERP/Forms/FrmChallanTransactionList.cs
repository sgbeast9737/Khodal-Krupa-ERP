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
    public partial class FrmChallanTransactionList : Form
    {
        public FrmChallanTransactionList()
        {
            InitializeComponent();
            Helper.setAnalysisConfig(sfDataGrid1);
        }

        private void FrmChallanTransactionList_Load(object sender, EventArgs e)
        {
            setCustomerDropDown(CustomerController.GetAllCustomers());
            sfDataGrid1.DataSource = ChallanTransactionController.GetAllChallanTransactions();
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

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (cbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Plese select customer", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
    }
}

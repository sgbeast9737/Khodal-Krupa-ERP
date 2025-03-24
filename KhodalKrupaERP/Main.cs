using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Forms;
using KhodalKrupaERP.Models;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhodalKrupaERP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomerController.GetAllcustomers();
        }

        private void biCustomer_Click(object sender, EventArgs e)
        {
            AddFormToTab(new Temp(),"temp form");
            //tabControlMain.TabPages.Add();
        }

        private void AddFormToTab(Form childForm, string tabName)
        {
            // Create a new tab page
            TabPageAdv tabPage = new TabPageAdv(tabName);
            
            // Set form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add form to tab
            tabPage.Controls.Add(childForm);
            tabControlMain.TabPages.Add(tabPage);
            // Set the newly added tab as active
            tabControlMain.SelectedTab = tabPage;

            // Show the form inside the tab
            childForm.Show();
        }
    }
}

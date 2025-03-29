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

        private void AddFormToTab(Form childForm, string tabName)
        {
            // Set form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = System.Drawing.Color.White;

            addTab(childForm, tabName);
            // Show the form inside the tab
            childForm.Show();
        }

        private void addTab(Control control, string tabName)
        {
            // Create a new tab page
            TabPageAdv tabPage = new TabPageAdv(tabName);
            tabPage.Padding = new System.Windows.Forms.Padding(10);

            tabPage.BackColor = System.Drawing.Color.White;
            tabPage.TabBackColor = System.Drawing.Color.White;

            // Add form to tab
            tabPage.Controls.Add(control);
            tabControlMain.TabPages.Add(tabPage);
            // Set the newly added tab as active
            tabControlMain.SelectedTab = tabPage;
        }

        private void biCustomer_Click(object sender, EventArgs e) //customer option click
        {
            AddFormToTab(new FrmCustomer(),"Customer Management");
        }

        private void biChallan_Click(object sender, EventArgs e) // challan option click
        {
            AddFormToTab(new FrmChallan(), "Challan Management");
        }
    }
}

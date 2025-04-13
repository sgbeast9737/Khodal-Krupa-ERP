using KhodalKrupaERP.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Windows.Forms;

namespace KhodalKrupaERP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void AddFormToTab(Form childForm, string tabName)
        {
            if (childForm.IsDisposed)
                return;

            //check if tab already exist than make it active
            foreach (TabPageAdv tabPage in tabControlMain.TabPages)
            {
                if (tabPage.Text == tabName && tabName != "Edit Challan")
                {
                    tabControlMain.SelectedTab = tabPage;
                    return;
                }
            }

            // Set form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.StartPosition = FormStartPosition.CenterParent;
            childForm.BackColor = System.Drawing.Color.White;

            addTab(childForm, tabName);
            // Show the form inside the tab
            childForm.Show();
        }

        private void addTab(Control control, string tabName)
        {
            // Create a new tab page
            TabPageAdv newTabPage = new TabPageAdv(tabName);
            newTabPage.Padding = new System.Windows.Forms.Padding(10);

            newTabPage.BackColor = System.Drawing.Color.White;
            newTabPage.TabBackColor = System.Drawing.Color.White;

            // Add form to tab
            newTabPage.Controls.Add(control);
            newTabPage.Dock = DockStyle.Fill;
            tabControlMain.TabPages.Add(newTabPage);

            // Set the newly added tab as active
            tabControlMain.SelectedTab = newTabPage;

            if (control is Form childForm)
                childForm.FormClosed += (sender, e) => newTabPage.Close();
        }

        private void biCustomer_Click(object sender, EventArgs e) //customer option click
        {
            AddFormToTab(new FrmCustomer(),"Customer Management");
        }

        private void biChallan_Click(object sender, EventArgs e) // challan option click
        {
            AddFormToTab(new FrmChallanList(), "Challan List");
        }

        private void biMonthlyBillReport_Click(object sender, EventArgs e)
        {
            AddFormToTab(new FrmChallanTransactionList(),"Challan Transaction List");
        }

        private void biService_Click(object sender, EventArgs e)
        {
            AddFormToTab(new FrmService(),"Services Management");
        }
    }
}

using KhodalKrupaERP.Controllers;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace KhodalKrupaERP.Forms
{
    public partial class FrmService : Form
    {
        private BindingList<Service> serviceBindingList;

        public FrmService()
        {
            InitializeComponent();
            serviceBindingList = ServiceController.GetAllBindableServices();
            sfDataGrid1.DataSource = serviceBindingList;

            Helper.hideColumn(sfDataGrid1, "UpdatedAt");

            Helper.setDataInputConfig(sfDataGrid1,false);
        }

        private void sfDataGrid1_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            if (e.DataRow.RowData is Service service)
            {
                // Example: Validate Name field
                if (string.IsNullOrWhiteSpace(service.Name))
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Service name is required!";
                }

                if (!e.IsValid)
                    MessageBox.Show(e.ErrorMessage,"Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void sfDataGrid1_RowValidated(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatedEventArgs e)
        {
            if (e.DataRow.RowData is Service service)
            {
                try
                {
                    ServiceController.UpdateOrAddService(service);
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
                foreach (Service service in e.Items)
                {
                    ServiceController.DeleteService(service.ServiceId);
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error while deleting record : \n\n" + ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using ServiceTitanBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ServiceTitanApp
{
    public partial class ManageServices : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public ManageServices(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            ManageServicesLoad();
        }

        private void ManageServicesLoad()
        {
            comboCategory.DataSource = context.Categories.ToList();
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryID";
            // don't select a category once loaded
            comboCategory.SelectedItem = null;

            RefreshServicesDGV();
        }

        private void RefreshServicesDGV()
        {

            dgvServices.DataSource = null;

            var servicesToShow = context.Services.AsQueryable();

            if (txtSearch.Text != "")
            {
                servicesToShow = servicesToShow.Where(service => service.ServiceName.Contains(txtSearch.Text));
            }
            else if (comboCategory.SelectedValue != null)
            {
                servicesToShow = servicesToShow.Where(service => service.Category.CategoryID == Convert.ToInt32(comboCategory.SelectedValue));
            }

            dgvServices.DataSource = servicesToShow.Select(service => new
            {
                Id = service.ServiceID,
                Name = service.ServiceName,
                Category = service.Category.CategoryName,
                Price = service.ServiceType,
                NoOfTechnicans = service.Technicians.Count()
            }).ToList();
            // display a message to the user if nothing was found
            if (servicesToShow.ToList().Count == 0)
            {
                MessageBox.Show("No services were found mathcing your search criteria. Please try again.", "No services found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            AddEditService addEditService = new AddEditService();
            addEditService.ShowDialog();
            if (addEditService.DialogResult == DialogResult.OK)
            {
                RefreshServicesDGV();
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            int selectedServiceId = Convert.ToInt32(dgvServices.SelectedCells[0].OwningRow.Cells[0].Value);
            Service selectedService = context.Services.Find(selectedServiceId);
            AddEditService addEditService = new AddEditService(selectedService);
            addEditService.ShowDialog();

            if (addEditService.DialogResult == DialogResult.OK)
            {
                RefreshServicesDGV();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            comboCategory.SelectedItem = null;
            RefreshServicesDGV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedServiceId = Convert.ToInt32(dgvServices.SelectedCells[0].OwningRow.Cells[0].Value);
            Service selectedService = context.Services.Single(service => service.ServiceID == selectedServiceId);

            if (MessageBox.Show("Are you sure you want to delete the service (" + selectedService.ServiceName + " and its requests)?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // since we have on delete cascade, service requests are deleted as well
                context.Services.Remove(selectedService);
                context.SaveChanges();
                RefreshServicesDGV();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshServicesDGV();
        }
    }
}

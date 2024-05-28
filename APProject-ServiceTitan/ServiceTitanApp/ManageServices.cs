using Microsoft.EntityFrameworkCore;
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
        }

        private void ManageServices_Load(object sender, EventArgs e)
        {
            comboCategory.DataSource = context.Categories.ToList();
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryID";
            // don't select a category once loaded
            comboCategory.SelectedItem = null;

            // Customize DataGridView appearance
            CustomizeDataGridView();

            RefreshServicesDGV();
        }

        private void CustomizeDataGridView()
        {
            // Set grid styles
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServices.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Calming blue color
            dgvServices.DefaultCellStyle.SelectionForeColor = Color.Black; // Black for better contrast
            dgvServices.BackgroundColor = Color.White;

            dgvServices.EnableHeadersVisualStyles = false;
            dgvServices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);  // Brighter color
            dgvServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvServices.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold); // Large text for headers

            // Make the rest of the text smaller
            dgvServices.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.0F);

            // Set row height to add more space between lines
            dgvServices.RowTemplate.Height = 40;

            // Auto-resize columns to fit content
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Remove row header arrow
            dgvServices.RowHeadersVisible = false;
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
                Price = service.ServicePrice,
                NoOfTechnicans = service.ServiceTechnicians.Count()
            }).ToList();

            // display a message to the user if nothing was found
            if (!servicesToShow.Any())
            {
                MessageBox.Show("No services were found matching your search criteria. Please try again.", "No services found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Refresh the DataGridView appearance
            dgvServices.Refresh();
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
            Service selectedService = context.Services.Single(s => s.ServiceID == selectedServiceId);
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
            Service selectedService = context.Services.Include(s => s.Category).Single(service => service.ServiceID == selectedServiceId);

            if (Global.RoleName == "Manager")
            {
                if (selectedService.Category.CategoryManagerId!= Global.LoggedInUserId)
                {
                    MessageBox.Show("You cannot delete a service that is not in your category");
                    return;
                }
            }

            if (MessageBox.Show("Are you sure you want to delete the service (" + selectedService.ServiceName + " and its requests)?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // since we have on delete cascade, service requests are deleted as well
                context.Services.Remove(selectedService);
                string source = Helper.GetLogSource(this);
                context.Save(Global.User, source, "Deleted Service.");
                RefreshServicesDGV();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshServicesDGV();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(parentForm);
            parentForm.GoToForm(mainMenu);
        }

        private void btnViewRequests_Click(object sender, EventArgs e)
        {

            if (dgvServices.SelectedCells.Count > 0)
            {
                // get the service selected
                int selectedServiceId = Convert.ToInt32(dgvServices.SelectedCells[0].OwningRow.Cells[0].Value);
                Service selectedService = context.Services.Single(service => service.ServiceID == selectedServiceId);

                ViewRequests viewRequests = new ViewRequests(parentForm, selectedService);
                parentForm.GoToForm(viewRequests);
            }
            else
            {
                ViewRequests viewRequests = new ViewRequests(parentForm);
                parentForm.GoToForm(viewRequests);
            }

        }

        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

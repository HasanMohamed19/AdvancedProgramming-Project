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

namespace ServiceTitanApp
{
    public partial class ViewRequests : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        private Service service;

        public ViewRequests(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            service = new Service();
        }

        public ViewRequests(BaseForm parent, Service service)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            this.service = service;
        }

        private void ViewRequests_Load(object sender, EventArgs e)
        {
            // Load category combobox
            comboCategory.DataSource = context.Categories.ToList();
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryId";

            // Load client combobox
            comboClient.DataSource = context.Users.Where(u => u.RoleId == 4).ToList();
            comboClient.DisplayMember = "UserName";
            comboClient.ValueMember = "UserID";

            // Load service combobox
            comboService.DataSource = context.Services.ToList();
            comboService.DisplayMember = "ServiceName";
            comboService.ValueMember = "ServiceID";

            // Load technicians combobox
            comboTechnician.DataSource = context.Users.Where(u => u.RoleId == 3).ToList();
            comboTechnician.DisplayMember = "UserName";
            comboTechnician.ValueMember = "UserID";

            // If viewing for a specific service, set the selected items in comboboxes
            if (service.ServiceID > 0)
            {
                comboCategory.SelectedValue = this.service.CategoryId;
                comboService.SelectedValue = this.service.ServiceID;
                comboService.Enabled = false;
                comboCategory.Enabled = false;
            }

            // Customize DataGridView appearance
            CustomizeDataGridView();

            RefreshRequestsDGV();
        }

        private void CustomizeDataGridView()
        {
            // Set grid styles
            dgvRequests.BorderStyle = BorderStyle.None;
            dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRequests.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Calming blue color
            dgvRequests.DefaultCellStyle.SelectionForeColor = Color.Black; // Black for better contrast
            dgvRequests.BackgroundColor = Color.White;

            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set row height to add more space between lines
            dgvRequests.RowTemplate.Height = 40;

            // Auto-resize columns to fit content
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RefreshRequestsDGV()
        {

            dgvRequests.DataSource = null;

            var requestsToShow = context.ServiceRequests.AsQueryable();

            if (txtSearch.Text != "")
            {
                requestsToShow = requestsToShow.Where(request => request.Service.ServiceName.Contains(txtSearch.Text) || request.Service.Category.CategoryName.Contains(txtSearch.Text));
            }
            else if (comboCategory.SelectedValue != null)
            {
                requestsToShow = requestsToShow.Where(request => request.Service.CategoryId == Convert.ToInt32(comboCategory.SelectedValue));
            }
            else if (comboService.SelectedValue != null)
            {
                requestsToShow = requestsToShow.Where(request => request.ServiceId == Convert.ToInt32(comboService.SelectedValue));
            }
            else if (comboTechnician.SelectedValue != null)
            {
                requestsToShow = requestsToShow.Where(request => request.TechnicianId == Convert.ToInt32(comboTechnician.SelectedValue));
            }
            else if (comboClient.SelectedValue != null)
            {
                requestsToShow = requestsToShow.Where(request => request.ClientId == Convert.ToInt32(comboClient.SelectedValue));
            }

            dgvRequests.DataSource = requestsToShow.Select(request => new
            {
                Id = request.RequestID,
                Name = request.Service.ServiceName,
                Category = request.Service.Category.CategoryName,
                Price = request.RequestPrice.ToString("0.000"),
                Technician = request.Technician.UserEmail,
                Client = request.Client.UserEmail,
                Status = request.Status.Status
            }).ToList();
            // display a message to the user if nothing was found
            if (requestsToShow.ToList().Count == 0)
            {
                MessageBox.Show("No requests were found mathcing your search criteria. Please try again.", "No services found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(parentForm);
            parentForm.GoToForm(mainMenu);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshRequestsDGV();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            comboCategory.SelectedItem = null;
            comboClient.SelectedItem = null;
            comboTechnician.SelectedItem = null;
            comboService.SelectedItem = null;
            RefreshRequestsDGV();
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

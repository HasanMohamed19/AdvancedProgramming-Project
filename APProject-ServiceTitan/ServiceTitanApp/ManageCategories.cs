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
    public partial class ManageCategories : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;

        public ManageCategories(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
        }

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            comboManager.DataSource = context.Users.Where(user => user.RoleId == 2).ToList();
            comboManager.DisplayMember = "UserName";
            comboManager.ValueMember = "UserId";
            comboManager.SelectedItem = null;

            // Customize DataGridView appearance
            CustomizeDataGridView();

            RefreshCategoriesDGV();
        }

        private void CustomizeDataGridView()
        {
            // Set grid styles
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Calming blue color
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.Black; // Black for better contrast
            dgvCategories.BackgroundColor = Color.White;

            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set row height to add more space between lines
            dgvCategories.RowTemplate.Height = 40;

            // Auto-resize columns to fit content
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddEditCategory addEditCategory = new AddEditCategory();
            addEditCategory.ShowDialog();

            if (addEditCategory.DialogResult == DialogResult.OK)
            {
                RefreshCategoriesDGV();
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(dgvCategories.SelectedCells[0].OwningRow.Cells[0].Value);
            Category selectedCategory = context.Categories.Find(selectedCategoryId);

            AddEditCategory addEditCategory = new AddEditCategory(selectedCategory);
            addEditCategory.ShowDialog();

            if (addEditCategory.DialogResult == DialogResult.OK)
            {
                RefreshCategoriesDGV();
            }
        }

        private void RefreshCategoriesDGV()
        {
            dgvCategories.DataSource = null;

            var categoriesToShow = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                categoriesToShow = categoriesToShow.Where(category => category.CategoryName.Contains(txtSearch.Text));
            }
            else if (comboManager.SelectedValue != null)
            {
                categoriesToShow = categoriesToShow.Where(category => category.CategoryManagerId == Convert.ToInt32(comboManager.SelectedValue));
            }

            dgvCategories.DataSource = categoriesToShow.Select(category => new
            {
                Id = category.CategoryID,
                Name = category.CategoryName,
                ManagerName = category.CategoryManager.UserEmail,
                NoOfServices = category.Services.Count(),
            }).ToList();

            if (!categoriesToShow.Any())
            {
                MessageBox.Show("No categories were found matching your search criteria. Please try again.", "No services found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Refresh the DataGridView appearance
            dgvCategories.Refresh();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            comboManager.SelectedItem = null;
            RefreshCategoriesDGV();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshCategoriesDGV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(dgvCategories.SelectedCells[0].OwningRow.Cells[0].Value);
            Category selectedCategory = context.Categories.Single(category => category.CategoryID == selectedCategoryId);

            if (MessageBox.Show("Are you sure you want to delete the service (" + selectedCategory.CategoryName + " and its services)?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // since we don't have on delete cascade
                var alldet = context.Services.Where(service => service.CategoryId == selectedCategoryId).ToList();
                context.Services.RemoveRange(alldet);
                context.Categories.Remove(selectedCategory);
                context.SaveChanges();
                RefreshCategoriesDGV();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(parentForm);
            parentForm.GoToForm(mainMenu);
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

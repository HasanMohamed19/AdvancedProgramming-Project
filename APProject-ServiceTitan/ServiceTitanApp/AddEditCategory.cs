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
    public partial class AddEditCategory : Form
    {
        Category category;
        ServiceTitanDBContext context;
        public AddEditCategory()
        {
            InitializeComponent();
            context = new ServiceTitanDBContext();
            category = new Category();
        }

        public AddEditCategory(Category category)
        {
            InitializeComponent();
            context = new ServiceTitanDBContext();
            this.category = category;
        }

        private void AddEditCategory_Load(object sender, EventArgs e)
        {
            comboManager.DataSource = context.Users.Where(user => user.RoleId == 2).ToList();
            comboManager.DisplayMember = "FullName";
            comboManager.ValueMember = "UserId";
            // don't select a category once loaded
            comboManager.SelectedItem = null;

            // if edit load other stuff as well, and set the selected manager
            if (category.CategoryID > 0)
            {
                txtCategoryID.Text = category.CategoryID.ToString();
                txtName.Text = category.CategoryName;
                txtDescription.Text = category.CategoryDescription;
                comboManager.SelectedValue = category.CategoryManagerId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                //category.Services = null;
                category.CategoryManager = context.Users.Where(user => user.UserID == Convert.ToInt32(comboManager.SelectedValue)).FirstOrDefault();
                category.CategoryName = txtName.Text;
                category.CategoryDescription = txtDescription.Text;
                category.CategoryManagerId = category.CategoryManagerId;

                if (category.CategoryID > 0)
                {
                    context.Categories.Update(category);
                } else
                {
                    context.Categories.Add(category);
                }

                string source = Helper.GetLogSource(this);
                context.Save(Global.User, source, "Add/Edited Category.");
                this.DialogResult = DialogResult.OK;
                this.Close();

            } catch (Exception ex)
            {
                string source = Helper.GetLogSource(this);
                context.LogException(ex, Global.User, source);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

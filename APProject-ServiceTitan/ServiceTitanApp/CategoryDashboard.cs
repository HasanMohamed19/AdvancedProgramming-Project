using Microsoft.EntityFrameworkCore;
using ServiceTitanApp.FormControls;
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
    public partial class CategoryDashboard : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public CategoryDashboard(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            //CreateStatistics();
        }

        private void CategoryDashboard_Load(object sender, EventArgs e)
        {
            comboCategory.DataSource = context.Categories.ToList();
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryID";
            // select a category once loaded since this is for categories
            if (comboCategory.Items.Count > 0 )
            {
                comboCategory.SelectedItem = comboCategory.Items[0];
            }

            CreateStatistics();
        }

        private void CreateStatistics()
        {

            // relative to the selected category, this can be refactored to use as querable (todo: later)

            string totalSales = context.ServiceRequests
                .Where(s => s.Service.CategoryId == Convert.ToInt32(comboCategory.SelectedValue))
                .Sum(sr => sr.RequestPrice).ToString("0.000") + "BHD";

            Service topService = context.Services
                .Where(s => s.CategoryId == Convert.ToInt32(comboCategory.SelectedValue))
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault();
            string topSellingService = null;
            if (topService != null)
            {
                topSellingService = topService.ServiceName.ToString();
            }

            string pendingRequests = context.ServiceRequests
                .Where(sr => sr.StatusId == 2 && sr.Service.CategoryId == Convert.ToInt32(comboCategory.SelectedValue))
                .Count().ToString();

            tblStats.Controls.Add(new Statistic("Total Sales", totalSales, Statistic.StatImages.sales));
            tblStats.Controls.Add(new Statistic("Pending Requests", pendingRequests, Statistic.StatImages.requests));
            if (topSellingService != null)
            {
                tblStats.Controls.Add(new Statistic("Top Selling Service", topSellingService, Statistic.StatImages.topService));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(parentForm);
            parentForm.GoToForm(mainMenu);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            ManageCategories manageCategories = new ManageCategories(parentForm);
            parentForm.GoToForm(manageCategories);
        }

    }
}

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
            if (comboCategory.Items.Count > 0)
            {
                comboCategory.SelectedItem = comboCategory.Items[0];
            }

            CreateStatistics();
        }

        private void CreateStatistics()
        {
            tblStats.Controls.Clear();
            tblBigStats.Controls.Clear();
            // relative to the selected category, this can be refactored to use as querable (todo: later)

            comboCategory.SelectedValue ??= "0";
            int categoryId = Convert.ToInt32(comboCategory.SelectedValue);

            string totalSales = context.ServiceRequests
                .Where(s => s.Service.CategoryId == categoryId)
                .Sum(sr => sr.RequestPrice).ToString("0.000") + "BHD";

            var topService = context.Services
                .Where(s => s.CategoryId != null && s.CategoryId == categoryId)
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault();
            string topSellingService = topService != null ? topService.ServiceName : "None";
            topSellingService ??= "";

            string pendingRequests = context.ServiceRequests
                .Where(sr => sr.StatusId == 2 && sr.Service.CategoryId == categoryId)
                .Count().ToString();
            pendingRequests ??= "";

            string totalServiceRequests = context.ServiceRequests.Count(s => s.Service.CategoryId == categoryId).ToString();
            totalServiceRequests ??= "";

            string completedRequests = context.ServiceRequests.Count(s => s.Service.CategoryId == categoryId
                 && s.StatusId == 3).ToString();
            completedRequests ??= "";

            string overdueRequests = context.ServiceRequests.Count(s => s.Service.CategoryId == categoryId
                 && s.StatusId == 1
                 && s.RequestDateNeeded < DateTime.Now).ToString();
            overdueRequests ??= "";

            tblStats.Controls.Add(new Statistic("Total Sales", totalSales, Statistic.StatImages.sales));
            tblStats.Controls.Add(new Statistic("Top Selling Service", topSellingService, Statistic.StatImages.topService));
            tblStats.Controls.Add(new Statistic("Total Service Requests", totalServiceRequests, Statistic.StatImages.requests));

            tblBigStats.Controls.Add(new Statistic("Pending Requests", pendingRequests, Statistic.StatImages.requests));
            tblBigStats.Controls.Add(new Statistic("Completed Requests", completedRequests, Statistic.StatImages.services));
            tblBigStats.Controls.Add(new Statistic("Overdue Requests", overdueRequests, Statistic.StatImages.requests));
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

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CreateStatistics();
        }
    }
}

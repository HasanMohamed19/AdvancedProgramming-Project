using ServiceTitanBusinessObjects;
using ServiceTitanApp.FormControls;
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
using Microsoft.EntityFrameworkCore;

namespace ServiceTitanApp
{
    public partial class MainMenu : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public MainMenu(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            CreateStatistics();
            //
        }

        private void CreateStatistics()
        {
            string totalServices = context.Services.Count().ToString();
            string totalServiceRequests = context.ServiceRequests.Count().ToString();

            string totalClients = context.Users
                .Include(user => user.RoleID)
                .Where(user => user.RoleID.RoleID == 3).Count().ToString();

            // we used.Include for eager loading here, since we want the categoryName and it is a navigationalProperty
            string topsSellingCategory =
                context.ServiceRequests
                .Include(service => service.Service.Category)
                .OrderByDescending(sr => sr.Service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault()
                .Service.Category.CategoryName.ToString();
            
            string topSellingService = context.Services
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault()
                .ServiceName.ToString();

            //  format the float to include 3 decimal points
            string totalSales = context.ServiceRequests
                .Sum(sr => sr.RequestPrice).ToString("0.000");

            // get data and display

            tblMain.Controls.Add(new Statistic("Total Services", totalServices, Statistic.StatImages.services));
            tblMain.Controls.Add(new Statistic("Total Service Requests", totalServiceRequests, Statistic.StatImages.requests));
            tblMain.Controls.Add(new Statistic("Total Clients", totalClients, Statistic.StatImages.clients));
            tblMain.Controls.Add(new Statistic("Top Selling Category", topsSellingCategory, Statistic.StatImages.topCategory));
            tblMain.Controls.Add(new Statistic("Top Selling Service", topSellingService, Statistic.StatImages.topService));
            tblMain.Controls.Add(new Statistic("Total Sales", totalSales, Statistic.StatImages.sales));
        }

        private void btnViewCategories_Click(object sender, EventArgs e)
        {
            CategoryDashboard categoryDashboard = new CategoryDashboard(parentForm);
            parentForm.GoToForm(categoryDashboard);
        }

        private void btnManageServices_Click(object sender, EventArgs e)
        {
            ManageServices manageServices = new ManageServices(parentForm);
            parentForm.GoToForm(manageServices);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }
    }
}

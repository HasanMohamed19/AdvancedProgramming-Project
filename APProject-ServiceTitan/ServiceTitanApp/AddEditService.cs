using ServiceTitanBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTitanApp
{
    public partial class AddEditService : Form
    {
        ServiceTitanDBContext context;
        Service service;
        public AddEditService()
        {
            InitializeComponent();
            context = new ServiceTitanDBContext();
            service = new Service();
        }

        public AddEditService(Service service)
        {
            InitializeComponent();
            context = new ServiceTitanDBContext();
            this.service = service;
        }

        private void AddEditService_Load(object sender, EventArgs e)
        {
            // change this later placeholder
            txtCategory.Text = context.Categories.ToList()[0].ToString();

            // if edit
            if (service.ServiceID > 0)
            {
                txtServiceID.Text = service.ServiceID.ToString();
                txtCategory.Text = service.Category.CategoryName;
                txtName.Text = service.ServiceName;
                txtPrice.Text = service.ServicePrice.ToString("0.000");
                txtDescription.Text = service.ServiceDescription;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // this works
            Service service = new Service();
            service.ServiceName = "as";
            service.ServicePrice = Convert.ToDecimal(123.21);
            service.CategoryId = 1;
            service.ServiceDescription = "sdsdfd";
            service.Technicians = new List<User>();
            User tech = new User();
            tech.UserEmail = "asds";
            tech.UserName = "sadsad";
            tech.RoleId = 3;
            User u = context.Users.Where(u => u.UserID == 3).FirstOrDefault();
            MessageBox.Show(u.UserName);
            service.Technicians.Add(u);
            context.Services.Add(service);
            context.SaveChanges();


        }
    }
}

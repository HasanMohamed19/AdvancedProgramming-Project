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
                txtPrice.Text = service.ServiceType.ToString("0.000");
                txtDescription.Text = service.ServiceDescription;
            }
        }
    }
}

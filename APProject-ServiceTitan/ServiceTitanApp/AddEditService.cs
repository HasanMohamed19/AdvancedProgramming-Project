using Microsoft.EntityFrameworkCore.Query.Internal;
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
            comboCategory.DataSource = context.Categories.ToList();
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryID";

            comboCategory.SelectedItem = comboCategory.Items[0];

            // if edit
            if (service.ServiceID > 0)
            {
                txtServiceID.Text = service.ServiceID.ToString();
                comboCategory.SelectedValue = service.CategoryId;
                txtName.Text = service.ServiceName;
                txtPrice.Text = service.ServicePrice.ToString("0.000");
                txtDescription.Text = service.ServiceDescription;
                PopulateTechnicans(true);
            }
            else
            {
                PopulateTechnicans(false);
            }
        }

        private void PopulateTechnicans(bool isFiltered)
        {
            var technicans = context.Users.Where(u => u.RoleId == 3).AsQueryable();
            List<User> technicansToShow = new List<User>();
            if (isFiltered)
            {
                technicans = technicans.Where(u => u.Services.Contains(service));
            }
            technicansToShow = technicans.ToList();

            foreach (User user in technicansToShow)
            {
                chklistTechnicians.Items.Add(user, isFiltered);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // this works
            //Service service = new Service();
            //service.ServiceName = "as";
            //service.ServicePrice = Convert.ToDecimal(123.21);
            //service.CategoryId = 1;
            //service.ServiceDescription = "sdsdfd";
            service.Technicians = new List<User>();
            //User tech = new User();
            //tech.UserEmail = "asds";
            //tech.UserName = "sadsad";
            //tech.RoleId = 3;
            //User u = context.Users.Where(u => u.UserID == 3).FirstOrDefault();
            //MessageBox.Show(u.UserName);
            //service.Technicians.Add(u);
            //context.Services.Add(service);
            //context.SaveChanges();
            try
            {
                service.Category = null; service.ServiceRequests = null;
                service.ServiceName = txtName.Text;
                service.ServicePrice = Convert.ToDecimal(txtPrice.Text);


                if (service.ServiceID > 0)
                {
                    context.Services.Update(service);
                }
                else
                {
                    context.Services.Add(service);
                }

                context.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

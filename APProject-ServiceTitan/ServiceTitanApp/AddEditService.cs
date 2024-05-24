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
            this.service = context.Services.Find(service.ServiceID);
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
            }
            PopulateTechnicans();
        }

        private void PopulateTechnicans()
        {
            var technicans = context.Users.Where(u => u.RoleId == 3).AsQueryable();
            List<ApplicationUser> technicansToShow = new List<ApplicationUser>();
            technicansToShow = technicans.ToList();
            IQueryable<ApplicationUser> selectedTechnicians = Enumerable.Empty<ApplicationUser>().AsQueryable();
            if (service != null)
            {
                selectedTechnicians = technicans.Where(u => u.ServiceTechnicians
                .Select(s => s.ServicesId == service.ServiceID).Any());
            }

            foreach (ApplicationUser user in technicansToShow)
            {
                bool techSelected = selectedTechnicians.Contains(user);
                chklistTechnicians.Items.Add(user, techSelected);
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

                //MessageBox.Show("Database Service has technicians: "+dbService.Technicians.Count().ToString());

                service.ServiceName = txtName.Text;
                service.ServicePrice = Convert.ToDecimal(txtPrice.Text);
                service.ServiceDescription = txtDescription.Text;
                service.Category = (Category)comboCategory.SelectedItem;

                for (int i=0; i< chklistTechnicians.Items.Count; i++)
                {
                    ApplicationUser tech = (ApplicationUser)chklistTechnicians.Items[i];
                    bool relationshipExists = context.ServiceTechnicians
                        .Any(st => st.TechniciansId == tech.UserID
                        && st.ServicesId == service.ServiceID);

                    if (chklistTechnicians.GetItemChecked(i)
                        && !relationshipExists)
                    {
                        ServiceTechnician serviceTechnician = new ServiceTechnician();
                        serviceTechnician.TechniciansId = tech.UserID;
                        serviceTechnician.ServicesId = service.ServiceID;
                        context.ServiceTechnicians.Add(serviceTechnician);
                    } else if (!chklistTechnicians.GetItemChecked(i) && relationshipExists)
                    {
                        ServiceTechnician serviceTechnician = context.ServiceTechnicians
                            .Single(x => x.TechniciansId == tech.UserID && x.ServicesId == service.ServiceID);
                        context.ServiceTechnicians.Remove(serviceTechnician);
                    }
                }

                if (service.ServiceID > 0)
                {
                    context.Services.Update(service);
                }
                else
                {
                    context.Services.Add(service);
                }

                

                //foreach (User tech in chklistTechnicians.Items)
                //{
                //    if (chklistTechnicians.CheckedItems.Contains(tech))
                //    {
                //        if (!dbService.Technicians.Contains(tech))
                //        {
                //            dbService.Technicians.Add(tech);
                //        }
                //    } else
                //    {
                //        if (dbService.Technicians.Contains(tech))
                //            dbService.Technicians.Remove(tech);
                //    }
                //}

                //foreach (User tech in chklistTechnicians.CheckedItems)
                //{
                //    if (service != null)
                //    {
                //        if (!context.Services.Find(service.ServiceID).Technicians.Contains(tech))
                //            service.Technicians.Add(tech);
                //    } else
                //    {
                //        service.Technicians.Add(tech);
                //    }
                //}



                context.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.ToString());
                else MessageBox.Show(ex.ToString());
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

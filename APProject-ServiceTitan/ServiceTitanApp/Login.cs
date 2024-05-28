using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class Login : Form
    {
        private IServiceProvider serviceProvider;

        IdentityContext IdentityContext = new IdentityContext();

        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public Login(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            // sign out button should not appear on login screen
            parent.ShowSignOut(false);
        }

        public async Task<bool> VerifyUserNamePassword(string userName, string password)
        {
            try
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                serviceProvider = services.BuildServiceProvider();

                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var founduser = await userManager.FindByEmailAsync(userName);

                if (founduser != null)
                {
                    var passCheck = await userManager.CheckPasswordAsync(founduser, password) == true;

                    if (passCheck)
                    {
                        var roles = await userManager.GetRolesAsync(founduser);

                        string roleName = roles.FirstOrDefault();

                        if (roleName != "Admin"
                            && roleName != "Manager")
                        {
                            return false;
                        }

                        //save into global class
                        Global.User = founduser;
                        Global.RoleName = roleName;

                        // get the appUser userId and save it into global class
                        int userId = context.Users.Where(u => u.UserEmail == founduser.Email).FirstOrDefault().UserID;
                        Global.LoggedInUserId = userId;


                        //Those are added as extra just to show how you can query all users in a certain role
                        Global.AllAdmins = await userManager.GetUsersInRoleAsync("Admin");
                        Global.AllManagers = await userManager.GetUsersInRoleAsync("Manager");
                        Global.AllTechnicicans = await userManager.GetUsersInRoleAsync("Technician");
                        Global.AllUsers = await userManager.GetUsersInRoleAsync("User");
                    }
                    return passCheck;
                }
                return false;
            }
            catch (Exception ex)
            {
                string source = Helper.GetLogSource(this);
                context.LogException(ex, Global.User, source);
                MessageBox.Show("Error");
                return false;
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddEntityFrameworkSqlServer()
                    .AddDbContext<IdentityContext>();

                // Register UserManager & RoleManager
                services.AddIdentity<IdentityUser, IdentityRole>()
                   .AddEntityFrameworkStores<IdentityContext>()
                   .AddDefaultTokenProviders();

                // UserManager & RoleManager require logging and HttpContext dependencies
                services.AddLogging();
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var signInResults = await VerifyUserNamePassword(txtUsername.Text, txtPassword.Text);
            if (signInResults == true) //if user is verified
            {
                //do something.. i.e. navigate to next forms
                MainMenu mainMenu = new MainMenu(parentForm);
                parentForm.GoToForm(mainMenu);
                parentForm.ShowSignOut(true);
            }
            else
            {
                MessageBox.Show("Error. The username or password are not correct");
            }
        }
    }
}

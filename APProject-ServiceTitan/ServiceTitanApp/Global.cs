using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanApp
{
    public static class Global
    {
        public static IdentityUser User;
        public static string RoleName;
        public static int LoggedInUserId;

        public static IEnumerable<IdentityUser> AllAdmins;
        public static IEnumerable<IdentityUser> AllTechnicicans;
        public static IEnumerable<IdentityUser> AllManagers;
        public static IEnumerable<IdentityUser> AllUsers;

        public static void SignOut()
        {
            User = null;
            RoleName = null;
            LoggedInUserId = -1;

            AllAdmins = null;
            AllTechnicicans = null;
            AllManagers = null;
            AllUsers = null;
        }
    }

}

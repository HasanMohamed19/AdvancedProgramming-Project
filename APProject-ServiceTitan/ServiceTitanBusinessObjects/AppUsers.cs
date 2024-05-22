using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ServiceTitanBusinessObjects
{
    public class AppUsers : IdentityUser
    {
        public string? UserEmail { get; set; }
        public UserRole? Role { get; set; }

    }
}

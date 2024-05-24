using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServiceTitanBusinessObjects
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(15)]
        public string RoleName { get; set; }

        public static int GetRoleId(string roleName)
        {
            switch (roleName)
            {
                case "Admin":
                    return 1;
                case "Manager":
                    return 2;
                case "Technician":
                    return 3;
                case "User":
                    return 4;
                default:
                    return 0;
            }
        }

        public static string? GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Manager";
                case 3:
                    return "Technician";
                case 4:
                    return "User";
                default:
                    return null;
            }
        }
    }
}

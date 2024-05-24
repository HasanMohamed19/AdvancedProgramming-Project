using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class ServiceTechnician
    {
        public int TechniciansId { get; set; }
        public int ServicesId { get; set; }
        public Service Service { get; set; } = null!;
        public User Technician { get; set; } = null!;
    }
}

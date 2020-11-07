using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "位置")]
        public string Location { get; set; }

        public int EmployeeCount { get; set; }
    }
}

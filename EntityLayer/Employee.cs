using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        public int Age { get; set; }
        public int Wage { get; set; }
        public bool Gender { get; set; }      

    }
}

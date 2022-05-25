using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}

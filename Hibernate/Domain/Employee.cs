using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Domain
{
    public class Employee
    {
        public virtual int EmployeeId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
    }
}

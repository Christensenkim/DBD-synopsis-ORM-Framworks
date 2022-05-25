using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Domain
{
    public class Employee
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual EmployeeSkill EmployeeSkill { get; set; }
    }
}

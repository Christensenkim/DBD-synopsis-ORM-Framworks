using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Domain
{
    public class EmployeeSkill
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual Guid SkillId { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<SkillDescription> SkillDescriptions { get; set; }

    }
}

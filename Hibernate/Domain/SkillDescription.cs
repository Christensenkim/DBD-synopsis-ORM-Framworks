using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Domain
{
    public class SkillDescription
    {
        public virtual Guid SkillId { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<EmployeeSkill> Employeeskills { get; set; } = new List<EmployeeSkill>();



    }
}

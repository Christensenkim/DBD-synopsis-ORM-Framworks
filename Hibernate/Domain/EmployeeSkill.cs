using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Domain
{
    public class EmployeeSkill
    {
        public virtual Guid EmployeeSkillId { get; set; }
        public virtual Employee Employee { get; set; } = new Employee();
        public virtual SkillDescription SkillDescription { get; set; } = new SkillDescription();

    }
}

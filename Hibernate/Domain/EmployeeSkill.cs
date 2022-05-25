using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Domain
{
    public class EmployeeSkill
    {
        public Guid EmployeeId { get; set; }
        public Guid SkillId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class EmployeeSkill
    {
        public Guid EmployeeID { get; set; }
        public Guid SkillID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class EmployeeSkill
    {
        public Guid EmployeeSkillId { get; set; }
        public Employee Employee { get; set; }
        public SkillDescription SkillDescription { get; set; }
    }
}

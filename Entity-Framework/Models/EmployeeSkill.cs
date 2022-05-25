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
        [Key, Column(Order = 1)]
        public Guid EmployeeId { get; set; }
        [Key, Column(Order = 2)]
        public Guid SkillId { get; set; }
        public Employee Employee { get; set; }
        public SkillDescription SkillDescription { get; set; }
    }
}

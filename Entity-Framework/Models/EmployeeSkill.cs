using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class EmployeeSkill
    {
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        [ForeignKey("SkillDescription")]
        public Guid SkillID { get; set; }
    }
}

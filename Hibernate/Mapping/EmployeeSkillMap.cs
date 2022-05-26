using FluentNHibernate.Mapping;
using Hibernate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Mapping
{
    public class EmployeeSkillMap : ClassMap<EmployeeSkill>
    {
        public EmployeeSkillMap()
        {
            Id(x => x.EmployeeSkillId);
            References(x => x.Employee).Cascade.All();
            References(x => x.SkillDescription).Cascade.All();
            //HasMany(x => x.Employees).Cascade.All();
            //HasMany(x => x.SkillDescriptions).Cascade.All();
        }
    }
}

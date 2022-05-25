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
            HasMany(x => x.Employees);
            HasMany(x => x.SkillDescriptions);
        }
    }
}

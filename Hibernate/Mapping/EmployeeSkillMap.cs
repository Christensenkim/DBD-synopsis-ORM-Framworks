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
            HasMany(x => x.Employees).Inverse().Cascade.All();
            HasMany(x => x.SkillDescriptions).Inverse().Cascade.All();
        }
    }
}

using FluentNHibernate.Mapping;
using Hibernate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Mapping
{
    public class SkillDescriptionMap : ClassMap<SkillDescription>
    {
        public SkillDescriptionMap()
        {
            Id(x => x.SkillId);
            Map(x => x.Description);
            HasMany(x => x.Employeeskills).Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
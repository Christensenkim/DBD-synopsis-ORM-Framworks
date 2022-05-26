using FluentNHibernate.Mapping;
using Hibernate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernate.Mapping
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.EmployeeId);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Employeeskills).Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

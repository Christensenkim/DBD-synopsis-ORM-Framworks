using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hibernate.Domain;
using MockData;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;

namespace Hibernate
{
    public class HibernateService
    {
        private MockEmployee mock = new MockEmployee();

        public HibernateService()
        {

        }

        private MsSqlConfiguration getConnectionString()
        {
            return MsSqlConfiguration.MsSql2005
                .ConnectionString(c => c
                .Server("DESKTOP-NDVLOHO")
                .Database("HibernateTest")
                .TrustedConnection());
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=DESKTOP-NDVLOHO;Database=HibernateTest;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<HibernateService>())
                .BuildSessionFactory();

            //return Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=LECHAMPDK;Database=HibernateTest;Trusted_Connection=True;"))
            //    .Mappings(m => m.FluentMappings
            //    .AddFromAssemblyOf<HibernateService>())
            //    .BuildSessionFactory();
        }

        public void Insert_Test()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var emp = new Employee()
                    {
                        FirstName = mock.MockEmployeeFirstName(),
                        LastName = mock.MockEmployeeLastName(),
                    };

                    var empskilldesc = new SkillDescription()
                    {
                        Description = mock.MockSkillDescription(),
                    };

                    var empskill = new EmployeeSkill()
                    {
                        Employee = emp,
                        SkillDescription = empskilldesc
                    };

                    session.SaveOrUpdate(empskill);
                    transaction.Commit();
                }
            }
        }

        public void Update_Test(Employee employeeNH)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var emp = new Employee()
                    {
                        EmployeeId = employeeNH.EmployeeId,
                        FirstName = mock.MockEmployeeFirstName(),
                        LastName = mock.MockEmployeeLastName(),
                        Employeeskills = employeeNH.Employeeskills
                    };

                    session.Update(emp);
                    session.Transaction.Commit();
                }
            }
        }

        public Employee findProduct()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var x = session.CreateCriteria<Employee>();
                    x.SetFirstResult(0);
                    x.SetMaxResults(1);
                    Employee emp = x.UniqueResult<Employee>();

                    return emp;
                }
            }
        }

        public void Delete_Test(Employee employeeNH)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(employeeNH);
                    session.Transaction.Commit();
                }
            }
        }

        public void Read_Test()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var x = session.CreateCriteria<Employee>().List<Employee>();
                    Console.WriteLine("Employee Count: " + x.Count());
                }
            }
        }
    }
}

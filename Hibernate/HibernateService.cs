using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hibernate.Domain;
using MockData;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Linq;

namespace Hibernate
{
    public class HibernateService
    {
        private Configuration _myconfig;
        private MockEmployee mock = new MockEmployee();

        public HibernateService()
        {

        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=LECHAMPDK;Database=HibernateTesting;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<Employee>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                //.Create(true, true)
                )
                .BuildSessionFactory();
        }

        public void Insert_Test()
        {
            IList<Employee> employees = new List<Employee>();

            int run = 100;

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                //for (int i = 0; i < run; i++)
                //{
                //    using (var transaction = session.BeginTransaction())
                //    {
                //        Employee employee = new Employee
                //        {
                //            FirstName = mock.MockEmployeeFirstName(),
                //            LastName = mock.MockEmployeeLastName(),
                //        };
                //        session.Save(employee);
                //        transaction.Commit();
                //    }
                //}

                //for (int i = 0; i < 10; i++)
                //{
                //    using (var transaction = session.BeginTransaction())
                //    {
                //        SkillDescription skillDescription = new SkillDescription
                //        {
                //            Description = mock.MockSkillDescription()
                //        };
                //        session.Save(skillDescription);
                //        transaction.Commit();
                //    }
                //}

                //using (session.BeginTransaction())
                //{
                //    employees = session.CreateCriteria<Employee>().List<Employee>();
                //}

                //using (session.BeginTransaction())
                //{
                //    employees = session.CreateCriteria<Employee>().List<Employee>();
                //}



                using (var transaction = session.BeginTransaction())
                {
                    Employee employee = new Employee
                    {
                        FirstName = mock.MockEmployeeFirstName(),
                        LastName = mock.MockEmployeeLastName(),
                    };
                    //IList<Employee> empList = new List<Employee>();
                    //empList.Add(employee);

                    SkillDescription skillDescription = new SkillDescription
                    {
                        Description = mock.MockSkillDescription()
                    };
                    //IList<SkillDescription> skiList = new List<SkillDescription>();
                    //skiList.Add(skillDescription);

                    EmployeeSkill employeeSkill = new EmployeeSkill
                    {
                        Employee = employee,
                        SkillDescription = skillDescription
                    };

                    session.Save(employeeSkill);
                    transaction.Commit();
                }

            }
        }

        public void Update_Test(Employee employeeNH)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    employeeNH.FirstName = mock.MockEmployeeFirstName();
                    employeeNH.LastName = mock.MockEmployeeLastName();

                    session.Update(employeeNH);
                    session.Transaction.Commit();
                }
            }            
        }

        public Employee findProduct()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    ICriteria criteria = session.CreateCriteria<Employee>();
                    criteria.SetFirstResult(0);
                    criteria.SetMaxResults(1);
                    Employee product = criteria.UniqueResult<Employee>();

                    return product;
                }
            }
        }

        public void Delete_Test(Employee employeeNH)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Delete(employeeNH);
                    session.Transaction.Commit();
                }
            }
        }

        public void Read_Test()
        {
            IList<EmployeeSkill> employees = new List<EmployeeSkill>();

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    employees = session.CreateCriteria<EmployeeSkill>().List<EmployeeSkill>();
                    Console.ReadLine();
                }
            }
        }

        public void Read_Test(int id)
        {
            IList<EmployeeSkill> employees = new List<EmployeeSkill>();

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    employees = session.CreateCriteria<EmployeeSkill>().List<EmployeeSkill>();
                    Console.ReadLine();
                }
            }
        }
    }
}

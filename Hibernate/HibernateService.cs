﻿using FluentNHibernate.Cfg;
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
        private Configuration _myconfig;
        private ISessionFactory _sessionFactory;
        private ISession _session;
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
            //return Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=DESKTOP-NDVLOHO;Database=HibernateTest;Trusted_Connection=True;"))
            //    .Mappings(m => m.FluentMappings
            //    .AddFromAssemblyOf<HibernateService>())
            //    .BuildSessionFactory();

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=DESKTOP-NDVLOHO;Database=HibernateTest;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<HibernateService>())
                .BuildSessionFactory();
        }

        public void Insert_Test()
        {
            //_myconfig = new Configuration();
            //_myconfig.Configure();
            //_sessionFactory = _myconfig.BuildSessionFactory();
            //_session = _sessionFactory.OpenSession();

            //using (_session.BeginTransaction())
            //{
            //    Employee employee = new Employee
            //    {
            //        FirstName = mock.MockEmployeeFirstName(),
            //        LastName = mock.MockEmployeeLastName(),
            //    };

            //    _session.Save(employee);
            //    _session.Transaction.Commit();
            //}

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

                using (var transaction = session.BeginTransaction())
                {
                    var x = session.CreateCriteria<EmployeeSkill>().List<EmployeeSkill>();

                    foreach (var skill in x)
                    {
                        Console.WriteLine(skill.Employee.FirstName);
                    }
                }
            }
        }

        public void Update_Test(Employee employeeNH)
        {
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                employeeNH.FirstName = mock.MockEmployeeFirstName();
                employeeNH.LastName = mock.MockEmployeeLastName();

                _session.Update(employeeNH);
                _session.Transaction.Commit();
            }
        }

        public Employee findProduct()
        {
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                ICriteria criteria = _session.CreateCriteria<Employee>();
                criteria.SetFirstResult(0);
                criteria.SetMaxResults(1);
                Employee product = criteria.UniqueResult<Employee>();

                return product;
            }
        }

        public void Delete_Test(Employee employeeNH)
        {
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                _session.Delete(employeeNH);
                _session.Transaction.Commit();
            }
        }

        public void Read_Test()
        {
            //_myconfig = new Configuration();
            //_myconfig.Configure();
            //_sessionFactory = _myconfig.BuildSessionFactory();
            //_session = _sessionFactory.OpenSession();

            //using (_session.BeginTransaction())
            //{
            //    var employees = _session.CreateCriteria<Employee>().List<Employee>();
            //}

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var x = session.CreateCriteria<Employee>().List<Employee>();

                    foreach (var item in x)
                    {
                        Console.WriteLine(item.Employeeskills);
                    }
                }
            }
        }
    }
}

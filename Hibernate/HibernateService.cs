using Hibernate.Domain;
using MockData;
using NHibernate;
using NHibernate.Cfg;

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

        public void Insert_Test()
        {
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                Employee employee = new Employee
                {
                    Firstname = mock.MockProductsName(),
                    Lastname = mock.MockProductsCategory()
                };

                _session.Save(employee);
                _session.Transaction.Commit();
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
                employeeNH.Firstname = mock.MockProductsName();
                employeeNH.Lastname = mock.MockProductsCategory();

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
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                var employees = _session.CreateCriteria<Employee>().List<Employee>();
            }
        }
    }
}

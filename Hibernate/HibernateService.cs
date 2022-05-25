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
        private MockProduct mock = new MockProduct();

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
                Product product = new Product
                {
                    Name = mock.MockProductsName(),
                    Category = mock.MockProductsCategory(),
                    Discontinued = mock.MockProductsDiscontinued()
                };

                _session.Save(product);
                _session.Transaction.Commit();
            }

            //using (_session.BeginTransaction())
            //{
            //    ICriteria criteria = _session.CreateCriteria<Products>();
            //    IList<Products> products = criteria.List<Products>();
            //    _session.Transaction.Commit();
            //    Console.WriteLine(products.FirstOrDefault(x => x.Name == "Kim").Id);
            //}
        }

        public Product findProduct()
        {
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                ICriteria criteria = _session.CreateCriteria<Product>();
                criteria.SetFirstResult(0);
                criteria.SetMaxResults(1);
                Product product = criteria.UniqueResult<Product>();

                return product;
            }
        }

        public void Delete_Test(Product productNH)
        {
            _myconfig = new Configuration();
            _myconfig.Configure();
            _sessionFactory = _myconfig.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();

            using (_session.BeginTransaction())
            {
                _session.Delete(productNH);
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
                var products = _session.CreateCriteria<Product>().List<Product>();
            }
        }
    }
}

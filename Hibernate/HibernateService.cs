﻿using Hibernate.Domain;
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
                Products product = new Products
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
    }
}

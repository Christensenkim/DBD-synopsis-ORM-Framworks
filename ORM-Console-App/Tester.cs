using Entity_Framework;
using Hibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Console_App
{
    public class Tester
    {
        private EntityFrameworkService ef = new EntityFrameworkService();
        private HibernateService hibernate = new HibernateService();

        public void Insert_Test()
        {
            var watchEF = System.Diagnostics.Stopwatch.StartNew();
            ef.Insert_Test();
            watchEF.Stop();
            Console.WriteLine("Entity Framework insert time " + watchEF.Elapsed.ToString());

            var watchHibernate = System.Diagnostics.Stopwatch.StartNew();
            hibernate.Insert_Test();
            watchHibernate.Stop();
            Console.WriteLine("NHibernate insert time: " + watchHibernate.Elapsed.ToString());
        }

        public void Delete_Test()
        {
            var product = ef.findProduct();
            var watchEF = System.Diagnostics.Stopwatch.StartNew();
            ef.Delete_Test(product);
            watchEF.Stop();
            Console.WriteLine("Entity Framework Delete time " + watchEF.Elapsed.ToString());
        }
    }
}

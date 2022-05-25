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
            //var watchEF = System.Diagnostics.Stopwatch.StartNew();
            //ef.Insert_Test();
            //watchEF.Stop();
            //Console.WriteLine("Entity Framework insert time " + watchEF.Elapsed.ToString());

            var watchHibernate = System.Diagnostics.Stopwatch.StartNew();
            hibernate.Insert_Test();
            watchHibernate.Stop();
            Console.WriteLine("NHibernate insert time: " + watchHibernate.Elapsed.ToString());
        }

        internal void Update_Test()
        {
            var productEF = ef.FindEmployee();
            var watchEF = System.Diagnostics.Stopwatch.StartNew();
            ef.Update_Test(productEF);
            watchEF.Stop();
            Console.WriteLine("Entity Framework Update time " + watchEF.Elapsed.ToString());

            var productNH = hibernate.findProduct();
            var watchHibernate = System.Diagnostics.Stopwatch.StartNew();
            hibernate.Update_Test(productNH);
            watchHibernate.Stop();
            Console.WriteLine("NHibernate Update time " + watchHibernate.Elapsed.ToString());
        }

        public void Delete_Test()
        {
            var productEF = ef.FindEmployee();
            var watchEF = System.Diagnostics.Stopwatch.StartNew();
            ef.Delete_Test(productEF);
            watchEF.Stop();
            Console.WriteLine("Entity Framework Delete time " + watchEF.Elapsed.ToString());

            var productNH = hibernate.findProduct();
            var watchHibernate = System.Diagnostics.Stopwatch.StartNew();
            hibernate.Delete_Test(productNH);
            watchHibernate.Stop();
            Console.WriteLine("NHibernate Delete time " + watchHibernate.Elapsed.ToString());
        }

        public void Read_Test()
        {
            var watchEF = System.Diagnostics.Stopwatch.StartNew();
            ef.Read_Test();
            watchEF.Stop();
            Console.WriteLine("Entity Framework read time " + watchEF.Elapsed.ToString());

            var watchHibernate = System.Diagnostics.Stopwatch.StartNew();
            hibernate.Read_Test();
            watchHibernate.Stop();
            Console.WriteLine("NHibernate read time: " + watchHibernate.Elapsed.ToString());
        }
    }
}

using Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class EntityFrameworkService
    {
        public void Test()
        {
            using (var db =  new EFDbContext())
            {
                var prod = new Products
                {
                    Name = "KIM",
                    Category = "BIG GUY",
                    Discontinued = true
                };

                db.Products.Add(prod);
                db.SaveChanges();
            }
        }
    }
}

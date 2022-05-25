using Entity_Framework.Models;
using MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class EntityFrameworkService
    {
        private MockEmployee mock = new MockEmployee();

        public void Insert_Test()
        {
            using (var db =  new EFDbContext())
            {
                var prod = new Products
                {
                    Name = mock.MockEmployeeName(),
                    Category = mock.MockSkillDescription(),
                    Discontinued = mock.MockProductsDiscontinued()
                };

                db.Product.Add(prod);
                db.SaveChanges();
            }
        }

        public Products findProduct()
        {
            using (var db = new EFDbContext())
            {
                var targetToRemove = db.Product.FirstOrDefault();
                var product = new Products
                {
                    Id = targetToRemove.Id,
                    Name = targetToRemove.Name,
                    Category = targetToRemove.Category,
                    Discontinued = targetToRemove.Discontinued
                };
                return product;
            }
        }

        public void Update_Test(Products productEF)
        {
            using (var db = new EFDbContext())
            {
                productEF.Name = mock.MockEmployeeName();
                productEF.Category = mock.MockSkillDescription();
                productEF.Discontinued = mock.MockProductsDiscontinued();
                db.Update(productEF);

                db.SaveChanges();
            }
        }

        public void Delete_Test(Products product)
        {
            using (var db = new EFDbContext())
            {
                db.Product.Remove(product);
                db.SaveChanges();
            }
        }

        public void Read_Test()
        {
            using (var db = new EFDbContext())
            {
                db.Product.ToList();
            }
        }
    }
}

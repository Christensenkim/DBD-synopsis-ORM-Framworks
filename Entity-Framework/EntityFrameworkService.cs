﻿using Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class EntityFrameworkService
    {
        public void Insert_Test()
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

        public Products findProduct()
        {
            using (var db = new EFDbContext())
            {
                var targetToRemove = db.Products.First();
                return targetToRemove;
            }
        }

        public void Delete_Test(Products product)
        {
            using (var db = new EFDbContext())
            {
                db.Products.Remove(product);
            }
        }
    }
}

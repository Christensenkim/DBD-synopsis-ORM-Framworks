// See https://aka.ms/new-console-template for more information
using Entity_Framework;
using Hibernate;

Console.WriteLine("Hello, World!");

#region EFTest
var ef = new EntityFrameworkService();
ef.Test();
#endregion


#region HibernateTest
//var hibernate = new HibernateService();
//hibernate.test();
#endregion
using Entity_Framework.Models;
using MockData;

namespace Entity_Framework
{
    public class EntityFrameworkService
    {
        private MockProduct mock = new MockProduct();

        public void Insert_Test()
        {
            using (var db =  new EFDbContext())
            {
                var prod = new Employee
                {
                    Firstname = mock.MockProductsName(),
                    Lastname = mock.MockProductsCategory(),
                };

                db.Employee.Add(prod);
                db.SaveChanges();
            }
        }

        public Employee findProduct()
        {
            using (var db = new EFDbContext())
            {
                var targetToRemove = db.Employee.FirstOrDefault();
                var employee = new Employee
                {
                    EmployeeID = targetToRemove.EmployeeID,
                    Firstname = targetToRemove.Firstname,
                    Lastname = targetToRemove.Lastname,
                };
                return employee;
            }
        }

        public void Update_Test(Employee employeeEF)
        {
            using (var db = new EFDbContext())
            {
                employeeEF.Firstname = mock.MockProductsName();
                employeeEF.Lastname = mock.MockProductsCategory();
                db.Update(employeeEF);

                db.SaveChanges();
            }
        }

        public void Delete_Test(Employee employee)
        {
            using (var db = new EFDbContext())
            {
                db.Employee.Remove(employee);
                db.SaveChanges();
            }
        }

        public void Read_Test()
        {
            using (var db = new EFDbContext())
            {
                db.Employee.ToList();
            }
        }
    }
}

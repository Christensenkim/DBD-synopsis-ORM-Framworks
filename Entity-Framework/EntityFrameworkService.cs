using Entity_Framework.Models;
using MockData;

namespace Entity_Framework
{
    public class EntityFrameworkService
    {
        private MockEmployee mock = new MockEmployee();

        public void Insert_Test()
        {
            using (var db =  new EFDbContext())
            {
                var emp = new Employee
                {
                    Firstname = mock.MockEmployeeFirstName(),
                    Lastname = mock.MockEmployeeLastName()
                };

                db.Employee.Add(emp);
                db.SaveChanges();
            }
        }

        public Employee FindEmployee()
        {
            using (var db = new EFDbContext())
            {
                var targetToRemove = db.Employee.FirstOrDefault();
                var emp = new Employee
                {
                    EmployeeID = targetToRemove.EmployeeID,
                    Firstname = targetToRemove.Firstname,
                    Lastname = targetToRemove.Lastname
                };
                return emp;
            }
        }

        public void Update_Test(Employee emp)
        {
            using (var db = new EFDbContext())
            {
                emp.Firstname = mock.MockEmployeeFirstName();
                emp.Lastname = mock.MockEmployeeLastName();

                db.Update(emp);
                db.SaveChanges();
            }
        }

        public void Delete_Test(Employee emp)
        {
            using (var db = new EFDbContext())
            {
                db.Employee.Remove(emp);
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

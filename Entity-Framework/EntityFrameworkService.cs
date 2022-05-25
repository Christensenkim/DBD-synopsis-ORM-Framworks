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
                    FirstName = mock.MockEmployeeFirstName(),
                    LastName = mock.MockEmployeeLastName()
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
                    EmployeeId = targetToRemove.EmployeeId,
                    FirstName = targetToRemove.FirstName,
                    LastName = targetToRemove.LastName
                };
                return emp;
            }
        }

        public void Update_Test(Employee emp)
        {
            using (var db = new EFDbContext())
            {
                emp.FirstName = mock.MockEmployeeFirstName();
                emp.LastName = mock.MockEmployeeLastName();

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

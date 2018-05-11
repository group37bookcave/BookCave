using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Remotion.Linq.Clauses;

namespace BookCave.Repositories
{
    public class EmployeeRepo
    {
        private readonly StoreContext _db = new StoreContext();

        public Employee GetEmployee(int id)
        {
            return (from e in _db.Employees where e.Id == id select e).FirstOrDefault();
        }

        public void UpdateEmployee(int id)
        {
            var employee = GetEmployee(id);
        }

        public int AddEmployee(EmployeeInputModel model)
        {
            var employee = new Employee
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            _db.Add(employee);
            _db.SaveChanges();
            return employee.Id;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var emp = from e in _db.Employees select new EmployeeViewModel
            {
                Email = e.Email
            };
            return emp;
        }
    }
}
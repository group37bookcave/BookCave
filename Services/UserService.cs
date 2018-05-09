using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private readonly CustomerRepo _customerRepo = new CustomerRepo();
        private readonly EmployeeRepo _employeeRepo = new EmployeeRepo();
    
        public CustomerViewModel GetCustomer(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var addresses = _customerRepo.GetAddresses(id);

            var model = new CustomerViewModel
            {
                Email = customer.Email,
                Name = customer.FullName
            };
            foreach (var address in addresses)
            {
                model.Adresses.Add(new AddressViewModel
                {
                    Street = address.Street,
                    City = address.ZipCode.City,
                    Country = address.Country.Name,
                    Zipcode = address.ZipCode.Zip,
                    CountryId = address.Country.Id,
                    AddressId = address.Id
                });
            }
            return model;
        }

        public int CreateCustomer(RegisterInputModel model)
        {
            var customer = new CustomerInputModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            return _customerRepo.AddCustomer(customer);
        }

        
        public int CreateEmployee(RegisterInputModel model)
        {
            var employee = new EmployeeInputModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            return _employeeRepo.AddEmployee(employee);
        }
    }
}
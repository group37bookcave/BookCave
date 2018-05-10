using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private readonly CustomerRepo _customerRepo = new CustomerRepo();
        private readonly EmployeeRepo _employeeRepo = new EmployeeRepo();
        private readonly AddressRepo _addressRepo = new AddressRepo();

        public CustomerViewModel GetCustomer(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var addresses = _addressRepo.GetAddressesByCustomerId(id);

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
                    City = address.City,
                    Country = address.Country,
                    Zipcode = address.ZipCode,
                    AddressId = address.Id
                });
            }

            return model;
        }

        public int CreateCustomer(RegisterInputModel model)
        {
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                FavoriteBook = model.FavoriteBook,
                PhoneNumber = model.PhoneNumber
            };
            var address = _addressRepo.NewAddress(model.Street, model.Zipcode, model.City, model.CountryId);
            customer.CustomerAddresses = new List<CustomerAddress>
            {
                new CustomerAddress{ AddressId = address.Id, CustomerId = customer.Id}
            };
            var customerId = _customerRepo.AddCustomer(customer);
            return customerId;
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
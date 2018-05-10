﻿using BookCave.Models.EntityModels;
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

        public void AddAddressToCustomer(int customerId, AddressInputModel model)
        {
            
             var address = new Address
             {
                 City = model.City,
                 Street = model.Street,
                 CountryId = model.CountryId,
                 ZipCode = model.Zipcode
             };
            _addressRepo.AddAddress(address);
            _addressRepo.AddAddressToCustomer(customerId, address.Id);
            
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

            var address = new Address
            {
                City = model.City,
                CountryId = model.CountryId,
                ZipCode = model.Zipcode,
                Street = model.Street
            };

            _customerRepo.AddCustomer(customer);
            _addressRepo.AddAddress(address);
            _addressRepo.AddAddressToCustomer(customer.Id, address.Id);
            return customer.Id;
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
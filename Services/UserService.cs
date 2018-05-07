﻿using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private CustomerRepo _cr = new CustomerRepo();
        private OrderRepo _or = new OrderRepo();
    
        public CustomerViewModel GetCustomer(int id)
        {
            var customer = _cr.GetCustomer(id);
            var addresses = _cr.GetAddresses(id);

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
        
        

        public void AddCustomer(CustomerInputModel model)
        {
            _cr.AddCustomer(model);
        }
        
        
        
    }
}
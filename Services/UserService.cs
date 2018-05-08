using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private CustomerRepo _cr = new CustomerRepo();
    
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

        private int AddCustomer(CustomerInputModel model)
        {
            return _cr.AddCustomer(model);
        }

        public int CreateCustomer(RegisterInputModel model)
        {
            var customer = new CustomerInputModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            return AddCustomer(customer);
        }
        
        
        
    }
}
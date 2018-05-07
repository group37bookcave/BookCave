using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private CustomerRepo _cr = new CustomerRepo();
        private AddressRepo _ar = new AddressRepo();

        public CustomerViewModel GetCustomer(string email)
        {
            var customer = _cr.GetCustomer(email);
            var addresses = _ar.GetAddresses(customer);
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
                    Country = address.Country.Name,
                    Zipcode = address.ZipCode.Zip
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
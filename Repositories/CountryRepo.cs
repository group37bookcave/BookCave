using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class CountryRepo
    {
        private readonly StoreContext _db = new StoreContext();

        public List<Country> GetAllCountries()
        {
            var countries = from c in _db.Countries select c;
            return countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            var country = (from c in _db.Countries where c.Id == id select c).SingleOrDefault();
            if (country != null)
            {
                return country;
            }
            Console.WriteLine("NULLLL");
            return null;
        }

        public void AddCountry(CountryInputModel model)
        {
            var country = new Country
            {
                Name = model.Country,
                ShippingCost = model.ShippingCost
            };
            _db.Countries.Add(country);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public static class Helper
    {
        private static readonly CountryRepo CountryRepo = new CountryRepo();

        public static List<Country> GetCountries()
        {
            return CountryRepo.GetAllCountries();
        }

        public static double GetTotalPrice(OrderViewModel order)
        {
            double sum = 0;
            foreach (var item in order.Items)
            {
                sum += item.Price;
            }

            return sum;
        }
    }
}
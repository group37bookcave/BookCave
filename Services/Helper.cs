using System.Collections;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public static class Helper
    {
        private static readonly CountryRepo CountryRepo = new CountryRepo();

        public static List<Country> GetLanguages()
        {
            return CountryRepo.GetAllCountries();
        }
    }
}
using System;

namespace BookCave.Models.EntityModels
{
    public abstract class User : ApplicationUser
    {
        public string FirstName { get; set; }

        public string Lastname { get; set; }
        
        public bool IsActive { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;

namespace BookCave.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
    }
}
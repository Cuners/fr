using fr.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace fr.MyData
{
    public class Login
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = null!;
        public User Authorization()
        {
            using (var dbContext = new FreelaceContext())
            {
                User? person = new User();
                try
                {
                    person = (from a in dbContext.Users
                              where a.Email == Email && a.Password == Password
                              select a).Single();

                }
                catch (Exception ex) { }
                if (person.Email == null)
                {
                    return null;
                }
                return person;
            }
        }
    }
}

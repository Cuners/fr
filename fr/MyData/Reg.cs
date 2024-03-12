using fr.Models;
using System.ComponentModel.DataAnnotations;

namespace fr.MyData
{
    public class Reg
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Range(typeof(DateOnly), "1.1.1900", "1.1.2024", ErrorMessage = "Date of Birth must be between 1900 and 2024")]
        public DateOnly DateOfBirth { get; set; }

        public void Registration()
        {
            using (var dbContext = new FreelaceContext())
            {
                var user = new User
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                };
                dbContext.Users.Add(user);
                var profile = new Profile
                {
                    UserId = user.UserId
                };
                dbContext.Profiles.Add(profile);
                dbContext.SaveChanges();

            }

        }
    }
}

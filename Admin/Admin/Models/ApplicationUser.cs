using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public bool Gender {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Email {  get; set; }
    }
}

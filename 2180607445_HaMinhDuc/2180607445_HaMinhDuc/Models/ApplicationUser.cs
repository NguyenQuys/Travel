using Microsoft.AspNetCore.Identity;
using _2180607445_HaMinhDuc.Models;
using _2180607445_HaMinhDuc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace _2180607445_HaMinhDuc.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
    }
}

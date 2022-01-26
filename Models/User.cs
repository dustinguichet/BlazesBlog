using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazeBlog.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
    }
}

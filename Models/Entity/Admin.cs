using System.ComponentModel.DataAnnotations;

namespace AspNetMvcPersonalWebSite.Models.Entity
{
    public class Admin
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Mail { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Username { get; set; }

        public bool RememberMe { get; set; }
    }
}

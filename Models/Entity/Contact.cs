using System.ComponentModel.DataAnnotations;

namespace AspNetMvcPersonalWebSite.Models.Entity
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Mail { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Message { get; set; }

        public DateTime Tarih { get; set; }

    }
}

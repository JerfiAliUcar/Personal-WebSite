using System.ComponentModel.DataAnnotations;

namespace AspNetMvcPersonalWebSite.Models.Entity
{
    public class Skills
    {
        public int Id { get; set; }

        public string? Skill { get; set; }

        [Range(0,100)]
        public byte? Derece { get; set; }
    }
}

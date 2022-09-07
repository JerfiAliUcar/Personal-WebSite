using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcPersonalWebSite.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<About> About { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Certification> Certification { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<Experience> Experience { get; set; }

        public DbSet<Interests> Interests { get; set; }

        public DbSet<Skills> Skills { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = PersonalWebsiteDb; Trusted_Connection = True";
            

            builder.UseSqlServer(connectionString);
        }
    }
}

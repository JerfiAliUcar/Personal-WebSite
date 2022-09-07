using AspNetMvcPersonalWebSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Controllers
{
    public class PersonalController : Controller
    {
        private readonly AppDbContext db;

        public PersonalController(AppDbContext Db)
        {
            db = Db;
        }


        public IActionResult Education()
        {
            var educations = db.Education.ToList();            
            return View(educations);
        }
        
        public IActionResult Skills()
        {
            var skills = db.Skills.ToList();

            return View(skills);
        }
        
        public IActionResult Hobbies()
        {
            var hobbies = db.Interests.ToList();

            return View(hobbies);
        }
        
        public IActionResult Certification()
        {
            var certification = db.Certification.ToList();

            return View(certification);
        }
    }
}

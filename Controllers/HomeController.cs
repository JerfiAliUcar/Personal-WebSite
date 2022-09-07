using AspNetMvcPersonalWebSite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
        
            _db = db;
        }

        public IActionResult Index()
        {
            var info = _db.About.Where(e => e.Id == 1).ToList();
            return View(info);
        }


        public IActionResult Experience()
        {
            var experiences = _db.Experience.ToList();

            return View(experiences);
        }
    }
}
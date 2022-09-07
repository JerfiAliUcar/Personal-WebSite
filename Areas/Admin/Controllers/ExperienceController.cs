using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly AppDbContext _db;

        public ExperienceController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var list = _db.Experience.ToList();

            return View(list);
        }


        public IActionResult Edit(int id)
        {
            var edit = _db.Experience.Find(id);
            if (edit != null)
            {
                return View(edit);
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                var experienceDb = _db.Experience.Find(experience.Id);
                if (experienceDb != null)
                {
                   experienceDb.Title=experience.Title;
                    experienceDb.SubTitle=experience.SubTitle;
                    experienceDb.Description=experience.Description;
                    experienceDb.Tarih=experience.Tarih;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.message = "Hata";
            return RedirectToAction("Index", ViewBag.message);
        }


        public ActionResult Delete(int Id)
        {
            var delete = _db.Experience.Find(Id);
            if (delete != null)
            {
                _db.Experience.Remove(delete);

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            if (experience.Title != null)
            {
                _db.Experience.Add(experience);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

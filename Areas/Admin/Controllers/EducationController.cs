using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly AppDbContext _db;

        public EducationController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var list = _db.Education.ToList();

            return View(list);
        }


        public IActionResult Edit(int id)
        {
            var edit = _db.Education.Find(id);
            if (edit != null)
            {
                return View(edit);
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                var educationDb = _db.Education.Find(education.Id);
                if (educationDb != null)
                {
                    educationDb.Title = education.Title;
                    educationDb.SubTitle1 = education.SubTitle1;
                    educationDb.SubTitle2 = education.SubTitle2;
                    educationDb.Tarih = education.Tarih;
                    educationDb.GNO = education.GNO;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.message = "Hata";
            return RedirectToAction("Index", ViewBag.message);
        }


        public ActionResult Delete(int Id)
        {
            var delete = _db.Education.Find(Id);
            if (delete != null)
            {
                _db.Education.Remove(delete);

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Education about)
        {
            if (about.Title != null)
            {
                _db.Education.Add(about);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

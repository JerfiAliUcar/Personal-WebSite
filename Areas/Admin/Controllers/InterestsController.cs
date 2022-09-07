using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class InterestsController : Controller
    {
        private readonly AppDbContext _db;

        public InterestsController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var list = _db.Interests.ToList();

            return View(list);
        }


        public IActionResult Edit(int id)
        {
            var edit = _db.Interests.Find(id);
            if (edit != null)
            {
                return View(edit);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Interests interests)
        {
            if (ModelState.IsValid)
            {
                var interestsDb = _db.Interests.Find(interests.Id);
                if (interestsDb != null)
                {
                    interestsDb.Description1 = interests.Description1;
                    interestsDb.Description2 = interests.Description2;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.message = "Hata";
            return RedirectToAction("Index", ViewBag.message);
        }


        public ActionResult Delete(int Id)
        {
            var delete = _db.Interests.Find(Id);
            if (delete != null)
            {
                _db.Interests.Remove(delete);

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Interests interests)
        {
            if (interests.Description1 != null)
            {
                _db.Interests.Add(interests);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

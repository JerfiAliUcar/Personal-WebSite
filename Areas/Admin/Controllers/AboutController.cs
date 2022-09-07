using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;

        //AboutRepository repository = new AboutRepository();

        public AboutController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var list = _db.About.ToList();

            return View(list);
        }


        public IActionResult Edit(int id)
        {
            var edit = _db.About.Find(id);
            if (edit != null)
            {
                return View(edit);
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                var aboutDb = _db.About.Find(about.Id);
                if (aboutDb != null)
                {
                    aboutDb.Name = about.Name;
                    aboutDb.Surname = about.Surname;
                    aboutDb.Adress = about.Adress;
                    aboutDb.Phone = about.Phone;
                    aboutDb.Mail = about.Mail;
                    aboutDb.Description = about.Description;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.message = "Hata";
            return RedirectToAction("Index", ViewBag.message);
        }


        public ActionResult Delete(int Id)
        {
            var delete = _db.About.Find(Id);
            if (delete != null)
            {
                _db.About.Remove(delete);

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            //var newPerson = new About();

            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            if (about.Name != null)
            {
                _db.About.Add(about);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

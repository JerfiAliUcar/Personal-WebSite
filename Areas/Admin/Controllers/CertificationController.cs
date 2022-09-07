using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CertificationController : Controller
    {
        private readonly AppDbContext _db;

        public CertificationController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var list = _db.Certification.ToList();

            return View(list);
        }


        public IActionResult Edit(int id)
        {
            var edit = _db.Certification.Find(id);
            if (edit != null)
            {
                return View(edit);
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Edit(Certification certification)
        {
            if (ModelState.IsValid)
            {
                var certificationDb = _db.Certification.Find(certification.Id);
                if (certificationDb != null)
                {
                    certificationDb.Description = certification.Description;
                    certificationDb.Link= certification.Link;
                    certificationDb.Tarih=certification.Tarih.ToString();

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.message = "Hata";
            return RedirectToAction("Index", ViewBag.message);
        }


        public ActionResult Delete(int Id)
        {
            var delete = _db.Certification.Find(Id);
            if (delete != null)
            {
                _db.Certification.Remove(delete);

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Certification certification)
        {
            if (certification.Description != null)
            {
                certification.Tarih.ToString();

                _db.Certification.Add(certification);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

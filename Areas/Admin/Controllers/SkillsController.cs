using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {
        private readonly AppDbContext Db;

        public SkillsController(AppDbContext db)
        {
            Db = db;
        }


        public IActionResult Index()
        {
            var list = Db.Skills.ToList();

            return View(list);
        }


        public IActionResult Edit(int id)
        {
            var edit = Db.Skills.Find(id);
            if (edit != null)
            {
                return View(edit);
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Edit(Skills skills)
        {
            if (ModelState.IsValid)
            {
                var skillsDb = Db.Skills.Find(skills.Id);
                if (skillsDb != null)
                {
                    skillsDb.Skill = skills.Skill;
                    skillsDb.Derece = skills.Derece;

                    Db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.message = "Hata";
            return RedirectToAction("Index", ViewBag.message);
        }


        public ActionResult Delete(int Id)
        {
            var delete = Db.Skills.Find(Id);
            if (delete != null)
            {
                Db.Skills.Remove(delete);

                Db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skills skills)
        {
            if (skills.Skill != null)
            {
                Db.Skills.Add(skills);

                Db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

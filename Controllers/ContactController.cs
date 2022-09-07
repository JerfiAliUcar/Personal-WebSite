using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext db;

        public ContactController(AppDbContext Db)
        {
            db = Db;
        }


        public IActionResult ContactMe()
        {
            //var contact = new Contact();
            return View();
        }

        [HttpPost]
        public IActionResult ContactMe(Contact contact)
        {
            contact.Tarih = DateTime.Parse(DateTime.Now.ToString());

            db.Contact.Add(contact);

            db.SaveChanges();

            ViewBag.Message = "Mesajınız başarıyla gönderildi";
            return View();
        }


    }
}

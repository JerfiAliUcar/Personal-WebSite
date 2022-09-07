using AspNetMvcPersonalWebSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcPersonalWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;

        public ContactController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var contact = _db.Contact.ToList();

            return View(contact);
        }
    }
}

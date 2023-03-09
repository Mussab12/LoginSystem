using LoginSystem.Models;
using LoginSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class EventController : Controller
    {
		
    private readonly DatabaseContext _db;
		public EventController(DatabaseContext db)
		{
			_db = db;
		}
		public IActionResult EventPage()
		{
			return View();

		}
		[HttpPost]
		[ValidateAntiForgeryToken] // to prevent csrf request
		public IActionResult Create(Event obj)
        {
			
			
			
				_db.Events.Add(obj);

				_db.SaveChanges();
				TempData["success"] = "Category Created Successfully";
				return RedirectToAction("EventPage");   // if the action is in some another controller for that
													// you need to write controller name like ("Index","<Controller_name">)
			
			
		}
    }
}


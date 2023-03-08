using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class EventController : Controller
    {
        public IActionResult EventPage()
        {
            return View();
        }
    }
}

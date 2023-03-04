using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityServer3.Core.Services;

namespace LoginSystem.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {
       
        public IActionResult Display()
        {
            return View();
        }
    }
}

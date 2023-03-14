using IdentityServer3.Core.Resources;
using IdentityServer3.Core.Services;
using LoginSystem.Helpers;
using LoginSystem.Models;
using LoginSystem.Models.Domain;
using LoginSystem.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static IdentityServer3.Core.Events.EventConstants;

namespace LoginSystem.Controllers;
    public class EventsController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IUserService? _userService;
        public EventsController(DatabaseContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }
    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetString("UserId");
        ViewData["UserId"] = userId;
        var events = await _db.Events
            .Where(s => s.MyApplicationUserId == userId) // Filter by MyApplicationUserId
            .ToListAsync();
       


        return View(events);
    }

    //Get
    public IActionResult Create()
    {

        return View();
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken] // to prevent csrf request
    public IActionResult Create(Models.Event obj)
    {
        if (obj.Name == obj.Description)
        {
            ModelState.AddModelError("Name", "The Display order cannot match the Name");
        }
        if (ModelState.IsValid)
        {
            var userId = HttpContext.Session.GetString("UserId");
            obj.MyApplicationUserId = userId; // Set the MyApplicationUserId property
            obj.ApplicationUser = _db.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            _db.Events.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");   // if the action is in some another controller for that
                                                // you need to write controller name like ("Index","<Controller_name">)
        }
        return RedirectToAction("Index");
    }
    //Get
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var studentFromDb = _db.Events.Find(id);
        // it wil return one element.
        //var CategoryFromDbFirst=_db.Categories.FirstOrDefault(u=>u.Id==id); // will through an exception if no elements are found for an id.
        //var CategoryFromDbSingle=_db.Categories.SingleOrDefault(u=>u.Id==id); // will through an exception if there is more than one element
        if (studentFromDb == null)
        {
            return NotFound();
        }


        return View(studentFromDb);
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken] // to prevent csrf request
    public IActionResult Edit(Models.Event obj)
    {
        if (obj.Name == obj.Description)
        {
            ModelState.AddModelError("Name", "The Display order cannot match the Name");
        }
        if (ModelState.IsValid)
        {
            var userId = HttpContext.Session.GetString("UserId");
            obj.MyApplicationUserId = userId; // Set the MyApplicationUserId property
            obj.ApplicationUser = _db.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            _db.Events.Update(obj);

            _db.SaveChanges();
            TempData["success"] = "Category Edited Successfully";

            return RedirectToAction("Index");   // if the action is in some another controller for that
                                                // you need to write controller name like ("Index","<Controller_name">)
        }
        return View(obj);
    }
    //Get
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Events.Find(id);
        //var CategoryFromDbFirst=_db.Categories.FirstOrDefault(u=>u.Id==id);
        //var CategoryFromDbSingle=_db.Categories.SingleOrDefault(u=>u.Id==id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }


        return View(categoryFromDb);
    }
    //Post // lets se we want Delete to be controller name when we submit our form but here in the code it produces redundancy error for this we add
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken] // to prevent csrf request
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Events.Find(id); // here it is null because fields in our model were disabled. So we need to add input field as hidden
        if (obj == null)
        {
            return NotFound();
        }
        _db.Events.Remove(obj);

        _db.SaveChanges();
        TempData["success"] = "Category Deleted Successfully";

        return RedirectToAction("Index");   // if the action is in some another controller for that
                                            // you need to write controller name like ("Index","<Controller_name">)


    }

}
      
    


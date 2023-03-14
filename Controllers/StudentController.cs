using LoginSystem.Models.Domain;	
using LoginSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using IdentityServer3.Core.Services;
using static IdentityServer3.Core.Events.EventConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using LoginSystem.Helpers;

namespace LoginSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly DatabaseContext ?_db;
        private readonly IUserService ?_userService;
        public StudentController(DatabaseContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;

        }
      
        public async Task<IActionResult> MainPage()
        {
            var userId = HttpContext.Session.GetString("UserId");
            ViewData["UserId"] = userId;
            var students = await _db.Events
                .Where(s => s.MyApplicationUserId == userId) // Filter by MyApplicationUserId
                .ToListAsync();
            var eventsJson = JSONListHelper.GetEventListJSONString(students);
            ViewData["eventsJson"] = eventsJson;

            return View(students);
        }
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            ViewData["UserId"] = userId;
            var students = await _db.MyStudents
                .Where(s => s.MyApplicationUserId == userId) // Filter by MyApplicationUserId
                .ToListAsync();

            return View(students);
        }

 
		//Post
		[HttpPost]
		[ValidateAntiForgeryToken] // to prevent csrf request
		public IActionResult Create(StudentsModel obj)
		{
			if (obj.Name == obj.Program)
			{
				ModelState.AddModelError("name", "The Display order cannot match the Name");
			}
			if (ModelState.IsValid)
			{
                var userId = HttpContext.Session.GetString("UserId");
                obj.MyApplicationUserId = userId; // Set the MyApplicationUserId property
                obj.ApplicationUser = _db.Users.FirstOrDefault(u => u.Id.ToString() == userId);
                _db.MyStudents.Add(obj);
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
			var studentFromDb = _db.MyStudents.Find(id);
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
        public IActionResult Edit(StudentsModel obj)
        {
            if (obj.Name == obj.Program)
            {
                ModelState.AddModelError("Name", "The Display order cannot match the Name");
            }
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                obj.MyApplicationUserId = userId; // Set the MyApplicationUserId property
                obj.ApplicationUser = _db.Users.FirstOrDefault(u => u.Id.ToString() == userId);
                _db.MyStudents.Update(obj);

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
            var categoryFromDb = _db.MyStudents.Find(id);
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
            var obj = _db.MyStudents.Find(id); // here it is null because fields in our model were disabled. So we need to add input field as hidden
            if (obj == null)
            {
                return NotFound();
            }
            _db.MyStudents.Remove(obj);

            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");   // if the action is in some another controller for that
                                                // you need to write controller name like ("Index","<Controller_name">)


        }

    }


}


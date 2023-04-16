using Microsoft.AspNetCore.Mvc;
using WebApplication007.DAL;
using WebApplication007.Models;
namespace WebApplication007.Controllers
{
	public class AppUsersController : Controller
	{
		public IActionResult Index()
		{
			Core007Context db = new Core007Context();
			var AppUsers = db.AppUsers.ToList();

			return View(AppUsers);
		}

		[HttpGet]
		public IActionResult Create()
		{
			Core007Context db = new Core007Context();

			var Genders= db.Genders.ToList ();
			ViewBag.GList = Genders;

			AppUsersCreateVM AppUsersVM = new AppUsersCreateVM();


            return View(AppUsersVM);
		}

		[HttpPost]
		public IActionResult Create(AppUsersCreateVM AppUsersVM)
		{
			Core007Context db = new Core007Context();

			if (ModelState.IsValid==true) {
				//Convert Values from AppUserVM to Users DTO  
				AppUser AppUser = new AppUser();

				AppUser.Id = AppUsersVM.Id;
				AppUser.Email = AppUsersVM.Email;
				AppUser.Password = AppUsersVM.Password;
				AppUser.FirstName = AppUsersVM.FirstName;
				AppUser.LastName = AppUsersVM.LastName;
				AppUser.MobileNo = AppUsersVM.MobileNo;
				AppUser.GenderId = AppUsersVM.GenderId;



				db.AppUsers.Add(AppUser);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

			var Genders = db.Genders.ToList();
			ViewBag.GList = Genders;

			return View(AppUsersVM);
		}
		public IActionResult Delete(int Id)
		{
			Core007Context db = new Core007Context();
			var appUser = db.AppUsers.Find(Id);
			if (appUser != null)
			{
				db.AppUsers.Remove(appUser);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(int id)
		{
			Core007Context db = new Core007Context();
			var AppUser = db.AppUsers.Find(id);

               return View(AppUser);
		}

		[HttpPost]
		public IActionResult Update(AppUser appuser)
		{
			Core007Context db = new Core007Context();
			db.AppUsers.Update(appuser);
			db.SaveChanges();


			return RedirectToAction("Index");
		}

		public IActionResult IsEmailValid(String Email)
		{
            Core007Context db = new Core007Context();
			var EmailId=db.AppUsers.Any(u => u.Email== Email);
			if (EmailId==true)
			{
				return Json("this emailId is already used,enter another email..");
			}
			else
			{
                return Json(true);
            }
           
		}

    }
}

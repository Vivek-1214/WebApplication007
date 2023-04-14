using Microsoft.AspNetCore.Mvc;
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
			ViewBag.Gen = Genders;

			AppUser AppUser = new AppUser();

			return View(AppUser);
		}

		[HttpPost]
		public IActionResult Create(AppUser AppUser)
		{
			Core007Context db = new Core007Context();

			if (ModelState.IsValid==true) { 
            db.AppUsers.Add(AppUser);
			db.SaveChanges();
            }
			var Genders = db.Genders.ToList();
			ViewBag.Gen = Genders;

			return View(AppUser);
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

	}
}

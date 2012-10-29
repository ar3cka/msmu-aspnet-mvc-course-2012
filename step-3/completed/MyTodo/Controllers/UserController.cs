using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTodo.Models;

namespace MyTodo.Controllers {
	public class UserController : Controller {

		private UsersRepository m_users = new UsersRepository();

		//
		// GET: /user/login
		public ActionResult Login() {
			return View();
		}

		//
		// POST: /user/login
		[HttpPost]
		public ActionResult Login(string email, string password) {
			var user = m_users.FindUserByEmail(Email.Parse(email));
			if (user == null || !user.Password.Equals(Password.CreateFromString(password))) {
				ViewBag.ErrorMessage = "Неверный е-мейл или пароль.";
				return View();
			}
			return RedirectToAction("GetAll", "Task");
		}

		//
		// GET: /user/register
		public ActionResult Register() {
			return View();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyTodo.Models;

namespace MyTodo.Controllers {
	public class UserController : Controller {

		private readonly UsersRepository m_users = new UsersRepository();

		//
		// GET: /user/login
		public ActionResult Login() {
			return View(new AuthenticationRequest());
		}

		//
		// POST: /user/login
		[HttpPost]
		public ActionResult Login(AuthenticationRequest request) {
			var email = request.Email;
			var password = request.Password;
			var user = m_users.FindUserByEmail(Email.Parse(email));
			if (user == null || !user.Password.Equals(Password.CreateFromString(password))) {
				ViewBag.ErrorMessage = "Неверный е-мейл или пароль.";
				return View();
			}

			FormsAuthentication.SetAuthCookie(request.Email, request.RememberPassword);

			return RedirectToAction("GetAll", "Task");
		}

		//
		// GET: /user/logout
		public ActionResult Logout() {
			FormsAuthentication.SignOut();
			return RedirectToAction("Login");
		}

		//
		// GET: /user/register
		public ActionResult Register() {
			return View(new RegistrationUserRequest());
		}

		//
		// POST: /user/register
		[HttpPost]
		public ActionResult Register(RegistrationUserRequest request) {
			if (ModelState.IsValid) {
				var email = Email.Parse(request.Email);
				var user = m_users.FindUserByEmail(email);
				if (user == null) {
					user = new User();
					user.Email = email;
					user.Name = request.Username;
					user.Password = Password.CreateFromString(request.Password);
					m_users.Create(user);
					return RedirectToAction("Login");
				}

				ModelState.AddModelError("email", "Пользователь с таким адресом эоектронной почты уже зарегистрирован.");
			}

			return View(request);
		}
	}
}

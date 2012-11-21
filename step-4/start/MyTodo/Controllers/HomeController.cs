using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTodo.Models;

namespace MyTodo.Controllers {
	[Authorize]
	public class HomeController : ApplicationController {
		private TasksRepository m_tasks;

		protected override void OnActionExecuting(ActionExecutingContext filterContext) {
			base.OnActionExecuting(filterContext);
			m_tasks = new TasksRepository(CurrentUser);
		}

		//
		// GET: /Home/
		public ActionResult Index() {
			return View(m_tasks.FindUncompletedTasks());
		}
	}
}

using System;
using System.Web.Mvc;
using MyTodo.Models;

namespace MyTodo.Controllers {
	public class TaskController : Controller {
		private readonly TasksRepository m_tasks = new TasksRepository();

		//
		// GET: /task
		public ActionResult GetAll() {
			return View(m_tasks.FindUncompletedTasks());
		}

		//
		// GET /task/details
		public ActionResult Details(int id) {
			var task = m_tasks.FindTask(id);
			return View(task);
		}

		//
		// GET: /task/edit
		public ActionResult Edit(int id) {
			var task = m_tasks.FindTask(id);
			return View(task);
		}

		//
		// POST: /task/edit
		[HttpPost]
		public ActionResult Edit(int id, Task updatedTask) {
			m_tasks.UpdateTask(id, updatedTask);
			return RedirectToAction("GetAll");
		}

		//
		// GET: /task/create
		public ActionResult Create() {
			return View();
		}

		//
		// POST: /task/create
		[HttpPost]
		public ActionResult Create(Task task) {
			m_tasks.AddTask(task);
			return RedirectToAction("GetAll");
		}

		//
		// GET: /task/delete
		public ActionResult Delete(int id) {
			return View(m_tasks.FindTask(id));
		}

		//
		// POST: /task/delete
		[HttpPost]
		public ActionResult Delete(int id, FormCollection formData) {
			m_tasks.DeleteTask(id);
			return RedirectToAction("GetAll");
		}
	}
}

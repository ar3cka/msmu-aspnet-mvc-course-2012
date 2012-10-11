using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTodo.Models;

namespace MyTodo.Controllers {
	public class TaskController : Controller {

		private static int s_counter = 1;

		private static List<Task> s_tasks = new List<Task> {
            new Task { 
                TaskId = 1, 
                Title = "Зайти в магазин.", 
                Description = "Купить хлеб и зубную пасту.", 
                Completed = false  
            }
        };

		//
		// GET: /task
		public ActionResult GetAll() {
			return View(s_tasks.Where(t => !t.Completed));
		}

		//
		// GET /task/details
		public ActionResult Details(int id) {
			var task = s_tasks.Single(t => t.TaskId == id);
			return View(task);
		}

		//
		// GET: /task/edit
		public ActionResult Edit(int id) {
			var task = s_tasks.Single(t => t.TaskId == id);
			return View(task);
		}

		//
		// POST: /task/edit
		[HttpPost]
		public ActionResult Edit(int id, Task updatedTask) {
			var existingTask = s_tasks.Single(t => t.TaskId == id);
			existingTask.Title = updatedTask.Title;
			existingTask.Description = updatedTask.Description;
			existingTask.Completed = updatedTask.Completed;

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
			task.TaskId = ++s_counter;
			s_tasks.Add(task);
			return RedirectToAction("GetAll");
		}

		//
		// GET: /task/delete
		public ActionResult Delete(int id) {
			return View(s_tasks.Single(t => t.TaskId == id));
		}

		//
		// POST: /task/delete
		[HttpPost]
		public ActionResult Delete(int id, FormCollection formData) {
			var task = s_tasks.Single(t => t.TaskId == id);
			s_tasks.Remove(task);
			return RedirectToAction("GetAll");
		}
	}
}

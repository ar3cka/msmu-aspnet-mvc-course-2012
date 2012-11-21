using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyTodo.Models;

namespace MyTodo.Controllers {

	[Authorize]
	public class TaskController : ApiController {
		private TasksRepository m_task;

		protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext) {
			base.Initialize(controllerContext);
			var users = new UsersRepository();
			var user = users.FindUserByEmail(Email.Parse(User.Identity.Name));
			m_task = new TasksRepository(user);
		}

		// GET api/task
		public IEnumerable<Task> Get() {
			return m_task.FindUncompletedTasks();
		}

		// GET api/task/5
		public Task Get(int id) {
			return m_task.FindTask(id);
		}

		// POST api/task
		public void Post([FromBody] string value) {
			throw new NotImplementedException();
		}

		// PUT api/task/5
		public void Put(int id, [FromBody] string value) {
			throw new NotImplementedException();
		}

		// DELETE api/task/5
		public void Delete(int id) {
			m_task.DeleteTask(id);
		}
	}
}

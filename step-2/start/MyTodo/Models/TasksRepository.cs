using System.Collections.Generic;
using System.Linq;

namespace MyTodo.Models {
	public class TasksRepository {

		private static int s_counter = 1;

		private static readonly List<Task> s_tasks = new List<Task> {
			new Task {
				TaskId = 1,
				Title = "Зайти в магазин.",
				Description = "Купить хлеб и зубную пасту.",
				Completed = false
			}
		};

		public IEnumerable<Task> FindUncompletedTasks() {
			return s_tasks.Where(t => !t.Completed);
		}

		public Task FindTask(int id) {
			return s_tasks.Single(t => t.TaskId == id);
		}

		public void AddTask(Task task) {
			task.TaskId = ++s_counter;
			s_tasks.Add(task);
		}

		public void DeleteTask(int id) {
			var task = s_tasks.Single(t => t.TaskId == id);
			s_tasks.Remove(task);
		}
	}
}
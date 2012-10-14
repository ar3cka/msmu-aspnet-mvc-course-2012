using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyTodo.Models {
	public class TasksRepository {

		public IEnumerable<Task> FindUncompletedTasks() {
			using (var connection = CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "select * from task where completed = 0";

				connection.Open();
				var tasks = new List<Task>();
				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
					while (reader.Read()) {
						var task = new Task();
						task.TaskId = reader.GetInt32(0);
						task.Title = reader.GetString(1);
						task.Description = reader.GetString(2);
						task.Completed = reader.GetBoolean(3);
						tasks.Add(task);
					}		
				}

				return tasks;
			}
		}

		public Task FindTask(int id) {
			using (var connection = CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "select * from task where taskid = @taskid";
				command.Parameters.AddWithValue("@taskid", id);

				connection.Open();
				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
					if (reader.Read()) {
						// TODO: Extract method for reading task and use in all task readering methods.
						var task = new Task();
						task.TaskId = reader.GetInt32(0);
						task.Title = reader.GetString(1);
						task.Description = reader.GetString(2);
						task.Completed = reader.GetBoolean(3);
						return task;
					}
					return null;
				}
			}
		}

		public void AddTask(Task task) {
			using (var connection = CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "insert into task(title, description) values (@title, @description)";
				command.Parameters.AddWithValue("@title", task.Title);
				command.Parameters.AddWithValue("@description", task.Description);

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public void DeleteTask(int id) {
			throw new NotImplementedException();
		}

		public void UpdateTask(int id, Task task) {
			throw new NotImplementedException();
		}

		private static SqlConnection CreateConnection() {
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyTodoDatabase"].ConnectionString);
		}
	}
}
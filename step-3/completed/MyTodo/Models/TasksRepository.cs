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
						tasks.Add(ReadTaskFromRecord(reader));
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
					return reader.Read() ? ReadTaskFromRecord(reader) : null;
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
			using (var connection = CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "delete from task where taskid = @taskid";
				command.Parameters.AddWithValue("@taskid", id);

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public void UpdateTask(int id, Task task) {
			using (var connection = CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "update task set title = @title, description = @descr, completed = @cmpl where taskid = @taskid";
				command.Parameters.AddWithValue("@taskid", id);
				command.Parameters.AddWithValue("@title", task.Title);
				command.Parameters.AddWithValue("@descr", task.Description);
				command.Parameters.AddWithValue("@cmpl", task.Completed);

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private static SqlConnection CreateConnection() {
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyTodoDatabase"].ConnectionString);
		}

		private static Task ReadTaskFromRecord(IDataRecord record) {
			var task = new Task();
			task.TaskId = record.GetInt32(0);
			task.Title = record.GetString(1);
			task.Description = record.GetString(2);
			task.Completed = record.GetBoolean(3);
			return task;
		}
	}
}
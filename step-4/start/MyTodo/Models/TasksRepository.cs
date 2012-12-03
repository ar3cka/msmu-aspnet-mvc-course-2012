using System;
using System.Collections.Generic;
using System.Data;

namespace MyTodo.Models {
	public class TasksRepository {
	    private readonly User m_currentUser;

	    public TasksRepository(User currentUser) {
	        if (currentUser == null) throw new ArgumentNullException("currentUser");
	        m_currentUser = currentUser;
	    }

	    public IEnumerable<Task> FindUncompletedTasks() {
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "select * from task where completed = 0 and createdby = @userid";
			    command.Parameters.AddWithValue("@userid", m_currentUser.UserId);
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
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "select * from task where taskid = @taskid and createdby = @userid";
				command.Parameters.AddWithValue("@taskid", id);
                command.Parameters.AddWithValue("@userid", m_currentUser.UserId);

				connection.Open();
				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
					return reader.Read() ? ReadTaskFromRecord(reader) : null;
				}
			}
		}

		public int AddTask(Task task) {
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "add_task";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@title", task.Title);
				command.Parameters.AddWithValue("@description", task.Description);
				command.Parameters.AddWithValue("@created_by", m_currentUser.UserId);
				command.Parameters.AddWithValue("@task_id", -1).Direction = ParameterDirection.Output;

				connection.Open();
				command.ExecuteNonQuery();

				return (int) command.Parameters["@task_id"].Value;
			}
		}

		public void DeleteTask(int id) {
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "delete from task where taskid = @taskid and createdby = @userid";
				command.Parameters.AddWithValue("@taskid", id);
                command.Parameters.AddWithValue("@userid", m_currentUser.UserId);

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public void UpdateTask(int id, Task task) {
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "update task set title = @title, description = @descr, completed = @cmpl where taskid = @taskid and createdby = @userid";
				command.Parameters.AddWithValue("@taskid", id);
				command.Parameters.AddWithValue("@title", task.Title);
				command.Parameters.AddWithValue("@descr", task.Description);
				command.Parameters.AddWithValue("@cmpl", task.Completed);
                command.Parameters.AddWithValue("@userid", m_currentUser.UserId);

				connection.Open();
				command.ExecuteNonQuery();
			}
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
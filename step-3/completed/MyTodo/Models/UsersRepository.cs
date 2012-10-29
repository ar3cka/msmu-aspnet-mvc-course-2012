using System;
using System.Data;

namespace MyTodo.Models {
	public class UsersRepository {
		public User FindUserByEmail(string email) {
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "SELECT * FROM [dbo].[user] WHERE email = @email";
				command.Parameters.AddWithValue("@email", email);

				connection.Open();
				User result = null;
				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
					if (reader.Read()) {
						result = new User();
						result.UserId = reader.GetInt32(0);
						result.Name = reader.GetString(1);
						result.Email = reader.GetString(2);
						result.Password = new Password(reader.GetString(3));
					}
				}
				return result;
			}
		}
	}
}
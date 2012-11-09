using System;
using System.Data;

namespace MyTodo.Models {
	public class UsersRepository {
		public User FindUserByEmail(Email email) {
			using (var connection = DatabaseConnection.CreateConnection()) {
				var command = connection.CreateCommand();
				command.CommandText = "SELECT * FROM [dbo].[user] WHERE email = @email";
				command.Parameters.AddWithValue("@email", email.ToString());

				connection.Open();
				User result = null;
				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
					if (reader.Read()) {
						result = new User();
						result.UserId = reader.GetInt32(0);
						result.Name = reader.GetString(1);
						result.Email = Email.Parse(reader.GetString(2));
						result.Password = new Password(reader.GetString(3));
					}
				}
				return result;
			}
		}

	    public void Create(User user) {
	        using (var connection = DatabaseConnection.CreateConnection()) {
	            var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [dbo].[user](email, name, password) VALUES (@email, @name, @password)";
	            command.Parameters.AddWithValue("@email", user.Email.ToString());
	            command.Parameters.AddWithValue("@name", user.Name);
	            command.Parameters.AddWithValue("@password", user.Password.ToString());
                connection.Open();
	            command.ExecuteNonQuery();
	        }
	    }
	}
}
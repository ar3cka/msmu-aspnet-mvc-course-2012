using System.Configuration;
using System.Data.SqlClient;

namespace MyTodo.Models {
	internal class DatabaseConnection {
		public static SqlConnection CreateConnection() {
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyTodoDatabase"].ConnectionString);
		}
	}
}
using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
	public class RegistrationUserRequest {
		[Required]
		public string Username { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

		[Required, Compare("Password"), DataType(DataType.Password)]
		public string ConfirmedPassword { get; set; }
	}
}
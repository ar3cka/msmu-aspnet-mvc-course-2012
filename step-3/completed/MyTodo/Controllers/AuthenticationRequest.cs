using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
	public class AuthenticationRequest {
		[Required, EmailAddress]
		public string Email { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberPassword { get; set; }
	}
}
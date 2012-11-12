using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
	public class AuthenticationRequest {
		[Required, EmailAddress, Display(Name = "Электронной почта")]
		public string Email { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Пароль")]
		public string Password { get; set; }

		[Required, Display(Name = "Запомнить меня")]
		public bool RememberPassword { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
	public class RegistrationUserRequest {
		[Required(ErrorMessage = "Укажите Ваше имя."), Display(Name = "Имя")]
		public string Username { get; set; }

		[Required, EmailAddress, Display(Name = "Электронной почта")]
		public string Email { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Пароль")]
		public string Password { get; set; }

		[Required, Compare("Password"), DataType(DataType.Password), Display(Name = "Повторите пароль")]
		public string ConfirmedPassword { get; set; }
	}
}
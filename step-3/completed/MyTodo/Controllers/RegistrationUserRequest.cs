using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
	public class RegistrationUserRequest {
		[Required, Display(Name = "���")]
		public string Username { get; set; }

		[Required, EmailAddress, Display(Name = "����������� �����")]
		public string Email { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "������")]
		public string Password { get; set; }

		[Required, Compare("Password"), DataType(DataType.Password), Display(Name = "��������� ������")]
		public string ConfirmedPassword { get; set; }
	}
}
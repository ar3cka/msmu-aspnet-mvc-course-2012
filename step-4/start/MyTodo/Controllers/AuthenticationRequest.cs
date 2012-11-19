using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
	public class AuthenticationRequest {
		[Required, EmailAddress, Display(Name = "����������� �����")]
		public string Email { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "������")]
		public string Password { get; set; }

		[Required, Display(Name = "��������� ����")]
		public bool RememberPassword { get; set; }
	}
}
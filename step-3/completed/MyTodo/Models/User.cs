using System;

namespace MyTodo.Models {
	public class User {
		public int UserId { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public Password Password { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;

namespace MyTodo.Controllers {
    public class AuthenticationRequest {
        [Display(Name = "email"), Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "password"), Required]
        public string Password { get; set; }

        public bool RememberPassword { get; set; }
    }
}
using System.Web.Mvc;
using MyTodo.Models;

namespace MyTodo.Controllers {
	public abstract class ApplicationController : Controller {
		private User m_currentUser;

		protected override void OnAuthorization(AuthorizationContext filterContext) {
			base.OnAuthorization(filterContext);
			if (Request.IsAuthenticated) {
				m_currentUser = new UsersRepository().FindUserByEmail(Email.Parse(User.Identity.Name));
			}
		}

		public User CurrentUser {
			get { return m_currentUser; }
		}
	}
}
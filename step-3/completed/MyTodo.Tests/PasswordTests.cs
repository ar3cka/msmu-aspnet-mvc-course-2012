using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTodo.Models;

namespace MyTodo.Tests {
	[TestClass]
	public class PasswordTests {
		[TestMethod]
		public void CreateFromString_ReturnsHashedString() {
			// arrange
			//
			const string passwordString = "Passw0rd";

			// act
			//
			var password = Password.CreateFromString(passwordString);

			// assert
			//
			Assert.AreEqual(passwordString.Hash(), password.Hash);
		}

		[TestMethod]
		public void EqualsToPassword_ReturnsTrue_WhenPasswordStringsAreEquals() {
			// arrange
			//
			const string passwordString = "Passw0rd";
			var password1 = Password.CreateFromString(passwordString);
			var password2 = Password.CreateFromString(passwordString);

			// act
			//
			var result = password1.Equals(password2);

			// assert
			//
			Assert.IsTrue(result);
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTodo.Models;

namespace MyTodo.Tests {
	[TestClass]
	public class EmailTests {
		[TestMethod]
		public void EqualsToEmail_ForSameEmailStrings_ReturnTrue() {
			// arrange
			// 
			var email1 = Email.Parse("some_address@domain.com");
			var email2 = Email.Parse("some_address@domain.com");

			// act
			//
			var result = email1.Equals(email2);

			// assert
			//
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void EqualstoEmail_ForDifferentEmailStrings_ReturnFalse() {
			// arrange
			// 
			var email1 = Email.Parse("some_address_1@domain.com");
			var email2 = Email.Parse("some_address_2@domain.com");

			// act
			//
			var result = email1.Equals(email2);

			// assert
			//
			Assert.IsFalse(result);
		}

		[TestMethod]
		[ExpectedException(typeof(System.FormatException))]
		public void Parse_WhenStringIsNotEmailFormatted_ThrowInvalidFormatException() {
			Email.Parse("some_address_1");
		}

		[TestMethod]
		public void ToString_ReturnEmailString() {
			// arrange
			//
			const string expectedValue = "some_address@domain.com";
			var email = Email.Parse(expectedValue);
			
			// act
			//
			var actualValue = email.ToString();

			// assert
			//
			Assert.AreEqual(expectedValue, actualValue);
		}
	}
}
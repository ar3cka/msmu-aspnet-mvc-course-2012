using System;
using System.Security.Cryptography;
using System.Text;

namespace MyTodo.Models {
	public static class StringExtensions {
		public static string Hash(this string target) {
			if (target == null) throw new ArgumentNullException("target");
			if (String.IsNullOrEmpty(target)) throw new ArgumentException("String is empty.", "target");

			using (var alg = new SHA256Managed()) {
				var data = Encoding.Unicode.GetBytes(target);
				var hash = alg.ComputeHash(data);
				return Convert.ToBase64String(hash);
			}
		}
	}
}
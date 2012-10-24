using System;

namespace MyTodo.Models {

	public sealed class Password : IEquatable<Password> {
		private readonly string m_hash;

		private Password(string hash) {
			if (hash == null) throw new ArgumentNullException("hash");
			if (string.IsNullOrEmpty(hash)) throw new ArgumentException("String value can not be null or empty", "hash");

			m_hash = hash;
		}

		public static Password CreateFromString(string passwordString) {
			if (passwordString == null) throw new ArgumentNullException("passwordString");
			if (string.IsNullOrEmpty(passwordString)) throw new ArgumentException("String value can not be null or empty", "passwordString");

			return new Password(passwordString.Hash());
		}

		public string Hash {
			get {
				return m_hash;
			}
		}

		public bool Equals(Password other) {
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || string.Equals(m_hash, other.m_hash);
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			var password = obj as Password;
			return password != null && Equals(password);
		}

		public override int GetHashCode() {
			return (m_hash != null ? m_hash.GetHashCode() : 0);
		}
	}
}
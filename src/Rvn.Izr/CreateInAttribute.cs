using System;

namespace Rvn.Izr
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class CreateInAttribute : Attribute, IEquatable<string>
	{
		public CreateInAttribute(string database)
		{
			if (database == null) throw new ArgumentNullException("database", "Database cannot be null");
			if (string.IsNullOrWhiteSpace(database)) throw new ArgumentException("Database cannot be empty", "database");

			Database = database;
		}

		public string Database { get; private set; }

		public bool Equals(string other)
		{
			return StringComparer.OrdinalIgnoreCase.Equals(Database, other);
		}

		public override string ToString()
		{
			return Database;
		}

		internal static CreateInAttribute Get(Type type)
		{
			return (CreateInAttribute) GetCustomAttribute(type, typeof (CreateInAttribute), true);
		}
	}
}

using System;

namespace Rvn.Izr
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	internal sealed class CreateInAttribute : Attribute
	{
		public CreateInAttribute(string database)
		{
			if (database == null) throw new ArgumentNullException("database", "Databse cannot be null");
			if (string.IsNullOrWhiteSpace(database)) throw new ArgumentException("Database cannot be empty");

			Database = database;
		}

		public string Database { get; private set; }

		public override string ToString()
		{
			return Database;
		}
	}
}

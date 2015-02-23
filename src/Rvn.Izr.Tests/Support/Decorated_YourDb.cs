using System;
using System.Linq;
using Raven.Client.Indexes;

namespace Rvn.Izr.Tests.Support
{
	[CreateIn("your_db")]
	public class Decorated_YourDb : AbstractIndexCreationTask<Exception>
	{
		public Decorated_YourDb()
		{
			Map = ex => ex.Select(e => e.Message);
		}
	}
}
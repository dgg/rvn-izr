using System;
using System.Linq;
using Raven.Client.Indexes;

namespace Rvn.Izr.Tests.Support
{
	[CreateIn("my_db")]
	public class Decorated_MyDb : AbstractIndexCreationTask<Exception>
	{
		public Decorated_MyDb()
		{
			Map = ex => ex.Select(e => e.Message);
		} 
	}
}
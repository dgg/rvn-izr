using System;
using System.Linq;
using Raven.Client.Indexes;

namespace Rvn.Izr.Tests.Support
{
	public class NotDecorated : AbstractIndexCreationTask<Exception>
	{
		public NotDecorated()
		{
			Map = ex => ex.Select(e => e.Message);
		}
	}
}
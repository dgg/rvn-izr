using System;
using System.Linq;
using Raven.Client.Indexes;

namespace Rvn.Izr.Tests.Support
{
	[CreateIn("your_db")]
	public class Index_YourDb : AbstractIndexCreationTask<Exception>
	{
		public Index_YourDb()
		{
			Map = ex => ex.Select(e => new[] { e.Message });
		}
	}

	[CreateIn("your_db")]
	public class Transformer_YourDb : AbstractTransformerCreationTask<Exception>
	{
		public Transformer_YourDb()
		{
			TransformResults = ex => ex.Select(e => new { e.Message });
		}
	}
}
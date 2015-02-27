using System;
using System.Linq;
using Raven.Client.Indexes;

namespace Rvn.Izr.Tests.Support
{
	[CreateIn("my_db")]
	public class Index_MyDb : AbstractIndexCreationTask<Exception>
	{
		public Index_MyDb()
		{
			Map = ex => ex.Select(e => new { e.Message });
		}
	}

	[CreateIn("my_db")]
	public class Transformer_MyDb : AbstractTransformerCreationTask<Exception>
	{
		public Transformer_MyDb()
		{
			TransformResults = ex => ex.Select(e => new { e.Message });
		}
	}
}
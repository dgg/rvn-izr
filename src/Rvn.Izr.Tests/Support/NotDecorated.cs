using System;
using System.Linq;
using Raven.Client.Indexes;

namespace Rvn.Izr.Tests.Support
{
	public class Index_NotDecorated : AbstractIndexCreationTask<Exception>
	{
		public Index_NotDecorated()
		{
			Map = ex => ex.Select(e => new { e.Message });
		}
	}

	public class Transformer_NotDecorated : AbstractTransformerCreationTask<Exception>
	{
		public Transformer_NotDecorated()
		{
			TransformResults = ex => ex.Select(e => new { e.Message });
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Rvn.Izr
{
	internal class Contained : Indexes.IContained
	{
		private readonly IEnumerable<Tuple<Type, CreateInAttribute>> _pairs;

		public Contained(IEnumerable<Tuple<Type, CreateInAttribute>> pairs)
		{
			_pairs = pairs;
		}


		public ExportProvider For(string database)
		{
			var indexes = _pairs.Where(a => a.Item2.Equals(database))
				.Select(a => a.Item1);

			ComposablePartCatalog catalog = new TypeCatalog(indexes);
			return new CompositionContainer(catalog);
		}
	}
}
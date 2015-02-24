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
			ComposablePartCatalog catalog = new TypeCatalog(Select(database));
			return new CompositionContainer(catalog);
		}

		public IEnumerable<Type> Select(string database)
		{
			IEnumerable<Type> decoratedIndexes = _pairs
				.Where(a => a.Item2 != null)
				.Where(a => a.Item2.Equals(database))
				.Select(a => a.Item1);

			return decoratedIndexes;
		}

		public Type[] NotDecorated()
		{
			Type[] notDecoratedIndexes = _pairs
				.Where(a => a.Item2 == null)
				.Select(a => a.Item1)
				.ToArray();

			return notDecoratedIndexes;
		}
	}
}
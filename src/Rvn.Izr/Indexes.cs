using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using Raven.Client.Indexes;

namespace Rvn.Izr
{
	public class Indexes
	{
		public static IContainedIn ContainedBesides(params Type[] types)
		{
			return ContainedIn(types.Select(t => t.Assembly).ToArray());
		}

		public static IContainedIn ContainedIn(params Assembly[] assemblies)
		{
			var types = assemblies.SelectMany(a => a.GetTypes())
				.Where(t => typeof(AbstractIndexCreationTask).IsAssignableFrom(t))
				.Select(t => Tuple.Create(t, CreateInAttribute.Get(t)))
				.Where(a => a.Item2 != null);

			return new ContainedIn(types);
		}
	}

	internal class ContainedIn : IContainedIn
	{
		private readonly IEnumerable<Tuple<Type, CreateInAttribute>> _pairs;

		public ContainedIn(IEnumerable<Tuple<Type, CreateInAttribute>> pairs)
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

	public interface IContainedIn
	{
		ExportProvider For(string database);
	}
}
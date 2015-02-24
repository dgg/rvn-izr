using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Raven.Client.Indexes;

namespace Rvn.Izr
{
	public class Indexes
	{
		public interface IContained
		{
			ExportProvider For(string database);
			IEnumerable<Type> Select(string database);
			Type[] NotDecorated();
		}

		public static IContained ContainedBesides(params Type[] types)
		{
			return ContainedIn(types.Select(t => t.Assembly).ToArray());
		}

		public static IContained ContainedIn(params Assembly[] assemblies)
		{
			var types = assemblies.SelectMany(a => a.GetTypes())
				.Where(t => typeof(AbstractIndexCreationTask).IsAssignableFrom(t))
				.Select(t => Tuple.Create(t, CreateInAttribute.Get(t)));

			return new Contained(types);
		}
	}
}
using System;
using System.Collections.Generic;
using Raven.Client;

namespace Rvn.Izr.Abstractions
{
	public interface IBulkInsert : IDisposable
	{
		void Store<T>(T document) where T : class;
		void Store<T>(params T[] documents) where T : class;
		void Store<T>(IEnumerable<T> documents) where T : class;
		IDocumentStore DocStore { get; }
	}
}
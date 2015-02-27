using System.Collections.Generic;
using System.Linq;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using Rvn.Izr.Abstractions;

namespace Rvn.Izr.Adapters
{
	internal class BulkInsertAdapter : IBulkInsert
	{
		private readonly IDocumentStore _store;
		private readonly BulkInsertOperation _operation;

		public BulkInsertAdapter(IDocumentStore store, string database, BulkInsertOptions options)
		{
			_store = store;
			_operation = store.BulkInsert(database, options);
		}

		public void Dispose()
		{
			_operation.Dispose();
		}

		public void Store<T>(T document) where T : class
		{
			_operation.Store(document);
		}

		public void Store<T>(params T[] documents) where T : class
		{
			Store(documents.AsEnumerable());
		}

		public void Store<T>(IEnumerable<T> documents) where T : class
		{
			foreach (var document in documents)
			{
				Store(document);
			}
		}

		public IDocumentStore DocStore { get { return _store; } }
	}
}
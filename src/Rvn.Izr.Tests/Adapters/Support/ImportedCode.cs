using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Client.Linq;

namespace Rvn.Izr.Tests.Adapters.Support
{
	internal abstract class DbSessionAdapter : IDocumentSession
	{
		private readonly IDocumentSession _session;

		protected DbSessionAdapter(IDocumentSession session)
		{
			_session = session;
		}

		public void Dispose()
		{
			_session.Dispose();
		}

		public void Delete<T>(T entity)
		{
			_session.Delete(entity);
		}

		public T Load<T>(string id)
		{
			return _session.Load<T>(id);
		}

		public T[] Load<T>(params string[] ids)
		{
			return _session.Load<T>(ids);
		}

		public T[] Load<T>(IEnumerable<string> ids)
		{
			return _session.Load<T>(ids);
		}

		public T Load<T>(ValueType id)
		{
			return _session.Load<T>(id);
		}

		public T[] Load<T>(params ValueType[] ids)
		{
			return _session.Load<T>(ids);
		}

		public T[] Load<T>(IEnumerable<ValueType> ids)
		{
			return _session.Load<T>(ids);
		}

		public IRavenQueryable<T> Query<T>(string indexName, bool isMapReduce = false)
		{
			return _session.Query<T>(indexName, isMapReduce);
		}

		public IRavenQueryable<T> Query<T>()
		{
			return _session.Query<T>();
		}

		public IRavenQueryable<T> Query<T, TIndexCreator>() where TIndexCreator : AbstractIndexCreationTask, new()
		{
			return _session.Query<T, TIndexCreator>();
		}

		public ILoaderWithInclude<object> Include(string path)
		{
			return _session.Include(path);
		}

		public ILoaderWithInclude<T> Include<T>(Expression<Func<T, object>> path)
		{
			return _session.Include(path);
		}

		public ILoaderWithInclude<T> Include<T, TInclude>(Expression<Func<T, object>> path)
		{
			return _session.Include<T, TInclude>(path);
		}

		public TResult Load<TTransformer, TResult>(string id) where TTransformer : AbstractTransformerCreationTask, new()
		{
			return _session.Load<TTransformer, TResult>(id);
		}

		public TResult Load<TTransformer, TResult>(string id, Action<ILoadConfiguration> configure) where TTransformer : AbstractTransformerCreationTask, new()
		{
			return _session.Load<TTransformer, TResult>(id, configure);
		}

		public TResult[] Load<TTransformer, TResult>(params string[] ids) where TTransformer : AbstractTransformerCreationTask, new()
		{
			return _session.Load<TTransformer, TResult>(ids);
		}

		public TResult[] Load<TTransformer, TResult>(IEnumerable<string> ids, Action<ILoadConfiguration> configure) where TTransformer : AbstractTransformerCreationTask, new()
		{
			return _session.Load<TTransformer, TResult>(ids, configure);
		}

		public void SaveChanges()
		{
			_session.SaveChanges();
		}

		public void Store(object entity, Etag etag)
		{
			_session.Store(entity, etag);
		}

		public void Store(object entity, Etag etag, string id)
		{
			_session.Store(entity, etag, id);
		}

		public void Store(dynamic entity)
		{
			_session.Store(entity);
		}

		public void Store(dynamic entity, string id)
		{
			_session.Store(entity, id);
		}

		public ISyncAdvancedSessionOperation Advanced
		{
			get { return _session.Advanced; }
		}
	}


}
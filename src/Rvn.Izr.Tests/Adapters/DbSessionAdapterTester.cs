using System;
using NUnit.Framework;
using Raven.Client;

namespace Rvn.Izr.Tests.Adapters
{
	[TestFixture, Category("usage")]
	public class DbSessionAdapterTester
	{
		public interface IMyDbSession : IDocumentSession { }

		internal class MyDbSession : Support.DbSessionAdapter, IMyDbSession
		{
			public MyDbSession(IDocumentSession session) : base(session) { }
		}

		[Test, Ignore]
		public void MyDb()
		 {
			 For<IMyDbSession>()
				 .HybridHttpOrThreadLocalScoped()
				 .Use(ctx => new MyDbSession(ctx.GetInstance<IDocumentStore>()
					 .OpenSession("MyDbName")));
		 }

		#region structuremap mockup

		private object For<T>()
		{
			return null;
		}

		#endregion
	}

	internal static class StructureMapMockup
	{
		public static object HybridHttpOrThreadLocalScoped(this object asd) { return null; }

		public static void Use(this object o, Func<object, object> registration) { }

		public static T GetInstance<T>(this object o) { return default(T); }
	}
}
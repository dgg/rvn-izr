using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Rvn.Izr.Tests.Support;

namespace Rvn.Izr.Tests
{
	[TestFixture]
	public class IndexesTester
	{
		[Test]
		public void Builder_MyDb_ReturnsDecoratedIndexesForThatDatabase()
		{
			ExportProvider export = Indexes.ContainedBesides(typeof (IndexesTester))
				.For("my_db");

			IEnumerable<AbstractIndexCreationTask> myDbIndexes = export
				.GetExportedValues<AbstractIndexCreationTask>();

			Assert.That(myDbIndexes, Has
				.Exactly(1).Matches(Is.InstanceOf<Decorated_MyDb>()).And
				.None.Matches(Is.InstanceOf<NotDecorated>()).And
				.None.Matches(Is.InstanceOf<Decorated_YourDb>()));
		}

		[Test, Category("usage"), Ignore]
		public void IndexesBuilder()
		{
			string aDatabase = "a_database";

			IDocumentStore initializedStore = new DocumentStore()
			{
				DefaultDatabase = aDatabase
			};

			ExportProvider export = Indexes.ContainedBesides(typeof(IndexesTester))
				.For(aDatabase);

			IndexCreation.CreateIndexes(export, initializedStore);
		}
	}
}
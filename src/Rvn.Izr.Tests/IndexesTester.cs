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
		public void For_MyDb_ReturnsDecoratedIndexesForThatDatabase()
		{
			ExportProvider export = Indexes.ContainedBesides(typeof(IndexesTester))
				.For("my_db");

			IEnumerable<AbstractIndexCreationTask> myDbIndexes = export
				.GetExportedValues<AbstractIndexCreationTask>();

			Assert.That(myDbIndexes, Has
				.Exactly(1).Matches(Is.InstanceOf<Index_MyDb>()).And
				.None.Matches(Is.InstanceOf<Transformer_MyDb>()).And
				.None.Matches(Is.InstanceOf<Index_NotDecorated>()).And
				.None.Matches(Is.InstanceOf<Transformer_NotDecorated>()).And
				.None.Matches(Is.InstanceOf<Transformer_YourDb>()).And
				.None.Matches(Is.InstanceOf<Index_YourDb>()));
		}

		[Test]
		public void For_MyDb_ReturnsDecoratedTransformersForThatDatabase()
		{
			ExportProvider export = Indexes.ContainedBesides(typeof(IndexesTester))
				.For("my_db");

			IEnumerable<AbstractTransformerCreationTask> myDbIndexes = export
				.GetExportedValues<AbstractTransformerCreationTask>();

			Assert.That(myDbIndexes, Has
				.Exactly(1).Matches(Is.InstanceOf<Transformer_MyDb>()).And
				.None.Matches(Is.InstanceOf<Index_MyDb>()).And
				.None.Matches(Is.InstanceOf<Index_NotDecorated>()).And
				.None.Matches(Is.InstanceOf<Transformer_NotDecorated>()).And
				.None.Matches(Is.InstanceOf<Transformer_YourDb>()).And
				.None.Matches(Is.InstanceOf<Index_YourDb>()));
		}

		[Test]
		public void Select_MyDb_ReturnsDecoratedIndexesForThatDatabase()
		{
			var myDbIndexes = Indexes.ContainedBesides(typeof(IndexesTester))
				.Select("my_db");

			Assert.That(myDbIndexes, Is.EquivalentTo(new[]
			{
				typeof(Index_MyDb),
				typeof(Transformer_MyDb)
			}));
		}

		[Test]
		public void NotDecorated_ReturnsNotDecoratedIndexes()
		{
			var notDecorated = Indexes.ContainedBesides(typeof(IndexesTester))
				.NotDecorated();

			Assert.That(notDecorated, Is.EquivalentTo(new[] {
				typeof(Index_NotDecorated),
				typeof(Transformer_NotDecorated)
			}));
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

		[Test, Category("usage"), Ignore]
		public void DecoratedIndexesTester()
		{

			var notDecoratedIndexes = Indexes.ContainedBesides(typeof(IndexesTester))
				.NotDecorated();

			Assert.That(notDecoratedIndexes, Is.Empty);
		}
	}
}
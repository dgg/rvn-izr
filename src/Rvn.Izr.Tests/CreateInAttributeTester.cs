using System;
using NUnit.Framework;

namespace Rvn.Izr.Tests
{
	[TestFixture]
    public class CreateInAttributeTester
    {
		[Test]
		public void Ctor_NullDatabase_Exception()
		{
			Assert.That(()=> new CreateInAttribute(null), Throws.InstanceOf<ArgumentNullException>().With
				.Message.StringContaining("null"));
		}

		[Test]
		public void Ctor_EmptyDatabase_Exception(
			[Values("", " ")]
			string empty)
		{
			Assert.That(() => new CreateInAttribute(empty), Throws.ArgumentException.With
				.Message.StringContaining("empty"));
		}
    }
}

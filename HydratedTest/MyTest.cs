
using System;
using Hydrated;
using NUnit.Framework;

namespace HydratedTest
{
	[TestFixture]
	public class MyTest
	{
		HydratedPage page = new HydratedPage();

		[Test]
		public void InitPageTest()
		{
			Assert.AreEqual(page.drops.Count, 10);
		}
	}
}

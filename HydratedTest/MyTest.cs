
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

		[Test]
		public void UpdateCountTest()
		{
			page.UpdateWaterCount(5);
			Assert.AreEqual(page.waterCount, 5);
		}

		[Test]
		public void ResetTest()
		{
			page.OnResetPressed(null, null);
			Assert.AreEqual(page.waterCount, 0);
		}

		[Test]
		public void OnDrinkPressedTest()
		{
			page.OnResetPressed(null, null);
			page.OnDrinkPressed(null, null);
			Assert.AreEqual(page.waterCount, 1);
		}

		[Test]
		public void ImageChangeTest()
		{
			page.UpdateWaterCount(1);
			var image = page.drops[0];
			if (image.Source is Xamarin.Forms.FileImageSource)
			{
				Xamarin.Forms.FileImageSource objFileImageSource = (Xamarin.Forms.FileImageSource)image.Source;
				//
				// Access the file that was specified:-
				string strFileName = objFileImageSource.File;
				Assert.AreEqual(strFileName, "WaterFilled");
			}
		}
	}
}

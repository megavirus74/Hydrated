using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Hydrated
{
	public partial class HydratedPage : ContentPage
	{
		public List<Image> drops = new List<Image>(10);
		public int waterCount = 0;
		public HydratedPage()
		{
			InitializeComponent();
			drops.Add(drop1);
			drops.Add(drop2);
			drops.Add(drop3);
			drops.Add(drop4);
			drops.Add(drop5);
			drops.Add(drop6);
			drops.Add(drop7);
			drops.Add(drop8);
			drops.Add(drop9);
			drops.Add(drop10);

			if (Application.Current.Properties.ContainsKey("count"))
			{
				var count = (int) Application.Current.Properties["count"];
				UpdateWaterCount(count);
			}
			if (Application.Current.Properties.ContainsKey("lastDate"))
			{
				var lastDate = (DateTime) Application.Current.Properties["lastDate"];
				if (lastDate.Day != DateTime.Today.Day || lastDate.Month != DateTime.Today.Month || lastDate.Year != DateTime.Today.Year)
				{
					UpdateWaterCount(0);
				}
			}

		}

		public void OnResetPressed(object sender, EventArgs e)
		{
			UpdateWaterCount(0);
		}
		public void OnDrinkPressed(object sender, EventArgs e)
		{
			UpdateWaterCount(waterCount+1);
		}

		public void UpdateWaterCount(int count)
		{
			for (int i = 0; i<10; i++) {
				if (i < count)
				{
					drops[i].RotateTo(360, 500);
					drops[i].Source = "WaterFilled";
				}
				else {
					drops[i].RotateTo(0, 250);
					drops[i].Source = "WaterNo";
				}
			}
			waterCount = count;
			countLabel.Text = count.ToString();
			if (waterCount >= 10)
			{
				drinkButton.Text = "На сегодня достаточно :)";
				drinkButton.IsEnabled = false;
			}
			else {
				drinkButton.Text = "Я выпил стакан воды";
				drinkButton.IsEnabled = true;
			}
			//store
			Application.Current.Properties["count"] = waterCount;
			//store
			Application.Current.Properties["lastDate"] = DateTime.Now;
			Application.Current.SavePropertiesAsync();
		}
	}
}

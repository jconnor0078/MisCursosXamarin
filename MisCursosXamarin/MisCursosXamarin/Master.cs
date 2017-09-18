using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MisCursosXamarin
{
	public class Master : MasterDetailPage
	{
		public Master ()
		{

			var lisview = new ListView();

			lisview.RowHeight = 50;
			lisview.BackgroundColor = Color.FromHex("dfdfdf");
			lisview.SeparatorColor = Color.White;

			var template = new DataTemplate(typeof(TextCell));
			template.SetValue(TextCell.TextColorProperty, Color.White);

			lisview.ItemsSource = new string[]
			{
				"Favorito",
				"Productos"
				,"Mas vendido"
				,"Menos Vendido"
			};

			this.Master = new ContentPage
			{
				Title = "Menu"
				,
				Content = new StackLayout
				{
					Children =
				   {
					   lisview
				   }
				}
			};

			this.Detail = new NavigationPage(new MainPage());
		}
	}
}
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo
{
	public partial class IssuePage : ContentPage
	{
		public IssuePage()
		{
			InitializeComponent();

			myList.ItemTemplate = new DataTemplate(typeof(IssueViewCell));

			myList.ItemsSource = new List<int>() { 0 };

			myList.HasUnevenRows = true;
		}
	}
}

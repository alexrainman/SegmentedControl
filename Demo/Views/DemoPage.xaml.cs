using System;
using Xamarin.Forms;

namespace Demo
{
	public partial class DemoPage : ContentPage
	{
		public DemoPage()
		{
			InitializeComponent();

			Title = "Segmented Control";
		}

		public void Handle_ValueChanged(object o, EventArgs e)
		{
			SegContent.Children.Clear();

			switch (SegControl.SelectedSegment)
			{
				case 0:
					SegContent.Children.Add(new Label() { Text="Items tab selected" });
					break;
				case 1:
					SegContent.Children.Add(new Label() { Text = "Notes tab selected" });
					break;
				case 2:
					SegContent.Children.Add(new Label() { Text = "Approvers tab selected" });
					break;
				case 3:
					SegContent.Children.Add(new Label() { Text = "Attachments tab selected" });
					break;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			SegControl.SetTintColor(Color.Blue);

			SegControl.SelectTab(1);
		}
	}
}


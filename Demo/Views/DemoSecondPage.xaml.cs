using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Demo
{
    /// <summary>
    /// This page is used to demo issue #51 where the Segmented Control
    /// doesn't display on a page that is navigated to.
    /// https://github.com/alexrainman/SegmentedControl/issues/51
    /// </summary>
	public partial class DemoSecondPage : ContentPage
	{
		public DemoSecondPage()
		{
			InitializeComponent();

			Title = "Segmented Control on Second Page";

			SegControl.ValueChanged += SegControl_ValueChanged;
		}

		void SegControl_ValueChanged(object sender, EventArgs e)
		{
			SegContent.Children.Clear();

			switch (SegControl.SelectedSegment)
			{
				case 0:
					SegContent.Children.Add(new Label() { Text = "Items tab selected" });
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

            //SegControl.SelectedSegment = 1;

			//SegControl.TintColor = Color.Purple;

			//SegControl.IsEnabled = false;

            //SegControl.SelectedTextColor = Color.Red;
		}
	}
}


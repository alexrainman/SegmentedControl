using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();

			Title = "Segmented Control 2";

			BindingContext = new MainViewModel();

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
    }
}

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

            Title = "Second Page";
        }

        void Handle_ValueChanged(object sender, SegmentedControl.FormsPlugin.Abstractions.ValueChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case 0:
                    SegContent.Children.Clear();
                    SegContent.Children.Add(new Label() { Text = "Items tab selected" });
                    break;
                case 1:
                    SegContent.Children.Clear();
                    SegContent.Children.Add(new Label() { Text = "Notes tab selected" });
                    break;
                case 2:
                    SegContent.Children.Clear();
                    SegContent.Children.Add(new Label() { Text = "Approvers tab selected" });
                    break;
                case 3:
                    SegContent.Children.Clear();
                    SegContent.Children.Add(new Label() { Text = "Attachments tab selected" });
                    break;
            }
        }
    }
}

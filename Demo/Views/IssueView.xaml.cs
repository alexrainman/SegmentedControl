using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Demo
{
	public partial class IssueView : ContentView
	{
		public IssueView()
		{
			InitializeComponent();

			SegControl.ValueChanged += SegControl_ValueChanged;
		}

		void SegControl_ValueChanged(object sender, int e)
		{
			SegContent.Children.Clear();

			switch (e)
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

	public class IssueViewCell : ViewCell
	{
		public IssueViewCell()
		{
			View = new IssueView();
		}
	}
}

using SegmentedControl.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;
using SegmentedControl.FormsPlugin.Android;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Content.Res;
using AR = Android.Resource;

[assembly: ExportRenderer(typeof(SegmentedControl.FormsPlugin.Abstractions.SegmentedControl), typeof(SegmentedControlRenderer))]
namespace SegmentedControl.FormsPlugin.Android
{
    /// <summary>
    /// SegmentedControl Renderer
    /// </summary>
    public class SegmentedControlRenderer : ViewRenderer<SegmentedControl.FormsPlugin.Abstractions.SegmentedControl, RadioGroup>
	{
		RadioGroup nativeControl;
		RadioButton _v;

		protected override void OnElementChanged(ElementChangedEventArgs<SegmentedControl.FormsPlugin.Abstractions.SegmentedControl> e)
		{
			base.OnElementChanged(e);

			var layoutInflater = LayoutInflater.From(Forms.Context);

			if (Control == null)
			{
				// Instantiate the native control and assign it to the Control property with
				// the SetNativeControl method

				nativeControl = (RadioGroup)layoutInflater.Inflate(Resource.Layout.RadioGroup, null);
				SetNativeControl(nativeControl);
			}

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources

				if (nativeControl != null)
					nativeControl.CheckedChange -= NativeControl_CheckedChange;
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers

				for (var i = 0; i < e.NewElement.Children.Count; i++)
				{
					var o = e.NewElement.Children[i];
					var v = (RadioButton)layoutInflater.Inflate(Resource.Layout.RadioButton, null);

					v.SetWidth(Resources.DisplayMetrics.WidthPixels / 4 - 23);
					v.Text = o.Text;

					//int[][] states = new int[][] { new int[] { -AR.Attribute.StateChecked }, new int[] { -AR.Attribute.StateSelected } };
					//int[] colors = new int[] { Resource.Color.highlight, Resource.Color.highlight };
					//var csl = new ColorStateList(states, colors);
					//v.SetTextColor(csl)

					if (i == Element.SelectedSegment)
					{
						v.SetTextColor(Color.White.ToAndroid());
						_v = v;
					}
					else {
						v.SetTextColor(Element.TintColor.ToAndroid());
					}

					if (i == 0)
						v.SetBackgroundResource(Resource.Drawable.segmented_control_first_background);
					else if (i == e.NewElement.Children.Count - 1)
						v.SetBackgroundResource(Resource.Drawable.segmented_control_last_background);

					SetTintColor(i, v);

					nativeControl.AddView(v);
				}

				var option = (RadioButton)nativeControl.GetChildAt(Element.SelectedSegment);
				nativeControl.Check(option.Id);
				e.NewElement.SelectedText = e.NewElement.Children[Element.SelectedSegment].Text;

				nativeControl.CheckedChange += NativeControl_CheckedChange;
			}
		}

		void NativeControl_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
		{
			var rg = (RadioGroup)sender;
			if (rg.CheckedRadioButtonId != -1)
			{
				var id = rg.CheckedRadioButtonId;
				var radioButton = rg.FindViewById(id);
				var radioId = rg.IndexOfChild(radioButton);
				var btn = (RadioButton)rg.GetChildAt(radioId);
				_v.SetTextColor(Element.TintColor.ToAndroid());
				btn.SetTextColor(Color.White.ToAndroid());
				_v = btn;
				var selection = btn.Text;
				Element.SelectedSegment = radioId;
				Element.SelectedText = selection;
			}
		}

		void SetTintColor(int index, RadioButton button)
		{
			GradientDrawable selectedShape;
			GradientDrawable unselectedShape;

			var gradientDrawable = (StateListDrawable)button.Background;
			var drawableContainerState = (DrawableContainer.DrawableContainerState)gradientDrawable.GetConstantState();
			var children = drawableContainerState.GetChildren();
			if (index == Element.Children.Count - 1)
			{
				selectedShape = (GradientDrawable)children[0];
				unselectedShape = (GradientDrawable)children[1];
			}
			else {
				var selectedItem = (InsetDrawable)children[0];
				var unselectedItem = (InsetDrawable)children[1];
				selectedShape = (GradientDrawable)selectedItem.Drawable;
				unselectedShape = (GradientDrawable)unselectedItem.Drawable;
			}

			selectedShape.SetStroke(3, Element.TintColor.ToAndroid());
			selectedShape.SetColor(Element.TintColor.ToAndroid());
			unselectedShape.SetStroke(3, Element.TintColor.ToAndroid());
		}

		protected override void Dispose(bool disposing)
		{
			nativeControl.Dispose();
			nativeControl = null;
			_v = null;

			try
			{
				base.Dispose(disposing);
			}
			catch (Exception ex)
			{
				return;
			}
		}
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() {
			var temp = DateTime.Now;
		}
    }
}
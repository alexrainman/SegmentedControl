using System;
using Xamarin.Forms;
using SegmentedControl.FormsPlugin.UWP;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using System.Linq;

/*
 * https://github.com/1iveowl/Plugin.SegmentedControl
 */ 

[assembly: ExportRenderer(typeof(SegmentedControl.FormsPlugin.Abstractions.SegmentedControl), typeof(SegmentedControlRenderer))]
namespace SegmentedControl.FormsPlugin.UWP
{
    /// <summary>
    /// SegmentedControl Renderer
    /// </summary>
    public class SegmentedControlRenderer : ViewRenderer<Abstractions.SegmentedControl, SegmentedUserControl>
    {
        private SegmentedUserControl nativeControl;

        private readonly ColorConverter _colorConverter = new ColorConverter();

        protected override void OnElementChanged(ElementChangedEventArgs<Abstractions.SegmentedControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                nativeControl = new SegmentedUserControl();

                var radioButtonGroupName = Guid.NewGuid().ToString();

                var grid = nativeControl.SegmentedControlGrid;
                grid.BorderBrush = (SolidColorBrush)_colorConverter.Convert(Element.TintColor, null, null, "");

                grid.ColumnDefinitions.Clear();
                grid.Children.Clear();

                for (var i = 0; i < Element.Children.Count; i++)
                {
                    var segmentButton = new SegmentRadioButton
                    {
                        GroupName = radioButtonGroupName,
                        Style = (Windows.UI.Xaml.Style)nativeControl.Resources["SegmentedRadioButtonStyle"],
                        Content = Element.Children[i].Text,
                        Tag = i,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        BorderBrush = (SolidColorBrush)_colorConverter.Convert(Element.TintColor, null, null, ""),
                        SelectedTextColor = (SolidColorBrush)_colorConverter.Convert(Element.SelectedTextColor, null, null, ""),
                        TintColor = (SolidColorBrush)_colorConverter.Convert(Element.TintColor, null, null, ""),
                        DisabledColor = (SolidColorBrush)_colorConverter.Convert(Element.DisabledColor, null, null, ""),
                        BorderThickness = i > 0 ? new Windows.UI.Xaml.Thickness(1, 0, 0, 0) : new Windows.UI.Xaml.Thickness(0, 0, 0, 0),
                        IsEnabled = Element.IsEnabled
                    };

                    segmentButton.Checked += SegmentRadioButtonOnChecked;

                    if (i == Element.SelectedSegment)
                    {
                        segmentButton.IsChecked = true;
                    }

                    grid.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition
                    {
                        Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star),
                    });

                    grid.Children.Add(segmentButton);

                    Windows.UI.Xaml.Controls.Grid.SetColumn(segmentButton, i);
                }

                SetNativeControl(nativeControl);
            }

            if (e.OldElement != null)
            {
                DisposeEventHandlers();
            }

            if (e.NewElement != null)
            {
                
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (nativeControl == null || Element == null) return;

            switch (e.PropertyName)
            {
                case "Renderer":
                    Element?.SendValueChanged();
                    break;
                case "SelectedSegment":
                    if (Element.SelectedSegment == -1)
                    {
                        // find checked segment and unselect it
                        var segment = (Windows.UI.Xaml.Controls.RadioButton)nativeControl.SegmentedControlGrid.Children
                        .Where(x =>
                        {
                            var btn = (Windows.UI.Xaml.Controls.RadioButton)x;
                            return btn.IsChecked == true;
                        })
                        .FirstOrDefault();
                        segment.IsChecked = false;
                        return;
                    }
                    if (nativeControl.SegmentedControlGrid.Children
                        .Where(x =>
                        {
                            var btn = (Windows.UI.Xaml.Controls.RadioButton)x;

                            int.TryParse(btn.Tag.ToString(), out var i);
                            return i == Element.SelectedSegment;
                        })
                        .FirstOrDefault() is Windows.UI.Xaml.Controls.RadioButton checkedButton)
                    {
                        checkedButton.IsChecked = true;
                    }
                    Element?.SendValueChanged();
                    break;
                case "TintColor":
                    foreach (var segment in nativeControl.SegmentedControlGrid.Children)
                    {
                        ((SegmentRadioButton)segment).TintColor = (SolidColorBrush)_colorConverter.Convert(Element.TintColor, null, null, "");
                    }
                    break;
                case "DisabledColor":
                    foreach (var segment in nativeControl.SegmentedControlGrid.Children)
                    {
                        ((SegmentRadioButton)segment).DisabledColor = (SolidColorBrush)_colorConverter.Convert(Element.DisabledColor, null, null, "");
                    }
                    break;
                case "Height":
                    // Hack to fix IsEnabled at First Launch
                    foreach (var uiElement in nativeControl.SegmentedControlGrid.Children)
                    {
                        var segment = (SegmentRadioButton)uiElement;
                        SegmentRadioButton.Refresh(segment);
                    }
                    nativeControl.SegmentedControlGrid.BorderBrush = Element.IsEnabled ? (SolidColorBrush)_colorConverter.Convert(Element.TintColor, null, null, "") : (SolidColorBrush)_colorConverter.Convert(Element.DisabledColor, null, null, "");
                    break;
                case "IsEnabled":
                    foreach (var uiElement in nativeControl.SegmentedControlGrid.Children)
                    {
                        var segment = (SegmentRadioButton)uiElement;
                        segment.IsEnabled = Element.IsEnabled;
                    }
                    nativeControl.SegmentedControlGrid.BorderBrush = Element.IsEnabled ? (SolidColorBrush)_colorConverter.Convert(Element.TintColor, null, null, "") : (SolidColorBrush)_colorConverter.Convert(Element.DisabledColor, null, null, "");
                    break;
                case "SelectedTextColor":
                    SetSelectedTextColor();
                    break;
            }
        }

        private void SetSelectedTextColor()
        {
            foreach (var segment in nativeControl.SegmentedControlGrid.Children)
            {
                ((SegmentRadioButton)segment).SelectedTextColor = (SolidColorBrush)_colorConverter.Convert(Element.SelectedTextColor, null, null, "");
            }
        }

        private void SegmentRadioButtonOnChecked(object sender, RoutedEventArgs e)
        {
            var button = (SegmentRadioButton)sender;

            if (button != null)
            {
                Element.SelectedSegment = int.Parse(button.Tag.ToString());
                Element?.SendValueChanged();
            }
        }

        protected override void Dispose(bool disposing)
        {
            DisposeEventHandlers();

            base.Dispose(disposing);
        }

        private void DisposeEventHandlers()
        {
            if (nativeControl != null)
            {
                foreach (var segment in nativeControl.SegmentedControlGrid.Children)
                {
                    ((SegmentRadioButton)segment).Checked -= SegmentRadioButtonOnChecked;
                }
            }
        }
    }
}

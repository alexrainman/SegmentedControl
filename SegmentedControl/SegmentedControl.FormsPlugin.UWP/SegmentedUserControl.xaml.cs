using Windows.UI.Xaml.Controls;

/*
 * https://github.com/1iveowl/Plugin.SegmentedControl
 */

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SegmentedControl.FormsPlugin.UWP
{
    public sealed partial class SegmentedUserControl : UserControl
    {
        public Grid SegmentedControlGrid => mainGrid;
        public SegmentedUserControl()
        {
            this.InitializeComponent();
        }
    }
}

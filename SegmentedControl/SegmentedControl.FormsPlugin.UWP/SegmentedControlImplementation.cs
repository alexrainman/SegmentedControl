using SegmentedControl.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;
using SegmentedControl.FormsPlugin.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(SegmentedControl.FormsPlugin.Abstractions.SegmentedControlControl), typeof(SegmentedControlRenderer))]
namespace SegmentedControl.FormsPlugin.UWP
{
    /// <summary>
    /// SegmentedControl Renderer
    /// </summary>
    public class SegmentedControlRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}

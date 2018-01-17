# Segmented Control Plugin for Xamarin Forms

#### Setup
* Available on NuGet: https://www.nuget.org/packages/SegmentedControl.FormsPlugin/ [![NuGet](https://img.shields.io/nuget/v/SegmentedControl.FormsPlugin.svg?label=NuGet)](https://www.nuget.org/packages/SegmentedControl.FormsPlugin/)
* Install in your PCL project and Client projects.

**Platform Support**

|Platform|Supported|Version|Renderer|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|iOS 8.1+|UISegmentedControl|
|Xamarin.Android|Yes|API 18+|RadioGroup|

#### Usage

In your iOS and Android projects call:

```
Xamarin.Forms.Init();
SegmentedControlRenderer.Init();
```

#### XAML

```xml
xmlns:controls="clr-namespace:SegmentedControl.FormsPlugin.Abstractions;assembly=SegmentedControl.FormsPlugin.Abstractions"
```

```xml
<controls:SegmentedControl x:Name="SegControl" TintColor="#007AFF" SelectedSegment="0">
  <controls:SegmentedControl.Children>
    <controls:SegmentedControlOption Text="Tab 1" />
    <controls:SegmentedControlOption Text="Tab 2" />
    <controls:SegmentedControlOption Text="Tab 3" />
    <controls:SegmentedControlOption Text="Tab 4" />
  </controls:SegmentedControl.Children>
</controls:SegmentedControl>
<StackLayout x:Name="SegContent">
</StackLayout>
```

#### Event handler

```
public void Handle_ValueChanged(object o, int e)
{
	SegContent.Children.Clear();

	switch (e)
	{
		case 0:
			SegContent.Children.Add(new Label() { Text="Tab 1 selected" });
			break;
		case 1:
			SegContent.Children.Add(new Label() { Text = "Tab 2 selected" });
			break;
		case 2:
			SegContent.Children.Add(new Label() { Text = "Tab 3 selected" });
			break;
		case 3:
			SegContent.Children.Add(new Label() { Text = "Tab 4 selected" });
			break;
	}
}
```

**Bindable Properties**

```TintColor```: Fill color for the control (Color, default #007AFF)

```SelectedTextColor```: Selected segment text color (Color, default #FFFFFF)

```SelectedSegment```: Selected segment index (int, default 0).

**Event Handlers**

```ValueChanged```: Called when a segment is selected.

#### Roadmap

* Change font family/size

#### Release Notes

2.0.1

[Android] Segmented Control Not Displaying on Second Page #71

2.0.0

[Update] Adding support for netstandard2.0

[Update] Adding support for UWP

[Update] Adding DisabledColor bindable property

1.3.4

[Android] Setting SelectedSegment to -1 to clear selection throws error in Android #61

[Update] Changing ValueChanged to event to make it available from XAML

1.3.3

[Update] Adding support for no segment selected

[Update] Preventing crashes OnElementPropertyChanged because Element or NativeControl are null.

1.3.2

[Android] Segmented Control Not Displaying on Second Page #51

[Android] About 150 warnings about resources #50

[Android] Android package incompatible with latest Xamarin Forms #48

[Android] Segmented Control Not rendering in Android #46

[Android] Late instantiation of the RadioGroup control in the Android renderer fails to display bug #45

[Android] Object Disposed Exception. Crash. Android only #44

[Android] Segmented control changed displaying inside Grid #42

[Update] Doesn't work with Xamarin.Forms Previewer #49

1.3.1

[Android] Regression: control is not displayed anymore on Android #36 fixed.

1.3.0

[Update] SelectedText property deprecated.

[Update] SelectTab method deprecated (changed SelectedSegment property instead).

[Update] ChangeTintColor method deprecated (change TintColor property instead).

[iOS] SelectedTextColor property implemented.

[Android] Strange colors with disabled android control #16 (fixed).

[Android] Blue color on first and third control #19 (fixed).

[Android] SegmentedControlOption are getting duplicated on android rotation #23 (fixed).

[Android] TintColor not getting set #26 (fixed).

[Android] Segment Text Misaligns when page is left, returned to #30 (fixed).

1.2.4

[Android] #14 IsEnabled has no effect on Android (fixed)

1.2.3

[Android] #14 IsEnabled has no effect on Android (fixed)

1.2.2

[Android] Adding SelectedTextColor property to match iOS control behavior

[Android] Fixing bug #11 Invalid cast exception. Android platform

1.2.1

[Android] Matching tint color behavior with iOS control

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under MIT

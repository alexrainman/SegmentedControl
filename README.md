# ModalPage Plugin for Xamarin Forms

#### Setup
* Available on NuGet: https://www.nuget.org/packages/Plugin.ModalPage/ [![NuGet](https://img.shields.io/nuget/v/Plugin.ModalPage.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.ModalPage/)
* Install in your PCL project and Client projects.

**Platform Support**

|Platform|Supported|Version|Renderer|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|iOS 8.1+|UIViewController|
|Xamarin.Android|Yes|API 15+|AlertDialog|

#### Usage

Push a custom modal:

```
var view = new MyModalView();
CrossModalPage.Current.PushCustomModal(view); // ContentView as parameter
```

Pop a custom modal:

```
CrossModalPage.Current.PopCustomModal();
```

#### Known issues

- You have to provide HeighRequest for elements like Label, Entry ... I still need to figure it out how to propagate request layout down to each children.

- If you are worried about label height you can use this gist: [ITextMeter](https://gist.github.com/alexrainman/82b00160ab32bef9e69dee6d460f44fa)

- Horizontal StackLayout doesn't works. Why? No idea :) You may use a multi-column Grid instead.

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license

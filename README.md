# Snackbar-UI-Utility
Unity package to provide Snackbar UI similar to Android for both Android and IOS platforms.

## Disclaimer
This package has made possible by Dented pixel who has created this awesome package [*LeanTween*](https://assetstore.unity.com/packages/tools/animation/leantween-3595).<br>Copyright (c) 2017 Russell Savage - Dented Pixel, Licensed under The MIT License (MIT)

## Documentation
Simply Import the package. Once imported you can fine a prefab in `DigvijaysinhG`→`Snackbar-UI`→`Framework→Resources`→`SnackBar`<br><br>
![Prefab location](https://user-images.githubusercontent.com/48823553/164162306-5f0fd571-eae2-4c9c-96e1-e16831f7e9dd.png)

On that prefab you can find `SnackBarUi` script component with following settings.<br><br>
![SnackBarUi component](https://user-images.githubusercontent.com/48823553/164162652-4005c737-6ec0-47c0-b165-6669191dcafa.png)

* `Animation Time In Seconds` Float - Define the time for slide animation to complete.
* `Auto Hide` Bool - Determines whether to auto hide the snack bar or not.
* `Duration In Seconds` Float - *Only available if **Auto Hide** is **true**,* determines after how many seconds snack bar should hide.
* `Override With Curve` Bool - Determines the ease effect of animation.
* `Ease type` enum - *Only available if **Override With Curve** is **false**,* determines the animation ease type from predefined enum.
* `Ease curve` Animation Curve - *Only available if **Override With Curve** is **true**,* overrides the animation ease effect with custom curve.

After the prefab is setup, we can display *SnackBar* from any script by calling
``` c#
SnackBar.Show("Your message");
```
And to hide it simply call 
``` c#
SnackBar.Hide();
```
You need to use following namespace for that
``` c#
using DigvijaysinhG.SnackBarUtility;
```

You can also find a *Demo* scene in Example folder

![Example](https://user-images.githubusercontent.com/48823553/164169029-23f148b0-dbdb-4f4c-b9f8-cebdfb8fd52a.gif)

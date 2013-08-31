# Metro dialogs

This user control lib implement some dialogs at metro style:
 * About box dialog
 * Message dialogs
 * Open/save file dialog
 * Select folder dialog
 * Select items dialog
 * Splash screen dialog

Based on MahApps.Metro and Caliburn.Micro

icons:http://modernuiicons.com/

```csharp
//create by ctor
var svc = new WindowDialogs()
//or using IoC
var svc = IoC.Get<IWindowsDialogs>();
```

## About box
```csharp
//show dialog and get result "key1" or "key2" ...
var result = svc.ShowAboutBox("Metro Dialogs", "0.1.2.345", "About program, bla-bla-bla...",
                                         new ActionViewModel("DefaultAction", "key1", true),
                                         new ActionViewModel("CancelAction", "key2", false, true),
                                         new ActionViewModel("CustomAction", "key3"));
```
![about](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/about.png)

## Splash screen
```csharp
svc.OpenSplashScreen("Metro.Dialogs", "0.1.2.34", "About box\nSplash screen\netc...",
                                             "Organization ltd.", "all right reserved", "licened to ");
```
![splash](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/splash.png)

## Select item dialog
```csharp
//without filter
svc.SelectItemDialog("Caption", "Message", false,
                new SelectItem("DisplayName 1", "Description 1", 1),
                new SelectItem("DisplayName 2", "Description 2", 2);
                
//with filter items
svc.SelectItemDialog("Caption", "Message", true,
                new SelectItem("DisplayName 1", "Description 1", 1,_=>_ == "1"),
                new SelectItem("DisplayName 2", "Description 2", 2, _ => _ == "2"));
```
![select](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/select.png)

## Message box dialogs
### Error
![error](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/error.png)
### Info
![info](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/info.png)
### Warn
![warn](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/warn.png)
### Ask user yes/no
![askyesno](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/ask-yes-no.png)
### Dialog with button info
![withInfoButton](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/withInfoButton.png)
### Dialog with custom buttons
![customButton](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/customButton.png)

## Example app
![main](https://raw.github.com/ErwinCat/Metro.Dialogs/master/doc/screenshots/main.png)




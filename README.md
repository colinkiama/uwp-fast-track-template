# WinUI2Template
A UWP project template that let's developers get started with WinUI 2 quickly!

Available in Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=ColinKiama.uwp-fast-track

You can also select "Use this template" and rename namespaces and files yourself.

![WinUI2 Template Screenshot](img/WinUI2Template.png)

## Template Structure
This template is a UWP app with WinUI 2.4 installed and ready to use.

- MainPage (Where a NavigationView for the whole app exists)
- HomePage (The first page displayed in the navigation view)
- Page1 (A secondary page that used to show how you can navigate between pages)
- SettingsPage (Shows when you select the settings item on the NavigationView)

## Branches
| Branch Name | Description |
|-------------|----------- |
| master | Changes from the `runnable` branch used in the latest production release. |
| runnable | A runnable version of the template that will be exported in the `dev` branch. |
| dev | Takes the changes from the `runnable` branch and replaces the names with template parameters.|

## Making your own templates
Learn how to make your own templates here (It can save you a lot of time!): https://docs.microsoft.com/en-us/visualstudio/extensibility/creating-custom-project-and-item-templates?view=vs-2019

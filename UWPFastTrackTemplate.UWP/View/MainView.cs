using EmojiDebugSystem;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using $ext_safeprojectname$.Services;
using $ext_safeprojectname$.UWP;
using $ext_safeprojectname$.UWP.Services;
using $ext_safeprojectname$.ViewModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using WinUI2Template.Model;
using muxc = Microsoft.UI.Xaml.Controls;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace $ext_safeprojectname$.UWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        private double NavViewCompactModeThresholdWidth { get { return NavView.CompactModeThresholdWidth; } }

        public MainView()
        {
            this.InitializeComponent();
            this.DataContext = App.Services.GetRequiredService<MainViewModel>();
        }

        public MainViewModel ViewModel => (MainViewModel)this.DataContext;
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // Add handler for ContentFrame navigation.
            ContentFrame.Navigated += On_Navigated;
            EmojiDebug.WriteLine(DebugEmoji.Celebrate, "NavigationView Loaded (Emoji Debug Test)");
            // NavView doesn't load any page by default, so load home page.
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.

            //// Add keyboard accelerators for backwards navigation.
            //var goBack = new KeyboardAccelerator { Key = Windows.System.VirtualKey.GoBack };
            //goBack.Invoked += BackInvoked;
            //this.KeyboardAccelerators.Add(goBack);

            //// ALT routes here
            //var altLeft = new KeyboardAccelerator
            //{
            //    Key = Windows.System.VirtualKey.Left,
            //    Modifiers = Windows.System.VirtualKeyModifiers.Menu
            //};
            //altLeft.Invoked += BackInvoked;
            //this.KeyboardAccelerators.Add(altLeft);
            //SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            //Debug.WriteLine("ViewModel:", ViewModel.ViewModelName);
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = On_BackRequested();
        }

        private void NavView_ItemInvoked(muxc.NavigationView sender,
                                         muxc.NavigationViewItemInvokedEventArgs args)
        {
            string tag = "";
            
            if (args.IsSettingsInvoked == true)
            {
                tag = "settings";
            }
            else if (args.InvokedItemContainer != null)
            {
                tag = args.InvokedItemContainer.Tag.ToString();
            }
            ViewModel.HandleNavTag(tag, new NavigationInfo(null, args.RecommendedNavigationTransitionInfo));
        }


        private void NavView_BackRequested(muxc.NavigationView sender,
                                           muxc.NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        private void BackInvoked(KeyboardAccelerator sender,
                                 KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private bool On_BackRequested()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavView.IsPaneOpen &&
                (NavView.DisplayMode == muxc.NavigationViewDisplayMode.Compact ||
                 NavView.DisplayMode == muxc.NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();
            return true;
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;
        }

        private void ContentFrame_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService navService = (NavigationService)App.Services.GetRequiredService<INavigationService>();
            navService.LoadFrame(sender as Frame);
            ViewModel.HandleFrameLoad();
        }
    }
}

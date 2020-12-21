using System;
using System.Collections.Generic;
using UWPFastTrackTemplate.Services;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WinUI2Template.Services
{
    public class NavigationService : INavigationService
    {
        public Frame _frame;

        public IDictionary<Type, Type> ViewModelToPageMap { get; } = new Dictionary<Type, Type>();

        public NavigationService(Frame navigationFrame)
        {
            _frame = navigationFrame;
            _frame.Navigated += NavigationFrame_Navigated;
            _frame.PointerPressed += NavigationFrame_PointerPressed;
            SystemNavigationManager.GetForCurrentView().BackRequested += NavService_BackRequested;
        }

        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void LoadFrame(Frame frame)
        {
            // Unregister old frame events then register
            // new one
            if (_frame != null)
            {
                _frame.Navigating -= NavigationFrame_Navigating;
                _frame.Navigated -= NavigationFrame_Navigated;
                _frame.NavigationFailed -= NavigationFrame_NavigationFailed;
                _frame.NavigationStopped -= NavigationFrame_NavigationStopped;

            }
            _frame = frame;
            _frame.Navigated += NavigationFrame_Navigated;
            _frame.Navigating += NavigationFrame_Navigating;
            _frame.NavigationFailed += NavigationFrame_NavigationFailed;
            _frame.NavigationStopped += NavigationFrame_NavigationStopped;
        }

        private void NavigationFrame_NavigationStopped(object sender, NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NavigationFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NavigationFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NavigationFrame_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            bool isXButton1Pressed =
        e.GetCurrentPoint(sender as UIElement).Properties.PointerUpdateKind == PointerUpdateKind.XButton1Pressed;

            if (isXButton1Pressed)
            {
                e.Handled = OnBackRequested();
            }
        }

        private void NavService_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = OnBackRequested();
        }

        private bool OnBackRequested()
        {
            return GoBack();
        }

        public NavigationService RegisterForNavigation<TPage, TViewModel>() where TPage : Page
        {
            ViewModelToPageMap[typeof(TViewModel)] = typeof(TPage);
            return this;
        }


        public bool Navigate<TViewModel>()
        {
            return _frame.Navigate(ViewModelToPageMap[typeof(TViewModel)]);

        }

        public bool GoBack()
        {
            bool canGoBack = false;
            if (_frame.CanGoBack)
            {
                canGoBack = true;
                _frame.GoBack();
            }

            return canGoBack;
        }

    }
}

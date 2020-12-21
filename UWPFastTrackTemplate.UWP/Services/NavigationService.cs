using System;
using System.Collections.Generic;
using System.Linq;
using UWPFastTrackTemplate.Services;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace WinUI2Template.Services
{
    public class NavigationService : INavigationService
    {
        public Frame _frame;
        public event NavigatedEventHandler Navigated;
        public event NavigatingCancelEventHandler Navigating;
        public event NavigationFailedEventHandler NavigationFailed;
        public event NavigationStoppedEventHandler NavigationStopped;

        public IDictionary<Type, Type> ViewModelToPageMap { get; } = new Dictionary<Type, Type>();

        public NavigationService(Frame navigationFrame)
        {
            _frame = navigationFrame;
            _frame.Navigated += _frame_Navigated;
            _frame.PointerPressed += NavigationFrame_PointerPressed;
            SystemNavigationManager.GetForCurrentView().BackRequested += NavService_BackRequested;
        }


        public void LoadFrame(Frame frame)
        {
            // Unregister old frame events then register
            // new one
            if (_frame != null)
            {
                _frame.Navigating -= _frame_Navigating;
                _frame.Navigated -= _frame_Navigated;
                _frame.NavigationFailed -= _frame_NavigationFailed;
                _frame.NavigationStopped -= _frame_NavigationStopped;

            }
            _frame = frame;
            _frame.Navigated += _frame_Navigated;
            _frame.Navigating += _frame_Navigating;
            _frame.NavigationFailed += _frame_NavigationFailed;
            _frame.NavigationStopped += _frame_NavigationStopped;
        }

        private void _frame_NavigationStopped(object sender, NavigationEventArgs e)
        {
            NavigationStopped?.Invoke(this, e);
        }

        private void _frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            NavigationFailed?.Invoke(this, e);
        }

        private void _frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            Navigating?.Invoke(this, e);
        }

        private void _frame_Navigated(object sender, NavigationEventArgs e)
        {
            Navigated?.Invoke(this, e);
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
            // Try to see if you can navigate to a frame
            // by going forward first (Saving memory and time)

            Type sourcePageType = ViewModelToPageMap[typeof(TViewModel)];
            bool didNavigate = false;
            if (_frame.CanGoForward)
            {
                PageStackEntry nextPageInStack = _frame.ForwardStack.First();
                if (nextPageInStack.SourcePageType == sourcePageType)
                {
                    _frame.GoForward();
                    didNavigate = true;
                }
            }
            if (!didNavigate)
            {
                didNavigate = _frame.Navigate(sourcePageType, null, new EntranceNavigationTransitionInfo());
            }
            return didNavigate;
        }


        public bool Navigate<TViewModel>(object parameter)
        {
            Type sourcePageType = ViewModelToPageMap[typeof(TViewModel)];
            return _frame.Navigate(sourcePageType, parameter);
        }

        public bool Navigate<TViewModel>(object parameter, NavigationTransitionInfo infoOverride)
        {
            Type sourcePageType = ViewModelToPageMap[typeof(TViewModel)];
            return _frame.Navigate(sourcePageType, parameter, infoOverride);
        }

        public bool IsCurrentPageOfType(Type typeQuery)
        {
            return _frame.SourcePageType.Equals(typeQuery);
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

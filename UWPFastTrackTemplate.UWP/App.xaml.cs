﻿using Microsoft.Extensions.DependencyInjection;
using System;
using UWPFastTrackTemplate.Services;
using UWPFastTrackTemplate.UWP.Services;
using UWPFastTrackTemplate.UWP.View;
using UWPFastTrackTemplate.ViewModel;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinUI2Template.Model;

namespace UWPFastTrackTemplate.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance for the current application instance.
        /// </summary>
        public static IServiceProvider Services
        {
            get
            {
                IServiceProvider serviceProvider = ((App)Current)._serviceProvider;

                if (serviceProvider is null)
                {
                    throw new InvalidOperationException("The service provider is not initialized");
                }

                return serviceProvider;
            }
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            // CoreApplication.EnablePrelaunch was introduced in Windows 10 version 1607
            bool canEnablePrelaunch = Windows.Foundation.Metadata.ApiInformation.IsMethodPresent("Windows.ApplicationModel.Core.CoreApplication", "EnablePrelaunch");
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                AppStartup();
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }


                // Place the frame in the current Window
                Window.Current.Content = rootFrame;

                _serviceProvider = ConfigureServices(rootFrame);
            }

            if (e.PrelaunchActivated == false)
            {
                if (canEnablePrelaunch)
                {
                    TryEnablePrelaunch();
                }
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                var navService = Services.GetRequiredService<INavigationService>();
                navService.Navigate<MainViewModel>(new NavigationInfo(e.Arguments, null));
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }


        protected override void OnActivated(IActivatedEventArgs args)
        {

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                AppStartup();
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;

                _serviceProvider = ConfigureServices(rootFrame);
            }


            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                var navService = Services.GetRequiredService<NavigationService>();
                navService.Navigate<MainViewModel>(new NavigationInfo(args, null));
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        private void TryEnablePrelaunch()
        {
            Windows.ApplicationModel.Core.CoreApplication.EnablePrelaunch(true);
        }

        private void AppStartup()
        {


        }


        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        /// <summary>
        /// Configures a new <see cref="IServiceProvider"/> instance with the required services.
        /// </summary>
        private static IServiceProvider ConfigureServices(Frame rootFrame)
        {
            //.AddSingleton(new NavigationService(rootFrame))
            return new ServiceCollection()
                .AddSingleton<INavigationService, NavigationService>((e) =>
                {
                    var navService = new NavigationService(rootFrame);
                    navService.RegisterForNavigation<MainView, MainViewModel>()
                    .RegisterForNavigation<HomeView, HomeViewModel>()
                    .RegisterForNavigation<Page1, Page1ViewModel>()
                    .RegisterForNavigation<SettingsView, SettingsViewModel>();
                    return navService;
                })
                .AddSingleton<MainViewModel>()
                .AddSingleton<HomeViewModel>()
                .AddSingleton<Page1ViewModel>()
                .AddSingleton<SettingsViewModel>()
                .BuildServiceProvider();
        }


    }
}

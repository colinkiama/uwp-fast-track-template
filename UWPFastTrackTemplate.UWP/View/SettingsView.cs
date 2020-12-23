﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using $ext_safeprojectname$.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

<<<<<<< HEAD:UWPFastTrackTemplate.UWP/HomePage.xaml.cs
namespace UWPFastTrackTemplate.UWP
=======
namespace $ext_safeprojectname$.UWP.View
>>>>>>> 481833a80f2386ad4ecfc48eb1dbb794264d626c:UWPFastTrackTemplate.UWP/View/SettingsView.cs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsView : Page
    {
        public SettingsView()
        {
            this.InitializeComponent();
            this.DataContext = App.Services.GetRequiredService<SettingsViewModel>();

        }

        SettingsViewModel ViewModel => (SettingsViewModel)this.DataContext;
    }
}

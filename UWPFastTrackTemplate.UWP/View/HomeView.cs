using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Numerics;
using System.Threading.Tasks;
using UWPFastTrackTemplate.ViewModel;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFastTrackTemplate.UWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();
            this.DataContext = App.Services.GetRequiredService<HomeViewModel>();
        }

        public HomeViewModel ViewModel => (HomeViewModel)this.DataContext;

        private async void LogoDropShadowPanel_Loaded(object sender, RoutedEventArgs e)
        {
            await SetupRotateAnimationAsync();
        }

        private async Task SetupRotateAnimationAsync()
        {
            // Don't start animating until inital slide animation has ended
            await Task.Delay(1000);

            Visual logoDropShadowVisual = ElementCompositionPreview.GetElementVisual(LogoDropShadowPanel);
            Compositor compositor = logoDropShadowVisual.Compositor;

            ScalarKeyFrameAnimation animation = compositor.CreateScalarKeyFrameAnimation();
            
            // Ensures that visual rotates at a consistent rate.
            LinearEasingFunction easing = compositor.CreateLinearEasingFunction();

            animation.InsertKeyFrame(1f, 360f, easing);
            animation.Duration = TimeSpan.FromSeconds(5);
            animation.IterationBehavior = AnimationIterationBehavior.Forever;

            logoDropShadowVisual.CenterPoint = new Vector3(logoDropShadowVisual.Size * 0.5f, 0);
            logoDropShadowVisual.StartAnimation("RotationAngleInDegrees", animation);
        }
    }

}

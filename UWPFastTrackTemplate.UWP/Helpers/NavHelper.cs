using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace WinUI2Template.Helpers
{
    internal static class NavHelper
    {
        internal static (object Parameter, NavigationTransitionInfo TransitionInfo) CreateNavigationParameter(object parameter, NavigationTransitionInfo navigationTransition)
        {
            return (parameter, navigationTransition);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace WinUI2Template.Model
{
    internal class NavigationInfo
    {
        public object Parameter { get; set; }
        public NavigationTransitionInfo TransitionInfo { get; set; }
        internal NavigationInfo(object parameter, NavigationTransitionInfo transitionInfo)
        {
            Parameter = parameter;
            TransitionInfo = transitionInfo;
        }
    }
}

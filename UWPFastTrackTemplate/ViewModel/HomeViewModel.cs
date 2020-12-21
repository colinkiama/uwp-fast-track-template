using System;
using System.Collections.Generic;
using System.Text;
using UWPFastTrackTemplate.Services;

namespace UWPFastTrackTemplate.ViewModel
{
    public class HomeViewModel : NavigatableViewModelBase
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}

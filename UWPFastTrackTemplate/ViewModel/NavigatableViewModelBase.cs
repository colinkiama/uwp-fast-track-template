using System;
using System.Collections.Generic;
using System.Text;
using UWPFastTrackTemplate.Services;

namespace UWPFastTrackTemplate.ViewModel
{
    public abstract class NavigatableViewModelBase: ViewModelBase
    {
        private INavigationService _navigationService;
        public NavigatableViewModelBase(INavigationService navigationService) {
            _navigationService = navigationService;
        }
    }
}

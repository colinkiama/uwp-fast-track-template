using System;
using System.Collections.Generic;
using System.Linq;
using UWPFastTrackTemplate.Services;

namespace UWPFastTrackTemplate.ViewModel
{
    public abstract class NavigatableViewModelBase : ViewModelBase
    {
        protected INavigationService _navigationService;
        public NavigatableViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}

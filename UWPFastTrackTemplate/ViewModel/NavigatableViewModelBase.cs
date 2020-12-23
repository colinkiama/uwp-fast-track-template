using System;
using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Services;

namespace $safeprojectname$.ViewModel
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

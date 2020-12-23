using System;
using System.Collections.Generic;
using System.Linq;
using $ext_safeprojectname$.Services;

namespace $ext_safeprojectname$.ViewModel
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

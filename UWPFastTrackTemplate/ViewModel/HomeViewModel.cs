using System;
using System.Collections.Generic;
using System.Text;
using $safeprojectname$.Services;

namespace $safeprojectname$.ViewModel
{
    public class HomeViewModel : NavigatableViewModelBase
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}

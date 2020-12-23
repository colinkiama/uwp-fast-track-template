using System;
using System.Collections.Generic;
using System.Text;
using $ext_safeprojectname$.Services;

namespace $ext_safeprojectname$.ViewModel
{
    public class HomeViewModel : NavigatableViewModelBase
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}

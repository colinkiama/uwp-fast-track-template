using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Services
{
    public interface INavigationService
    {
        bool Navigate<TViewModel>();
        bool Navigate<TViewModel>(object parameter);
        bool Navigate(Type viewModel);
        bool Navigate(Type viewModel, object parameter);
        bool GoBack();
    }
}

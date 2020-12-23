using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using $safeprojectname$.Model;
using $safeprojectname$.Services;

namespace $safeprojectname$.ViewModel
{

    public class MainViewModel : NavigatableViewModelBase
    {
        
        private string _currentViewHeader;

        public string CurrentViewHeader
        {
            get { return _currentViewHeader; }
            set
            {
                _currentViewHeader = value;
                NotifyPropertyChanged();
            }
        }

        private MenuElement _selectedItem;

        public MenuElement SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged();
            }
        }


        public List<MenuElement> MenuElements { get; set; }

        public MenuElement SettingsElement { get; set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            ResourceManager rm = Strings.Resources.ResourceManager;

            MenuElements = new List<MenuElement>() {
            new MenuElement { Title = rm.GetString("HomeTitle"), Icon="Home", Tag="home"},
            new MenuElement { Title = rm.GetString("Page1Title"), Icon="Page", Tag="page1"}
            };


            SettingsElement = new MenuElement { Title = rm.GetString("SettingsTitle"), Icon = "Settings", Tag = "settings" };
            CurrentViewHeader = rm.GetString("HomeTitle");
            SelectedItem = MenuElements.First();
        }

        // List of ValueTuple holding the Navigation Tag and the relative ViewModel
        private readonly List<(string Tag, Type ViewModel)> viewModelTags = new List<(string Tag, Type Page)>
        {
            ("home", typeof(HomeViewModel)),
            ("page1", typeof(Page1ViewModel)),
            ("settings", typeof(SettingsViewModel))
        };

        public void HandleNavTag(string tag, object parameter)
        {
            Type viewModel = null;


            var item = viewModelTags.FirstOrDefault(p => p.Tag.Equals(tag));
            viewModel = item.ViewModel;

            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.

            if (viewModel != null)
            {
                bool navigated = _navigationService.Navigate(viewModel, parameter);
                if (navigated)
                {
                    if (tag == "settings")
                    {
                        SelectedItem = SettingsElement;
                    }
                    else
                    {
                        SelectedItem = MenuElements.Where(x => x.Tag == tag).First();

                    }
                    CurrentViewHeader = SelectedItem.Title;
                }
            }
        }

        public void HandleFrameLoad()
        {
            _navigationService.Navigate<HomeViewModel>();
        }


    }
}

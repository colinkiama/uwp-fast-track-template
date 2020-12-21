using System;
using System.Collections.Generic;
using System.Linq;
using UWPFastTrackTemplate.Model;
using UWPFastTrackTemplate.Services;

namespace UWPFastTrackTemplate.ViewModel
{
    public class MainViewModel : NavigatableViewModelBase
    {
        private string _viewModelName;

        public string ViewModelName
        {
            get { return _viewModelName; }
            set
            {
                _viewModelName = value;
                NotifyPropertyChanged();
            }
        }


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

        public MenuElement SettingsElement = new MenuElement { Title = "Settings", Icon = "Settings", Tag = "settings" };

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            MenuElements = new List<MenuElement>() {
            new MenuElement { Title = "Home", Icon="Home", Tag="home"},
            new MenuElement { Title = "Page 1", Icon="Page", Tag="page1"}
            };

            ViewModelName = "MainViewModel";
            CurrentViewHeader = "Home";
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

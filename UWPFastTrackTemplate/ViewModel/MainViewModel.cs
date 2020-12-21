using System;
using System.Collections.Generic;
using System.Linq;
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


        private string _currentTag;

        public string CurrentTag
        {
            get { return _currentTag; }
            set
            {
                _currentTag = value;
                NotifyPropertyChanged();
            }
        }


        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            ViewModelName = "MainViewModel";
        }

        // List of ValueTuple holding the Navigation Tag and the relative ViewModel
        private readonly List<(string Tag, Type ViewModel)> viewModelTags = new List<(string Tag, Type Page)>
        {
            ("home", typeof(HomeViewModel)),
            ("page1", typeof(Page1ViewModel)),
            ("settings", typeof(SettingsViewModel))
        };

        public void HandleNavTag(string tag)
        {
            Type viewModel = null;


            var item = viewModelTags.FirstOrDefault(p => p.Tag.Equals(tag));
            viewModel = item.ViewModel;

            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.

            if (viewModel != null)
            {
                bool navigated = _navigationService.Navigate(viewModel);
                if (navigated)
                {
                    CurrentTag = tag;
                }
            }
        }

        public void HandleFrameLoad()
        {
            _navigationService.Navigate<HomeViewModel>();
        }
    }
}

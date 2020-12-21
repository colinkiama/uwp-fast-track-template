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

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }


    }
}

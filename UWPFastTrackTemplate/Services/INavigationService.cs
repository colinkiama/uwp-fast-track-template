using System;
using System.Collections.Generic;
using System.Text;

namespace UWPFastTrackTemplate.Services
{
    public interface INavigationService
    {
        bool Navigate<TViewModel>();
        bool GoBack();
    }
}

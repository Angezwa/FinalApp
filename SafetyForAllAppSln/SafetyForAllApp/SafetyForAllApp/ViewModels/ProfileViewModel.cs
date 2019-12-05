using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafetyForAllApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Profile";
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafetyForAllApp.ViewModels
{
    public class SelfDefenseTipsViewModel : ViewModelBase
    {
        public SelfDefenseTipsViewModel (INavigationService navigationService) : base(navigationService)
        {
            Title = "Self Defense Tips";
        }
    }
}

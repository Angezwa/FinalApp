using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SafetyForAllApp.Model;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SafetyForAllApp.ViewModels
{
    public class MenuPageViewModel : ViewModelBase
    {
        
        private DelegateCommand _helpMeCommand;
        public DelegateCommand HelpMeCommand =>
            _helpMeCommand ?? (_helpMeCommand = new DelegateCommand(ExecuteHelpMeCommand));

        private async void ExecuteHelpMeCommand()
        {
            await NavigationService.NavigateAsync("MainPage");
        }
        public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Emergency";

        }
    }
}

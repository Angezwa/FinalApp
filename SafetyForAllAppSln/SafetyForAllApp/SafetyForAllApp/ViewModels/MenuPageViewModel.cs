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

        private DelegateCommand _reportGBVCommand;
        public DelegateCommand ReportGBVCommand =>
            _reportGBVCommand ?? (_reportGBVCommand = new DelegateCommand(ExecuteReportGBVCommand));

        private DelegateCommand _shareLocationCommand;
        public DelegateCommand ShareLocationCommand =>
            _shareLocationCommand ?? (_shareLocationCommand = new DelegateCommand(ExecuteShareLocationCommand));

        private DelegateCommand _ePDCommand;
        public DelegateCommand EPDCommand =>
            _ePDCommand ?? (_ePDCommand = new DelegateCommand(ExecuteEPDCommand));

        private async void ExecuteEPDCommand()
        {
            await NavigationService.NavigateAsync("EmergencyDirectory");
        }

        private async void ExecuteShareLocationCommand()
        {
            await NavigationService.NavigateAsync("ShareLocation");
        }

        private async void ExecuteReportGBVCommand()
        {
            await NavigationService.NavigateAsync("ReportGbv");
        }

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

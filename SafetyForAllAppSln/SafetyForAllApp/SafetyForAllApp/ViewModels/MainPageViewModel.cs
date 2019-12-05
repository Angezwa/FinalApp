using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SafetyForAllApp.Messages;
using SafetyForAllApp.Model;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafetyForAllApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IMenuService _menuService;
        private IEventAggregator _eventAggregator;

        private DelegateCommand _createNewAccountCommand;
        public DelegateCommand CreateNewAccountCommand =>
            _createNewAccountCommand ?? (_createNewAccountCommand = new DelegateCommand(ExecuteCreateNewAccountCommand));

        private DelegateCommand _logInCommand;
        public DelegateCommand LogInCommand =>
            _logInCommand ?? (_logInCommand = new DelegateCommand(ExecuteLogInCommand));

       private async void ExecuteLogInCommand()
        {
            await NavigationService.NavigateAsync("MasterDetail/NavigationPage/MenuPage", useModalNavigation:true);

            var loginResult = _menuService.LogIn("Test User", "Password");

            
            var userProfile = new UserP();

            if (loginResult)
            {
                _eventAggregator.GetEvent<LogInMessage>().Publish(userProfile);
            }
        }
       private async void ExecuteCreateNewAccountCommand()
        {
            await NavigationService.NavigateAsync("SignUpPage");
        }
        public MainPageViewModel(INavigationService navigationService, IMenuService menuService, IEventAggregator eventAggregator) : base(navigationService)
        {
            Title = "Main Page";

        }
    }
}

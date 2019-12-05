using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafetyForAllApp.Model;
using SafetyForAllApp.MyDatabase;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafetyForAllApp.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private IDatabase _database;

        private DelegateCommand _registerCommand;
        public DelegateCommand RegisterCommand =>
            _registerCommand ?? (_registerCommand = new DelegateCommand(ExecuteRegisterCommand));

        public SignUpDetails Details { get; set; }

       private async void ExecuteRegisterCommand()
        {

            //var connection = new SQLconn();
            //await connection.SaveItemAsync(Details);

            //await _database.SaveItemAsync(Details);
            await NavigationService.NavigateAsync("MainPage");
        }

        public SignUpPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}

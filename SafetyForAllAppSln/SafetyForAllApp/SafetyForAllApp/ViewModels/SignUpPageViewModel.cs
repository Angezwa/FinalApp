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

        private SignUpDetails _details;
        public SignUpDetails Details { get; set; }



        public SignUpPageViewModel(INavigationService navigationService, IDatabase database) : base(navigationService)
        {
            var details = new SignUpDetails();
            Details = details;

            _database = database;
        }

        private async void ExecuteRegisterCommand()
        {
            var registeredUser = await _database.GetUserByUserName(Details.Username);

            //var connection = new SQLconn();
            //await connection.SaveItemAsync(Details);

            await _database.SaveItemAsync(Details);

            await NavigationService.NavigateAsync("MainPage");
        }
    }
}

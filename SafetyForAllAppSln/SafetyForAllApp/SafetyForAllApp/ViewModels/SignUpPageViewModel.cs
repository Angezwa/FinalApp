using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafetyForAllApp.Model;
using SafetyForAllApp.MyDatabase;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

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


            await _database.SaveItemAsync(Details);

            //var client = new HttpClient();
            //var url = "http://10.0.2.2:5000/SignUpDetails";
            //var json = JsonConvert.SerializeObject(Details);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //await client.PostAsync(url, content);

            await NavigationService.NavigateAsync("MainPage");
        }
    }
}

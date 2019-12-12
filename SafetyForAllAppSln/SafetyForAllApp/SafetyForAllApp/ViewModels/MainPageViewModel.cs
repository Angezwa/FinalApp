using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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
        private IDatabase _database;
        private IPageDialogService _dialogService;
        private IMenuService _menuService;
        private IEventAggregator _eventAggregator;

        public bool PasswordExist { get; set; }
        public SignUpDetails LogInDetails { get; set; }

        private DelegateCommand _createNewAccountCommand;
        public DelegateCommand CreateNewAccountCommand =>
            _createNewAccountCommand ?? (_createNewAccountCommand = new DelegateCommand(ExecuteCreateNewAccountCommand));

        private DelegateCommand _logInCommand;
        public DelegateCommand LogInCommand =>
            _logInCommand ?? (_logInCommand = new DelegateCommand(ExecuteLogInCommand));


        private SignUpDetails _details;
        public SignUpDetails Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }


        private async void ExecuteLogInCommand()
        {

            var registeredUser = await _database.GetUserByUserName(LogInDetails.Username);

            if (registeredUser == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "User does not exist!", "ok");
                return;
            }


            if (LogInDetails.Username == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Please Fill in Username!", "ok");
            }
            else if (LogInDetails.Password == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Please Fill in Password", "ok");
            }
            else

            {
                if (registeredUser.Password == LogInDetails.Password)
                {
                    PasswordExist = true;
                    var loginResult = _menuService.LogIn("Test User", "Password");

                   // var userProfile = new UserP();

                    if (loginResult)
                    {
                        _eventAggregator.GetEvent<LogInMessage>().Publish();
                    }

           //         await NavigationService.NavigateAsync("MasterDetail/NavigationPage/MenuPage", useModalNavigation: true);
                    return;
                }

                else
                    PasswordExist = false;

            }
        }
       private async void ExecuteCreateNewAccountCommand()
        {
            
            await NavigationService.NavigateAsync("SignUpPage");
        }
        public MainPageViewModel(INavigationService navigationService,IPageDialogService dialogService, IMenuService menuService, IEventAggregator eventAggregator, IDatabase database) : base(navigationService)
        {
            Title = "Main Page";

            _database = database;

            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _menuService = menuService;
            

            Details = new SignUpDetails();
            LogInDetails = Details;


        }
    }
}

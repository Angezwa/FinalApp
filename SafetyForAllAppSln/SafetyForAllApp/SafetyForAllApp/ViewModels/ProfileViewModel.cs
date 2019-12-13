using Prism.Commands;
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
    public class ProfileViewModel : ViewModelBase
    {

        private IDatabase _database;
        private IUserP _userP;


        private SignUpDetails _loggedInUser;
        public SignUpDetails LoggedInUser
        {
            get { return _loggedInUser; }
            set { SetProperty(ref _loggedInUser, value); }
        }
       
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            LoggedInUser = _userP.GetLoggedInUser();
        }
        //private IUserP _userP;

        //public SignUpDetails UserInfor { get; set; }

        //public List<SignUpDetails> CustomerDetails { get; set; }
        //private SignUpDetails _loggedin;
        //private object IUserP;

        //public SignUpDetails LoggedInUser
        //{
        //    get { return _loggedin; }
        //    set { SetProperty(ref _loggedin, value); }
        //}
        //public override void Initialize(INavigationParameters parameters)
        //{
        //    base.Initialize(parameters);
        //    LoggedInUser = _userP.GetLoggedInUser();
        //}


        private DelegateCommand _saveChangesCommand;
        public DelegateCommand SaveChangesCommand =>
            _saveChangesCommand ?? (_saveChangesCommand = new DelegateCommand(ExecuteSaveChangesCommand));

        void ExecuteSaveChangesCommand()
        {

        }

        public ProfileViewModel(INavigationService navigationService, IDatabase database, IUserP userP) : base(navigationService)
        {
            Title = "Profile";

            _database = database;
            _userP = userP;
        }

        //private SignUpDetails _details;
        //public SignUpDetails Details
        //{
        //    get { return _details; }
        //    set { SetProperty(ref _details, value); }
    }
}

       

        //public async override void Initialize(INavigationParameters parameters)
        //{
        //    base.OnNavigatedFrom(parameters);

        //    await _database.GetUserByUserName(Details.Username);

            
        //}

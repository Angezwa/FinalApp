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

        private DelegateCommand _saveChangesCommand;
        public DelegateCommand SaveChangesCommand =>
            _saveChangesCommand ?? (_saveChangesCommand = new DelegateCommand(ExecuteSaveChangesCommand));

        void ExecuteSaveChangesCommand()
        {

        }


        private SignUpDetails _details;
        public SignUpDetails Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }

        public ProfileViewModel(INavigationService navigationService, IDatabase database) : base(navigationService)
        {
            Title = "Profile";

            _database = database;
        }

        //public async override void Initialize(INavigationParameters parameters)
        //{
        //    base.OnNavigatedFrom(parameters);

        //    await _database.GetUserByUserName(Details.Username);

            
        //}


    }
}

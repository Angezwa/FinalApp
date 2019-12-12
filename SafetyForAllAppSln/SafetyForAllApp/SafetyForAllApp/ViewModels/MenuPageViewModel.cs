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
using System.Threading.Tasks;
using Xamarin.Essentials;

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
            var contactNumbers = new List<string>();
            contactNumbers.Add("0718980404");
            contactNumbers.Add("0638771175");
            contactNumbers.Add("0639620424");
            contactNumbers.Add("0793709715");


            await SendSms("I need Help, I'm in Danger", contactNumbers.ToArray());
            //await SendCoordinates()
        }
        public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Emergency";

        }

        public async Task SendSms(string messageText, string[] recipients)
        {
            try
            {
                var message = new SmsMessage(messageText, recipients);
                await Sms.ComposeAsync(message);

                //var requestLoc = new GeolocationRequest(GeolocationAccuracy.Medium);
                //var location = await Geolocation.GetLocationAsync(request);
                //double Latitude = location.Latitude;
                //double Longitude = location.Longitude;
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}


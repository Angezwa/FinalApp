using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SafetyForAllApp.Messages;
using SafetyForAllApp.Model;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SafetyForAllApp.ViewModels
{
    public class MasterDetailViewModel : ViewModelBase
    {
        private IMenuService _menuService;
        private IEventAggregator _eventAggregator;
        private IDocumentViewer _documentViewer;

        private string _pdfPath;

        private ObservableCollection<DetailsItem> _detailsItems;
        public ObservableCollection<DetailsItem> DetailsItems
        {
            get { return _detailsItems; }
            set { SetProperty(ref _detailsItems, value); }
        }

        private DelegateCommand<DetailsItem> _navigateCommand;
        public DelegateCommand<DetailsItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<DetailsItem>(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand(DetailsItem item)
        {
            {
                if (item.MenuType == SafetyForAllApp.MenuType.MenuItemEnum.LogOut)
                    _menuService.LogOut();
                else
                {
                    if (!string.IsNullOrEmpty(item.NavigationPath))
                    await NavigationService.NavigateAsync(item.NavigationPath);
                    else
                    {
                        switch (item.Id)
                        {
                            case 3: // Id of the menu

                                CopyEmbeddedContent("SafetyForAllApp.PdfFile.PersonalSafety.pdf", "PersonalSafety.pdf");
                                _documentViewer.ViewDocument(_pdfPath, "PersonalSafety.pdf");

                                break;
                        }
                    }
                }
            }
        }
        public MasterDetailViewModel(INavigationService navigationService, IMenuService menuService, IEventAggregator eventAggregator, IDocumentViewer documentViewer) : base(navigationService)
        {
            _menuService = menuService;
            _eventAggregator = eventAggregator;
            _documentViewer = documentViewer;

            DetailsItems = new ObservableCollection<DetailsItem>(_menuService.GetAllowedAccessItems());

            _eventAggregator.GetEvent<LogInMessage>().Subscribe(LoginEvent);
            _eventAggregator.GetEvent<LogOutMessage>().Subscribe(LogOutEvent);


            _pdfPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        }

        public void LoginEvent(UserP userProfile)
        {
            DetailsItems = new ObservableCollection<DetailsItem>(_menuService.GetAllowedAccessItems());

            NavigationService.NavigateAsync("NavigationPage/MenuPage");
        }

        public void LogOutEvent()
        {
            DetailsItems = new ObservableCollection<DetailsItem>(_menuService.GetAllowedAccessItems());

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        private void CopyEmbeddedContent(string resourceName, string outputFileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            using (Stream resFilestream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resFilestream == null) return;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);

                File.WriteAllBytes(Path.Combine(_pdfPath, outputFileName), ba);
            }
        }

    }
}

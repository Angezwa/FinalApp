using ControlExamples.Controls.Maps;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafetyForAllApp.Model;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Maps;

namespace SafetyForAllApp.ViewModels
{
    public class ShareLocationViewModel : ViewModelBase
    {
        private IMapping _mappingService;

        readonly ObservableCollection<Location> _locations;

        private MapSpan _centerPosition;
        public MapSpan CenterPosition
        {
            get { return _centerPosition; }
            set { SetProperty(ref _centerPosition, value); }
        }

        public IEnumerable Locations => _locations;


        public ShareLocationViewModel(INavigationService navigationService, IMapping mapping) : base(navigationService)
        {
            _locations = new ObservableCollection<Location>();

             _mappingService = mapping;
        }

        public async  override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var location = await _mappingService.GetNewLocation();

            CenterPosition = MapSpan.FromCenterAndRadius(location.Position, Distance.FromMiles(10));



            _locations.Add(location);
        }
    }
}

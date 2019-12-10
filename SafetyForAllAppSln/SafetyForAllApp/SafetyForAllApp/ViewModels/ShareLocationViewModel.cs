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

        public IEnumerable Locations => _locations;


        private DelegateCommand _addLocationCommand;
        public DelegateCommand AddLocationCommand =>
            _addLocationCommand ?? (_addLocationCommand = new DelegateCommand(ExecuteAddLocation));
        private DelegateCommand _removeLocationCommand;

        public DelegateCommand RemoveLocationCommand =>
            _removeLocationCommand ?? (_removeLocationCommand = new DelegateCommand(ExecuteRemoveLocation));

        private DelegateCommand _clearLocationCommand;
        public DelegateCommand ClearLocationsCommand =>
    _clearLocationCommand ?? (_clearLocationCommand = new DelegateCommand(ExecuteClearLocation));


        private DelegateCommand _updateLocationCommand;
        public DelegateCommand UpdateLocationCommand =>
    _updateLocationCommand ?? (_updateLocationCommand = new DelegateCommand(ExecuteUpdateLocations));

        private DelegateCommand _replaceLocationCommand;
        public DelegateCommand ReplaceLocationCommand =>
        _replaceLocationCommand ?? (_replaceLocationCommand = new DelegateCommand(ExecuteReplaceLocation));


        public ShareLocationViewModel(INavigationService navigationService, IMapping mapping) : base(navigationService)
        {
            _locations = new ObservableCollection<Location>();

             _mappingService = mapping;
        }

        private void ExecuteAddLocation()
        {
            _locations.Add(_mappingService.GetNewLocation());
        }

        private void ExecuteUpdateLocations()
        {
            if (!_locations.Any())
            {
                return;
            }

            double lastLatitude = _locations.Last().Position.Latitude;
            foreach (Location location in Locations)
            {
                location.Position = new Position(lastLatitude, location.Position.Longitude);
            }

        }

        private void ExecuteReplaceLocation()
        {
            if (!_locations.Any())
            {
                return;
            }

            _locations[_locations.Count - 1] = _mappingService.GetNewLocation();

        }

        private void ExecuteClearLocation()
        {
            _locations.Clear();
        }

        private void ExecuteRemoveLocation()
        {
            if (_locations.Any())
            {
                _locations.Remove(_locations.First());
            }
        }
    }
}

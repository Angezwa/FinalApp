using SafetyForAllApp.Model;
using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace SafetyForAllApp.Service
{
    public class MappingService : IMapping
    {
        int _pinCreatedCount = 0;

        public async Task<ControlExamples.Controls.Maps.Location> GetNewLocation()
        {

            var location = await Geolocation.GetLastKnownLocationAsync();

            var position = new Position(location.Latitude, location.Longitude);

            var returnLocation = new ControlExamples.Controls.Maps.Location("Current Location","Current Location", position);

            return returnLocation;
        }
    }
}

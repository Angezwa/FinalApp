using SafetyForAllApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafetyForAllApp.Service.Interfaces
{
    public interface IMapping
    {
        Task<ControlExamples.Controls.Maps.Location> GetNewLocation();
    }
}

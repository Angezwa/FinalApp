using SafetyForAllApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyForAllApp.Service.Interfaces
{
    public interface IMenuService
    {
        IList<DetailsItem> GetAllowedAccessItems();
        bool LogIn(string Username, string Password);
        void LogOut();
    }
}

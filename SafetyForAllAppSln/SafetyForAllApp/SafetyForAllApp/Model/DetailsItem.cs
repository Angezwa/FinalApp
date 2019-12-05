using SafetyForAllApp.MenuType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyForAllApp.Model
{
    public class DetailsItem
    {
        public int Id { get; set; }
        public int MenuOrder { get; set; }
        public string DetailsItemName {get; set;}
        public string DetailsImageName { get; set; }
        public string NavigationPath { get; set; }
        public MenuItemEnum MenuType { get; set; }
    }
}

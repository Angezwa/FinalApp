using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyForAllApp.Model
{
    public class UserP : IUserP
    {
        private SignUpDetails _loggedInUser;
        public void SetLoggedinUser(SignUpDetails signUpDetails)
        {
            _loggedInUser = signUpDetails;
        }
        public SignUpDetails GetLoggedInUser()
        {
            return _loggedInUser;
        }
    }
}

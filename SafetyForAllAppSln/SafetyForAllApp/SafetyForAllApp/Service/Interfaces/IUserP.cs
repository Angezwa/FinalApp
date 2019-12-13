using SafetyForAllApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyForAllApp.Service.Interfaces
{
    public interface IUserP
    {
        void SetLoggedinUser(SignUpDetails signUpDetails);

        SignUpDetails GetLoggedInUser();
    }
}

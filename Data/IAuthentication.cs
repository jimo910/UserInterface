using UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface.Data
{
    public interface IAuthentication
    {
        bool AuthenticationFunc(string AuthToken);
        void updateAuthenticated(bool isTrue, string AuthToken);

    }
}

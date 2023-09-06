using UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface.Data
{
    public interface ILogin
    {
        User Login(string emailAddress, string password);

    }
}

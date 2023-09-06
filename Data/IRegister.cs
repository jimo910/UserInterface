using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface.Data
{
    public interface IRegister
    {
        string  Register(string[] fields);
        bool UserExists(string emailAddress);
    }
}


using UserInterface.FieldValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface.Views
{
    public interface IView
    {
        void RunView();
        IFieldValidator FieldValidator { get; }
    }
}
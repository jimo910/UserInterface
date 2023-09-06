using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.Data;
using UserInterface.FieldValidators;
using  UserInterface.Models;

namespace UserInterface.Views
{
    public class UserAuthenticationView : IView
    {
        IAuthentication  _AuthenticateUser = null;
        public IFieldValidator FieldValidator => null;

        public UserAuthenticationView ( IAuthentication authenticate)
        {
            _AuthenticateUser = authenticate;
        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

         //   CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your Authentication Key");

            string AuthenticationToken = Console.ReadLine();

          

        //    User user = _loginUser.Login(emailAddress,password);
            bool isExist = _AuthenticateUser.AuthenticationFunc(AuthenticationToken);

            if (isExist == true)
            {
                             
                _AuthenticateUser.updateAuthenticated(isExist, AuthenticationToken);
                 Console.Clear();
                 CommonOutputFormat.ChangeFontColor(FontTheme.Success);
                 Console.WriteLine(" ThE user is now authenticated, and can proceed to login");

            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match any of our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }

        }
    }
}

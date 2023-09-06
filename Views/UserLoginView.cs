using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.Data;
using UserInterface.FieldValidators;
using  UserInterface.Models;

namespace UserInterface.Views
{
    public class UserLoginView : IView
    {
        ILogin _loginUser = null;
        public IFieldValidator FieldValidator => null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");

            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password");

            string password = Console.ReadLine();

            User user = _loginUser.Login(emailAddress,password);

            if (user != null)
            {
                if(user.Authenticated==1){
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
                }else{
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("User Profile have not been Authenticated, authenticate User profile and try again");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();

                }

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

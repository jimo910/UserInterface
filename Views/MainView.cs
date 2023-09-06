using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.FieldValidators;


namespace UserInterface.Views
{
    class MainView : IView
    {
        public IFieldValidator FieldValidator => null;

        IView _registerView = null;
        IView _loginView = null;
        IView _AuthenticateView = null;
        IView _updateProfileView = null;

        public MainView(IView registerView, IView loginView, IView AuthenticateView, IView UpdateProfileView)
        {
            _registerView = registerView;
            _loginView = loginView;
            _AuthenticateView = AuthenticateView;
            _updateProfileView= UpdateProfileView;

        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or  if you are not yet registered please press 'r',  or press 'u' to Authenticate");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunAuthenticationView();
            }
            else if (key == ConsoleKey.L)
            {
                RunLoginView();
            }
            else if (key == ConsoleKey.U)
            {
               RunAuthenticationView();
               RunLoginView();
            }else if(key ==ConsoleKey.P){

                    RunUpdateProfileViews();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.ReadKey();
               
            }
        
        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();
        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }
        private void RunAuthenticationView(){
            _AuthenticateView.RunView();
        }
        private void RunUpdateProfileViews(){

            _updateProfileView.RunView();
        }

    }
}


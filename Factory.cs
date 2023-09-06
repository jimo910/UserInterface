using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.Views;
using UserInterface.Data;
using UserInterface.FieldValidators;

namespace UserInterface
{
    public static class Factory
    {
        public static IView GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IRegister updateProfile = new UpdateUser();
            IAuthentication authenticate = new  UserAuthentication();
            IFieldValidator userRegistrationValidator = new UserRegistrationValidator(register);
            IFieldValidator UserUpdateValidator = new UserRegistrationValidator(updateProfile);
            userRegistrationValidator.InitialiseValidatorDelegates();

            IView registerView = new UserRegistrationView(register, userRegistrationValidator, 0);
            IView UpdateProfileView = new UserUpdateProfileView(updateProfile,UserUpdateValidator, 1);
            IView loginView = new UserLoginView(login);
            IView authenticateview = new UserAuthenticationView(authenticate);

            IView mainView = new MainView(registerView, loginView, authenticateview, UpdateProfileView);

            return mainView;

        }
    }
}

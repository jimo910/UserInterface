using UserInterface.Models;
using UserInterface.TokenAuth;
using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.FieldValidators;
using System.Linq;

namespace UserInterface.Data
{
    public class RegisterUser : IRegister
    {
        public bool UserExists(string emailAddress)
        {
            bool emailExists = false;

            using (var dbContext = new UserInterfaceDbContext())
            {
                emailExists = dbContext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }
            return emailExists;
        }

        public string Register(string[] fields)
        {
           string  AuthenticationTokengenerate=null;
            using (var dbContext = new UserInterfaceDbContext())
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],
                    AuthenticationToken= TokenAuthentication.GenerateJwtToken(fields[(int)FieldConstants.UserRegistrationField.EmailAddress]),
                    Authenticated = 0
                };
                AuthenticationTokengenerate = user.AuthenticationToken;
                dbContext.Users.Add(user);

                dbContext.SaveChanges();
            }
            return AuthenticationTokengenerate;
        }
    }
}

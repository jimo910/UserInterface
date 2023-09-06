using UserInterface.Models;
using UserInterface.TokenAuth;
using System;
using System.Collections.Generic;
using System.Text;
using UserInterface.FieldValidators;
using System.Linq;

namespace UserInterface.Data
{
    public class UpdateUser : IRegister
    {
        User _USERS=null;
        string _AuthTokens = null;
        
        
        
        public bool UserExists(string AuthToken)
        {
            bool UserExists = false;
            
           var context = new UserInterfaceDbContext();
            User UserExist =  context.Users.FirstOrDefault(a => a.AuthenticationToken == AuthToken); 
            _USERS= UserExist;
                   if (UserExist != null)
                {
                    _USERS =UserExist;
                    return true;

                }

                return false;
            
          
        }


        public string Register(string[] fields)
        {
                     var context = new UserInterfaceDbContext();
                    _USERS.EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress];
                     _USERS.FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName];
                     _USERS.LastName = fields[(int)FieldConstants.UserRegistrationField.LastName];
                     _USERS.Password = fields[(int)FieldConstants.UserRegistrationField.Password];
                     _USERS.DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]);
                     _USERS.PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber];
                     _USERS.AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine];
                     _USERS.AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine];
                     _USERS.AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity];
                     _USERS.PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode];
                    // _USERS.AuthenticationToken= TokenAuthentication.GenerateJwtToken(fields[(int)FieldConstants.UserRegistrationField.EmailAddress]),
                     _USERS.Authenticated = 1;
                      context.SaveChanges();

                 return "UPDATED";
            }
           
        }
    }


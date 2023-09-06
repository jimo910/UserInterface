using UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UserInterface.Data
{
    
    public class UserAuthentication: IAuthentication{


            
        public bool  AuthenticationFunc(string AuthToken){

        var context = new  UserInterfaceDbContext();
         var UserExist =  context.Users.FirstOrDefault(a => a.AuthenticationToken == AuthToken); 
                   if (UserExist != null)
                {
                    return true;

                }

                return false;
        }


     public void updateAuthenticated(bool isTrue,  string AuthToken){

        if(isTrue){
            var context = new  UserInterfaceDbContext();
            var UserExist =  context.Users.FirstOrDefault(a => a.AuthenticationToken == AuthToken); 
            UserExist.Authenticated = 1;
            context.SaveChanges();
        }

     }



    }

}

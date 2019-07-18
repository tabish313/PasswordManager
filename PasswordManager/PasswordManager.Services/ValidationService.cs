using PasswordManager.Entities;
using PasswordManager.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides Validation for Different Entities and Objects in BearPass
    /// </summary>
    public class ValidationService
    {
        private static ValidationService _instance;

        protected ValidationService()
        {
        }

        public static ValidationService Instance()
        {
            if (_instance == null)
            {
                _instance = new ValidationService();
            }

            return _instance;
        }

        /// <summary>
        /// Determines wether the supplied User object is valid.
        /// </summary>
        /// <param name="user">User object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public bool User(Users user)
        {
            //we should also check if user is authorized or exists -gul:0301171247
            //i think that would be heavy operation because i am calling this method in so many places. -gul:0401171150
            if (user != null)
            {
                if (Verifier.Text(user.Username) && Verifier.Text(user.Master))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied Password object is valid.
        /// </summary>
        /// <param name="password">Password object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public bool Password(Passwords password)
        {
            if (password != null)
            {
                if (Verifier.Email(password.Email) && Verifier.Text(password.Text))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        
    }
}

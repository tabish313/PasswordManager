using PasswordManager.Data;
using PasswordManager.Entities;
using PasswordManager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to User related objects and data.
    /// </summary>
    public class UsersService
    {
        private static UsersService _instance;

        private DB Database = DB.Instance();

        protected UsersService()
        {
        }

        public static UsersService Instance()
        {
            if (_instance == null)
            {
                _instance = new UsersService();
            }

            return _instance;
        }

        /// <summary>
        /// Determines wether User already exists or not.
        /// </summary>
        /// <param name="user">User to check.</param>
        /// <returns>Boolean: True if User exists, False if not.</returns>
        public Task<bool> UserExistAsync(Users user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (ValidationService.Instance().User(user))
                {
                    if (UsersData.Instance().LoginUser(user) != null)
                        return true;
                    else return false;
                }
                else return false;
            });
        }

        /// <summary>
        /// Registers the new User.
        /// </summary>
        /// <param name="user">User to be registered.</param>
        /// <returns>User: The newly registered user with Default Settings.</returns>


        /// <summary>
        /// Login the User.
        /// </summary>
        /// <param name="user">User to be Login.</param>
        /// <returns>User: The logged in User.</returns>
        public Task<Users> LoginUserAsync(Users user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (ValidationService.Instance().User(user))
                {
                    Users Check = Database.CheckLogin(user);
                    if (Check != null)
                    {
                        return Check;
                    }
                    else
                    {
                        return null;
                    }

                }
                else return null;
            });
        }

        /// <summary>
        /// Login the User.
        /// </summary>
        /// <param name="user">User to be Login.</param>
        /// <returns>User: The logged in User.</returns>
        public Users LoginUser(Users user)
        {
            if (ValidationService.Instance().User(user))
            {
                Users UserFromDB = UsersData.Instance().LoginUser(user);
                if (ValidationService.Instance().User(UserFromDB) && PasswordsService.Instance().IsSame(UserFromDB.Master, user.Master))
                {
                    return UserFromDB;
                }
                else return null;
            }
            else return null;
        }
    }
}

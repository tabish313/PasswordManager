
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Database;

namespace PasswordManager.Data
{
    public class UsersData
    {
        private DB Database = DB.Instance();

        private static UsersData _instance;

        protected UsersData()
        {
        }

        public static UsersData Instance()
        {
            if (_instance == null)
            {
                _instance = new UsersData();
            }

            return _instance;
        }

        public Users LoginUser(Users user)
        {
            return Database.GetUserByUsername(user.Email);
        }

        public int UpdateUser(Users user)
        {
            return Database.UpdateUser(user);
        }
    }
}

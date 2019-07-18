using PasswordManager.Database;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data
{
    public class PasswordsData
    {
        private static PasswordsData _instance;

        private DB Database = DB.Instance();

        protected PasswordsData()
        {
        }

        public static PasswordsData Instance()
        {
            if (_instance == null)
            {
                _instance = new PasswordsData();
            }

            return _instance;
        }


        
    }
}

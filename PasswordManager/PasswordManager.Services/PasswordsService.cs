using PasswordManager.Data;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Database;


namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to User related Passwords and data.
    /// </summary>
    public class PasswordsService
    {
        private static PasswordsService _instance;

        private DB Database = DB.Instance();
        protected PasswordsService()
        {
        }

        public static PasswordsService Instance()
        {
            if (_instance == null)
            {
                _instance = new PasswordsService();
            }

            return _instance;
        }

        public List<Passwords> GetPasswords()
        {
            return Database.GetPasswordsList();
        }

        public string GetPasswordByID(int ID)
        {
            return Database.GetPasswordbyID(ID);
        }


        public int DeletePassword(int ID)
        {
            return Database.DeletePasswordByID(ID);
        }

        public Task<Passwords> SaveNewUserPasswordsAsync(Passwords passwords)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Database.SaveNewUserPasswords(CryptoService.Instance().EncryptUserPasswords(passwords)) > 0)
                {
                    return passwords;
                }
                else return null;
            });
        }

        public Task<List<Passwords>> RetrieveUserPasswordsAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                List<Passwords> passwordList = null;

                passwordList = CryptoService.Instance().DecryptUserPasswords(Database.RetrievePassword());

                return passwordList ;
            });
        }



        public Task<bool> IsSameAsync(string Pass1, string Pass2)
        {
            //this need a little refactoring in a more better way i think. -gul:0301171513
            return Task.Factory.StartNew(() =>
            {
                return string.Equals(Pass1, Pass2);
            });
        }

        /// <summary>
        /// Determines weather the Supplied Passwords are Same or Not.
        /// </summary>
        /// <param name="Pass1">Password to be Matched.</param>
        /// <param name="Pass2">Password to be Matched With.</param>
        /// <returns>Boolean: True if Same otherwise False.</returns>
        public bool IsSame(string Pass1, string Pass2)
        {
            return string.Equals(Pass1, Pass2);
        }
    }
}

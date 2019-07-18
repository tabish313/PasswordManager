using PasswordManager.Entities;
using PasswordManager.Globals;
using System.Collections.Generic;
using System.Threading.Tasks;
using PasswordManager.Hash;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to DataEncryption and DataDecryption functions.
    /// </summary>
    public class CryptoService
    {
        private static CryptoService _instance;

        protected CryptoService()
        {
        }

        public static CryptoService Instance()
        {
            if (_instance == null)
            {
                _instance = new CryptoService();
            }

            return _instance;
        }

        /// <summary>
        /// DataEncrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be DataEncrypted.</param>
        /// <param name="password">Password to be DataEncrypted.</param>
        /// <returns>Password: The Password in DataEncrypted format.</returns>
        public Passwords EncryptUserPasswords(Passwords password)
        {
                password.Name = Gulipso.DataEncrypt(password.Name);
                password.Email = Gulipso.DataEncrypt(password.Email);
                password.Username = Gulipso.DataEncrypt(password.Username);
                password.Website = Gulipso.DataEncrypt(password.Website);
                password.Text = Gulipso.DataEncrypt(password.Text);
                password.Notes = Gulipso.DataEncrypt(password.Notes);
            return password;
         
        }

        public Passwords DecryptUserPasswords(Passwords password)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.DataDecrypt(password.Name);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.DataDecrypt(password.Email);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.DataDecrypt(password.Username);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.DataDecrypt(password.Website);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.DataDecrypt(password.Text);
            if (Verifier.Text(password.Notes)) password.Notes = Gulipso.DataDecrypt(password.Notes);
            return password;

        }

        public List<Passwords> DecryptUserPasswords(List<Passwords> passwords)
        {
            List<Passwords> decryptedPasswords = new List<Passwords>();

            foreach (var password in passwords)
            {
                decryptedPasswords.Add(DecryptUserPasswords(password));
            }
            return decryptedPasswords;
        }
    }
}

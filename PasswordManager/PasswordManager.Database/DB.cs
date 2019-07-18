using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;

namespace PasswordManager.Database
{
    public class DB
    {
        private static DB _instance;

        private static DbEntities db;
        
        public static void SetDatabase(string DatabasePath)
        {
            db = new DbEntities(DatabasePath);
        }

        public static DB Instance()
        {
            if (_instance == null)
            {
                _instance = new DB();
            }
            return _instance;
        }

        public int AddNewUser(Users user)
        {

            int affectedrows = -1;

            db.Users.Add(user);

            affectedrows = db.SaveChanges();

            return affectedrows;
        }

        public Users GetUserByUsername(string username)
        {
            var us = db.Users.Where(c => c.Username == username).FirstOrDefault();
            
            return us;
        }

        public int UpdateUser(Users user)
        {
            int AffectedRows = -1;

            db.Entry(user).State = System.Data.Entity.EntityState.Modified;

            AffectedRows = db.SaveChanges();
            
            return AffectedRows;
        }

        public Users CheckLogin(Users users)
        {
            var check = db.Users.Where(c => c.Username == users.Username && c.Master == users.Master).FirstOrDefault();

            if (check != null)
            {
                return check;
            }
            else
            {
                return null;
            }
        }

        public List<Passwords> GetPasswordsList()
        {
            var list = db.Passwords.ToList();

            return list;
        }

        public string GetPasswordbyID(int ID)
        {
            var password = db.Passwords.Where(c => c.ID == ID).FirstOrDefault();

            return password.Text.ToString();
        }

        public int DeletePasswordByID(int ID)
        {
            try
            {
                var password = db.Passwords.Where(c => c.ID == ID).FirstOrDefault();
                db.Entry(password).State = System.Data.Entity.EntityState.Deleted;
                int status = db.SaveChanges();

                if (status > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void DbRefresh()
        {
            var context = ((IObjectContextAdapter)db).ObjectContext;
            var refreshableObjects = db.ChangeTracker.Entries().Select(c => c.Entity).ToList();
            context.Refresh(RefreshMode.StoreWins, refreshableObjects);
        }

        public int SaveNewUserPasswords(Passwords passwords)
        {
            db.Passwords.Add(passwords);
            int affectedrow = db.SaveChanges();
            return affectedrow;
        }

        public List<Passwords> RetrievePassword()
        {
            var pass = db.Passwords.ToList();

            return pass;
        }

        public string GetPassHash(int ID)
        {
            var HashPas = db.Passwords.Where(c => c.ID == ID).FirstOrDefault();
            return HashPas.Text;
        }
    }
}

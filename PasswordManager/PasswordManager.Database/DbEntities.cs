using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Entities;

namespace PasswordManager.Database
{
    public class DbEntities : DbContext
    {
        public DbEntities(string Databasepath) :
            base(new SQLiteConnection()
            {
                /*/ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = Application.StartupPath + @"\Database\database-2019.db", ForeignKeys = true }.ConnectionString/*/
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = Databasepath, ForeignKeys = true }.ConnectionString

            }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Passwords> Passwords { get; set; }
    }
}

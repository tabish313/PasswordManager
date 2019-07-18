using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;


namespace PasswordManager.Entities
{
    [Table(Name = "Passwords")]
    public class Passwords
    {
        [Display(Name = "ID")]
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "Name", DbType = "VARCHAR")]
        public string Name { get; set; }

        [Column(Name = "Email", DbType = "VARCHAR")]
        public string Email { get; set; }

        [Column(Name = "Username", DbType = "VARCHAR")]
        public string Username { get; set; }

        [Column(Name = "Website", DbType = "VARCHAR")]
        public string Website { get; set; }

        [Column(Name = "Text", DbType = "VARCHAR")]
        public string Text { get; set; }

        [Column(Name = "Notes", DbType = "VARCHAR")]
        public string Notes { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    [Table(Name ="Users")]
    public class Users
    {
        [Display(Name = "ID")]
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Column(Name = "Name", DbType = "VARCHAR")]
        public string Name { get; set; }

        [Display(Name = "Username")]
        [Column(Name = "Username", DbType = "VARCHAR")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Column(Name = "Email", DbType = "VARCHAR")]
        public string Email { get; set; }

        [Display(Name = "Master")]
        [Column(Name = "Master", DbType = "VARCHAR")]
        public string Master { get; set; }
        
    }
}

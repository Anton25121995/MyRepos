using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace HelloMvxForms.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [OneToMany]
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", Email, Password);
        }
    }
}

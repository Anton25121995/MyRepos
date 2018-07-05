using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace HelloMvxForms.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;

        public string ImageName { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ManyToOne]
        public User User { get; set; }
        
        [Ignore]
        public bool ToRemove { get; set; } = false;

        public override string ToString()
        {
            return String.Format("{0} {1}", Title, Description);
        }
        public Item() { }
    }
}

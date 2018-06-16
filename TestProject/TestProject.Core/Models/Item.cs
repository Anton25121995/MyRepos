using SQLite;

namespace TestProject.Core.Models
{
    [Table("Table")]
    public class Item
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;

        public string ImageName { get; set; }
        
        [Ignore]
        public bool ToRemove { get; set; } = false;

        public Item() { }
    }
}

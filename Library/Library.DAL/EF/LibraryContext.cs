using System;
using System.Data.Entity;
using Library.Entities.Entities;

namespace Library.DAL
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=LibraryContext")
        {

        }

        public virtual DbSet<Brochure> Brochures { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}

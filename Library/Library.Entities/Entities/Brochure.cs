using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Entities
{
    public class Brochure : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Publishing { get; set; }
    }
}

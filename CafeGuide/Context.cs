using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
    class Context
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Type> Types { get; set; }

        public Context() : base("CafeDB")
        {
        }
    }
}

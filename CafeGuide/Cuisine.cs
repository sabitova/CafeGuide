using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Cafe> Cafes { get; set; }
    }
}

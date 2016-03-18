using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
    class Cafe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public List<Cuisine> Cuisine { get; set; }
        public Address Address { get; set; }
        public double CheckAvg { get; set; }
        public bool WiFi { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public int Time { get; set; }
    }
}

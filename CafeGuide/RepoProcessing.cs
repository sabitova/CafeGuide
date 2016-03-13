using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
    public class RepoProcessing : IProcessing
    {
        public List<Cafe> Cafes = new List<Cafe>();

        public void AddEntities()
        {
            var anticafe = new Type
            {
                Id = 1,
                Name = "anticafe"
            };

            var bar = new Type
            {
                Id = 2,
                Name = "bar"
            };

            var address1 = new Address
            {
                Id = 1,
                Text = "Myasnitskaya ul., d. 17, str. 2",
                Lat = "55.763789",
                Long = "37.634681"
            };

            var address2 = new Address
            {
                Id = 2,
                Text = "Pokrovka ul., d. 19",
                Lat = "55.759794",
                Long = "37.646223899999995"
            };

            var eu = new Cuisine
            {
                Id = 1,
                Name = "European"
            };

            var it = new Cuisine
            {
                Id = 2,
                Name = "Italian"
            };

            var Cafe1 = new Cafe
            {
                Id = 1,
                Name = "Checkpoint",
                Type = anticafe,
                Address = address1,
                CheckAvg = 300,
                WiFi = true,
                Cuisine = new List<Cuisine> { eu }
            };

            var Cafe2 = new Cafe
            {
                Id = 2,
                Name = "19Bar&Atmosphere",
                Type = bar,
                Address = address2,
                CheckAvg = 1000,
                WiFi = false,
                Cuisine = new List<Cuisine> { eu, it }
            };

            Cafes.Add(Cafe1);
            Cafes.Add(Cafe2);
        }

        public List<Cafe> GetSuitableCafes(int time)
        {
            var address3 = new Address
            {
                Id = 3,
                Text = "Krasnaya pl., d. 1",
                Lat = "55.7537523",
                Long = "37.62251679999997"
            };

            var SuitableCafes = new List<Cafe>();

            foreach (var c in Cafes)
            {
                if (APIDirection.GetTime(address3, c.Address) < time * 60)
                    SuitableCafes.Add(c);
            }

            return SuitableCafes;
        }
    }
}

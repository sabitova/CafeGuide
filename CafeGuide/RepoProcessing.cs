using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
    public class RepoProcessing : IProcessing
    {
        public List<Cafe> cafes = new List<Cafe>();
        public List<Cuisine> cuisines = new List<Cuisine>();
        public List<Type> types = new List<Type>();

        public List<Cafe> suitableCafes;

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

            var address3 = new Address
            {
                Id = 3,
                Text = "Krasnaya pl., d. 1",
                Lat = "55.7537523",
                Long = "37.62251679999997"
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

            
            cuisines.Add(eu);
            cuisines.Add(it);

            types.Add(anticafe);
            types.Add(bar);

            cafes.Add(Cafe1);
            cafes.Add(Cafe2);
        }

        public void GetSuitableCafes(int time, string type, string cuisine, int avgCheck, bool wi_fi)
        {
            suitableCafes = cafes.Where(c => c.Cuisine.Contains(cuisines.FirstOrDefault(cu => cu.Name == cuisine)))
                                 .Where(c => c.Type.Name == type)
                                 .Where(c => c.Time <= time)
                                 .Where(c => c.CheckAvg <= avgCheck)
                                 .Where(c => wi_fi)
                                 .ToList();
        }

        public void GetTimeForAllCafes(Address from, string mode)
        {
            foreach (var c in cafes)
            {
                c.Time = APIDirection.GetTime(from, c.Address, mode);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CafeGuide
{
    public class RepoProcessing : IProcessing
    {
        public List<Cafe> cafes;
        public List<Cuisine> cuisines;
        public List<Type> types;
        public List<Address> addresses;

        public List<Cafe> suitableCafes;

        public void AddEntities()
        {
            cafes = new List<Cafe>();
            cuisines = new List<Cuisine>();
            types = new List<Type>();
            addresses = new List<Address>();

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
                Text = "Zemlyanoj Val ul., 60c1",
                Lat = "55.7469",
                Long = "37.654963",
                PlaceId = "ChIJmzoe4e5KtUYRnI2rgFXy2j0"
            };

            var address2 = new Address
            {
                Id = 2,
                Text = "Ladozhskaja ul., 2/37, str. 1",
                Lat = "55.77105899999999",
                Long = "37.6792975",
                PlaceId = "ChIJi8L8bYJKtUYRKSs35OFfI0U"
            };

            var address3 = new Address
            {
                Id = 3,
                Text = "Staraja Basmannaja ul., 7, str. 1",
                Lat = "55.7645437",
                Long = "37.6569245",
                PlaceId = "ChIJNcJmWYhKtUYRYYOkITwbA1g"
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
                Cuisine = new List<Cuisine> { eu, it }
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

            addresses.Add(address1);
            addresses.Add(address2);
            addresses.Add(address3);
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

        public void FindCafeByName(string name)
        {
            var placeid = cafes.Where(c => c.Name == name)
                               .First()
                               .Address.PlaceId;

            DetailedInformation info = new DetailedInformation(placeid);
            info.ShowDialog();
        }

        public ArrayList GetPlaceInfo(string placeid)
        {
            ArrayList info = new ArrayList();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).Name).ToString();


            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).Address.Text).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).CheckAvg).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).Cuisine).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).Type.Name).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).OpeningTime).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).ClosingTime).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).WiFi).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).Website).ToString();

            info.Add(((cafes.Where(c => c.Address.PlaceId == placeid))
                            .FirstOrDefault()).PhoneNumber).ToString();

            return info;
        }
    }
}

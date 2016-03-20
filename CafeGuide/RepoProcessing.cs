using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace CafeGuide
{
    public class RepoProcessing : IProcessing
    {
        public List<Cafe> cafes { get; set; }
        public List<Cuisine> cuisines { get; set; }
        public List<Type> types { get; set; }
        public List<Address> addresses { get; set; }

        public List<Cafe> suitableCafes { get; set; }

        public void AddEntities()
        {
            cafes = new List<Cafe>();
            cuisines = new List<Cuisine>();
            types = new List<Type>();
            addresses = new List<Address>();

            var anticafe = new Type
            {
                Id = 1,
                Name = "Anticafe"
            };

            var bar = new Type
            {
                Id = 2,
                Name = "Bar"
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
            List<Cafe> suitableCafes = cafes;
            if (cuisine != "" && cuisine != null)
            {
                var suitableCuisine = cuisines.Where(cu => cu.Name == cuisine).FirstOrDefault();
                suitableCafes = cafes.Where(c => c.Cuisine.Contains(suitableCuisine)).ToList();
            }

            if (type != "" && type != null)
                suitableCafes = suitableCafes.Where(c => c.Type.Name == type).ToList();

            if (time != 0)
                suitableCafes = suitableCafes.Where(c => c.Time <= time).ToList();

            if (avgCheck != 0)
                suitableCafes = suitableCafes.Where(c => c.CheckAvg <= avgCheck).ToList();

                suitableCafes = suitableCafes.Where(c => c.WiFi == wi_fi || true).ToList();

            ResultList.dt.Columns.Add("Name");
            ResultList.dt.Columns.Add("Time (min)");
            ResultList.dt.Columns.Add("Average Check (rub)");

            foreach (var item in suitableCafes)
            {
                var row = ResultList.dt.NewRow();

                row["Name"] = item.Name;
                row["Time (min)"] = item.Time.ToString();
                row["Average Check (rub)"] = item.CheckAvg.ToString();

                ResultList.dt.Rows.Add(row);
            }
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
                            .FirstOrDefault()).Cuisine);

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

        public string GetPlaceId(string name)
        {
            return (cafes.Where(c => c.Name == name)
                        .FirstOrDefault()).Address.PlaceId.ToString();
        }

        public string GetLat(string placeid)
        {
            return ((addresses.Where(a => a.PlaceId == placeid)).FirstOrDefault()).Lat;
        }

        public string GetLong(string placeid)
        {
            return ((addresses.Where(a => a.PlaceId == placeid)).FirstOrDefault()).Long;
        }
    }
}

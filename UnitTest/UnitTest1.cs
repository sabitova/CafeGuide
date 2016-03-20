using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeGuide;
using System.Collections.Generic;
using Moq;
using System.Collections;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public List<Cafe> cafes = new List<Cafe>();
        public List<Cuisine> cuisines = new List<Cuisine>();
        public List<CafeGuide.Type> types = new List<CafeGuide.Type>();
        public List<Address> addresses;

        public void AddEntities()
        {
            cafes = new List<Cafe>();
            cuisines = new List<Cuisine>();
            types = new List<CafeGuide.Type>();
            addresses = new List<Address>();

            var anticafe = new CafeGuide.Type
            {
                Id = 1,
                Name = "anticafe"
            };

            var bar = new CafeGuide.Type
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
                Cuisine = new List<Cuisine> { eu },
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

        [TestMethod]
        public void GetTimeForAllCafes_ReturnsCorrectResults()
        {
            AddEntities();
            RepoProcessing repo = new RepoProcessing();

            repo.GetTimeForAllCafes(addresses[2], "driving");
             
            foreach (var c in cafes)
            {
                Assert.IsNotNull(c.Time);
            }
            

        }

        [TestMethod]
        public void GetPlaceInfo_ReturnsCorrectResults()
        {
            string[] placeIDs = { "ChIJmzoe4e5KtUYRnI2rgFXy2j0", "ChIJi8L8bYJKtUYRKSs35OFfI0U", "ChIJNcJmWYhKtUYRYYOkITwbA1g" };

            List<ArrayList> info = new List<ArrayList>();

            foreach (string id in placeIDs)
            {
                DBProcessing dp = new DBProcessing();
                info.Add(dp.GetPlaceInfo(id));
            }
            foreach(var i in info)
            {
                Assert.AreEqual(10, i.Capacity-1);
            }
                       
        }
    }
}

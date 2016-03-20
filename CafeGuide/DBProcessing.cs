using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CafeGuide
{
    public class DBProcessing : IProcessing
    {
        public string ConnectionString = "Data Source = DESKTOP-RE0AOSG; Initial Catalog = CafesDB; Integrated Security = True";

        public void GetSuitableCafes(int time, string type, string cuisine, int avgCheck, bool wifi)
        {
            // building a string

            string query = "select distinct Cafe.Name, Time/60 as [Time (min)], CheckAvg as [Average Check (rub)] " +
                           "from Cafe " +
                           "join " +
                           "CafeCuisine on Cafe.Id = CafeCuisine.CafeId " +
                           "join " +
                           "Cuisine ON Cuisine.Id = CafeCuisine.CuisineId " +
                           "join " +
                           "Type ON Type.Id = Cafe.TypeId " +
                           "where";

            if (type != "")
                query += String.Format(" Type.Name = '{0}' and", type);

            if (cuisine != "")
                query += String.Format(" Cuisine.Name = '{0}' and", cuisine);

            if (avgCheck != 0)
                query += String.Format(" CheckAvg <= {0} and", avgCheck);

            if (time != 0)
                query += String.Format(" Time/60 <= {0} and", time);

            if (wifi)
                query += String.Format(" WiFi = 1");

            if (query.EndsWith("where"))
                query = query.Remove(query.Length - 5);

            if (query.EndsWith("and"))
                query = query.Remove(query.Length - 3);

            // making a query

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ResultList.dt);
                    }
                }
            }
        }

        public void GetTimeForAllCafes(Address from, string mode)
        {
            List<int> time = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command1 = new SqlCommand("select * from Address", connection))
                {
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            time.Add(APIDirection.GetTime(from, 
                            new Address
                            { Lat = reader.GetFieldValue<string>(2),
                              Long = reader.GetFieldValue<string>(3),
                            },
                            mode));
                        }
                    }
                }

                for (int i = 0; i < time.Count(); i++)
                {
                    using (var command2 = new SqlCommand(String.Format("UPDATE Cafe SET Time = {0} WHERE Id = {1}", time[i], i + 1), connection))
                    {
                        command2.ExecuteNonQuery();
                    }
                }
            }
        }

        public string GetPlaceId(string name)
        {
            string placeid = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(string.Format("select PlaceId " +
                                                    "from Address " +
                                                    "join Cafe " +
                                                    "on Cafe.AdressId = Address.Id " +
                                                    "where Cafe.Name = '{0}'", name), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            placeid = reader.GetFieldValue<string>(0);
                        }
                    }
                }
            }
            return placeid;
        }

        public ArrayList GetPlaceInfo(string placeid)
        {
            ArrayList info = new ArrayList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(string.Format("select Name " +
                                                    "from Cafe " +
                                                    "join Address " +
                                                    "on Cafe.AdressId = Address.Id " +
                                                    "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select Text " +
                                                    "from Address " +
                                                    "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select CheckAvg " +
                                                    "from Cafe " +
                                                    "join Address " +
                                                    "on Cafe.AdressId = Address.Id " +
                                                    "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<int>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select Cuisine.Name " +
                                                   "from Cuisine " +
                                                   "join CafeCuisine " +
                                                   "on CafeCuisine.CuisineId = Cuisine.Id " +
                                                   "join Cafe " +
                                                   "on CafeCuisine.CafeId = Cafe.Id " +
                                                   "join Address " +
                                                   "on Cafe.AdressId = Address.Id " +
                                                   "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select Type.Name " +
                                                   "from Type " +
                                                   "join Cafe " +
                                                   "on Cafe.TypeId = Type.Id " +
                                                   "join Address " +
                                                   "on Cafe.AdressId = Address.Id " +
                                                   "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }

                 using (var command = new SqlCommand(string.Format("select OpeningTime " +
                                                   "from Cafe " +
                                                   "join Address " +
                                                   "on Cafe.AdressId = Address.Id " +
                                                   "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<TimeSpan>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select ClosingTime " +
                                                  "from Cafe " +
                                                  "join Address " +
                                                  "on Cafe.AdressId = Address.Id " +
                                                  "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<TimeSpan>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select WiFi " +
                                                 "from Cafe " +
                                                 "join Address " +
                                                 "on Cafe.AdressId = Address.Id " +
                                                 "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<bool>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select Website " +
                                                 "from Cafe " +
                                                 "join Address " +
                                                 "on Cafe.AdressId = Address.Id " +
                                                 "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }

                using (var command = new SqlCommand(string.Format("select PhoneNumber " +
                                                 "from Cafe " +
                                                 "join Address " +
                                                 "on Cafe.AdressId = Address.Id " +
                                                 "where Address.PlaceId = '{0}'", placeid), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }
            }

            return info;
        }

        public void FindCafeByName(string name)
        {
            string placeid = GetPlaceId(name);
            DetailedInformation info = new DetailedInformation(placeid);
            info.ShowDialog();
        }
    }
}

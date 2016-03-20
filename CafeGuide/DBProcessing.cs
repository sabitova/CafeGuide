using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CafeGuide
{
    public class DBProcessing : IProcessing
    {
        public string ConnectionString = "Data Source = DESKTOP-RE0AOSG; Initial Catalog = CafesDB; Integrated Security = True";

        public void GetSuitableCafes(int time, string type, string cuisine, int avgCheck, bool wifi)
        {
            // building a string

            string query = "select Cafe.Name, Time/60 as [Time], CheckAvg as [Average Check] " +
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
                        //dataGrid_Results.ItemsSource = dt.DefaultView;
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
    }
}

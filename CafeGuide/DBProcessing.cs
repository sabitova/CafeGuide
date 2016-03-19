using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeGuide
{
    public class DBProcessing : IProcessing
    {
        public string ConnectionString = "Data Source = DESKTOP-RE0AOSG; Initial Catalog = CafesDB; Integrated Security = True";

        public List<Cafe> GetSuitableCafes(int time, string type, string cuisine, int avgCheck, bool wi_fi)
        {
            throw new NotImplementedException();
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

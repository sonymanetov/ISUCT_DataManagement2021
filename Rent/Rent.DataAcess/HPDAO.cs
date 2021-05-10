using Rent.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Rent.DataAcess
{
    public class HPDAO : IHPDAO
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConfig"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        private static HP CreateHP(SqlDataReader reader)
        {
            HP hp = new HP();
            hp.finish = reader.GetDateTime(reader.GetOrdinal("FinishDate"));

            return hp;
        }
        public IList<HP> getList(string Name)
        {
            IList<HP> hp = new List<HP>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "[IsActive] @Name";
                    cmd.Parameters.AddWithValue("@Name", Name);

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            hp.Add(CreateHP(dataReader));
                        }
                    }

                }
            }

            return hp;
        }
    }
}

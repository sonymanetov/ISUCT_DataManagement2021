using Rent.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Rent.DataAcess
{
    public class ClientDAO : IClientDAO
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConfig"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        public Client get(int ID)
        {
            throw new NotImplementedException();
        }
        public void add(Client client)
        {
            
        }
        public void update(Client client)
        {
            
        }
        public void delete(int ID)
        {
            
        }

        public IList<Client> getList()
        {
            throw new NotImplementedException();
        }
    }
}

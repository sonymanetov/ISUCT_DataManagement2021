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
        private static Client CreateClient(SqlDataReader reader)
        {
            Client client = new Client();
            client.ClientID = reader.GetInt32(reader.GetOrdinal("ClientID"));
            client.Name = reader.GetString(reader.GetOrdinal("Name"));
            client.BankDetails = reader.GetString(reader.GetOrdinal("BankDetails"));
            client.Adress = reader.GetString(reader.GetOrdinal("Adress"));
            client.Phone = reader.GetString(reader.GetOrdinal("Phone"));
            client.AgentName = reader.GetString(reader.GetOrdinal("AgentName"));

            return client;
        }
        public Client get(int ClientID)
        {
           using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select [ClientID], [Name], [BankDetails],[Adress], [Phone], [AgentName] From [Client] where [ClientID] = @ClientID";
                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateClient(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }
        public void add(Client client)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into [Client] ([Name], [BankDetails],[Adress], [Phone], [AgentName]) values (@Name, @BankDetails, @Adress, @Phone, @AgentName)";

                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@BankDetails", client.BankDetails);
                    cmd.Parameters.AddWithValue("@Adress", client.Adress);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@AgentName", client.AgentName);
                    cmd.ExecuteNonQuery();
                }
            }
                }
                public void update(Client client)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Update [Client] set [Name] = @Name, [BankDetails] = @BankDetails, [Adress] = @Adress, [Phone] = @Phone, [AgentName] = @AgentName where [ClientID]= @ClientID";

                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@BankDetails", client.BankDetails);
                    cmd.Parameters.AddWithValue("@Adress", client.Adress);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@AgentName", client.AgentName);
                    cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void delete(int ClientID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Delete from [Client] where [ClientID]= @ClientID";

                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Client> getList()
        {
            IList<Client> client = new List<Client>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select [ClientID], [Name], [BankDetails],[Adress], [Phone], [AgentName] From [Client]";
          
                    using (var dataReader = cmd.ExecuteReader())
                    {
                     while (dataReader.Read())
                        {
                            client.Add(CreateClient(dataReader));
                        }
                    }

                }
            }

            return client;
        }

        public IList<Client> SearchClient(string Name, string Bank, string Agent)
        {
            IList<Client> clients = new List<Client>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ClientID, Name, BankDetails, Phone, Adress, AgentName FROM Client WHERE Name like @Name AND BankDetails like @Bank AND AgentName like @Agent";
                    cmd.Parameters.AddWithValue("@Name","%"+Name +"%");
                    cmd.Parameters.AddWithValue("@Bank", "%" + Bank + "%");
                    cmd.Parameters.AddWithValue("@Agent", "%" + Agent + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            clients.Add(CreateClient(dataReader));
                        }
                    }
                }
            }
            return clients;
        }

    }
}

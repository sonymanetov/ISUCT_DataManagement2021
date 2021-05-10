using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Rent.DataAcess.Entities;
using System.Data;

namespace Rent.DataAcess
{
    public class AgreementDAO : IAgreementDAO
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConfig"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        private static Agreement CreateAgreement(SqlDataReader reader)
        {
            Agreement agreement = new Agreement();
            agreement.RentID = reader.GetInt32(reader.GetOrdinal("RentID"));
            agreement.ClientID = reader.GetInt32(reader.GetOrdinal("ClientID"));
            agreement.RoomID = reader.GetInt32(reader.GetOrdinal("RoomID"));
            agreement.Start = reader.GetDateTime(reader.GetOrdinal("StartDate"));
            agreement.Finish = reader.GetDateTime(reader.GetOrdinal("FinishDate"));
            agreement.Payday = reader.GetDecimal(reader.GetOrdinal("PaymentDay"));

            return agreement;
        }
        public Agreement Get(int RentID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from [LeaseAgreement] where [RentID] = @RentID";
                    cmd.Parameters.AddWithValue("@RentID", RentID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateAgreement(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }
        public void Add(Agreement agreement)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into [LeaseAgreement] ([ClientID], [RoomID], [StartDate], [FinishDate], [PaymentDay]) values (@ClientID, @RoomID, @Start, @Finish, @Payday)";

                    cmd.Parameters.AddWithValue("@ClientID", agreement.ClientID);
                    cmd.Parameters.AddWithValue("@RoomID", agreement.RoomID);
                    cmd.Parameters.AddWithValue("@Start", agreement.Start);
                    cmd.Parameters.AddWithValue("@Finish", agreement.Finish);
                    cmd.Parameters.AddWithValue("@Payday", agreement.Payday);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Agreement agreement)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Update [LeaseAgreement] set [ClientID] = @ClientID, [RoomID] = @RoomID, [StartDate] = @Start, [FinishDate] = @Finish, [PaymentDay] = @Payday where [RentID] = @RentID";

                    cmd.Parameters.AddWithValue("@ClientID", agreement.ClientID);
                    cmd.Parameters.AddWithValue("@RoomID", agreement.RoomID);
                    cmd.Parameters.AddWithValue("@Start", agreement.Start);
                    cmd.Parameters.AddWithValue("@Finish", agreement.Finish);
                    cmd.Parameters.AddWithValue("@Payday", agreement.Payday);
                    cmd.Parameters.AddWithValue("@RentID", agreement.RentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int RentID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Delete from [LeaseAgreement] where [RentID]= @RentID";

                    cmd.Parameters.AddWithValue("@RentID", RentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Agreement> getList()
        {
            IList<Agreement> agreement = new List<Agreement>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * From [LeaseAgreement]";

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            agreement.Add(CreateAgreement(dataReader));
                        }
                    }

                }
            }

            return agreement;
        }
        }
    }


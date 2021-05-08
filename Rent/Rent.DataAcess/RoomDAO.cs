using Rent.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Rent.DataAcess
{
    public class RoomDAO : IRoomDAO
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConfig"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        private static Room CreateRoom(SqlDataReader reader)
        {
            Room room = new Room();
            room.RoomID = reader.GetInt32(reader.GetOrdinal("RoomID"));
            room.Floor = reader.GetDecimal(reader.GetOrdinal("Floor"));
            room.Area = reader.GetDecimal(reader.GetOrdinal("Area"));
            room.Conditioner = reader.GetBoolean(reader.GetOrdinal("Conditioner"));
            room.RentCostPerDay = reader.GetDecimal(reader.GetOrdinal("RentCostPerDay"));
            
            return room;
        }
        public Room Get(int RoomID)
        {
           using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select [RoomID], [Floor], [Area], [Сonditioner], [RentCostPerDay] From [RentPremise] where [RoomID] = @RoomID";
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateRoom(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }
        public void Add(Room room)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into [RentPremise] ([Floor], [Area], [Сonditioner], [RentCostPerDay]) values (@Floor, @Area, @Сonditioner, @RentCostPerDay)";

                    cmd.Parameters.AddWithValue("@Floor", room.Floor);
                    cmd.Parameters.AddWithValue("@Area", room.Area);
                    cmd.Parameters.AddWithValue("@Сonditioner", room.Conditioner);
                    cmd.Parameters.AddWithValue("@RentCostPerDay", room.RentCostPerDay);
                 
                    cmd.ExecuteNonQuery();
                }
            }
                }
                public void Update(Room room)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Update [RentPremise] set [Floor] = @Floor, [Area] = @Area, [Conditioner] = @Conditioner, [RentCostPerDay] = @RentCostPerDay where [RoomID] = @RoomID";

                    cmd.Parameters.AddWithValue("@Floor", room.Floor);
                    cmd.Parameters.AddWithValue("@Area", room.Area);
                    cmd.Parameters.AddWithValue("@Conditioner", room.Conditioner);
                    cmd.Parameters.AddWithValue("@RentCostPerDay", room.RentCostPerDay);
                    cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int RoomID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Delete from [RentPremise] where [RoomID]= @RoomID";

                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Room> getList()
        {
            IList<Room> room = new List<Room>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select [RoomID], [Floor], [Area], [Conditioner], [RentCostPerDay] From [RentPremise]";
          
                    using (var dataReader = cmd.ExecuteReader())
                    {
                     while (dataReader.Read())
                        {
                            room.Add(CreateRoom(dataReader));
                        }
                    }

                }
            }

            return room;
        }
    }
}

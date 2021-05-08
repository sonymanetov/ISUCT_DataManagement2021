using Rent.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Rent.DataAcess
{
    public class PaymentDAO : IPaymentDAO
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConfig"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        private static Payment CreatePayment(SqlDataReader reader)
        {
            Payment payment = new Payment();
            payment.PayID = reader.GetInt32(reader.GetOrdinal("PaymentID"));
            payment.RentID = reader.GetInt32(reader.GetOrdinal("RentID"));
            payment.Date = reader.GetDateTime(reader.GetOrdinal("PaymentDate"));
            payment.Month = reader.GetInt32(reader.GetOrdinal("PaymentMonth"));
            payment.Sum = reader.GetDecimal(reader.GetOrdinal("PaymentSum"));
            payment.Ontime = reader.GetBoolean(reader.GetOrdinal("OnTime"));

            return payment;
        }
        public Payment Get(int PayID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from [MonthlyPayment] where [PaymentID] = @PayID";
                    cmd.Parameters.AddWithValue("@PayID", PayID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreatePayment(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }
        public void Add(Payment payment)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into [MonthlyPayment] ([RentID], [PaymentDate], [PaymentSum], [PaymentMonth], [OnTime]) values (@RentID, @Date, @Sum, @Month, @Ontime)";

                    cmd.Parameters.AddWithValue("@RentID", payment.RentID);
                    cmd.Parameters.AddWithValue("@Date", payment.Date);
                    cmd.Parameters.AddWithValue("@Sum", payment.Sum);
                    cmd.Parameters.AddWithValue("@Month", payment.Month);
                    cmd.Parameters.AddWithValue("@Ontime", payment.Ontime);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Payment payment)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Update [MonthlyPayment] set [RentID] = @RentID, [PaymentDate] = @Date, [PaymentSum] = @Sum, [PaymentMonth] = @Month, [OnTime] = @Ontime where [PaymentID] = @PayID";

                    cmd.Parameters.AddWithValue("@RentID", payment.RentID);
                    cmd.Parameters.AddWithValue("@Date", payment.Date);
                    cmd.Parameters.AddWithValue("@Sum", payment.Sum);
                    cmd.Parameters.AddWithValue("@Month", payment.Month);
                    cmd.Parameters.AddWithValue("@Ontime", payment.Ontime);
                    cmd.Parameters.AddWithValue("@PayID", payment.PayID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int PayID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Delete from [MonthlyPayment] where [PaymentID]= @PayID";

                    cmd.Parameters.AddWithValue("@PayID", PayID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Payment> getList()
        {
            IList<Payment> payment = new List<Payment>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from [MonthlyPayment]";

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            payment.Add(CreatePayment(dataReader));
                        }
                    }

                }
            }

            return payment;
        }
    }
}

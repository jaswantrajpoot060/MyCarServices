using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class PaymentDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(Payment payment)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Payment_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", payment.Id);
            _ = cmd.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
            _ = cmd.Parameters.AddWithValue("@DopsitFee", payment.DopsitFee);
            _ = cmd.Parameters.AddWithValue("@Remark", payment.Remark);
            _ = cmd.Parameters.AddWithValue("@Status", payment.Status);
            _ = cmd.Parameters.AddWithValue("@Date", payment.Date);
            _ = cmd.Parameters.AddWithValue("@ExtraValue", payment.ExtraValue);
            _ = cmd.Parameters.AddWithValue("@Extra", payment.Extra);
            _ = cmd.Parameters.AddWithValue("@UserId", payment.UserId);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", payment.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", payment.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", payment.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", payment.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }



        public static void Update(Payment payment)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Payment_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", payment.Id);
            _ = cmd.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
            _ = cmd.Parameters.AddWithValue("@DopsitFee", payment.DopsitFee);
            _ = cmd.Parameters.AddWithValue("@Remark", payment.Remark);
            _ = cmd.Parameters.AddWithValue("@Status", payment.Status);
            _ = cmd.Parameters.AddWithValue("@Date", payment.Date);
            _ = cmd.Parameters.AddWithValue("@ExtraValue", payment.ExtraValue);
            _ = cmd.Parameters.AddWithValue("@Extra", payment.Extra);
            _ = cmd.Parameters.AddWithValue("@UserId", payment.UserId);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", payment.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", payment.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", payment.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", payment.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Payment payment)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Payment_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", payment.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<Payment> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Payment_Search"
            };
            _ = cmd.Parameters.AddWithValue("@CowId", word);
            _ = cmd.Parameters.AddWithValue("@Date", word);
            _ = cmd.Parameters.AddWithValue("@Morning", word);
            _ = cmd.Parameters.AddWithValue("@Evening", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Payment> EmailList = new List<Payment>();
            while (reader.Read())
            {
                Payment Obj = new Payment(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<Payment> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Payment_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Payment> EmailList = new List<Payment>();
            while (reader.Read())
            {
                Payment Obj = new Payment(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static DataSet Getdataset()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Usp_Payment_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static Payment GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Payment_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Payment payment = null;
            while (reader.Read())
            {
                payment = new Payment(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return payment;
        }


        public static Payment GetByUserId(Guid UserId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Payment_GetByUserId"
            };
            _ = cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Payment payment = null;
            while (reader.Read())
            {
                payment = new Payment(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return payment;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class FeedBackDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(FeedBack feedback)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_FeedBack_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", feedback.Id);
            _ = cmd.Parameters.AddWithValue("@AnswerId", feedback.AnswerId);
            _ = cmd.Parameters.AddWithValue("@Comment", feedback.Comment);
            _ = cmd.Parameters.AddWithValue("@Name", feedback.Name);
            _ = cmd.Parameters.AddWithValue("@Email", feedback.Email);
            _ = cmd.Parameters.AddWithValue("@Contact", feedback.Contact);
            _ = cmd.Parameters.AddWithValue("@Location", feedback.Location);
            _ = cmd.Parameters.AddWithValue("@Address", feedback.Address);
            _ = cmd.Parameters.AddWithValue("@DateTime", feedback.DateTime);
            _ = cmd.Parameters.AddWithValue("@Extra", feedback.Extra);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", feedback.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", feedback.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", feedback.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", feedback.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(FeedBack feedback)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_FeedBack_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", feedback.Id);
            _ = cmd.Parameters.AddWithValue("@AnswerId", feedback.AnswerId);
            _ = cmd.Parameters.AddWithValue("@Comment", feedback.Comment);
            _ = cmd.Parameters.AddWithValue("@Name", feedback.Name);
            _ = cmd.Parameters.AddWithValue("@Email", feedback.Email);
            _ = cmd.Parameters.AddWithValue("@Contact", feedback.Contact);
            _ = cmd.Parameters.AddWithValue("@Loctaion", feedback.Location);
            _ = cmd.Parameters.AddWithValue("@Address", feedback.Address);
            _ = cmd.Parameters.AddWithValue("@DateTime", feedback.DateTime);
            _ = cmd.Parameters.AddWithValue("@Extra", feedback.Extra);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", feedback.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", feedback.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", feedback.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", feedback.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(FeedBack feedback)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_FeedBack_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", feedback.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<FeedBack> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_FeedBack_Search"
            };
            _ = cmd.Parameters.AddWithValue("@CowId", word);
            _ = cmd.Parameters.AddWithValue("@Date", word);
            _ = cmd.Parameters.AddWithValue("@Morning", word);
            _ = cmd.Parameters.AddWithValue("@Evening", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<FeedBack> EmailList = new List<FeedBack>();
            while (reader.Read())
            {
                FeedBack Obj = new FeedBack(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<FeedBack> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_FeedBack_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<FeedBack> EmailList = new List<FeedBack>();
            while (reader.Read())
            {
                FeedBack Obj = new FeedBack(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_FeedBack_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static FeedBack GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_FeedBack_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            FeedBack feedback = null;
            while (reader.Read())
            {
                feedback = new FeedBack(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return feedback;
        }

    }
}

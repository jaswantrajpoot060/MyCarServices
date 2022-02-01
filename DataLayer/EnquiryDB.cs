using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class EnquiryDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(Enquiry Enquiry)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Enquiry_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", Enquiry.Id);
            _ = cmd.Parameters.AddWithValue("@Name", Enquiry.Name);
            _ = cmd.Parameters.AddWithValue("@Email", Enquiry.Email);
            _ = cmd.Parameters.AddWithValue("@Mobile", Enquiry.Mobile);
            _ = cmd.Parameters.AddWithValue("@Descripation", Enquiry.Descripation);
            _ = cmd.Parameters.AddWithValue("@Locaton", Enquiry.Locaton);
            _ = cmd.Parameters.AddWithValue("@DateTime", Enquiry.DateTime);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(Enquiry Enquiry)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Enquiry_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", Enquiry.Id);
            _ = cmd.Parameters.AddWithValue("@Name", Enquiry.Name);
            _ = cmd.Parameters.AddWithValue("@Email", Enquiry.Email);
            _ = cmd.Parameters.AddWithValue("@Mobile", Enquiry.Mobile);
            _ = cmd.Parameters.AddWithValue("@Descripation", Enquiry.Descripation);
            _ = cmd.Parameters.AddWithValue("@Locaton", Enquiry.Locaton);
            _ = cmd.Parameters.AddWithValue("@DateTime", Enquiry.DateTime);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Enquiry Enquiry)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Enquiry_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Enquiry.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static List<Enquiry> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Enquiry_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Enquiry> CityList = new List<Enquiry>();
            while (reader.Read())
            {
                Enquiry Obj = new Enquiry(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }


        public static List<Enquiry> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Enquiry_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Enquiry> EmailList = new List<Enquiry>();
            while (reader.Read())
            {
                Enquiry Obj = new Enquiry(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_Enquiry_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static Enquiry GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Enquiry_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Enquiry Enquiry = null;
            while (reader.Read())
            {
                Enquiry = new Enquiry(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return Enquiry;
        }
    }
}


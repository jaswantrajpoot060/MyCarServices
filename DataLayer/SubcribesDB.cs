using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class SubcribesDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(Subcribes subcribes)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Subcribes_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", subcribes.Id);
            _ = cmd.Parameters.AddWithValue("@Name", subcribes.Name);
            _ = cmd.Parameters.AddWithValue("@Email", subcribes.Email);
            _ = cmd.Parameters.AddWithValue("@Mobile", subcribes.Mobile);
            _ = cmd.Parameters.AddWithValue("@DateTime", subcribes.DateTime);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(Subcribes subcribes)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Subcribes_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", subcribes.Id);
            _ = cmd.Parameters.AddWithValue("@Name", subcribes.Name);
            _ = cmd.Parameters.AddWithValue("@Email", subcribes.Email);
            _ = cmd.Parameters.AddWithValue("@Mobile", subcribes.Mobile);
            _ = cmd.Parameters.AddWithValue("@DateTime", subcribes.DateTime);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Subcribes subcribes)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Subcribes_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", subcribes.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<Subcribes> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Subcribes_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Subcribes> CityList = new List<Subcribes>();
            while (reader.Read())
            {
                Subcribes Obj = new Subcribes(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }



        public static List<Subcribes> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Subcribes_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Subcribes> EmailList = new List<Subcribes>();
            while (reader.Read())
            {
                Subcribes Obj = new Subcribes(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_Subcribes_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static Subcribes GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Subcribes_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Subcribes subcribes = null;
            while (reader.Read())
            {
                subcribes = new Subcribes(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return subcribes;
        }
    }
}


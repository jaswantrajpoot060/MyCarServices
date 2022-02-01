using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class PImageDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(PImage pimage)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_PImage_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", pimage.Id);
            _ = cmd.Parameters.AddWithValue("@PakageId", pimage.PakageId);
            _ = cmd.Parameters.AddWithValue("@Image", pimage.Image);
            _ = cmd.Parameters.AddWithValue("@Extra", pimage.Extra);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(PImage pimage)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_PImage_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", pimage.Id);
            _ = cmd.Parameters.AddWithValue("@PakageId", pimage.PakageId);
            _ = cmd.Parameters.AddWithValue("@Image", pimage.Image);
            _ = cmd.Parameters.AddWithValue("@Extra", pimage.Extra);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(PImage pimage)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_PImage_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", pimage.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<PImage> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_PImage_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<PImage> CityList = new List<PImage>();
            while (reader.Read())
            {
                PImage Obj = new PImage(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }



        public static List<PImage> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_PImage_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<PImage> EmailList = new List<PImage>();
            while (reader.Read())
            {
                PImage Obj = new PImage(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_PImage_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static PImage GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_PImage_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            PImage pimage = null;
            while (reader.Read())
            {
                pimage = new PImage(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return pimage;
        }


        public static PImage GetByPackageId(Guid PackageId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_PImage_GetByPackageId"
            };
            _ = cmd.Parameters.AddWithValue("@PakageId", PackageId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            PImage pimage = null;
            while (reader.Read())
            {
                pimage = new PImage(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return pimage;
        }


        public static List<PImage> GetByPackageIdlist(Guid PackageId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_PImage_GetByPackageId"
            };
            _ = cmd.Parameters.AddWithValue("@PakageId", PackageId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<PImage> EmailList = new List<PImage>();
            while (reader.Read())
            {
                PImage Obj = new PImage(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }
    }
}


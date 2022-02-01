using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class PackageDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(Package package)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Package_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", package.Id);
            _ = cmd.Parameters.AddWithValue("@Name", package.Name);
            _ = cmd.Parameters.AddWithValue("@Duration", package.Duration);
            _ = cmd.Parameters.AddWithValue("@TraininerName", package.TraininerName);
            _ = cmd.Parameters.AddWithValue("@Price", package.Price);
            _ = cmd.Parameters.AddWithValue("@Discription", package.Discription);
            _ = cmd.Parameters.AddWithValue("@Extra", package.Extra);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(Package package)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Package_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", package.Id);
            _ = cmd.Parameters.AddWithValue("@Name", package.Name);
            _ = cmd.Parameters.AddWithValue("@Duration", package.Duration);
            _ = cmd.Parameters.AddWithValue("@TraininerName", package.TraininerName);
            _ = cmd.Parameters.AddWithValue("@Price", package.Price);
            _ = cmd.Parameters.AddWithValue("@Discription", package.Discription);
            _ = cmd.Parameters.AddWithValue("@Extra", package.Extra);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Package package)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Package_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", package.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<Package> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Package_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Package> CityList = new List<Package>();
            while (reader.Read())
            {
                Package Obj = new Package(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }


        public static List<Package> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Package_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Package> EmailList = new List<Package>();
            while (reader.Read())
            {
                Package Obj = new Package(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_Package_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static Package GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Package_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Package package = null;
            while (reader.Read())
            {
                package = new Package(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return package;
        }
    }
}


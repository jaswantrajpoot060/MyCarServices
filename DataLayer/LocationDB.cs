using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class LocationDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(Location location)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Location_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", location.Id);
            _ = cmd.Parameters.AddWithValue("@RefId", location.RefId);
            _ = cmd.Parameters.AddWithValue("@LoctaionName", location.LoctaionName);
            _ = cmd.Parameters.AddWithValue("@LocationAssign", location.LocationAssign);
            _ = cmd.Parameters.AddWithValue("@LPerson", location.LPerson);
            _ = cmd.Parameters.AddWithValue("@LPContact", location.LPContact);
            _ = cmd.Parameters.AddWithValue("@Extra", location.Extra);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", location.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", location.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", location.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", location.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(Location location)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Location_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@RefId", location.RefId);
            _ = cmd.Parameters.AddWithValue("@LoctaionName", location.LoctaionName);
            _ = cmd.Parameters.AddWithValue("@LocationAssign", location.LocationAssign);
            _ = cmd.Parameters.AddWithValue("@LPerson", location.LPerson);
            _ = cmd.Parameters.AddWithValue("@LPContact", location.LPContact);
            _ = cmd.Parameters.AddWithValue("@Extra", location.Extra);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", location.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", location.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", location.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", location.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Location location)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Location_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", location.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<Location> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Location_Search"
            };
            _ = cmd.Parameters.AddWithValue("@CowId", word);
            _ = cmd.Parameters.AddWithValue("@Date", word);
            _ = cmd.Parameters.AddWithValue("@Morning", word);
            _ = cmd.Parameters.AddWithValue("@Evening", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Location> EmailList = new List<Location>();
            while (reader.Read())
            {
                Location Obj = new Location(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<Location> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Location_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Location> EmailList = new List<Location>();
            while (reader.Read())
            {
                Location Obj = new Location(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_Location_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static Location GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Location_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Location location = null;
            while (reader.Read())
            {
                location = new Location(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return location;
        }

    }
}

using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class CityMasterDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(CityMaster citymaster)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_CityMaster_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", citymaster.Id);
            _ = cmd.Parameters.AddWithValue("@Name", citymaster.Name);
            _ = cmd.Parameters.AddWithValue("@CityCode", citymaster.CityCode);
            _ = cmd.Parameters.AddWithValue("@StateId", citymaster.StateId);
            _ = cmd.Parameters.AddWithValue("@ExtraColumn", citymaster.ExtraColumn);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", citymaster.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", citymaster.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", citymaster.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", citymaster.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Update(CityMaster citymaster)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_CityMaster_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", citymaster.Id);
            _ = cmd.Parameters.AddWithValue("@Name", citymaster.Name);
            _ = cmd.Parameters.AddWithValue("@CityCode", citymaster.CityCode);
            _ = cmd.Parameters.AddWithValue("@StateId", citymaster.StateId);
            _ = cmd.Parameters.AddWithValue("@ExtraColumn", citymaster.ExtraColumn);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", citymaster.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", citymaster.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", citymaster.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", citymaster.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(CityMaster citymaster)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CityMaster_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", citymaster.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<CityMaster> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CityMaster_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CityMaster> CityList = new List<CityMaster>();
            while (reader.Read())
            {
                CityMaster Obj = new CityMaster(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }


        public static List<CityMaster> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CityMaster_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CityMaster> EmailList = new List<CityMaster>();
            while (reader.Read())
            {
                CityMaster Obj = new CityMaster(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_CityMaster_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static CityMaster GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CityMaster_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            CityMaster citymaster = null;
            while (reader.Read())
            {
                citymaster = new CityMaster(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return citymaster;
        }
    }
}


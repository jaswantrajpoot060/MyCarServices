using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class StateMasterDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(StateMaster statemaster)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_StateMaster_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", statemaster.Id);
            _ = cmd.Parameters.AddWithValue("@CountryId", statemaster.CountryId);
            _ = cmd.Parameters.AddWithValue("@Name", statemaster.Name);
            _ = cmd.Parameters.AddWithValue("@ExtraColumn", statemaster.ExtraColumn);
            _ = cmd.Parameters.AddWithValue("@StateCode", statemaster.StateCode);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", statemaster.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", statemaster.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", statemaster.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", statemaster.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(StateMaster statemaster)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_StateMaster_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", statemaster.Id);
            _ = cmd.Parameters.AddWithValue("@CountryId", statemaster.CountryId);
            _ = cmd.Parameters.AddWithValue("@Name", statemaster.Name);
            _ = cmd.Parameters.AddWithValue("@ExtraColumn", statemaster.ExtraColumn);
            _ = cmd.Parameters.AddWithValue("@StateCode", statemaster.StateCode);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", statemaster.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", statemaster.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", statemaster.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", statemaster.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(StateMaster statemaster)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_StateMaster_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", statemaster.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<StateMaster> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_StateMaster_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<StateMaster> StateList = new List<StateMaster>();
            while (reader.Read())
            {
                StateMaster Obj = new StateMaster(reader);
                StateList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return StateList;
        }


        public static List<StateMaster> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_StateMaster_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<StateMaster> EmailList = new List<StateMaster>();
            while (reader.Read())
            {
                StateMaster Obj = new StateMaster(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_StateMaster_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }

        public static StateMaster GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_StateMaster_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            StateMaster statemaster = null;
            while (reader.Read())
            {
                statemaster = new StateMaster(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return statemaster;
        }
    }
}


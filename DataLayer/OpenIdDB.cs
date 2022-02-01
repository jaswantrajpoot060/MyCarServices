using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class OpenIdDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(OpenId openid)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_OpenId_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", openid.Id);
            _ = cmd.Parameters.AddWithValue("@UserId", openid.UserId);
            _ = cmd.Parameters.AddWithValue("@UserName", openid.UserName);
            _ = cmd.Parameters.AddWithValue("@ResponseId", openid.ResponseId);
            _ = cmd.Parameters.AddWithValue("@Provider", openid.Provider);
            _ = cmd.Parameters.AddWithValue("@LoginDate", openid.LoginDate);
            _ = cmd.Parameters.AddWithValue("@IsAuthenticated", openid.IsAuthenticated);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", openid.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", openid.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", openid.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", openid.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(OpenId openid)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_OpenId_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", openid.Id);
            _ = cmd.Parameters.AddWithValue("@UserId", openid.UserId);
            _ = cmd.Parameters.AddWithValue("@UserName", openid.UserName);
            _ = cmd.Parameters.AddWithValue("@ResponseId", openid.ResponseId);
            _ = cmd.Parameters.AddWithValue("@Provider", openid.Provider);
            _ = cmd.Parameters.AddWithValue("@LoginDate", openid.LoginDate);
            _ = cmd.Parameters.AddWithValue("@IsAuthenticated", openid.IsAuthenticated);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", openid.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", openid.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", openid.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", openid.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(OpenId openid)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_OpenId_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", openid.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<OpenId> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_OpenId_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<OpenId> CityList = new List<OpenId>();
            while (reader.Read())
            {
                OpenId Obj = new OpenId(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }


        public static List<OpenId> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_OpenId_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<OpenId> EmailList = new List<OpenId>();
            while (reader.Read())
            {
                OpenId Obj = new OpenId(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_OpenId_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static OpenId GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_OpenId_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            OpenId openid = null;
            while (reader.Read())
            {
                openid = new OpenId(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return openid;
        }

        public static List<OpenId> LoginExist(string Provider, string ResponseId, string UserName, string CreatedBy)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "usp_OpenId_LoginExist"
            };
            _ = cmd.Parameters.AddWithValue("@Provider", Provider);
            _ = cmd.Parameters.AddWithValue("@ResponseId", ResponseId);
            _ = cmd.Parameters.AddWithValue("@UserName", UserName);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<OpenId> EmailList = new List<OpenId>();
            while (reader.Read())
            {
                OpenId Obj = new OpenId(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }

        public static List<OpenId> Login(string ResponseId, string UserName, string CreatedBy)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "usp_OpenId_Login"
            };
            _ = cmd.Parameters.AddWithValue("@ResponseId", ResponseId);
            _ = cmd.Parameters.AddWithValue("@UserName", UserName);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<OpenId> EmailList = new List<OpenId>();
            while (reader.Read())
            {
                OpenId Obj = new OpenId(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }

        public static OpenId GetByResponseId(string ResponseId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "usp_OpenId_GetByResponseId"
            };
            _ = cmd.Parameters.AddWithValue("@ResponseId", ResponseId);
            cmd.Connection = con;
            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            OpenId OpenId = null;
            while (reader.Read())
            {
                OpenId = new OpenId(reader);
            }
            reader.Close();
            cmd.Connection.Close();

            return OpenId;

        }
        public static OpenId GetByUserName(string userName)
        {

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "usp_OpenId_GetByUserName"
            };
            _ = cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Connection = con;
            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            OpenId OpenId = null;
            while (reader.Read())
            {
                OpenId = new OpenId(reader);
            }
            reader.Close();
            cmd.Connection.Close();

            return OpenId;
        }


        public static OpenId GetByUserId(Guid UserId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "usp_OpenId_GetByUserId"
            };
            _ = cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Connection = con;
            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            OpenId OpenId = null;
            while (reader.Read())
            {
                OpenId = new OpenId(reader);
            }
            reader.Close();
            cmd.Connection.Close();

            return OpenId;

        }
    }
}


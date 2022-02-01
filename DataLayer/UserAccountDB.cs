using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class UserAccountDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(UserAccount useraccount)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_UserAccount_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Email", useraccount.Email);
            _ = cmd.Parameters.AddWithValue("@Name", useraccount.Name);
            _ = cmd.Parameters.AddWithValue("@GivenName", useraccount.GivenName);
            _ = cmd.Parameters.AddWithValue("@SurName", useraccount.SurName);
            _ = cmd.Parameters.AddWithValue("@Identifier", useraccount.Identifier);
            _ = cmd.Parameters.AddWithValue("@IsActive", useraccount.IsActive);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", useraccount.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", useraccount.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", useraccount.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", useraccount.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(UserAccount useraccount)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_UserAccount_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Email", useraccount.Email);
            _ = cmd.Parameters.AddWithValue("@Name", useraccount.Name);
            _ = cmd.Parameters.AddWithValue("@GivenName", useraccount.GivenName);
            _ = cmd.Parameters.AddWithValue("@SurName", useraccount.SurName);
            _ = cmd.Parameters.AddWithValue("@Identifier", useraccount.Identifier);
            _ = cmd.Parameters.AddWithValue("@IsActive", useraccount.IsActive);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", useraccount.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", useraccount.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", useraccount.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", useraccount.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(UserAccount useraccount)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", useraccount.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<UserAccount> Login(string Email, string Password)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_Login"
            };
            _ = cmd.Parameters.AddWithValue("@Email", Email);
            _ = cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserAccount> EmailList = new List<UserAccount>();
            while (reader.Read())
            {
                UserAccount Obj = new UserAccount(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<UserAccount> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_Search"
            };
            _ = cmd.Parameters.AddWithValue("@Name", word);
            _ = cmd.Parameters.AddWithValue("@UserName", word);
            _ = cmd.Parameters.AddWithValue("@Role", word);
            _ = cmd.Parameters.AddWithValue("@ContactNo", word);
            _ = cmd.Parameters.AddWithValue("@Email", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserAccount> EmailList = new List<UserAccount>();
            while (reader.Read())
            {
                UserAccount Obj = new UserAccount(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<UserAccount> GetByOtherRole()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_GetByOtherRole",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserAccount> EmailList = new List<UserAccount>();
            while (reader.Read())
            {
                UserAccount Obj = new UserAccount(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<UserAccount> GetByUserRole(string Role)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_GetByUserRole"
            };
            _ = cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserAccount> EmailList = new List<UserAccount>();
            while (reader.Read())
            {
                UserAccount Obj = new UserAccount(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<UserAccount> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserAccount> EmailList = new List<UserAccount>();
            while (reader.Read())
            {
                UserAccount Obj = new UserAccount(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_UserAccount_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }

        public static UserAccount GetById(int Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserAccount useraccount = null;
            while (reader.Read())
            {
                useraccount = new UserAccount(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return useraccount;
        }

        public static UserAccount GetByEmailId(string Email)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_GetByEmailId"
            };
            _ = cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserAccount useraccount = null;
            while (reader.Read())
            {
                useraccount = new UserAccount(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return useraccount;
        }
        public static UserAccount GetByAdminPassword(int Id, string Password)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserAccount_GetByAdminPassword"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            _ = cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserAccount useraccount = null;
            while (reader.Read())
            {
                useraccount = new UserAccount(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return useraccount;
        }
    }
}

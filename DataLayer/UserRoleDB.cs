using System;
using System.Collections.Generic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class UserRoleDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(UserRole userrole)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_userRole_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", userrole.Id);
            _ = cmd.Parameters.AddWithValue("@RoleId", userrole.RoleId);
            _ = cmd.Parameters.AddWithValue("@UserId", userrole.UserId);
            _ = cmd.Parameters.AddWithValue("@Role", userrole.Role);
            _ = cmd.Parameters.AddWithValue("@IsActive", userrole.IsActive);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(UserRole userrole)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_userRole_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", userrole.Id);
            _ = cmd.Parameters.AddWithValue("@RoleId", userrole.RoleId);
            _ = cmd.Parameters.AddWithValue("@UserId", userrole.UserId);
            _ = cmd.Parameters.AddWithValue("@Role", userrole.Role);
            _ = cmd.Parameters.AddWithValue("@IsActive", userrole.IsActive);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(UserRole userrole)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_userRole_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", userrole.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<UserRole> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_userRole_Search"
            };
            _ = cmd.Parameters.AddWithValue("@word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRole> CityList = new List<UserRole>();
            while (reader.Read())
            {
                UserRole Obj = new UserRole(reader);
                CityList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return CityList;
        }



        public static List<UserRole> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_userRole_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRole> EmailList = new List<UserRole>();
            while (reader.Read())
            {
                UserRole Obj = new UserRole(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_userRole_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }



        public static UserRole GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_userRole_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserRole userrole = null;
            while (reader.Read())
            {
                userrole = new UserRole(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return userrole;
        }


        public static UserRole GetByPackageId(Guid PackageId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_userRole_GetByPackageId"
            };
            _ = cmd.Parameters.AddWithValue("@PakageId", PackageId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserRole userrole = null;
            while (reader.Read())
            {
                userrole = new UserRole(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return userrole;
        }


        public static List<UserRole> GetByPackageIdlist(Guid PackageId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_userRole_GetByPackageId"
            };
            _ = cmd.Parameters.AddWithValue("@PakageId", PackageId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRole> EmailList = new List<UserRole>();
            while (reader.Read())
            {
                UserRole Obj = new UserRole(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }
        public static List<UserRole> Usp_UserRole()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserRole",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRole> EmailList = new List<UserRole>();
            while (reader.Read())
            {
                UserRole Obj = new UserRole(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }

    }
}


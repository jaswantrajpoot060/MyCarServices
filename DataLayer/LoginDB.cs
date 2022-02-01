using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class LoginDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(Login login)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Login_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", login.Id);
            _ = cmd.Parameters.AddWithValue("@Name", login.Name);
            _ = cmd.Parameters.AddWithValue("@Password", login.Password);
            _ = cmd.Parameters.AddWithValue("@Location", login.Location);
            _ = cmd.Parameters.AddWithValue("@Role", login.Role);
            _ = cmd.Parameters.AddWithValue("@ContactNo", login.ContactNo);
            _ = cmd.Parameters.AddWithValue("@Email", login.Email);
            _ = cmd.Parameters.AddWithValue("@ExtraColumn", login.ExtraColumn);
            _ = cmd.Parameters.AddWithValue("@Signatue", login.Signatue);
            _ = cmd.Parameters.AddWithValue("@NewExtra", login.NewExtra);
            _ = cmd.Parameters.AddWithValue("@NewExtra2", login.NewExtra2);
            _ = cmd.Parameters.AddWithValue("@Extra1", login.Extra1);
            _ = cmd.Parameters.AddWithValue("@Extra2", login.Extra2);
            _ = cmd.Parameters.AddWithValue("@Extra3", login.Extra3);
            _ = cmd.Parameters.AddWithValue("@Extra4", login.Extra4);
            _ = cmd.Parameters.AddWithValue("@Extra5", login.Extra5);
            _ = cmd.Parameters.AddWithValue("@IsActive", login.IsActive);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", login.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", login.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", login.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", login.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(Login login)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Login_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", login.Id);
            _ = cmd.Parameters.AddWithValue("@Name", login.Name);
            _ = cmd.Parameters.AddWithValue("@Password", login.Password);
            _ = cmd.Parameters.AddWithValue("@Location", login.Location);
            _ = cmd.Parameters.AddWithValue("@Role", login.Role);
            _ = cmd.Parameters.AddWithValue("@ContactNo", login.ContactNo);
            _ = cmd.Parameters.AddWithValue("@Email", login.Email);
            _ = cmd.Parameters.AddWithValue("@ExtraColumn", login.ExtraColumn);
            _ = cmd.Parameters.AddWithValue("@Signatue", login.Signatue);
            _ = cmd.Parameters.AddWithValue("@NewExtra", login.NewExtra);
            _ = cmd.Parameters.AddWithValue("@NewExtra2", login.NewExtra2);
            _ = cmd.Parameters.AddWithValue("@Extra1", login.Extra1);
            _ = cmd.Parameters.AddWithValue("@Extra2", login.Extra2);
            _ = cmd.Parameters.AddWithValue("@Extra3", login.Extra3);
            _ = cmd.Parameters.AddWithValue("@Extra4", login.Extra4);
            _ = cmd.Parameters.AddWithValue("@Extra5", login.Extra5);
            _ = cmd.Parameters.AddWithValue("@IsActive", login.IsActive);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", login.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", login.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", login.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", login.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Login login)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", login.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<Login> GetByRole(string username)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_GetByRole"
            };
            _ = cmd.Parameters.AddWithValue("@Email", username);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> EmailList = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }
        public static List<Login> Login(string Email, string Password)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_Login"
            };
            _ = cmd.Parameters.AddWithValue("@Email", Email);
            _ = cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> EmailList = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<Login> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_Search"
            };
            _ = cmd.Parameters.AddWithValue("@Name", word);
            _ = cmd.Parameters.AddWithValue("@UserName", word);
            _ = cmd.Parameters.AddWithValue("@Role", word);
            _ = cmd.Parameters.AddWithValue("@ContactNo", word);
            _ = cmd.Parameters.AddWithValue("@Email", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> EmailList = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<Login> GetByOtherRole()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_GetByOtherRole",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> EmailList = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }

        //Role
        public static List<Login> Usp_UserRole(string username)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_UserRole"
            };
            _ = cmd.Parameters.AddWithValue("@Email", username);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> EmailList = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<Login> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> EmailList = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_Login_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }

        public static Login GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login login = null;
            while (reader.Read())
            {
                login = new Login(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return login;
        }

        public static Login GetByEmailId(string Email)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_GetByEmailId"
            };
            _ = cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login login = null;
            while (reader.Read())
            {
                login = new Login(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return login;
        }
        public static Login GetByAdminPassword(Guid Id, string Password)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Login_GetByAdminPassword"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            _ = cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login login = null;
            while (reader.Read())
            {
                login = new Login(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return login;
        }
    }
}

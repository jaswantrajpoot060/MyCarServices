using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class ApplyUserDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(ApplyUser applyuser)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_ApplyUser_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", applyuser.Id);
            _ = cmd.Parameters.AddWithValue("@RegistrationNo ", applyuser.RegistrationNo);
            _ = cmd.Parameters.AddWithValue("@PackageId", applyuser.PackageId);
            _ = cmd.Parameters.AddWithValue("@PackageName", applyuser.PackageName);
            _ = cmd.Parameters.AddWithValue("@TrainingTime", applyuser.TrainingTime);
            _ = cmd.Parameters.AddWithValue("@Name", applyuser.Name);
            _ = cmd.Parameters.AddWithValue("@Email", applyuser.Email);
            _ = cmd.Parameters.AddWithValue("@Contact", applyuser.Contact);
            _ = cmd.Parameters.AddWithValue("@Gender", applyuser.Gender);
            _ = cmd.Parameters.AddWithValue("@LicenseNumber", applyuser.LicenseNumber);
            _ = cmd.Parameters.AddWithValue("@LicenseImg", applyuser.LicenseImg);
            _ = cmd.Parameters.AddWithValue("@Dob", applyuser.Dob);
            _ = cmd.Parameters.AddWithValue("@Age", applyuser.Age);
            _ = cmd.Parameters.AddWithValue("@Address", applyuser.Address);
            _ = cmd.Parameters.AddWithValue("@AlternateNo", applyuser.AlternateNo);
            _ = cmd.Parameters.AddWithValue("@Extra", applyuser.Extra);
            _ = cmd.Parameters.AddWithValue("@IsActive", applyuser.IsActive);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", applyuser.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", applyuser.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", applyuser.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", applyuser.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(ApplyUser applyuser)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_ApplyUser_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", applyuser.Id);
            _ = cmd.Parameters.AddWithValue("@RegistrationNo ", applyuser.RegistrationNo);
            _ = cmd.Parameters.AddWithValue("@PackageId", applyuser.PackageId);
            _ = cmd.Parameters.AddWithValue("@PackageName", applyuser.PackageName);
            _ = cmd.Parameters.AddWithValue("@TrainingTime", applyuser.TrainingTime);
            _ = cmd.Parameters.AddWithValue("@Name", applyuser.Name);
            _ = cmd.Parameters.AddWithValue("@Email", applyuser.Email);
            _ = cmd.Parameters.AddWithValue("@Contact", applyuser.Contact);
            _ = cmd.Parameters.AddWithValue("@Gender", applyuser.Gender);
            _ = cmd.Parameters.AddWithValue("@LicenseNumber", applyuser.LicenseNumber);
            _ = cmd.Parameters.AddWithValue("@LicenseImg", applyuser.LicenseImg);
            _ = cmd.Parameters.AddWithValue("@Dob", applyuser.Dob);
            _ = cmd.Parameters.AddWithValue("@Age", applyuser.Age);
            _ = cmd.Parameters.AddWithValue("@Address", applyuser.Address);
            _ = cmd.Parameters.AddWithValue("@AlternateNo", applyuser.AlternateNo);
            _ = cmd.Parameters.AddWithValue("@Extra", applyuser.Extra);
            _ = cmd.Parameters.AddWithValue("@IsActive", applyuser.IsActive);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", applyuser.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", applyuser.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", applyuser.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", applyuser.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(ApplyUser applyuser)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_ApplyUser_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", applyuser.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static List<ApplyUser> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_ApplyUser_Search"
            };
            _ = cmd.Parameters.AddWithValue("@CowId", word);
            _ = cmd.Parameters.AddWithValue("@Date", word);
            _ = cmd.Parameters.AddWithValue("@Morning", word);
            _ = cmd.Parameters.AddWithValue("@Evening", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ApplyUser> EmailList = new List<ApplyUser>();
            while (reader.Read())
            {
                ApplyUser Obj = new ApplyUser(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<ApplyUser> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_ApplyUser_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ApplyUser> EmailList = new List<ApplyUser>();
            while (reader.Read())
            {
                ApplyUser Obj = new ApplyUser(reader)
                {
                    PackageDetails = DBNull.Value != reader["PackageDetails"] ? (string)reader["PackageDetails"] : default
                };
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
            SqlCommand cmd = new SqlCommand("Usp_ApplyUser_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static ApplyUser GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_ApplyUser_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ApplyUser applyuser = null;
            while (reader.Read())
            {
                applyuser = new ApplyUser(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return applyuser;
        }


        public static ApplyUser GetPaymentId(Guid PaymentId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_ApplyUser_GetPaymentId"
            };
            _ = cmd.Parameters.AddWithValue("@PaymentId", PaymentId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ApplyUser applyuser = null;
            while (reader.Read())
            {
                applyuser = new ApplyUser(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return applyuser;
        }


        public static ApplyUser GetPackageId(Guid PackageId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_ApplyUser_GetPackageId"
            };
            _ = cmd.Parameters.AddWithValue("@PackageId", PackageId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ApplyUser applyuser = null;
            while (reader.Read())
            {
                applyuser = new ApplyUser(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return applyuser;
        }
    }
}

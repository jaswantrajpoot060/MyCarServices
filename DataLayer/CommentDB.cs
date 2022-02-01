using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{

    [Obsolete]
    public class CommentDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];


        public static void Add(Comment comment)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Comment_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", comment.Id);
            _ = cmd.Parameters.AddWithValue("@RefId", comment.RefId);
            _ = cmd.Parameters.AddWithValue("@UserId", comment.UserId);
            _ = cmd.Parameters.AddWithValue("@Name", comment.Name);
            _ = cmd.Parameters.AddWithValue("@Description", comment.Description);
            _ = cmd.Parameters.AddWithValue("@Flag", comment.Flag);
            _ = cmd.Parameters.AddWithValue("@Extra1", comment.Extra1);
            _ = cmd.Parameters.AddWithValue("@Extra2", comment.Extra2);
            _ = cmd.Parameters.AddWithValue("@Status", comment.Status);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", comment.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", comment.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", comment.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", comment.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(Comment comment)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Comment_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", comment.Id);
            _ = cmd.Parameters.AddWithValue("@RefId", comment.RefId);
            _ = cmd.Parameters.AddWithValue("@UserId", comment.UserId);
            _ = cmd.Parameters.AddWithValue("@Name", comment.Name);
            _ = cmd.Parameters.AddWithValue("@Description", comment.Description);
            _ = cmd.Parameters.AddWithValue("@Flag", comment.Flag);
            _ = cmd.Parameters.AddWithValue("@Extra1", comment.Extra1);
            _ = cmd.Parameters.AddWithValue("@Extra2", comment.Extra2);
            _ = cmd.Parameters.AddWithValue("@Status", comment.Status);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", comment.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", comment.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", comment.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", comment.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(Comment comment)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Comment_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", comment.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<Comment> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Comment_Search"
            };
            _ = cmd.Parameters.AddWithValue("@CowId", word);
            _ = cmd.Parameters.AddWithValue("@Date", word);
            _ = cmd.Parameters.AddWithValue("@Morning", word);
            _ = cmd.Parameters.AddWithValue("@Evening", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Comment> EmailList = new List<Comment>();
            while (reader.Read())
            {
                Comment Obj = new Comment(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<Comment> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Comment_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Comment> EmailList = new List<Comment>();
            while (reader.Read())
            {
                Comment Obj = new Comment(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_Comment_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static Comment GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Comment_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Comment comment = null;
            while (reader.Read())
            {
                comment = new Comment(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return comment;
        }

        public static List<Comment> GetByRefId(Guid RefId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_Comment_GetByRefId"
            };
            _ = cmd.Parameters.AddWithValue("@RefId", RefId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Comment> EmailList = new List<Comment>();
            while (reader.Read())
            {
                Comment Obj = new Comment(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
    [Obsolete]
    public class CommentReplyDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(CommentReply commentreply)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_CommentReply_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", commentreply.Id);
            _ = cmd.Parameters.AddWithValue("@CommentId", commentreply.CommentId);
            _ = cmd.Parameters.AddWithValue("@RefId", commentreply.RefId);
            _ = cmd.Parameters.AddWithValue("@UserId", commentreply.UserId);
            _ = cmd.Parameters.AddWithValue("@Name", commentreply.Name);
            _ = cmd.Parameters.AddWithValue("@Description", commentreply.Description);
            _ = cmd.Parameters.AddWithValue("@Flag", commentreply.Flag);
            _ = cmd.Parameters.AddWithValue("@Extra1", commentreply.Extra1);
            _ = cmd.Parameters.AddWithValue("@Extra2", commentreply.Extra2);
            _ = cmd.Parameters.AddWithValue("@Status", commentreply.Status);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", commentreply.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", commentreply.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", commentreply.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", commentreply.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Update(CommentReply commentreply)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_CommentReply_Update", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@Id", commentreply.Id);
            _ = cmd.Parameters.AddWithValue("@CommentId", commentreply.CommentId);
            _ = cmd.Parameters.AddWithValue("@RefId", commentreply.RefId);
            _ = cmd.Parameters.AddWithValue("@UserId", commentreply.UserId);
            _ = cmd.Parameters.AddWithValue("@Name", commentreply.Name);
            _ = cmd.Parameters.AddWithValue("@Description", commentreply.Description);
            _ = cmd.Parameters.AddWithValue("@Flag", commentreply.Flag);
            _ = cmd.Parameters.AddWithValue("@Extra1", commentreply.Extra1);
            _ = cmd.Parameters.AddWithValue("@Extra2", commentreply.Extra2);
            _ = cmd.Parameters.AddWithValue("@Status", commentreply.Status);
            _ = cmd.Parameters.AddWithValue("@CreatedBy", commentreply.CreatedBy);
            _ = cmd.Parameters.AddWithValue("@CreatedOn", commentreply.CreatedOn);
            _ = cmd.Parameters.AddWithValue("@UpdatedBy", commentreply.UpdatedBy);
            _ = cmd.Parameters.AddWithValue("@UpdatedOn", commentreply.UpdatedOn);
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void Delete(CommentReply commentreply)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CommentReply_Delete"
            };
            _ = cmd.Parameters.AddWithValue("@Id", commentreply.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            _ = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public static List<CommentReply> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CommentReply_Search"
            };
            _ = cmd.Parameters.AddWithValue("@CowId", word);
            _ = cmd.Parameters.AddWithValue("@Date", word);
            _ = cmd.Parameters.AddWithValue("@Morning", word);
            _ = cmd.Parameters.AddWithValue("@Evening", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CommentReply> EmailList = new List<CommentReply>();
            while (reader.Read())
            {
                CommentReply Obj = new CommentReply(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


        public static List<CommentReply> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CommentReply_GetAll",
                Connection = con
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CommentReply> EmailList = new List<CommentReply>();
            while (reader.Read())
            {
                CommentReply Obj = new CommentReply(reader);
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
            SqlCommand cmd = new SqlCommand("Usp_CommentReply_GetAll", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            _ = sda.Fill(ds);
            return ds;
        }


        public static CommentReply GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CommentReply_GetById"
            };
            _ = cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            CommentReply commentreply = null;
            while (reader.Read())
            {
                commentreply = new CommentReply(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return commentreply;
        }

        public static List<CommentReply> GetByRefId(Guid RefId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Usp_CommentReply_GetByRefId"
            };
            _ = cmd.Parameters.AddWithValue("@RefId", RefId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CommentReply> EmailList = new List<CommentReply>();
            while (reader.Read())
            {
                CommentReply Obj = new CommentReply(reader);
                EmailList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return EmailList;
        }


    }
}

using System;
using System.Data;

namespace BusinessObject
{
    public class CommentReply : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public Guid CommentId { get; set; }

        public Guid RefId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Flag { get; set; }

        public string Extra1 { get; set; }

        public string Extra2 { get; set; }

        public string Status { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public CommentReply()
            : base()
        {
        }
        public CommentReply(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            CommentId = DBNull.Value != reader["CommentId"] ? (Guid)reader["CommentId"] : default;
            RefId = DBNull.Value != reader["RefId"] ? (Guid)reader["RefId"] : default;
            UserId = DBNull.Value != reader["UserId"] ? (Guid)reader["UserId"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Description = DBNull.Value != reader["Description"] ? (string)reader["Description"] : default;
            Flag = DBNull.Value != reader["Flag"] ? (string)reader["Flag"] : default;
            Extra1 = DBNull.Value != reader["Extra1"] ? (string)reader["Extra1"] : default;
            Extra2 = DBNull.Value != reader["Extra2"] ? (string)reader["Extra2"] : default;
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}

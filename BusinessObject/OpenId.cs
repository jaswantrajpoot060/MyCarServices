using System;
using System.Data;

namespace BusinessObject
{
    public class OpenId : BaseObject
    {
        #region Properties

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string ResponseId { get; set; }

        public string Provider { get; set; }

        public bool IsAuthenticated { get; set; }

        public DateTime LoginDate { get; set; }



        #endregion


        #region Method
        public OpenId()
            : base()
        {
        }

        public OpenId(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            UserId = DBNull.Value != reader["UserId"] ? (Guid)reader["UserId"] : default;
            UserName = DBNull.Value != reader["UserName"] ? (string)reader["UserName"] : default;
            ResponseId = DBNull.Value != reader["ResponseId"] ? (string)reader["ResponseId"] : default;
            Provider = DBNull.Value != reader["Provider"] ? (string)reader["Provider"] : default;
            LoginDate = DBNull.Value != reader["LoginDate"] ? (DateTime)reader["LoginDate"] : default;
            IsAuthenticated = DBNull.Value != reader["IsAuthenticated"] && (bool)reader["IsAuthenticated"];
        }
        #endregion
    }
}

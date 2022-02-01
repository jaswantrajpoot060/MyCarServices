using System;
using System.Data;

namespace BusinessObject
{
    public class UserAccount : BaseObject
    {
        #region Property

        public int Id { get; set; }

        public string Email { get; set; }

        public string GivenName { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Identifier { get; set; }

        public bool IsActive { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public UserAccount()
            : base()
        {
        }
        public UserAccount(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (int)reader["Id"] : default;
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default;
            GivenName = DBNull.Value != reader["GivenName"] ? (string)reader["GivenName"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            SurName = DBNull.Value != reader["SurName"] ? (string)reader["SurName"] : default;
            Identifier = DBNull.Value != reader["Identifier"] ? (string)reader["Identifier"] : default;
            IsActive = DBNull.Value != reader["IsActive"] && (bool)reader["IsActive"];
        }
        #endregion
    }
}

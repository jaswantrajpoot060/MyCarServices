using System;
using System.Data;

namespace BusinessObject
{
    public class Login : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Location { get; set; }

        public string Role { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public string ExtraColumn { get; set; }

        public string Signatue { get; set; }

        public string NewExtra { get; set; }

        public string NewExtra2 { get; set; }

        public string Extra1 { get; set; }

        public string Extra2 { get; set; }

        public string Extra3 { get; set; }

        public string Extra4 { get; set; }

        public string Extra5 { get; set; }
        public bool IsActive { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public Login()
            : base()
        {
        }
        public Login(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Password = DBNull.Value != reader["Password"] ? (string)reader["Password"] : default;
            Location = DBNull.Value != reader["Location"] ? (string)reader["Location"] : default;
            Role = DBNull.Value != reader["Role"] ? (string)reader["Role"] : default;
            ContactNo = DBNull.Value != reader["ContactNo"] ? (string)reader["ContactNo"] : default;
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default;
            ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default;
            Signatue = DBNull.Value != reader["Signatue"] ? (string)reader["Signatue"] : default;
            NewExtra = DBNull.Value != reader["NewExtra"] ? (string)reader["NewExtra"] : default;
            NewExtra2 = DBNull.Value != reader["NewExtra2"] ? (string)reader["NewExtra2"] : default;
            Extra1 = DBNull.Value != reader["Extra1"] ? (string)reader["Extra1"] : default;
            Extra2 = DBNull.Value != reader["Extra2"] ? (string)reader["Extra2"] : default;
            Extra3 = DBNull.Value != reader["Extra3"] ? (string)reader["Extra3"] : default;
            Extra4 = DBNull.Value != reader["Extra4"] ? (string)reader["Extra4"] : default;
            Extra5 = DBNull.Value != reader["Extra5"] ? (string)reader["Extra5"] : default;
            IsActive = DBNull.Value != reader["IsActive"] && (bool)reader["IsActive"];
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}

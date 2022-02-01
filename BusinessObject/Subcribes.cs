using System;
using System.Data;

namespace BusinessObject
{
    public class Subcribes : BaseObject1
    {
        #region Property

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public DateTime DateTime { get; set; }

        public int Code { get; set; }

        #endregion


        #region OtherProperty

        #endregion

        #region Method
        public Subcribes()
           : base()
        {
        }


        public Subcribes(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default;
            Mobile = DBNull.Value != reader["Mobile"] ? (string)reader["Mobile"] : default;
            DateTime = DBNull.Value != reader["DateTime"] ? (DateTime)reader["DateTime"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;

        }
        #endregion
    }
}

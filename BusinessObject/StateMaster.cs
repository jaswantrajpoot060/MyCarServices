using System;
using System.Data;

namespace BusinessObject
{
    public class StateMaster : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public Guid CountryId { get; set; }

        public string Name { get; set; }

        public string ExtraColumn { get; set; }

        public string StateCode { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public StateMaster()
            : base()
        {
        }

        public StateMaster(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            CountryId = DBNull.Value != reader["CountryId"] ? (Guid)reader["CountryId"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            StateCode = DBNull.Value != reader["StateCode"] ? (string)reader["StateCode"] : default;
            ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}


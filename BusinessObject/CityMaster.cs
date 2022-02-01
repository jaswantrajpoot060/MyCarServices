using System;
using System.Data;

namespace BusinessObject
{
    public class CityMaster : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public Guid StateId { get; set; }

        public string Name { get; set; }

        public string CityCode { get; set; }

        public string ExtraColumn { get; set; }

        public int Code { get; set; }

        #endregion


        #region OtherProperty

        public Guid CountryId { get; set; }

        public string CountryName { get; set; }

        #endregion

        #region Method
        public CityMaster()
           : base()
        {
        }


        public CityMaster(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            StateId = DBNull.Value != reader["StateId"] ? (Guid)reader["StateId"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            CityCode = DBNull.Value != reader["CityCode"] ? (string)reader["CityCode"] : default;
            ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;

        }
        #endregion
    }
}

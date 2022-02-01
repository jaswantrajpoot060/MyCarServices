using System;
using System.Data;

namespace BusinessObject
{
    public class Location : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public Guid RefId { get; set; }

        public string LoctaionName { get; set; }

        public string LocationAssign { get; set; }

        public string LPerson { get; set; }

        public string LPContact { get; set; }

        public string Extra { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public Location()
            : base()
        {
        }

        public Location(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            RefId = DBNull.Value != reader["RefId"] ? (Guid)reader["RefId"] : default;
            LoctaionName = DBNull.Value != reader["LoctaionName"] ? (string)reader["LoctaionName"] : default;
            LocationAssign = DBNull.Value != reader["LocationAssign"] ? (string)reader["LocationAssign"] : default;
            LPerson = DBNull.Value != reader["LPerson"] ? (string)reader["LPerson"] : default;
            LPContact = DBNull.Value != reader["LPContact"] ? (string)reader["LPContact"] : default;
            Extra = DBNull.Value != reader["Extra"] ? (string)reader["Extra"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}

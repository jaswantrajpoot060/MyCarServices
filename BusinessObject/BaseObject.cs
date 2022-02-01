using System;
using System.Data;
namespace BusinessObject
{
    public abstract class BaseObject
    {
        public string InfoMessage { get; set; }
        public string AlertMessage { get; set; }

        #region Properties
        //[DataMember]
        public string CreatedBy { get; set; }
        //[DataMember]
        public DateTime CreatedOn { get; set; }
        //[DataMember]
        public string UpdatedBy { get; set; }
        //[DataMember]
        public DateTime UpdatedOn { get; set; }
        #endregion

        public BaseObject()
        {
            //Id = Guid.Empty;
        }

        public BaseObject(string createdBy, DateTime createdOn, string updatedBy, DateTime updatedOn)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
        }


        public BaseObject(IDataReader reader)
        {
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default;
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default;
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default;
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default;

        }

        public BaseObject(DataRow row)
        {
            CreatedBy = DBNull.Value != row["CreatedBy"] ? (string)row["CreatedBy"] : default;
            CreatedOn = DBNull.Value != row["CreatedOn"] ? (DateTime)row["CreatedOn"] : default;
            UpdatedBy = DBNull.Value != row["UpdatedBy"] ? (string)row["UpdatedBy"] : default;
            UpdatedOn = DBNull.Value != row["UpdatedOn"] ? (DateTime)row["UpdatedOn"] : default;

        }

        public BaseObject(BaseObject obj)
        {
            CreatedBy = obj.CreatedBy;
            CreatedOn = obj.CreatedOn;
            UpdatedBy = obj.UpdatedBy;
            UpdatedOn = obj.UpdatedOn;
        }
    }
}

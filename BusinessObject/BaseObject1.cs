using System;
using System.Data;

namespace BusinessObject
{
    public abstract class BaseObject1
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

        public BaseObject1()
        {
            //Id = Guid.Empty;
        }

        public BaseObject1(string createdBy, DateTime createdOn, string updatedBy, DateTime updatedOn)
        {
            //Id = id;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
        }


        //public BaseObject1(IDataReader reader)
        //{
        //    //Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
        //    //CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default;
        //    //CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default;
        //    //UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default;
        //    //UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default;
        //}

        public BaseObject1(DataRow row)
        {
            CreatedBy = DBNull.Value != row["CreatedBy"] ? (string)row["CreatedBy"] : default;
            CreatedOn = DBNull.Value != row["CreatedOn"] ? (DateTime)row["CreatedOn"] : default;
            UpdatedBy = DBNull.Value != row["UpdatedBy"] ? (string)row["UpdatedBy"] : default;
            UpdatedOn = DBNull.Value != row["UpdatedOn"] ? (DateTime)row["UpdatedOn"] : default;

        }

        public BaseObject1(BaseObject1 obj)
        {
            CreatedBy = obj.CreatedBy;
            CreatedOn = obj.CreatedOn;
            UpdatedBy = obj.UpdatedBy;
            UpdatedOn = obj.UpdatedOn;
        }
    }
}

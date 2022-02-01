using System;
using System.Data;

namespace BusinessObject
{
    public class PImage : BaseObject1
    {
        #region Property

        public Guid Id { get; set; }

        public Guid PakageId { get; set; }

        public string Image { get; set; }

        public string Extra { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public PImage()
            : base()
        {
        }


        public PImage(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            PakageId = DBNull.Value != reader["PakageId"] ? (Guid)reader["PakageId"] : default;
            Image = DBNull.Value != reader["Image"] ? (string)reader["Image"] : default;
            Extra = DBNull.Value != reader["Extra"] ? (string)reader["Extra"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}

using System;
using System.Data;

namespace BusinessObject
{
    public class Package : BaseObject1
    {
        #region Property

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Duration { get; set; }

        public string TraininerName { get; set; }

        public decimal Price { get; set; }

        public string Discription { get; set; }

        public string Extra { get; set; }

        public int Code { get; set; }

        #endregion


        #region OtherProperty

        #endregion

        #region Method
        public Package()
           : base()
        {
        }


        public Package(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Duration = DBNull.Value != reader["Duration"] ? (string)reader["Duration"] : default;
            TraininerName = DBNull.Value != reader["TraininerName"] ? (string)reader["TraininerName"] : default;
            Price = DBNull.Value != reader["Price"] ? (decimal)reader["Price"] : default;
            Discription = DBNull.Value != reader["Discription"] ? (string)reader["Discription"] : default;
            Extra = DBNull.Value != reader["Extra"] ? (string)reader["Extra"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;

        }
        #endregion
    }
}

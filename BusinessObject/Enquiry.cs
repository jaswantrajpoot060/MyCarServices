using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Enquiry : BaseObject1
    {
        #region Property

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Fill Your Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Fill Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Fill Your Mobile")]
        public string Mobile { get; set; }

        public string Descripation { get; set; }

        [Required(ErrorMessage = "Please Fill Your Location")]
        public string Locaton { get; set; }

        public DateTime DateTime { get; set; }

        public int Code { get; set; }

        #endregion


        #region OtherProperty

        #endregion

        #region Method
        public Enquiry()
           : base()
        {
        }

        public Enquiry(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default;
            Mobile = DBNull.Value != reader["Mobile"] ? (string)reader["Mobile"] : default;
            Descripation = DBNull.Value != reader["Descripation"] ? (string)reader["Descripation"] : default;
            Locaton = DBNull.Value != reader["Locaton"] ? (string)reader["Locaton"] : default;
            DateTime = DBNull.Value != reader["DateTime"] ? (DateTime)reader["DateTime"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;

        }
        #endregion
    }
}

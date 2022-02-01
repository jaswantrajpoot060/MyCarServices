using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class FeedBack : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public int AnswerId { get; set; }

        public string Comment { get; set; }

        [Required(ErrorMessage = "Please Fill Your Full Name")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Fill Your Contact Number")]
        [Phone]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Fill Your Location")]
        public string Location { get; set; }

        public string Address { get; set; }

        public string DateTime { get; set; }

        public string Extra { get; set; }

        public int Code { get; set; }

        [Required(ErrorMessage = "Please select your rating")]
        public int Select { get; set; }

        public List<Answer> Answers { get; set; }

        #endregion


        #region Method
        public FeedBack()
            : base()
        {
        }
        public FeedBack(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            AnswerId = DBNull.Value != reader["AnswerId"] ? (int)reader["AnswerId"] : default;
            Comment = DBNull.Value != reader["Comment"] ? (string)reader["Comment"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default;
            Contact = DBNull.Value != reader["Contact"] ? (string)reader["Contact"] : default;
            Location = DBNull.Value != reader["Location"] ? (string)reader["Location"] : default;
            Address = DBNull.Value != reader["Address"] ? (string)reader["Address"] : default;
            DateTime = DBNull.Value != reader["DateTime"] ? (string)reader["DateTime"] : default;
            Extra = DBNull.Value != reader["Extra"] ? (string)reader["Extra"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}

using System;
using System.Data;

namespace BusinessObject
{
    public class ApplyUserView : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public string RegistrationNo { get; set; }

        public Guid PackageId { get; set; }

        public string PackageName { get; set; }

        public string TrainingTime { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public string Gender { get; set; }

        public string LicenseNumber { get; set; }

        public string LicenseImg { get; set; }

        public string Dob { get; set; }

        public string Age { get; set; }

        public string Address { get; set; }

        public string AlternateNo { get; set; }

        public bool IsActive { get; set; }

        public string Extra { get; set; }

        public int Code { get; set; }

        #endregion
        public string PackageDetails { get; set; }

        #region Method
        public ApplyUserView()
            : base()
        {
        }

        public ApplyUserView(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            RegistrationNo = DBNull.Value != reader["RegistrationNo"] ? (string)reader["RegistrationNo"] : default;
            PackageId = DBNull.Value != reader["PackageId"] ? (Guid)reader["PackageId"] : default;
            PackageName = DBNull.Value != reader["PackageName"] ? (string)reader["PackageName"] : default;
            TrainingTime = DBNull.Value != reader["TrainingTime"] ? (string)reader["TrainingTime"] : default;
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default;
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default;
            Contact = DBNull.Value != reader["Contact"] ? (string)reader["Contact"] : default;
            Gender = DBNull.Value != reader["Gender"] ? (string)reader["Gender"] : default;
            LicenseNumber = DBNull.Value != reader["LicenseNumber"] ? (string)reader["LicenseNumber"] : default;
            LicenseImg = DBNull.Value != reader["LicenseImg"] ? (string)reader["LicenseImg"] : default;
            Dob = DBNull.Value != reader["Dob"] ? (string)reader["Dob"] : default;
            Age = DBNull.Value != reader["Age"] ? (string)reader["Age"] : default;
            Address = DBNull.Value != reader["Address"] ? (string)reader["Address"] : default;
            AlternateNo = DBNull.Value != reader["AlternateNo"] ? (string)reader["AlternateNo"] : default;
            Extra = DBNull.Value != reader["Extra"] ? (string)reader["Extra"] : default;
            IsActive = DBNull.Value != reader["IsActive"] && (bool)reader["IsActive"];
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}

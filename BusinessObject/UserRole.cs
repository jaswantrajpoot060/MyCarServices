using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserRole
    {
        #region Property

        public Guid Id { get; set; }

        public string RoleId { get; set; }

        public Guid UserId { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        #endregion


        #region Method
        public UserRole()
            : base()
        {
        }


        public UserRole(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            RoleId = DBNull.Value != reader["RoleId"] ? (string)reader["RoleId"] : default;
            UserId = DBNull.Value != reader["UserId"] ? (Guid)reader["UserId"] : default;
            Role = DBNull.Value != reader["Role"] ? (string)reader["Role"] : default;
            IsActive = DBNull.Value != reader["IsActive"] ? (bool)reader["IsActive"] : default;
        }
        #endregion
    }
}


namespace MyCarService.Models
{
    using BusinessObject;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class DrivingSchool_DBEntities : DbContext
    {
        public DrivingSchool_DBEntities()
            : base("name=DrivingSchool_DBEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}

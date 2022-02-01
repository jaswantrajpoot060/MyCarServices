using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;
using System.Data;

namespace BusinessManager
{
    [Obsolete]
    public class UserRoleManager
    {
        public static void Add(UserRole userrole)
        {
            if (userrole == null)
            {
                throw new ArgumentException("userrole is null.");
            }

            UserRoleDB.Add(userrole);
        }

        public static void Update(UserRole userrole)
        {
            if (userrole == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (userrole.Id == null || userrole.Id == default)
            {
                throw new ArgumentException("userrole.Id value not set.");
            }

            UserRoleDB.Update(userrole);
        }

        public static void Delete(UserRole userrole)
        {
            if (userrole == null)
            {
                throw new ArgumentException("userrole is null.");
            }

            if (userrole.Id == null || userrole.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            UserRoleDB.Delete(userrole);
        }


        public static UserRole GetById(Guid id)
        {
            UserRole userrole = UserRoleDB.GetById(id);
            return userrole;
        }

        public static UserRole GetByPackageId(Guid PackageId)
        {
            UserRole userrole = UserRoleDB.GetByPackageId(PackageId);
            return userrole;
        }
        public static List<UserRole> GetAll()
        {
            return UserRoleDB.GetAll();
        }

        public static DataSet Getdataset()
        {
            return UserRoleDB.Getdataset();
        }
        public static List<UserRole> Usp_UserRole()
        {
            return UserRoleDB.Usp_UserRole();
        }
        public static List<UserRole> GetByPackageIdlist(Guid PackageId)
        {
            return UserRoleDB.GetByPackageIdlist(PackageId);
        }
        public static List<UserRole> Search(string word)
        {
            return UserRoleDB.Search(word);
        }

    }
}
using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class UserAccountManager
    {
        public static void Add(UserAccount useraccount)
        {
            if (useraccount == null)
            {
                throw new ArgumentException("useraccount is null.");
            }

            UserAccountDB.Add(useraccount);
        }

        public static void Update(UserAccount useraccount)
        {
            if (useraccount == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (useraccount.Id == default)
            {
                throw new ArgumentException("useraccount.Id value not set.");
            }

            UserAccountDB.Update(useraccount);
        }

        public static void Delete(UserAccount useraccount)
        {
            if (useraccount == null)
            {
                throw new ArgumentException("useraccount is null.");
            }

            if (useraccount.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            UserAccountDB.Delete(useraccount);
        }

        public static UserAccount GetById(int id)
        {
            UserAccount useraccount = UserAccountDB.GetById(id);
            return useraccount;
        }
        public static UserAccount GetByAdminPassword(int Id, string Password)
        {
            UserAccount useraccount = UserAccountDB.GetByAdminPassword(Id, Password);
            return useraccount;
        }
        public static UserAccount GetByEmailId(string Email)
        {
            return UserAccountDB.GetByEmailId(Email);
        }
        public static List<UserAccount> GetAll()
        {
            return UserAccountDB.GetAll();
        }

        public static List<UserAccount> GetByUserRole(string Role)
        {
            return UserAccountDB.GetByUserRole(Role);
        }

        public static List<UserAccount> GetByOtherRole()
        {
            return UserAccountDB.GetByOtherRole();
        }

        public static System.Data.DataSet Getdataset()
        {
            return UserAccountDB.Getdataset();
        }

        public static List<UserAccount> Search(string word)
        {
            return UserAccountDB.Search(word);
        }

        public static List<UserAccount> Login(string Email, string Password)
        {
            return UserAccountDB.Login(Email, Password);
        }
    }
}
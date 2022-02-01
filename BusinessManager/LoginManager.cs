using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class LoginManager
    {
        public static void Add(Login login)
        {
            if (login == null)
            {
                throw new ArgumentException("login is null.");
            }

            LoginDB.Add(login);
        }

        public static void Update(Login login)
        {
            if (login == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (login.Id == null || login.Id == default)
            {
                throw new ArgumentException("login.Id value not set.");
            }

            LoginDB.Update(login);
        }

        public static void Delete(Login login)
        {
            if (login == null)
            {
                throw new ArgumentException("login is null.");
            }

            if (login.Id == null || login.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            LoginDB.Delete(login);
        }

        public static Login GetById(Guid id)
        {
            Login login = LoginDB.GetById(id);
            return login;
        }

        public static Login GetByAdminPassword(Guid Id, string Password)
        {
            Login login = LoginDB.GetByAdminPassword(Id, Password);
            return login;
        }

        public static Login GetByEmailId(string Email)
        {
            return LoginDB.GetByEmailId(Email);
        }

        public static List<Login> GetAll()
        {
            return LoginDB.GetAll();
        }

        public static List<Login> GetByRole(string username)
        {
            return LoginDB.GetByRole(username);
        }

        public static List<Login> Usp_UserRole(string username)
        {
            return LoginDB.Usp_UserRole(username);
        }

        public static List<Login> GetByOtherRole()
        {
            return LoginDB.GetByOtherRole();
        }

        public static System.Data.DataSet Getdataset()
        {
            return LoginDB.Getdataset();
        }

        public static List<Login> Search(string word)
        {
            return LoginDB.Search(word);
        }

        public static List<Login> Login(string Email, string Password)
        {
            return LoginDB.Login(Email, Password);
        }
    }
}
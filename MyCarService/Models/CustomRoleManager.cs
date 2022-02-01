using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BusinessManager;
using BusinessObject;

namespace MyCarService.Models
{
    [Obsolete]
    public class CustomRoleManager : RoleProvider
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        SqlConnection con = new SqlConnection(connection);
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //string[] reader = null;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_UserRole", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string UserRole = "";
            if (dt.Rows.Count > 0)
                UserRole = dt.Rows[0]["Role"].ToString();
            string[] resultS =  UserRole.Split(',') ;
            return resultS;

            //using (DrivingSchool_DBEntities dbContext = new DrivingSchool_DBEntities())
            //{               

            //    //var result = (from user in dbContext.Logins
            //    //              join role in dbContext.UserRoles on user.Id equals role.UserId
            //    //              where user.Email == username
            //    //              select role.Role).ToArray();

            //    //return result;

            //    //string pro = "google";
            //    //dbContext.OpenIds.Select(x => x.Provider == pro);
            //    //if (pro == null)
            //    //{
            //    //    var result1 = (from user in dbContext.OpenIds
            //    //                   join role in dbContext.UserRoles on user.Id equals role.UserId
            //    //                   where user.CreatedBy == username
            //    //                   select role.Role).ToArray();

            //    //    return result1;
            //    //}
            //}
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
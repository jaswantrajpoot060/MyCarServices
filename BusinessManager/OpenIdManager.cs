using System;
using System.Collections.Generic;
using System.Data;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    [Obsolete]
    public class OpenIdManager
    {
        public static void Add(OpenId openid)
        {
            if (openid == null)
            {
                throw new ArgumentException("openid is null.");
            }

            OpenIdDB.Add(openid);
        }

        public static void Update(OpenId openid)
        {
            if (openid == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (openid.Id == null || openid.Id == default)
            {
                throw new ArgumentException("openid.Id value not set.");
            }

            OpenIdDB.Update(openid);
        }

        public static void Delete(OpenId openid)
        {
            if (openid == null)
            {
                throw new ArgumentException("openid is null.");
            }

            if (openid.Id == null || openid.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            OpenIdDB.Delete(openid);
        }
        public static OpenId GetByResponseId(string ResponseId)
        {
            OpenId OpenId = OpenIdDB.GetByResponseId(ResponseId);
            return OpenId;

        }

        public static OpenId GetById(Guid id)
        {
            OpenId openid = OpenIdDB.GetById(id);
            return openid;
        }

        public static List<OpenId> GetAll()
        {
            return OpenIdDB.GetAll();
        }

        public static DataSet Getdataset()
        {
            return OpenIdDB.Getdataset();
        }

        public static List<OpenId> Search(string word)
        {
            return OpenIdDB.Search(word);
        }

        public static OpenId GetByUserId(Guid userId)
        {
            OpenId OpenId = OpenIdDB.GetByUserId(userId);
            return OpenId;

        }

        public static OpenId GetByUserName(string userName)
        {
            OpenId OpenId = OpenIdDB.GetByResponseId(userName);
            return OpenId;

        }

        public static List<OpenId> Login(string ResponseId, string UserName, string CreatedBy)
        {
            return OpenIdDB.Login(ResponseId, UserName, CreatedBy);
        }

        public static List<OpenId> LoginExist(string Provider, string ResponseId, string UserName, string CreatedBy)
        {
            return OpenIdDB.LoginExist(Provider, ResponseId, UserName, CreatedBy);
        }
    }
}



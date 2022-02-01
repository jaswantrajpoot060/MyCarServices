using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class ApplyUserManager
    {
        public static void Add(ApplyUser applyuser)
        {
            if (applyuser == null)
            {
                throw new ArgumentException("applyuser is null.");
            }

            ApplyUserDB.Add(applyuser);
        }

        public static void Update(ApplyUser applyuser)
        {
            if (applyuser == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (applyuser.Id == null || applyuser.Id == default)
            {
                throw new ArgumentException("applyuser.Id value not set.");
            }

            ApplyUserDB.Update(applyuser);
        }

        public static void Delete(ApplyUser applyuser)
        {
            if (applyuser == null)
            {
                throw new ArgumentException("applyuser is null.");
            }

            if (applyuser.Id == null || applyuser.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            ApplyUserDB.Delete(applyuser);
        }

        public static ApplyUser GetById(Guid id)
        {
            ApplyUser applyuser = ApplyUserDB.GetById(id);
            return applyuser;
        }

        public static ApplyUser GetPaymentId(Guid PaymentId)
        {
            ApplyUser applyuser = ApplyUserDB.GetPaymentId(PaymentId);
            return applyuser;
        }

        public static ApplyUser GetPackageId(Guid PackageId)
        {
            ApplyUser applyuser = ApplyUserDB.GetPackageId(PackageId);
            return applyuser;
        }

        public static List<ApplyUser> GetAll()
        {
            return ApplyUserDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return ApplyUserDB.Getdataset();
        }

        public static List<ApplyUser> Search(string word)
        {
            return ApplyUserDB.Search(word);
        }

    }
}
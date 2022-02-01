using System;
using System.Collections.Generic;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    [Obsolete]
    public class EnquiryManager
    {
        public static void Add(Enquiry Enquiry)
        {
            if (Enquiry == null)
            {
                throw new ArgumentException("Enquiry is null.");
            }

            EnquiryDB.Add(Enquiry);
        }

        public static void Update(Enquiry Enquiry)
        {
            if (Enquiry == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (Enquiry.Id == null || Enquiry.Id == default)
            {
                throw new ArgumentException("Enquiry.Id value not set.");
            }

            EnquiryDB.Update(Enquiry);
        }

        public static void Delete(Enquiry Enquiry)
        {
            if (Enquiry == null)
            {
                throw new ArgumentException("Enquiry is null.");
            }

            if (Enquiry.Id == null || Enquiry.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            EnquiryDB.Delete(Enquiry);
        }

        public static Enquiry GetById(Guid id)
        {
            Enquiry Enquiry = EnquiryDB.GetById(id);
            return Enquiry;
        }

        public static List<Enquiry> GetAll()
        {
            return EnquiryDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return EnquiryDB.Getdataset();
        }

        public static List<Enquiry> Search(string word)
        {
            return EnquiryDB.Search(word);
        }
    }
}



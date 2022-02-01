using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class FeedBackManager
    {
        public static void Add(FeedBack feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentException("feedback is null.");
            }

            FeedBackDB.Add(feedback);
        }

        public static void Update(FeedBack feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (feedback.Id == null || feedback.Id == default)
            {
                throw new ArgumentException("feedback.Id value not set.");
            }

            FeedBackDB.Update(feedback);
        }

        public static void Delete(FeedBack feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentException("feedback is null.");
            }

            if (feedback.Id == null || feedback.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            FeedBackDB.Delete(feedback);
        }

        public static FeedBack GetById(Guid id)
        {
            FeedBack feedback = FeedBackDB.GetById(id);
            return feedback;
        }

        public static List<FeedBack> GetAll()
        {
            return FeedBackDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return FeedBackDB.Getdataset();
        }

        public static List<FeedBack> Search(string word)
        {
            return FeedBackDB.Search(word);
        }

    }
}
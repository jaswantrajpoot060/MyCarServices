using System;
using System.Collections.Generic;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    [Obsolete]
    public class SubcribesManager
    {
        public static void Add(Subcribes subcribes)
        {
            if (subcribes == null)
            {
                throw new ArgumentException("subcribes is null.");
            }

            SubcribesDB.Add(subcribes);
        }

        public static void Update(Subcribes subcribes)
        {
            if (subcribes == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (subcribes.Id == null || subcribes.Id == default)
            {
                throw new ArgumentException("subcribes.Id value not set.");
            }

            SubcribesDB.Update(subcribes);
        }

        public static void Delete(Subcribes subcribes)
        {
            if (subcribes == null)
            {
                throw new ArgumentException("subcribes is null.");
            }

            if (subcribes.Id == null || subcribes.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            SubcribesDB.Delete(subcribes);
        }

        public static Subcribes GetById(Guid id)
        {
            Subcribes subcribes = SubcribesDB.GetById(id);
            return subcribes;
        }

        public static List<Subcribes> GetAll()
        {
            return SubcribesDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return SubcribesDB.Getdataset();
        }

        public static List<Subcribes> Search(string word)
        {
            return SubcribesDB.Search(word);
        }
    }
}



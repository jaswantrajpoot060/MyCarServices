using System;
using System.Collections.Generic;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    [Obsolete]
    public class CityMasterManager
    {
        public static void Add(CityMaster citymaster)
        {
            if (citymaster == null)
            {
                throw new ArgumentException("citymaster is null.");
            }

            CityMasterDB.Add(citymaster);
        }

        public static void Update(CityMaster citymaster)
        {
            if (citymaster == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (citymaster.Id == null || citymaster.Id == default)
            {
                throw new ArgumentException("citymaster.Id value not set.");
            }

            CityMasterDB.Update(citymaster);
        }

        public static void Delete(CityMaster citymaster)
        {
            if (citymaster == null)
            {
                throw new ArgumentException("citymaster is null.");
            }

            if (citymaster.Id == null || citymaster.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            CityMasterDB.Delete(citymaster);
        }

        public static CityMaster GetById(Guid id)
        {
            CityMaster citymaster = CityMasterDB.GetById(id);
            return citymaster;
        }

        public static List<CityMaster> GetAll()
        {
            return CityMasterDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return CityMasterDB.Getdataset();
        }

        public static List<CityMaster> Search(string word)
        {
            return CityMasterDB.Search(word);
        }
    }
}



using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class LocationManager
    {
        public static void Add(Location location)
        {
            if (location == null)
            {
                throw new ArgumentException("location is null.");
            }

            LocationDB.Add(location);
        }

        public static void Update(Location location)
        {
            if (location == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (location.Id == null || location.Id == default)
            {
                throw new ArgumentException("location.Id value not set.");
            }

            LocationDB.Update(location);
        }

        public static void Delete(Location location)
        {
            if (location == null)
            {
                throw new ArgumentException("location is null.");
            }

            if (location.Id == null || location.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            LocationDB.Delete(location);
        }

        public static Location GetById(Guid id)
        {
            Location location = LocationDB.GetById(id);
            return location;
        }

        public static List<Location> GetAll()
        {
            return LocationDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return LocationDB.Getdataset();
        }

        public static List<Location> Search(string word)
        {
            return LocationDB.Search(word);
        }

    }
}
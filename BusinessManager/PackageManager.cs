using System;
using System.Collections.Generic;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    [Obsolete]
    public class PackageManager
    {
        public static void Add(Package package)
        {
            if (package == null)
            {
                throw new ArgumentException("package is null.");
            }

            PackageDB.Add(package);
        }

        public static void Update(Package package)
        {
            if (package == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (package.Id == null || package.Id == default)
            {
                throw new ArgumentException("package.Id value not set.");
            }

            PackageDB.Update(package);
        }

        public static void Delete(Package package)
        {
            if (package == null)
            {
                throw new ArgumentException("package is null.");
            }

            if (package.Id == null || package.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            PackageDB.Delete(package);
        }

        public static Package GetById(Guid id)
        {
            Package package = PackageDB.GetById(id);
            return package;
        }

        public static List<Package> GetAll()
        {
            return PackageDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return PackageDB.Getdataset();
        }

        public static List<Package> Search(string word)
        {
            return PackageDB.Search(word);
        }
    }
}



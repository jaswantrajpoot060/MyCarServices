using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class PImageManager
    {
        public static void Add(PImage pimage)
        {
            if (pimage == null)
            {
                throw new ArgumentException("pimage is null.");
            }

            PImageDB.Add(pimage);
        }

        public static void Update(PImage pimage)
        {
            if (pimage == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (pimage.Id == null || pimage.Id == default)
            {
                throw new ArgumentException("pimage.Id value not set.");
            }

            PImageDB.Update(pimage);
        }

        public static void Delete(PImage pimage)
        {
            if (pimage == null)
            {
                throw new ArgumentException("pimage is null.");
            }

            if (pimage.Id == null || pimage.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            PImageDB.Delete(pimage);
        }

        public static PImage GetById(Guid id)
        {
            PImage pimage = PImageDB.GetById(id);
            return pimage;
        }

        public static PImage GetByPackageId(Guid PackageId)
        {
            PImage pimage = PImageDB.GetByPackageId(PackageId);
            return pimage;
        }
        public static List<PImage> GetAll()
        {
            return PImageDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return PImageDB.Getdataset();
        }
        public static List<PImage> GetByPackageIdlist(Guid PackageId)
        {
            return PImageDB.GetByPackageIdlist(PackageId);
        }
        public static List<PImage> Search(string word)
        {
            return PImageDB.Search(word);
        }

    }
}
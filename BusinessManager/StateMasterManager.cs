using System;
using System.Collections.Generic;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    [Obsolete]
    public class StateMasterManager
    {
        public static void Add(StateMaster statemaster)
        {
            if (statemaster == null)
            {
                throw new ArgumentException("statemaster is null.");
            }

            StateMasterDB.Add(statemaster);
        }

        public static void Update(StateMaster statemaster)
        {
            if (statemaster == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (statemaster.Id == null || statemaster.Id == default)
            {
                throw new ArgumentException("statemaster.Id value not set.");
            }

            StateMasterDB.Update(statemaster);
        }

        public static void Delete(StateMaster statemaster)
        {
            if (statemaster == null)
            {
                throw new ArgumentException("statemaster is null.");
            }

            if (statemaster.Id == null || statemaster.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            StateMasterDB.Delete(statemaster);
        }

        public static StateMaster GetById(Guid id)
        {
            StateMaster statemaster = StateMasterDB.GetById(id);
            return statemaster;
        }

        public static List<StateMaster> GetAll()
        {
            return StateMasterDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return StateMasterDB.Getdataset();
        }

        public static List<StateMaster> Search(string word)
        {
            return StateMasterDB.Search(word);
        }
    }
}
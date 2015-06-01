using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using HaarbyTennis.DAL;
using HaarbyTennis.Global;

 
namespace HaarbyTennis.BLL
{
    public abstract class BasePublic : BizObject
    {
        private int _id = 0;
        public int ID
        {
            get { return _id; }
            protected set { _id = value; }
        }

        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate
        {
            get { return _addedDate; }
            protected set { _addedDate = value; }
        }

        private string _addedBy = "";
        public string AddedBy
        {
            get { return _addedBy; }
            protected set { _addedBy = value; }
        }

        protected static PublicElement Settings
        {
            get { return Globals.Settings.Public; }
        }

        /// <summary>
        /// Cache the input data, if caching is enabled
        /// </summary>
        protected static void CacheData(string key, object data)
        {
            if (Settings.EnableCaching && data != null)
            {
                BizObject.Cache.Insert(key, data, null,
                   DateTime.Now.AddSeconds(Settings.CacheDuration), TimeSpan.Zero);
            }
        }
    }
}
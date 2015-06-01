using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using HaarbyTennis.Global;
using HaarbyTennis.Model;

namespace HaarbyTennis.DAL
{
    public abstract class PublicProvider : DataAccess
    {
        static private PublicProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public PublicProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (PublicProvider)Activator.CreateInstance(
                                Type.GetType(Globals.Settings.Public.ProviderType));
                return _instance;
            }
        }

        public PublicProvider()
        {
            this.ConnectionString = Globals.Settings.Public.ConnectionString;
            this.EnableCaching = Globals.Settings.Public.EnableCaching;
            this.CacheDuration = Globals.Settings.Public.CacheDuration;
        }

        #region Nyheder
        // methoder som arbejder med Nyheder
        public abstract List<HaarbyTennis.Model.NyhedOplysning> GetNyheder(string sortExpression, int aarstal);
        public abstract List<HaarbyTennis.Model.NyhedOplysning> GetNyheder(int departmentID, string sortExpression, int pageIndex, int pageSize);

        public abstract int GetNyhedCount();

        public abstract HaarbyTennis.Model.NyhedOplysning GetNyhedByID(int nyhedID);
        public abstract bool DeleteNyhed(long nyhedID);
        public abstract bool UpdateNyhed(NyhedOplysning nyhed);
        public abstract bool InsertNyhed(NyhedOplysning nyhed);
  
  
        /// <summary>
        /// Returns a valid sort expression for the products
        /// </summary>
        protected virtual string EnsureValidProductsSortExpression(string sortExpression)
        {
            return "DESC";
            if (string.IsNullOrEmpty(sortExpression))
                return "tbh_Products.Title ASC";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("unitprice") && !sortExpr.Equals("unitprice asc") && !sortExpr.Equals("unitprice desc") &&
               !sortExpr.Equals("discountpercentage") && !sortExpr.Equals("discountpercentage asc") && !sortExpr.Equals("discountpercentage desc") &&
               !sortExpr.Equals("addeddate") && !sortExpr.Equals("addeddate asc") && !sortExpr.Equals("addeddate desc") &&
               !sortExpr.Equals("addedby") && !sortExpr.Equals("addedby asc") && !sortExpr.Equals("addedby desc") &&
               !sortExpr.Equals("unitsinstock") && !sortExpr.Equals("unitsinstock asc") && !sortExpr.Equals("unitsinstock desc") &&
               !sortExpr.Equals("title") && !sortExpr.Equals("title asc") && !sortExpr.Equals("title desc"))
            {
                sortExpr = "title asc";
            }
            if (!sortExpr.StartsWith("tbh_products"))
                sortExpr = "tbh_products." + sortExpr;
            if (!sortExpr.StartsWith("tbh_products.title"))
                sortExpr += ", tbh_products.title asc";
            return sortExpr;
        }


        /// <summary>
        /// Returns a new OrderDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual HaarbyTennis.Model.NyhedOplysning GetNyhedFromReader(IDataReader reader)
        {
            int testReader2 = (int)reader["Id"];
            string testReader = reader["overskrift"].ToString();
            testReader = reader["tekst"].ToString();           
            DateTime testReader3 = (DateTime)reader["dato"];
            testReader = reader["Billede1"].ToString();
            testReader = reader["Billede2"].ToString();
            testReader = reader["Redirect"].ToString();


            return new HaarbyTennis.Model.NyhedOplysning(
               (int)reader["Id"],
               (DateTime)reader["dato"],
               reader["overskrift"].ToString(),
               reader["tekst"].ToString(),
               reader["Billede1"].ToString(),
               reader["Billede2"].ToString(),
               reader["Redirect"].ToString());
               
        }
      
        /// <summary>
        /// Returnerer en collection af NyhedDetails objekter med data læst fra input DataReader
        /// </summary>
        protected virtual List<HaarbyTennis.Model.NyhedOplysning> GetNyhedCollectionFromReader(IDataReader reader)
        {
            List<HaarbyTennis.Model.NyhedOplysning> nyheder = new List<HaarbyTennis.Model.NyhedOplysning>();
            while (reader.Read())
                nyheder.Add(GetNyhedFromReader(reader));
            return nyheder;
        }
        #endregion

     
    }
}

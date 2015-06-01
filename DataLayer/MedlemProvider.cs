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
    public abstract class MedlemProvider : DataAccess
    {
        static private MedlemProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public MedlemProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (MedlemProvider)Activator.CreateInstance(
                                Type.GetType(Globals.Settings.Medlem.ProviderType));
                return _instance;
            }
        }

        public MedlemProvider()
        {
            this.ConnectionString = Globals.Settings.Public.ConnectionString;
            this.EnableCaching = Globals.Settings.Public.EnableCaching;
            this.CacheDuration = Globals.Settings.Public.CacheDuration;
        }

    
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


    

        #region Medlemmer


        // methoder som arbejder med Medlemmer
        public abstract List<HaarbyTennis.Model.Medlem> GetMedlemmer(string sortExpression, string medlemtype);
        public abstract HaarbyTennis.Model.Medlem GetMedlemById(int medlemId); 
        public abstract bool UpdateMedlem(Medlem medlem);
        public abstract bool InsertMedlem(Medlem medlem);
        public abstract bool InsertAdministrationsLog(AdminitrationLog loginfo);



        /// <summary>
        /// Returnerer en collection af NyhedDetails objekter med data læst fra input DataReader
        /// </summary>
        protected virtual List<HaarbyTennis.Model.Medlem> GetMedlemCollectionFromReader(IDataReader reader)
        {
            List<HaarbyTennis.Model.Medlem> medlemmer = new List<HaarbyTennis.Model.Medlem>();
            while (reader.Read())
                medlemmer.Add(GetMedlemFromReader(reader));
            return medlemmer;
        }


        /// <summary>
        /// Returns a new OrderDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual HaarbyTennis.Model.Medlem GetMedlemFromReader(IDataReader reader)
        {
            int testReader1 = (int)reader["Id"];
          

            string testReade2 = reader["Fornavn"].ToString();
            string testReader3 = reader["Email"].ToString();
                        
            DateTime testReader4 = (DateTime)reader["Foedselsdato"];
            decimal testReader5 = (decimal)reader["Kontingent"];
          
            decimal testReader7 = (decimal)reader["Indendørs"];
           
            decimal testReader9 = (decimal)reader["Boldkanon"];

            decimal testReader8 = (decimal)reader["Minitennis"];
            string testReader10 = reader["PassivMedlem"].ToString();
            DateTime testReader11 = (DateTime)reader["MedlemSiden"];
            bool testReader12 = (bool)reader["JaTilNyheder"];
            bool testReader13 = (bool)reader["Udmeldt"];

            return new HaarbyTennis.Model.Medlem(
               (int)reader["Id"],
               reader["Efternavn"].ToString(),
               reader["Fornavn"].ToString(),
               reader["Adresse"].ToString(),
               reader["Postnummer"].ToString(),
               reader["Bynavn"].ToString(),
               reader["TLF_1"].ToString(),
             
               reader["Email"].ToString(),
               (DateTime)reader["Foedselsdato"],
               (decimal)reader["Kontingent"],
               (decimal)reader["Nøgle"],
               (decimal)reader["Indendørs"],
               (decimal)reader["Minitennis"],
               reader["Rabat"].ToString(),
               (decimal)reader["Boldkanon"],            
               (bool)reader["JaTilNyheder"],
               reader["OpdateretAfBruger"].ToString(),
                (bool)reader["Udmeldt"],
               (Int16)reader["MasterPeriode"]
               );


        }

        #endregion
    }
}

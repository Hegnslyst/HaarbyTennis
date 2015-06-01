using System;
using System.Collections.Generic;
using System.Text;
using HaarbyTennis.Global;
using HaarbyTennis.DAL;
using HaarbyTennis.Utilities;
using HaarbyTennis.Model;



namespace HaarbyTennis.BLL
{
    public class NyhederService : BasePublic
    {
        /// <summary>
        /// Returnerer en samling/Collection med alle Nyheder
        /// </summary>

        /***********************************
     * Static methods
     ************************************/

        /// <summary>
        /// Returnerer en samling/Collection med alle Nyheder
        /// </summary>

        public static List<HaarbyTennis.Model.NyhedOplysning> GetNyheder(string sortExpression, int aarstal)
        {
            if (sortExpression == null)
                sortExpression = "";

            List<HaarbyTennis.Model.NyhedOplysning> response = null;
            string key = "Nyheder_" + sortExpression;

            HaarbyTennis.Model.HentNyhedOplysningRequest request = new Model.HentNyhedOplysningRequest();

            request.nyhedAarstalFra = aarstal;
            request.sortExpression = sortExpression;

           
            
            if (BasePublic.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                response = (List<HaarbyTennis.Model.NyhedOplysning>)BizObject.Cache[key];
            }
            else
            {

                response = SiteProvider.PublicSite.GetNyheder(sortExpression, aarstal);
               
                BasePublic.CacheData(key, response);
            }
            response = SiteProvider.PublicSite.GetNyheder(sortExpression, aarstal);
            return response;
        }

                //HaarbyTennis.Model.
                //ServiceEjendom.HentEjendomOplysningRequest request = new ServiceEjendom.HentEjendomOplysningRequest();
                //request.E0101_EJENDOMSNR = enr;
                //request.X0002_KOMMUNE = knr;
                //try
                //{
                //    // udfør kald
                //    response = service.HentEjendomOplysning(m_RequestIdentity, request);
                //}
                //catch (Exception e)
                //{
                //    HaandterException(e);
                //}
        /// <summary>
        /// Returns the number of total products
        /// </summary>
        public static int GetNyhedCount()
        {
            int nyhedCount = 0;
            string key = "Public_NyhedCount";

            if (BasePublic.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                nyhedCount = (int)BizObject.Cache[key];
            }
            else
            {
                nyhedCount = SiteProvider.PublicSite.GetNyhedCount();
                BasePublic.CacheData(key, nyhedCount);
            }
            return nyhedCount;
        }


        /// <summary>
        /// Returns an Product object with the specified ID
        /// </summary>
        public static HaarbyTennis.Model.NyhedOplysning GetNyhedByID(int nyhedID)
        {
            HaarbyTennis.Model.NyhedOplysning nyhed = null;
            string key = "TennisPublic_Nyhed_" + nyhedID.ToString();

            if (BasePublic.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                nyhed = (HaarbyTennis.Model.NyhedOplysning)BizObject.Cache[key];
            }
            else
            {
                nyhed = GetNyhedFromNyhedDetails(SiteProvider.PublicSite.GetNyhedByID(nyhedID));
                BasePublic.CacheData(key, nyhed);
            }
            return nyhed;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        public static bool UpdateNyhed(long Id, DateTime dato, string overSkrift,
                           string tekst)
        {
            string billede_1 = "";
            string billede_2 = "";
            string redirect = "";
            dato = BizObject.ConvertNullToEmptyDateTime(dato);
            overSkrift = BizObject.ConvertNullToEmptyString(overSkrift);
            tekst = BizObject.ConvertNullToEmptyString(tekst);
            billede_1 = BizObject.ConvertNullToEmptyString(billede_1);
            redirect = BizObject.ConvertNullToEmptyString(redirect);

            NyhedOplysning record = new NyhedOplysning(Id, DateTime.Now, overSkrift, tekst, billede_1, billede_2, redirect);
            bool ret = SiteProvider.PublicSite.UpdateNyhed(record);

            BizObject.PurgeCacheItems("PublicSite_nyhed_" + Id.ToString());
            BizObject.PurgeCacheItems("PublicSite_nyhed");
            return ret;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        public static bool InsertNyhed(string OverSkrift, string tekst)
        {
            //Benyttes ikke indtil videre.
            string billede_1 = "";
            string billede_2 = "";
            string redirect = "";
            tekst = BizObject.ConvertNullToEmptyString(tekst);
            OverSkrift = BizObject.ConvertNullToEmptyString(OverSkrift);
            billede_1 = BizObject.ConvertNullToEmptyString(billede_1);
            billede_2 = BizObject.ConvertNullToEmptyString(billede_2);
            redirect = BizObject.ConvertNullToEmptyString(redirect);

            //BizObject.CurrentUserName todo: indsæt det v. oprettelse og ændring.
            NyhedOplysning record = new NyhedOplysning(0, DateTime.Now, OverSkrift, tekst, billede_1, billede_2, redirect);
            bool ret = SiteProvider.PublicSite.InsertNyhed(record);

            BizObject.PurgeCacheItems("PublicSite_Nyhed");
            return ret;
        }

        /// <summary>
        /// Deletes an existing product
        /// </summary>
        public static bool DeleteNyhed(long id)
        {
            bool ret = SiteProvider.PublicSite.DeleteNyhed(id);
            new RecordDeletedEvent("nyhed", id, null).Raise();
            BizObject.PurgeCacheItems("Public_nyhed");
            return ret;
        }


        /// <summary>
        /// Returns a Product object filled with the data taken from the input ProductDetails
        /// </summary>
        private static HaarbyTennis.Model.NyhedOplysning GetNyhedFromNyhedDetails(HaarbyTennis.Model.NyhedOplysning record)
        {
            if (record == null)
                return null;
            else
            {
                return new HaarbyTennis.Model.NyhedOplysning(record.Id, record.Dato, record.OverSkrift,
                   record.Tekst, record.Billede_1, record.Billede_2, record.Redirect);
            }
        }

        /// <summary>
        /// Returnerer en liste  Nyhed objecter fyldt med data fra input listen i NyhedDetails
        /// Mapning af recordset til objekt med Nyhed objekter.
        /// </summary>
        private static List<HaarbyTennis.Model.NyhedOplysning> GetNyhedListFromNyhedDetailsList(List<HaarbyTennis.Model.NyhedOplysning> recordset)
        {
            List<HaarbyTennis.Model.NyhedOplysning> nyheder = new List<HaarbyTennis.Model.NyhedOplysning>();
            foreach (HaarbyTennis.Model.NyhedOplysning record in recordset)
                nyheder.Add(GetNyhedFromNyhedDetails(record));
            return nyheder;
        }

        #region HaandterException TODO!!!
        private void HaandterException(Exception exception)
        {
            //if (exception.GetType() == typeof(FaultException<ServiceEjendom.ArgumentFault>))
            //{
            //    FaultException<ServiceEjendom.ArgumentFault> af = (FaultException<ServiceEjendom.ArgumentFault>)exception;
            //    // exception er kastet og logget på webservicen
            //    //af.Detail.ParamName
            //    //af.Detail.Id
            //    //af.Detail.Message
            //    throw new ServiceException(af.Detail.ParamName, af.Detail.Id.ToString(), af.Detail.Message);
            //}
            //else if (exception.GetType() == typeof(FaultException<ServiceEjendom.ServiceUnavailableFault>))
            //{
            //    FaultException<ServiceEjendom.ServiceUnavailableFault> suf = (FaultException<ServiceEjendom.ServiceUnavailableFault>)exception;
            //    // exception er kastet og logget på webservicen
            //    //suf.Detail.Id;
            //    //suf.Detail.Message
            //    throw new ServiceException(suf.Detail.Id.ToString(), suf.Detail.Message);
            //}
            //else
            //{
                // evt. ingen forbindelse til webservicen
                // kald metode til at logge
                // MANGLER!!!!!!

                throw new ServiceException(exception.ToString());
            //}
        }
        #endregion

    }
}

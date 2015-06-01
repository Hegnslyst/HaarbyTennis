﻿using System;
using System.Collections.Generic;
using System.Text;
using HaarbyTennis.Global;
using HaarbyTennis.DAL;
using HaarbyTennis.Utilities;
using HaarbyTennis.Model;



namespace HaarbyTennis.BLL
{
    public class MedlemmerService : BasePublic
    {
        /// <summary>
        /// Returnerer en samling/Collection med alle Nyheder
        /// </summary>

        /***********************************
     * Static methods
     ************************************/


       

        /// <summary>
        /// Returnerer en samling/Collection med alle Medlemmer
        /// </summary>

        public static List<HaarbyTennis.Model.Medlem> GetMedlemmer(string sortExpression, string medlemtype)
        {
            if (sortExpression == null)
                sortExpression = "";

            List<HaarbyTennis.Model.Medlem> response = null;
            string key = "Nyheder_" + sortExpression;

            HaarbyTennis.Model.HentMedlemOplysningRequest request = new Model.HentMedlemOplysningRequest();

            request.Medlemtype = medlemtype;
            request.sortExpression = sortExpression;



            if (BasePublic.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                response = (List<HaarbyTennis.Model.Medlem>)BizObject.Cache[key];
            }
            else
            {

                response = SiteProvider.MedlemSite.GetMedlemmer(sortExpression, medlemtype);

                BasePublic.CacheData(key, response);
            }
            response = SiteProvider.MedlemSite.GetMedlemmer(sortExpression, medlemtype);
            return response;
        }


        /// <summary>
        /// Returns an Member object with the specified ID
        /// </summary>
        public static HaarbyTennis.Model.Medlem GetMedlemmerByID(int medlemId)
        {
            
            HaarbyTennis.Model.HentMedlemOplysningRequest request = new Model.HentMedlemOplysningRequest();
            HaarbyTennis.Model.Medlem response = null;
            response = SiteProvider.MedlemSite.GetMedlemById(medlemId);
            return response;
        }
       
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
        public static bool UpdateMedlem(Medlem medlem)
            {

            

            medlem.Efternavn = BizObject.ConvertNullToEmptyString(medlem.Efternavn);
            medlem.Fornavn = BizObject.ConvertNullToEmptyString(medlem.Fornavn);
            medlem.Adresse = BizObject.ConvertNullToEmptyString(medlem.Adresse);
            medlem.Postnummer = BizObject.ConvertNullToEmptyString(medlem.Postnummer);
            medlem.Bynavn = BizObject.ConvertNullToEmptyString(medlem.Bynavn);
            medlem.Tlf_1 = BizObject.ConvertNullToEmptyString(medlem.Tlf_1);  
            medlem.Rabat = BizObject.ConvertNullToEmptyString(medlem.Rabat);
            medlem.Foedselsdato = BizObject.ConvertNullToEmptyDateTime(medlem.Foedselsdato);
            medlem.OpdateretAfBruger = BizObject.ConvertNullToEmptyString(medlem.OpdateretAfBruger);
            


            Medlem record = new Medlem(medlem.Id, medlem.Efternavn, medlem.Fornavn, medlem.Adresse, medlem.Postnummer, medlem.Bynavn, medlem.Tlf_1, 
                                       medlem.Email, medlem.Foedselsdato, medlem.Kontingent, 
                                       medlem.Noegle, medlem.Indendoers, medlem.Minitennis, medlem.Rabat, medlem.Boldkanon, medlem.JaTilNyheder, medlem.OpdateretAfBruger, 
                                       medlem.Udmeldt, medlem.MasterPeriode);
            
            bool ret = SiteProvider.MedlemSite.UpdateMedlem(record);

            BizObject.PurgeCacheItems("PublicSite_nyhed_" + medlem.Id.ToString());
            BizObject.PurgeCacheItems("PublicSite_nyhed");
            return ret;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        public static bool InsertMedlem(Medlem medlem)
        {

            medlem.Efternavn = BizObject.ConvertNullToEmptyString(medlem.Efternavn);
            medlem.Fornavn = BizObject.ConvertNullToEmptyString(medlem.Fornavn);
            medlem.Adresse = BizObject.ConvertNullToEmptyString(medlem.Adresse);
            medlem.Postnummer = BizObject.ConvertNullToEmptyString(medlem.Postnummer);
            medlem.Bynavn = BizObject.ConvertNullToEmptyString(medlem.Bynavn);
            medlem.Tlf_1 = BizObject.ConvertNullToEmptyString(medlem.Tlf_1);
            medlem.Rabat = BizObject.ConvertNullToEmptyString(medlem.Rabat);
            medlem.Foedselsdato = BizObject.ConvertNullToEmptyDateTime(medlem.Foedselsdato);
            medlem.OpdateretAfBruger = BizObject.ConvertNullToEmptyString(medlem.OpdateretAfBruger);            

            Medlem record = new Medlem(1, medlem.Efternavn, medlem.Fornavn, medlem.Adresse, medlem.Postnummer, medlem.Bynavn, medlem.Tlf_1, medlem.Email, medlem.Foedselsdato, medlem.Kontingent,
                                       medlem.Noegle, medlem.Indendoers, medlem.Minitennis, medlem.Rabat, medlem.Boldkanon, medlem.JaTilNyheder, medlem.OpdateretAfBruger, medlem.Udmeldt, medlem.MasterPeriode);

            bool ret = SiteProvider.MedlemSite.InsertMedlem(record);

            BizObject.PurgeCacheItems("PublicSite_nyhed_" + medlem.Id.ToString());
            BizObject.PurgeCacheItems("PublicSite_nyhed");
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

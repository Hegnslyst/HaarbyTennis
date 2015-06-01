using System;
using System.Collections.Generic;
using System.Text;
using HaarbyTennis.Global;
using HaarbyTennis.DAL;
using HaarbyTennis.Utilities;
using HaarbyTennis.Model;



namespace HaarbyTennis.BLL
{
    public class LogningService : BasePublic
    {
        /// <summary>
        /// Returnerer en samling/Collection med alle Nyheder
        /// </summary>

        /***********************************
     * Static methods
     ************************************/




       


     

     

      

        /// <summary>
        /// Updates an existing product
        /// </summary>
        public static bool InsertLogning(int Id,
                                         DateTime LogTid,
                                         string BrugerType,
                                         string BrugerNavn,
                                         string LogType,
                                         string LogGruppe,
                                         string Kilde,
                                         string LogInfo)

         

        {
            LogTid = BizObject.ConvertNullToEmptyDateTime(LogTid);
            BrugerType = BizObject.ConvertNullToEmptyString(BrugerType);
            BrugerNavn = BizObject.ConvertNullToEmptyString(BrugerNavn);
            LogType = BizObject.ConvertNullToEmptyString(LogType);
            LogGruppe = BizObject.ConvertNullToEmptyString(LogGruppe);
            Kilde = BizObject.ConvertNullToEmptyString(Kilde);
            LogInfo = BizObject.ConvertNullToEmptyString(LogInfo);
            

            AdminitrationLog record = new AdminitrationLog(Id, LogTid, BrugerType, BrugerNavn, LogType, LogGruppe, Kilde, LogInfo);

            bool ret = SiteProvider.MedlemSite.InsertAdministrationsLog(record);

            BizObject.PurgeCacheItems("PublicSite_nyhed_" + Id.ToString());
            BizObject.PurgeCacheItems("PublicSite_nyhed");
            return ret;
        }

      

    }
}

using HaarbyTennis.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using SPOC.App.DAL;

namespace HaarbyTennis.App.Logic
{
    public class LogStatus
    {
        public enum eLogGruppe
	    {
            BrugerLogon,
            StudentLogon,
            NyBruger,
            NyAftale,
            AftaleReservation,
            Mail,
            Ukendt
	    }

        public enum eBrugerType
	    {
            Ukendt,
            Administrator,
            Medlem
	    }

        public enum eLogType
        {
            Fejl,
            Info
        }

        public static void LogUserInfo(eLogGruppe logGruppe, string logTekst, string kilde = "", string brugerNavn = "", int aftaleId = 0)
        {
            LogMessage(eLogType.Info, eBrugerType.Administrator, logGruppe, logTekst, kilde, brugerNavn, aftaleId);
        }

        public static void LogUserError(eLogGruppe logGruppe, string logTekst, string kilde = "", string brugerNavn = "", int aftaleId = 0)
        {
            //logTekst.Replace("'","");
            LogMessage(eLogType.Fejl, eBrugerType.Administrator, logGruppe, logTekst, kilde, brugerNavn, aftaleId);
        }

        private static void LogMessage(eLogType logType, eBrugerType brugerType, eLogGruppe logGruppe, string logTekst, string kilde, string brugerNavn, int aftaleId)
        {

            LogningService.InsertLogning(0, DateTime.Now, BrugerTypeToString(brugerType), brugerNavn, LogTypeToString(logType), LogGruppeToString(logGruppe), kilde, logTekst);
        }

        private static string LogGruppeToString(eLogGruppe logGruppe)
        {
            string result = "Ukendt";
            switch (logGruppe)
            {
                case eLogGruppe.BrugerLogon:
                    result = "BrugerLogon";
                    break;
                case eLogGruppe.StudentLogon:
                    result = "StudentLogon";
                    break;
                case eLogGruppe.NyBruger:
                    result = "NyBruger";
                    break;
                case eLogGruppe.NyAftale:
                    result = "NyAftale";
                    break;
                case eLogGruppe.AftaleReservation:
                    result = "Reservation";
                    break;
                case eLogGruppe.Mail:
                    result = "Mail";
                    break;
            }
            return result;
        }

        private static string BrugerTypeToString(eBrugerType brugerType)
        {            
            if (brugerType == eBrugerType.Administrator)
            {
                return "Administrator";
            }
            else if (brugerType == eBrugerType.Medlem)
            {
                return "Medlem";
            }
            else
            {
                return "?";
            }
        }

        private static string LogTypeToString(eLogType logType)
        {
            if (logType == eLogType.Fejl)
            {
                return "Fejl";
            }
            else
            {
                return "Info";
            }        
        }

    }
}
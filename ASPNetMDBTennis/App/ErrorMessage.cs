using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarbyTennis.App
{
    public static class ErrorMessage
    {

        public static void ShowErrorPage(HttpResponse httpResponse, ApplicationContext appContext, string errorMessage, string errorCaption = "Fejl")
        {

            //Skriv fejlinformation i Historiktabellen. 
            //TODO: Hvis dette udføres, kan historiktabellen fyldes op med fejlmeddelser. I stedet bruges fejllog.

            //appContext.CurrentContact.HenvendelseStatusTekst = errorMessage;
            //appContext.CurrentContact.InsertHistorikInformation(out errorMessage);
            
            appContext.ErrorMessage.ErrorCaption = errorCaption;
            appContext.ErrorMessage.ErrorMessage = errorMessage;
            httpResponse.Redirect("~/ErrorPage.aspx");        
        }
        

    }
}
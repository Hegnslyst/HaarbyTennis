using HaarbyTennis.App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetMDBTennis.UI
{
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: husk at udkommentere...

            //if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{

            //    Response.Redirect("/UI/Velkommen.aspx", true);
            
            //}
            string LogMessage = System.Web.HttpContext.Current.User.Identity.Name + " er logget på";
            LogStatus.LogUserInfo(LogStatus.eLogGruppe.NyBruger, LogMessage, Properties.Settings.Default.ApplicationName + ".SaveItem", "Administrator");


        }
    }
}
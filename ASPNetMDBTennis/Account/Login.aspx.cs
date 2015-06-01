using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web;
using System.Web.Configuration;

namespace ASPNetMDBTennis.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

            }
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "Lasse", DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes), true, "Test");

            // Create the encrypted cookie             
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            //if (rememberMe)                 
            //cookie.Expires = DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes);
            // Add the cookie to user browser             
            //Response.Cookies.Set(cookie);

            //this.Master.FindControl("Soeg").Visible = false;
            if (Roles.IsUserInRole("Admin"))
            {
                WebConfigurationManager.GetSection("asfasdf");
            }
        }
    }
}

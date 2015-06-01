using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetMDBTennis
{
    public partial class SiteOrangeMaster : System.Web.UI.MasterPage
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

               
               

                string name = System.Web.HttpContext.Current.User.Identity.Name;
                string name1 = System.Web.HttpContext.Current.User.Identity.AuthenticationType;
                string name2 = System.Web.HttpContext.Current.User.Identity.ToString();
                if (System.Web.HttpContext.Current.User.IsInRole("Admin"))
                {
                                       
                
                }

               

            }
           
            
        }
        protected void mnuHeader_MenuItemClick(object sender, MenuEventArgs e)
        {
           

        }
    }
}

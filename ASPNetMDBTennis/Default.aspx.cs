using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ASPNetMDBTennis
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                //this.FindControl("teten").Visible = false;

                string name = System.Web.HttpContext.Current.User.Identity.Name;
                string name1 = System.Web.HttpContext.Current.User.Identity.AuthenticationType;
                string name2 = System.Web.HttpContext.Current.User.Identity.ToString();
                //if (System.Web.HttpContext.Current.User.IsInRole("Admin"))
                //{


                //}

                if (name == "Hegnslyst" || name == "Tennisformand" || name == "TennisKasserer" || name == "TennisBaneFormand" || name == "TennisBygning")
                {
                    Response.Redirect("/Admin/Administration.aspx", true);

                }



            }
            Response.Redirect("/UI/VelkommenVinter.aspx", true);
            //Response.Redirect("/Admin/Administration.aspx", true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetMDBTennis.UI
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.AppContext == null)
            //{
            lblErrorCaption.Text = "Ukendt fejl";
            lblErrorContent.Text = "Der er opstået en ukendt fejl i programmet og eksekveringen er stoppet. Det er desværre ikke muligt at fortsætte.";
            //}
            //else
            //{
            //    lblErrorCaption.Text = this.AppContext.ErrorMessage.ErrorCaption;
            //    lblErrorContent.Text = this.AppContext.ErrorMessage.ErrorMessage;
            //}
        }

        //public ApplicationContext AppContext
        //{
        //    get
        //    {
        //        return (ApplicationContext)Session["ApplicationContext"];
        //    }
        //}   
    }
}
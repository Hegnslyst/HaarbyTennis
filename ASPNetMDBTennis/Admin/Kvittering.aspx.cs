using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetMDBTennis.Admin
{
    public partial class Kvittering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKvittering.Text = "Mails er nu korrekt afsendt";
        }
    }
}
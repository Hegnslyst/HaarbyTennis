using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Management;

namespace HaarbyTennis.Global
{
    public abstract class WebCustomEvent : WebBaseEvent
    {
        public WebCustomEvent(string message, object eventSource, int eventCode)
            : base(message, eventSource, eventCode) { }
    }

    public class RecordDeletedEvent : WebCustomEvent
    {
        private const int eventCode = WebEventCodes.WebExtendedBase + 10;
        private const string message = "The {0} with ID = {1} was deleted by user {2}.";

        public RecordDeletedEvent(string entity, long id, object eventSource)
            : base(string.Format(message, entity, id, HttpContext.Current.User.Identity.Name), eventSource, eventCode)
        { }
    }
}
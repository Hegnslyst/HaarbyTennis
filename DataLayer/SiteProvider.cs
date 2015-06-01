using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HaarbyTennis.DAL
{
    public static class SiteProvider
    {
        //public static ArticlesProvider Articles
        //{
        //    get { return ArticlesProvider.Instance; }
        //}

        //public static PollsProvider Polls
        //{
        //    get { return PollsProvider.Instance; }
        //}

        //public static NewslettersProvider Newsletters
        //{
        //    get { return NewslettersProvider.Instance; }
        //}

        //public static ForumsProvider Forums
        //{
        //    get { return ForumsProvider.Instance; }
        //}

        public static PublicProvider PublicSite
        {
            get { return PublicProvider.Instance; }
        }

        public static MedlemProvider MedlemSite
        {
            get { return MedlemProvider.Instance; }
        }
    }
}

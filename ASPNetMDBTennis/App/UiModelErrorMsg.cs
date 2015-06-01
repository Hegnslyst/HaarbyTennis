using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarbyTennis.App
{
    public class UiModelErrorMsg
    {
        public UiModelErrorMsg()
        {
            this.ErrorCaption = "";
            this.ErrorMessage = "";
        }

        public string ErrorCaption { get; set; }

        public string ErrorMessage { get; set; }        

    }
}
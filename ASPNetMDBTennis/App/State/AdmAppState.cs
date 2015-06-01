using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HaarbyTennis.AppState
{
    public class AdmAppState
    {       
        public AdmAppState()
        {
            this.AppState = App.FormState.List;               
        }
        public App.FormState AppState { get; set; }

       
    }
}
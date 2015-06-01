using HaarbyTennis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarbyTennis.AppState
{
    public class AdmMedlemmerState
    {

        public AdmMedlemmerState()
        {
            this.AppState = App.FormState.List;
           
        }

        public  Medlem Current_Medlem { get; set; }

        public App.FormState AppState { get; set; }

     
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Diagnostics;
using HaarbyTennis.Model;
using HaarbyTennis.App.Logic;
using HaarbyTennis.App;

namespace HaarbyTennis.App
{

    public enum FormState
    {
        List,
        Edit,
        EditAll,
        New
    }
    public class ApplicationContext
    {
        public const string FORMAT_DATE = "dd-MM-yyyy";
        public const string FORMAT_TIME = "HH:mm";
        public const string FORMAT_DATE_TIME = FORMAT_DATE + " " + FORMAT_TIME;

        private string _appVersion = "";
        private string _legalCopyright = "";
     
        private MailHandler _currentMailSag = null;
        private UiModelErrorMsg _currentError = null;
        private AppUser _currentUser = null;
     
        public bool AppMode { get; set; }


      

        public AppUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = new AppUser(this);
                return _currentUser;
            }
        }

        public MailHandler CurMailHandler
        {
            get
            {
                if (_currentMailSag == null)
                    _currentMailSag = new MailHandler(this);
                return _currentMailSag;
            }
        }

        public UiModelErrorMsg ErrorMessage
        {
            get
            {
                if (_currentError == null)
                    _currentError = new UiModelErrorMsg();
                return _currentError;
            }
        }

      


        public string AppVersion
        {
            get
            {
                if (_appVersion == "")
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    _appVersion = fvi.FileMajorPart.ToString() + "." + fvi.FileMinorPart.ToString() + "." + fvi.ProductBuildPart.ToString();
                }
                return _appVersion;
            }
        }

        public string AppLegalCopyright
        {
            get
            {
                if (_legalCopyright == "")
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    _legalCopyright = fvi.LegalCopyright;
                }
                return _legalCopyright;
            }
        }



    }
}
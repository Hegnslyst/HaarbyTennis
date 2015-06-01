using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaarbyTennis.App
{



    public class AppUser
    {
        private ApplicationContext _appContext;
        private Bruger _bruger;

        public AppUser(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public bool IsLoggedOn { get; private set; }

        public bool IsAdmin
        {
            get { return _bruger.Admin == true; }
        }

        public Bruger Bruger
        {
            get { return _bruger; }
        }

        public int BrugerId
        {
            get
            {
                if (_bruger != null)
                {
                    return _bruger.BrugerId;
                }
                else
                {
                    return 0;
                }
            }
        }

    }

    }
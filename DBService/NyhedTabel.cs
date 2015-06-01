using System;
using System.Collections.Generic;
using System.Text;

namespace HaarbyTennis.DBService
{

    public class NyhederTabel
    {

        private long IdField;
        private string DatoField;
        private string OverSkriftField;
        private string TekstField;
        private string Billede_1Field;
        private string Billede_2Field;
        private string RedirectField;
        

        /// <remarks/>
        public long ID
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        /// <remarks/>
        public string Dato
        {
            get
            {
                return this.DatoField;
            }
            set
            {
                this.DatoField = value;
            }
        }

        /// <remarks/>
        public string OverSkrift
        {
            get
            {
                return this.OverSkriftField;
            }
            set
            {
                this.OverSkriftField = value;
            }
        }

        /// <remarks/>
        public string Tekst
        {
            get
            {
                return this.TekstField;
            }
            set
            {
                this.TekstField = value;
            }
        }

        /// <remarks/>
        public string Billede_1
        {
            get
            {
                return this.Billede_1Field;
            }
            set
            {
                this.Billede_1Field = value;
            }
        }

        /// <remarks/>
        public string Billede_2
        {
            get
            {
                return this.Billede_2Field;
            }
            set
            {
                this.Billede_2Field = value;
            }
        }

        /// <remarks/>
        public string Redirect
        {
            get
            {
                return this.RedirectField;
            }
            set
            {
                this.RedirectField = value;
            }
        }

        /// <remarks/>

    }

    //public partial class Nyhed
    //{

    //    private short funktionField;

    //    private NyhederTabel NyhedInfoField;

    //    /// <remarks/>
    //    public short Funktion
    //    {
    //        get
    //        {
    //            return this.funktionField;
    //        }
    //        set
    //        {
    //            this.funktionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public NyhederTabel NyhedInfo
    //    {
    //        get
    //        {
    //            return this.NyhedInfoField;
    //        }
    //        set
    //        {
    //            this.NyhedInfoField = value;
    //        }
    //    }
    //}
    public class Nyheder
        {

            private short funktionField;

            private int maxCountField;

            private NyhederTabel NyhedInfoField;

            /// <remarks/>
            public short Funktion
            {
                get
                {
                    return this.funktionField;
                }
                set
                {
                    this.funktionField = value;
                }
            }

            /// <remarks/>
            public int MaxCount
            {
                get
                {
                    return this.maxCountField;
                }
                set
                {
                    this.maxCountField = value;
                }
            }

            /// <remarks/>
            public NyhederTabel NyhedInfo
            {
                get
                {
                    return this.NyhedInfoField;
                }
                set
                {
                    this.NyhedInfoField = value;
                }
            }
        }
    
}
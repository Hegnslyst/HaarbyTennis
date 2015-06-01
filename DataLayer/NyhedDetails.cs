using System;
using System.Collections.Generic;
using System.Text;



namespace HaarbyTennis.DAL
{
    public class NyhedDetails
    {
        private long m_Id;
        private DateTime m_Dato;
        private string m_OverSkrift;
        private string m_Tekst;
        private string m_Billede_1;
        private string m_Billede_2;
        private string m_Redirect;


        public NyhedDetails() {}

        public NyhedDetails(long id, DateTime dato, string overskrift, string tekst,
            string billede_1, string billede_2, string redirect)
        {
            m_Id = id;
            m_Dato = dato;
            m_OverSkrift = overskrift;
            m_Tekst = tekst;
            m_Billede_1 = billede_1;
            m_Billede_2 = billede_2;
            m_Redirect = redirect;

        }

        public long Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        //Disse datoer er SQL min og max... Skal naturligvis sættes i Hosten, men har ikke lige tid.
        private static readonly DateTime MinimumsDato = new DateTime(1753, 1, 1, 12, 0, 0);
        private static readonly DateTime MaximumsDato = new DateTime(9999, 12, 31, 23, 59, 59);
 
        public DateTime Dato
        {
            get { return m_Dato; }
            set
            {
                if (value < MinimumsDato)
                {
                    m_Dato = MinimumsDato;
                }
                else if (value > MaximumsDato)
                {
                    m_Dato = MaximumsDato;
                }
                else
                {
                    m_Dato = value;
                }
            }
        }


   
        public String OverSkrift
        {
            get { return m_OverSkrift; }
            set { m_OverSkrift = value; }
        }
   
        public String Tekst
        {
            get { return m_Tekst; }
            set { m_Tekst = value; }
        }
        public String Billede_1
        {
            get { return m_Billede_1; }
            set { m_Billede_1 = value; }
        }
        public String Billede_2
        {
            get { return m_Billede_2; }
            set { m_Billede_2 = value; }
        }
        public String Redirect
        {
            get { return m_Redirect; }
            set { m_Redirect = value; }
        }

    }
}

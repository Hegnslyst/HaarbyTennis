using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaarbyTennis.Model
{
    public class Medlem
    {
        private int m_Id;
        private string m_Fornavn ;
        private string m_Efternavn ;
        private string m_Adresse ;
        private string m_Postnummer  ;
        private string m_Bynavn  ;
        private string m_Tlf_1  ;       
        private string m_Email  ;
        private DateTime m_Foedselsdato  ;
        private decimal m_Kontingent  ;
        private decimal m_Noegle;
        private decimal m_Minitennis;
        private decimal m_Indendoers ;
        private string m_Rabat  ;
        private decimal m_Boldkanon  ;
        private bool m_JaTilNyheder ;
        private string m_OpdateretAfBruger;
        private bool m_Udmeldt;
        private int m_MasterPeriode;

        public Medlem() { }

          public Medlem
          (int Id,
          string Efternavn,     
          string Fornavn,
          string Adresse,
          string Postnummer,
          string Bynavn,
          string Tlf_1,     
          string Email,
          DateTime Foedselsdato,
          decimal Kontingent,   
          decimal Noegle,
          decimal Indendoers,    
          decimal Minitennis,            
          string Rabat,
          decimal Boldkanon,        
          bool JaTilNyheder,
          string OpdateretAfBruger,
          bool Udmeldt,
          int MasterPeriode
          )
        {
            m_Id = Id;
            m_Efternavn = Efternavn;  
            m_Fornavn = Fornavn;
            m_Adresse = Adresse;
            m_Postnummer = Postnummer;
            m_Bynavn = Bynavn;
            m_Tlf_1 = Tlf_1;         
            m_Email = Email;
            m_Foedselsdato = Foedselsdato;
            m_Kontingent = Kontingent;
            m_Noegle = Noegle;
            m_Indendoers = Indendoers;          
            m_Minitennis = Minitennis;
            m_Rabat = Rabat;
            m_Boldkanon = Boldkanon;           
            m_JaTilNyheder = JaTilNyheder;
            m_OpdateretAfBruger = OpdateretAfBruger;
            m_Udmeldt = Udmeldt;
            m_MasterPeriode = MasterPeriode;
            
            
        }
        
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        
        public String Fornavn
        {
            get { return m_Fornavn; }
            set { m_Fornavn = value; }
        }
        public String Efternavn
        {
            get { return m_Efternavn; }
            set { m_Efternavn = value; }
        }

        public String Adresse
        {
            get { return m_Adresse; }
            set { m_Adresse = value; }
        }

        public String Postnummer
        {
            get { return m_Postnummer; }
            set { m_Postnummer = value; }
        }
        public String Bynavn
        {
            get { return m_Bynavn; }
            set { m_Bynavn = value; }
        }
        public String Tlf_1
        {
            get { return m_Tlf_1; }
            set { m_Tlf_1 = value; }
        }
      

        public String Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }
            
        public DateTime Foedselsdato
        {
            get { return m_Foedselsdato; }
            set { m_Foedselsdato = value; }
        }

        public Decimal Kontingent
        {
            get { return m_Kontingent; }
            set { m_Kontingent = value; }
        }
       
        public Decimal Noegle
        {
            get { return m_Noegle; }
            set { m_Noegle = value; }
        }

        public Decimal Minitennis
        {
            get { return m_Minitennis; }
            set { m_Minitennis = value; }
        }

        public Decimal Indendoers
        {
            get { return m_Indendoers; }
            set { m_Indendoers = value; }
        }

        public String Rabat
        {
            get { return m_Rabat; }
            set { m_Rabat = value; }
        }

        public Decimal Boldkanon
        {
            get { return m_Boldkanon; }
            set { m_Boldkanon = value; }
        }

       
        public Boolean JaTilNyheder
        {
            get { return m_JaTilNyheder; }
            set { m_JaTilNyheder = value; }
        }

        public string OpdateretAfBruger
        {
            get { return m_OpdateretAfBruger; }
            set { m_OpdateretAfBruger = value; }
        }
        public bool Udmeldt
        {
            get { return m_Udmeldt; }
            set { m_Udmeldt = value; }
        }
        public int MasterPeriode
        {
            get { return m_MasterPeriode; }
            set { m_MasterPeriode = value; }
        }
        

    }
}

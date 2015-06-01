using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaarbyTennis.Model
{
    public class AdminitrationLog
    {
   
        private int m_Adm_Id;
        private DateTime m_LogTid;
        private string m_BrugerType;
        private string m_BrugerNavn;
        private string m_LogType;
        private string m_LogGruppe;
        private string m_Kilde;
        private string m_LogInfo;

        public AdminitrationLog() { }

        public AdminitrationLog
          (int Adm_Id,
          DateTime LogTid,
          string BrugerType,
          string BrugerNavn,
          string LogType,
          string LogGruppe,
          string Kilde,
          string LogInfo)
        {
            m_Adm_Id = Adm_Id;
            m_LogTid = LogTid;
            m_BrugerType = BrugerType;
            m_BrugerNavn = BrugerNavn;
            m_LogGruppe = LogGruppe;
            m_LogType = LogType;
            m_Kilde = Kilde;
            m_LogInfo = LogInfo;        
                   
            
        }
        
        public int Adm_Id
        {
            get { return m_Adm_Id; }
            set { m_Adm_Id = value; }
        }


        public DateTime LogTid
        {
            get { return m_LogTid; }
            set { m_LogTid = value; }
        }
        public String BrugerType
        {
            get { return m_BrugerType; }
            set { m_BrugerType = value; }
        }

        public String BrugerNavn
        {
            get { return m_BrugerNavn; }
            set { m_BrugerNavn = value; }
        }

        public String LogGruppe
        {
            get { return m_LogGruppe; }
            set { m_LogGruppe = value; }
        }
        public String LogType
        {
            get { return m_LogType; }
            set { m_LogType = value; }
        }
        public String Kilde
        {
            get { return m_Kilde; }
            set { m_Kilde = value; }
        }

        public String LogInfo
        {
            get { return m_LogInfo; }
            set { m_LogInfo = value; }
        }
            
      

        

    }
}

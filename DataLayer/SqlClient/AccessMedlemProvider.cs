using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.OleDb;
using HaarbyTennis.DAL;
using HaarbyTennis.Model;

namespace HaarbyTennis.DAL.SqlClient
{
    public class AccessMedlemProvider : MedlemProvider
    {
       
        /// <summary>
        /// Hent alle medlemmer
        /// </summary>
        public override List<HaarbyTennis.Model.Medlem> GetMedlemmer(string sortExpression, string medlemtype) 
        {

            string sqlStmt = "";
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sortExpression = EnsureValidProductsSortExpression(sortExpression);

                if (!string.IsNullOrWhiteSpace(medlemtype))
                {
                    switch (medlemtype)
                    {
                        case "1": //Vis Seniorer først. 
                            sqlStmt = string.Format("SELECT * FROM Medlemsoplysninger WHERE MasterPeriode = 0 ORDER BY Foedselsdato ASC");
                            break;
                        case "2"://Vis juniorer først
                            sqlStmt = string.Format("SELECT * FROM Medlemsoplysninger WHERE MasterPeriode = 0 ORDER BY Foedselsdato DESC");
                            break;
                        case "3"://Vis KUN Master
                            sqlStmt = string.Format("SELECT * FROM Medlemsoplysninger WHERE MasterPeriode > 0 ORDER BY Fornavn ASC");
                            break;
                        case "4"://Vis KUN Udmeldt
                            sqlStmt = string.Format("SELECT * FROM Medlemsoplysninger WHERE Udmeldt = 1 ORDER BY Fornavn ASC");
                            break;
                       

                    }
                }
                else
                {
                    sqlStmt = string.Format("SELECT * FROM Medlemsoplysninger WHERE MasterPeriode = 0 ORDER BY Fornavn ASC");
                }
                
                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                //OleDbDataReader objDataReader;
                //objDataReader = objCommand.ExecuteReader();
                
                return GetMedlemCollectionFromReader(ExecuteReader(objCommand));
                //return GetNyhedCollectionFromReader(ExecuteReader(cmd));
            }
        }


        /// <summary>
        /// Hent et enkelt medlem
        /// </summary>
        public override HaarbyTennis.Model.Medlem GetMedlemById(int medlemId)
        {

            string sqlStmt = "";
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {              
                sqlStmt = string.Format("SELECT * FROM Medlemsoplysninger WHERE Id = " + medlemId );
                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                objConn.Open();

                IDataReader reader = ExecuteReader(objCommand, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetMedlemFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Updates an product
        /// </summary>
        public override bool UpdateMedlem(Medlem medlem)
        {
            
            Int16 intJaTilNyheder = 0;
            if (medlem.JaTilNyheder)
                intJaTilNyheder = 1;
            else
                intJaTilNyheder = 0;
            
            Int16 intUdmeldt = 0;
            if (medlem.Udmeldt)
                intUdmeldt = 1;
            else
                intUdmeldt = 0;

            DateTime opdateretDatoTid = DateTime.Now;
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                //query += "update tbnewsletters set title = '" + Title + "', text = '" + Text + "', name = '" + Name.Replace("'", "''") + "', created = '" + UKDateTimeFormat(Created) + "' where id = " + Id;
                string sqlStmt = string.Format("update Medlemsoplysninger " + 
                    " set Efternavn     = '" +  medlem.Efternavn +
                    "', Fornavn         = '" + medlem.Fornavn + 
                    "', Adresse         = '" + medlem.Adresse + 
                    "', Postnummer      = '" + medlem.Postnummer + 
                    "', Bynavn          = '" + medlem.Bynavn + 
                    "', Tlf_1           = '" + medlem.Tlf_1 +                   
                    "', Email           = '" + medlem.Email + 
                    "', Foedselsdato    = '" + medlem.Foedselsdato +
                    "', Kontingent      = '" + medlem.Kontingent +
                    "', Nøgle           = '" + medlem.Noegle +
                    "', Indendørs       = '" + medlem.Indendoers + 
                    "', Minitennis      = '" + medlem.Minitennis +                  
                    "', Rabat           = '" + medlem.Rabat + 
                    "', Boldkanon       = '" + medlem.Boldkanon +                
                    "', JaTilNyheder    = '" + intJaTilNyheder +
                    "', SenestOpdateret = '" + opdateretDatoTid +
                    "', OpdateretAfBruger    = '" + "Lasse" +
                    "', Udmeldt         = '" + intUdmeldt +
                    "', MasterPeriode   = '" + medlem.MasterPeriode +      
                    "' where id = " + medlem.Id);
                    
                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                int ret = objCommand.ExecuteNonQuery();                 
                return (ret == 1);
                
             
            }
        }

        /// <summary>
        /// Indsætter et medlem
        /// </summary>
        public override bool InsertMedlem(Medlem medlem)
        {
            Int16 boolJaTilnyheder = 0;
            if (medlem.JaTilNyheder)
                boolJaTilnyheder = 1;
            else
                boolJaTilnyheder = 0;

            Int16 boolUdmeldt = 0;
            if (medlem.Udmeldt)
                boolUdmeldt = 1;
            else
                boolUdmeldt = 0;

             using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                //query += "insert into tbnewsletters (title, text, name, created) values ('" + Title.Replace("'", "''") + "', '" + Text.Replace("'", "''") + "', '" + Name.Replace("'", "''") + "', '" + UKDateTimeFormat(Created) + "')";
                //string sqlStmt = string.Format("insert into Medlemsoplysninger (Efternavn, Fornavn, Adresse, Postnummer, Bynavn, Tlf_1, Email, Foedselsdato, Kontingent, Indendørs, Rabat, Boldkanon, JaTilNyheder) values ('" + 
                //, Nøgle, Minitennis, JaTilNyheder, OpdateretAfBruger



                string sqlStmt = string.Format("insert into Medlemsoplysninger (Efternavn, Fornavn, Adresse, Postnummer, Bynavn, Tlf_1, Email, Foedselsdato, Kontingent, Indendørs, Rabat, Boldkanon, Nøgle, Minitennis, JaTilNyheder, OpdateretAfBruger, Udmeldt, MasterPeriode) values ('" + 
                    medlem.Efternavn    +  "', '" + 
                    medlem.Fornavn      +  "', '" + 
                    medlem.Adresse      +  "', '" + 
                    medlem.Postnummer   +  "', '" + 
                    medlem.Bynavn       +  "', '" + 
                    medlem.Tlf_1        +  "', '" + 
                    medlem.Email        +  "', '" + 
                    medlem.Foedselsdato +  "', '" + 
                    medlem.Kontingent   +  "', '" + 
                    medlem.Indendoers   +  "', '" + 
                    medlem.Rabat        +  "', '" + 
                    medlem.Boldkanon    +  "', '" +    
                    medlem.Noegle       +  "', '" + 
                    medlem.Minitennis   +  "', '" +
                    boolJaTilnyheder    +  "', '" +
                    medlem.OpdateretAfBruger + "', '" + 
                    boolUdmeldt         + "', '" + 
                    medlem.MasterPeriode +
   
                    "' )");
                    
                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                int ret = objCommand.ExecuteNonQuery();                 
                return (ret == 1);
                
             
            }
        }

        /// <summary>
        /// Indsætter et medlem
        /// </summary>
        public override bool InsertAdministrationsLog(AdminitrationLog loginfo)
        {
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))           
            {

                    string sqlStmt = string.Format("insert into TennisLog (LogTid, BrugerType, BrugerNavn, LogType, LogGruppe, Kilde, LogInfo) values ('" +
                    loginfo.LogTid + "', '" +
                    loginfo.BrugerType + "', '" +
                    loginfo.BrugerNavn + "', '" +
                    loginfo.LogType + "', '" +
                    loginfo.LogGruppe + "', '" +
                    loginfo.Kilde + "', '" +
                    loginfo.LogInfo + //"', '" +                   

                    "' )");

                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                int ret = objCommand.ExecuteNonQuery();
                return (ret == 1);


            }
        }
       

    }
}

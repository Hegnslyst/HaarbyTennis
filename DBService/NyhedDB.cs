using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;


namespace HaarbyTennis.DBService
{
    public class NyhedDB
    {
        #region Utility stuff

        private static string m_Fejltekst;

        public static string Fejltekst
        {
            get { return m_Fejltekst; }
            set { m_Fejltekst = value; }
        }


        public partial class Status1
        {

            private short returkodeField;

            private string returtekstField;

            private int antalField;

            private short samOpdatField;

            /// <remarks/>
            public short Returkode
            {
                get
                {
                    return this.returkodeField;
                }
                set
                {
                    this.returkodeField = value;
                }
            }

            /// <remarks/>
            public string Returtekst
            {
                get
                {
                    return this.returtekstField;
                }
                set
                {
                    this.returtekstField = value;
                }
            }

            /// <remarks/>
            public int Antal
            {
                get
                {
                    return this.antalField;
                }
                set
                {
                    this.antalField = value;
                }
            }
        }
        public static Status1 OKStatus1
        {
            get
            {
                Status1 s = new Status1();
                s.Returkode = 0;
                return s;
            }
        }
        public static Status1 FejlStatus1
        {
            get
            {
                Status1 s = new Status1();
                s.Returkode = 1;
                s.Returtekst = Fejltekst;
                return s;
            }
        }
    

       
        #endregion
        private static string ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Projects\KMD.YH.BibAppWin\Host\BibService\App_Data\DB2MockDB.mdf;Integrated Security=True;User Instance=True";

           

        #region Nyheder

        public static Status1 HentNyhederT(Nyheder soegekriterier, out NyhederTabel[] nyheder)
        {
            nyheder = null;
            try
            {
                List<NyhederTabel> nyhedListe = new List<NyhederTabel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string whereClause = BuildWhereClause(soegekriterier);
                    conn.Open();
                    Debug.WriteLine("SQL: " + string.Format("SELECT TOP " + (soegekriterier.MaxCount + 1).ToString() + " ID, ISBN, Titel, Forfatter, UdgAar, LaantAf, UdlaansDato, Version FROM BoegerTable {0}", whereClause));
                    using (SqlCommand cmd = new SqlCommand(string.Format("SELECT TOP " + (soegekriterier.MaxCount + 1).ToString() + " ID, ISBN, Titel, Forfatter, UdgAar, LaantAf, UdlaansDato, Version FROM BoegerTable {0}", whereClause), conn))
                    {
                        if (soegekriterier.NyhedInfo.ID > 0)
                        {
                            cmd.Parameters.Add("@ID", SqlDbType.NChar, 36);
                            cmd.Parameters["@ID"].Value = soegekriterier.NyhedInfo.ID;
                        }
                        if (!string.IsNullOrEmpty(soegekriterier.NyhedInfo.Dato))
                        {
                            cmd.Parameters.Add("@DATO", SqlDbType.NChar, 14);
                            cmd.Parameters["@DATO"].Value = soegekriterier.NyhedInfo.Dato;
                        }
                        if (!string.IsNullOrEmpty(soegekriterier.NyhedInfo.OverSkrift))
                        {
                            cmd.Parameters.Add(new SqlParameter("@Overskrift", "%" + soegekriterier.NyhedInfo.OverSkrift + "%"));
                        }
                        if (!string.IsNullOrEmpty(soegekriterier.NyhedInfo.Tekst))
                        {
                            cmd.Parameters.Add(new SqlParameter("@Tekst", "%" + soegekriterier.NyhedInfo.Tekst + "%"));
                        }


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nyhedListe.Add(BuildNyhederTabel(reader));
                            }
                        }
                    }
                }

                Status1 s = OKStatus1;
                s.Antal = nyhedListe.Count;
                if (s.Antal > soegekriterier.MaxCount)
                {
                    s.Returkode = 2;
                    s.Antal = soegekriterier.MaxCount;
                }

                //nyheder = new NyhederTabel[nyhedListe.Count];
                //int index = 0;
                //foreach (NyhederTabel bog in bogListe)
                //{
                //    boeger[index] = bog;
                //    index++;
                //    if (index == soegekriterier.MaxCount)
                //        break;
                //}
                return s;
            }
            catch (Exception ex)
            {
                Fejltekst = ex.ToString();
                return FejlStatus1;
            }
        }


        private static NyhederTabel BuildNyhederTabel(SqlDataReader reader)
        {
            NyhederTabel nyhed = new NyhederTabel();
            nyhed.ID = Convert.ToInt16(reader.GetValue(0));
            nyhed.Dato = Convert.ToString(reader.GetValue(1)).TrimEnd(' ');
            nyhed.OverSkrift = Convert.ToString(reader.GetValue(2)).TrimEnd(' ');
            nyhed.Tekst = Convert.ToString(reader.GetValue(3)).TrimEnd(' ');
            nyhed.Billede_1 = Convert.ToString(reader.GetValue(4)).TrimEnd(' ');
            nyhed.Billede_2 = Convert.ToString(reader.GetValue(5)).TrimEnd(' ');
            nyhed.Redirect = Convert.ToString(reader.GetValue(6)).TrimEnd(' ');
            return nyhed;
        }

        private static string BuildWhereClause(Nyheder soegekriterier)
        {
            bool addAnd = false;
            StringBuilder whereClause = new StringBuilder();
            //if (!string.IsNullOrEmpty(soegekriterier.BogInfo.ID))
            //{
            //    whereClause.Append(BuildEqualityClause("ID", ref addAnd));
            //}
            //if (!string.IsNullOrEmpty(soegekriterier.BogInfo.ISBN))
            //{
            //    whereClause.Append(BuildEqualityClause("ISBN", ref addAnd));
            //}
            //if (!string.IsNullOrEmpty(soegekriterier.BogInfo.Titel))
            //{
            //    whereClause.Append(BuildLikeClause("Titel", ref addAnd));
            //}
            //if (!string.IsNullOrEmpty(soegekriterier.BogInfo.Forfatter))
            //{
            //    whereClause.Append(BuildLikeClause("Forfatter", ref addAnd));
            //}
            //if (soegekriterier.BogInfo.UdgAar > 1000)
            //{
            //    whereClause.Append(BuildEqualityClause("UdgAar", ref addAnd));
            //}
            //if (!string.IsNullOrEmpty(soegekriterier.BogInfo.LaantAf))
            //{
            //    whereClause.Append(BuildEqualityClause("LaantAf", ref addAnd));
            //}
            //if (!string.IsNullOrEmpty(soegekriterier.BogInfo.UdlaansDato))
            //{
            //    whereClause.Append(BuildEqualityClause("UdlaansDato", ref addAnd));
            //}
            return whereClause.ToString();
        }

        #endregion
    }

    
}

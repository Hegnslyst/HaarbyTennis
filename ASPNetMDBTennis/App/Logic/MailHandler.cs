using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

using HaarbyTennis.Model;

namespace HaarbyTennis.App.Logic
{
    public class MailHandler
    {

        public enum eHendvendelseStatus
        {
            Fejl,
            Afsendt,
            EjAfsendt
        }
        public eHendvendelseStatus HenvendelseStatus { get;  set; }

        private ApplicationContext _appContext;

        public MailHandler(ApplicationContext appContext)
        {
            _appContext = appContext;
            MailAdresser = new List<string>();
            VedHaeftning = new List<MailContact>();
        }

        //En eller flere mailadresser på modtagere (Eksamenskontor mv.)
        public List <string> MailAdresser { get; set; }
        public string MailEmneIndhold { get; set; }
        public int MailEmneId { get; set; }
        public string MailEmneTekst { get; set; }
        public List <MailContact> VedHaeftning{ get; set; }


     
        
   
    //Håndtering af upload samt nedlægge filerne (folder i App_data).
    //Husk destructor
    //skrive mail ud fra skabelon - læs indholdet og lave replace.
    //Klasse FormmateretMail
    // - indlæs tekstfil (io) textreader
    // - objekt til læsning af mail

        /// <summary>
        /// Replaces text in a file.
        /// </summary>
        /// <param name="filePath">Path of the text file.</param>
        /// <param name="searchText">Text to search for.</param>
        /// <param name="replaceText">Text to replace the search text.</param>
        //TODO: Denne metode findes også i StudentContact.cs. Muligvis skal det flyttes til fælles Helpers\shared.cs
        static public void ReplaceInText(string content, string searchText, string replaceText, bool read)
        {            

            content = Regex.Replace(content, searchText, replaceText);
          
        }

        public void AddDocumentToMailContact(Byte[] document, string filename, DokumentType docType, string filePath)
        {
            MailContact contact = new MailContact();
            contact.DocNavn = filename;
            contact.Document = document;
            contact.DokumentTypeNavn = docType.Extension;
            contact.DocSize = document.Length;
            contact.FilePath = filePath;

            VedHaeftning.Add(contact);
        }

        internal void FinalReservationDokumenter(int aftaleId)
        {
            //DokumentAccess.AnonymousDocumentConnectAftale(_docGUID, aftaleId);
        }

        internal void DeleteDocument(int aftaleDokumenterId)
        {
            //DokumentAccess.SletDokument(aftaleDokumenterId);
        }


        //internal List<AftaleDokumenterViewModel> GetDokumenterListeViewModel()
        //{
        //    return DokumentAccess.GetDokumenterListeViewModel(_docGUID);
        //}
        
        
    }
   
}
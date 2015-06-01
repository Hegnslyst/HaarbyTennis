using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace HaarbyTennis.Model
{
    public class MailContact
    {

        public string DocGUID { get; set; }

        public string DocNavn { get; set; }

        public int DocSize { get; set; }
        
        public string FilePath { get; set; }

        public Byte[] Document { get; set; }

        public string Extension { get; set; }
        //public  Stream  Document { get; set; }
     
               
        //todo: Disse attributter kan sikkert fjernes - 
        public int DokumentTypeId { get; set; }

        public string DokumentTypeNavn { get; set; }

        public string DokumentTypeApplication { get; set; }

        public string MailDokumentId { get; set; }

        public DateTime OprettetTid { get; set; }

        public int? AftaleId { get; set; }

        public string Beskrivelse { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaarbyTennis.Model
{
    public class DokumentType
    {
        public int DokumentTypeId { get; set; }
        public string Extension { get; set; }
        public string Navn { get; set; }
        public byte[] Ikon { get; set; }
        public string Application { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KayaApp.Models.DataShowModels
{
    public class SiparisDetayModel
    {
        public DateTime SipTarih { get; set; }
        public DateTime TeslimTarih { get; set; }
        public string StokKod { get; set; } // stok kodu veya hizmet kodu
        public string StokAdi { get; set; } 
        public double Miktar { get; set; } 
        public double TeslimEdilen { get; set; }
        public double KalanMiktar { get; set; }
    }
}

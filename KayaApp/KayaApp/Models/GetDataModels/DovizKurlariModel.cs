using SQLite;
using System;

namespace KayaApp.Models
{
    public class DovizKurlariModel
    {
        [PrimaryKey, AutoIncrement]

        public int Kurlar_Local_id { get; set; }
        public int Kur_no { get; set; }
        public DateTime Kur_tarih { get; set; }
        public string Kur_fiyat1 { get; set; }
        public string Kur_fiyat2 { get; set; }

        private string _Kur_adi;
        public string Kur_adi
        {
            get { return _Kur_adi + ": " + Kur_fiyat1.ToString(); }
            set { _Kur_adi = value; }
        }
        public string Kur_sembol { get; set; }




    }
}
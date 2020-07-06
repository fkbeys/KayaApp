using SQLite;
using System;

namespace KayaApp.Models
{
    public class AktarimModel
    {
        [PrimaryKey, AutoIncrement]
        public int Local_Id_Aktarim { get; set; }
        public int Aktarim_IslemRecNo { get; set; }
        public int Aktarim_IslemKodu { get; set; }
        public string Aktarim_Baglanti_guid { get; set; }
        public string Aktarim_IslemAdi { get; set; }
        public DateTime Aktarim_Tarih { get; set; }
        public bool Aktarim_Sent { get; set; }
        public string Aktarim_Cari_Kod { get; set; }
        public string Aktarim_Cari_Isim { get; set; }
        public double Aktarim_Tutar { get; set; }
        public string Aktarim_IndirimTL { get; set; }
        public string Aktarim_IndirimYuzde { get; set; }


    }
}

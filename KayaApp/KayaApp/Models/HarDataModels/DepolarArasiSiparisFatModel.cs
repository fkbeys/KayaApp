using SQLite;
using System;

namespace KayaApp.Models
{
    public class DepolarArasiSiparisFatModel
    {
        [PrimaryKey, AutoIncrement]
        public int ssip_local_id { get; set; }
        public DateTime ssip_tarih { get; set; }
        public DateTime ssip_teslim_tarih { get; set; }
        public string ssip_evrak_seri { get; set; }
        public string ssip_stok_kod { get; set; }
        public double ssip_miktar { get; set; }
        public double ssip_tutar { get; set; }
        public string ssip_aciklama { get; set; }
        public int ssip_girdepo { get; set; }
        public int ssip_cikdepo { get; set; }
        public int ssip_fiyat_liste_no { get; set; }
        public string ssip_projekodu { get; set; }
        public string ssip_sormerkezi { get; set; }
        public double ssip_b_fiyat { get; set; }
        public string ssip_birim_ad { get; set; }
        public bool ssip_is_sent { get; set; }

        public int ssip_islemkodu { get; set; }
        public string ssip_islem_baglanti { get; set; }
        public int ssip_firma { get; set; }
        public int ssip_sube { get; set; }

        public int mikro_user_id { get; set; }

    }
}
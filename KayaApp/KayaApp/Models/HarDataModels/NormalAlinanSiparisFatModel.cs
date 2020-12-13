using SQLite;
using System;

namespace KayaApp.Models
{
    public class NormalAlinanSiparisFatModel  //:SatisFatModel
    {
        [PrimaryKey, AutoIncrement]
        public int sip_local_id { get; set; }               //ok
        public int sip_recno { get; set; }                   //ok
        public DateTime sip_tarih { get; set; }              //ok
        public DateTime sip_teslim_tarih { get; set; }      //ok
        public int sip_tip { get; set; }                     //ok
        public int sip_cins { get; set; }                   //ok
        public string sip_evrak_seri { get; set; } //ok
        public int sip_evrak_sira { get; set; } //ok
        public int sip_satirno { get; set; } //ok
        public int sip_satici_id { get; set; } //ok
        public string sip_cari_kod { get; set; } //ok
        public string sip_stok_kod { get; set; } //ok
        public string sip_birim_ad { get; set; } //ok

        public int sip_birim_pntr { get; set; } //ok
        public double sip_birim_fiyat { get; set; } //ok
        public double sip_miktar { get; set; }//ok
        public double sip_teslim_miktar { get; set; }
        public double sip_tutar { get; set; }//ok
        public double sip_iskonto1 { get; set; }//ok
        public double sip_iskonto2 { get; set; }//ok
        public int sip_vergi_pntr { get; set; }//ok
        public double sip_vergi { get; set; }//ok
        public string sip_aciklama { get; set; }   //ok
        public int sip_depo_no { get; set; }

        public string sip_cari_srm_mrkz { get; set; }
        public string sip_stok_srm_mrkz { get; set; }
        public string sip_cari_grupno { get; set; }
        public string sip_proje { get; set; }
        public bool sip_is_send { get; set; }
        public int sip_fiyat_liste_no { get; set; }

        public int sip_doviz_cinsi { get; set; }

        public double sip_doviz_kuru { get; set; }
        public string sip_doviz_ismi { get; set; }
        public int sip_islemkodu { get; set; }

        public string sip_islem_baglanti { get; set; }

        public string sip_renk_beden_seri_baglanti { get; set; }

        public int sip_firma { get; set; }
        public int sip_sube { get; set; }

        public int mikro_user_id { get; set; }           //ok

        public string Renk_beden_full_bilgi { get; set; }
    }
}
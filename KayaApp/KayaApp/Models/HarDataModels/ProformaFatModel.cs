using SQLite;
using System;

namespace KayaApp.Models
{
    public class ProformaFatModel
    {
        [PrimaryKey, AutoIncrement]
        public int pro_local_id { get; set; }               //ok
        public int pro_recno { get; set; }                  //ok
        public DateTime pro_tarih { get; set; }             //ok
        public DateTime pro_teslim_tarih { get; set; }      //ok
        public int pro_tip { get; set; }                    //ok
        public int pro_cins { get; set; }                   //ok
        public string pro_evrak_seri { get; set; }          //ok
        public int pro_evrak_sira { get; set; }             //ok
        public int pro_satirno { get; set; }                //ok
        public int pro_satici_id { get; set; }              //ok
        public string pro_cari_kod { get; set; }            //ok
        public string pro_stok_kod { get; set; }            //ok
        public int pro_birim { get; set; }
        public string pro_birim_ad { get; set; }         //ok
        public double pro_birim_fiyat { get; set; }         //ok
        public double pro_miktar { get; set; }              //ok
        public double pro_tutar { get; set; }               //ok
        public double pro_iskonto1 { get; set; }            //ok
        public double pro_iskonto2 { get; set; }            //ok
        public int pro_vergi_pntr { get; set; }             //ok
        public double pro_vergi { get; set; }               //ok
        public string pro_aciklama { get; set; }            //ok
        public int pro_depo_no { get; set; }                //ok
        public string pro_cari_srm_mrkz { get; set; }       //ok
        public string pro_stok_srm_mrkz { get; set; }       //ok
        public string pro_cari_grupno { get; set; }         //ok
        public string pro_proje { get; set; }               //ok
        public bool pro_is_send { get; set; }               //ok
        public int pro_dovizcinsi { get; set; }            //ok
        public double pro_dovizkuru { get; set; }          //ok
        public int pro_fiyat_liste_no { get; set; }

        public string pro_doviz_ismi { get; set; }
        public int pro_islemkodu { get; set; }
        public string pro_islem_baglanti { get; set; }

        public int pro_firma { get; set; }
        public int pro_sube { get; set; }

        public int mikro_user_id { get; set; }          //ok

    }
}

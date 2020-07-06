using KayaApp.Helpers;
using SQLite;
using System;
namespace KayaApp.Models
{
    public class SatisFatModel : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int fat_id { get; set; }
        public DateTime fat_tarih { get; set; }

        public string fat_personel { get; set; }

        public string fat_proje { get; set; }

        public string fat_cari_kod { get; set; }

        public string fat_srm_mrkzi { get; set; }

        public double fat_meblag { get; set; }


        private string _Gosterge_fat_meblag;

        public string Gosterge_fat_meblag
        {
            get
            {
                if (_Gosterge_fat_meblag == null)
                {
                    _Gosterge_fat_meblag = "0";
                }
                return NumericConverter.StringDecor(_Gosterge_fat_meblag.ToString());
            }
            set
            {
                _Gosterge_fat_meblag = value;
                INotifyPropertyChanged();

            }
        }


        public double fat_aratoplam { get; set; }

        public double fat_vergi1 { get; set; }

        public double fat_vergi2 { get; set; }

        public double fat_vergi3 { get; set; }

        public double fat_vergi4 { get; set; }

        public double fat_vergi5 { get; set; }

        public double fat_vergi6 { get; set; }

        public double fat_vergi7 { get; set; }

        public double fat_vergi8 { get; set; }

        public double fat_vergi9 { get; set; }

        public double fat_vergi10 { get; set; }

        public string fat_evrak_seri { get; set; }


        public int fat_evrak_tip { get; set; }

        public int fat_tip { get; set; }

        public string fat_aciklama { get; set; }

        public int fat_normal_Iade { get; set; }

        public string fat_kasa_hizkod { get; set; }

        public int fat_kasa_hizmet { get; set; }

        public int fat_d_cins { get; set; }

        public double fat_d_kur { get; set; }

        public int fat_cinsi { get; set; }

        public double fat_ft_iskonto1 { get; set; }

        public double fat_ft_iskonto2 { get; set; }

        public string fat_masraf_adi { get; set; }

        public int fat_cari_cins { get; set; }

        public int fat_karsidgrupno { get; set; }

        public DateTime fat_vade_tarihi { get; set; }

        public bool fat_sent { get; set; }
        public string fat_name { get; set; } //satis mi alis mi nesin kardes
        public bool fat_gonderim_hatali { get; set; }
        public string fat_sth_baglanti { get; set; }
        public int fat_islemkodu { get; set; }
        public int fat_firma { get; set; }
        public int fat_sube { get; set; }
        public int mikro_user_id { get; set; }
        public int fat_firmano { get; set; }
        public int fat_subeno { get; set; }
        public int fat_tpoz { get; set; }
        public int fat_grupno { get; set; }

        public int fat_vade { get; set; }
        public int fatura_acik_kasa_banka_belirteci { get; set; }


    }
}

using KayaApp.Helpers;
using SQLite;
using System;

namespace KayaApp.Models
{
    public class CustomerModel : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]

        public int cari_local_RECNO { get; set; }
        public int cari_RECno { get; set; }
        public string cari_kod { get; set; }
        private string _cari_unvan1;
        public string cari_unvan1
        {
            get
            {
                return _cari_unvan1;
            }
            set
            {
                _cari_unvan1 = value;
                INotifyPropertyChanged();
            }
        }
        public string cari_unvan2 { get; set; }
        public int cari_doviz_cinsi { get; set; }
        public int cari_fatura_adres_no { get; set; }
        public string cari_Ana_cari_kodu { get; set; }
        public string cari_satis_isk_kod { get; set; }
        private string _cari_sektor_kodu;
        public string cari_sektor_kodu
        {
            get
            {
                if (_cari_sektor_kodu == null)
                {
                    _cari_sektor_kodu = "";
                }
                return _cari_sektor_kodu;
            }
            set { _cari_sektor_kodu = value; }
        }
        public string cari_sektor_ismi { get; set; }
        public string cari_bolge_kodu { get; set; }
        public string cari_bolge_ismi { get; set; }
        public string cari_grup_kodu { get; set; }
        public string cari_grup_ismi { get; set; }
        public string cari_temsilci_kodu { get; set; }
        public string cari_temsilci_ismi { get; set; }
        private double _cari_bakiye;
        public double cari_bakiye
        {
            get
            {
                return Math.Round(_cari_bakiye, 2);
            }
            set { _cari_bakiye = Math.Round(value, 2); }
        }
        public string cari_vdaire_adi { get; set; }
        public string cari_vdaire_no { get; set; }
        public string cari_VergiKimlikNo { get; set; }
        public string cari_wwwadresi { get; set; }
        public string cari_EMail { get; set; }
        public string cari_CepTel { get; set; }
        public int cari_doviz1 { get; set; }
        public int cari_doviz2 { get; set; }
        public int cari_doviz3 { get; set; }
        public string cari_dovizName1 { get; set; }
        public string cari_dovizName2 { get; set; }
        public string cari_dovizName3 { get; set; }
        public double cari_teminat { get; set; }
        public int mikro_user_id { get; set; }
        //customer adress
        public int Adres_local_id { get; set; }
        public int Adr_mikro_userid { get; set; }
        public string Adr_cari_kod { get; set; }
        public string Adr_cadde { get; set; }
        public string Adr_sokak { get; set; }
        public string Adr_Posta { get; set; }
        public string Adr_ilce { get; set; }
        public string Adr_il { get; set; }
        public float Adr_enlem { get; set; }
        public float Adr_boylam { get; set; }
        public int cari_islemkodu { get; set; }

    }
}
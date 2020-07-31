using KayaApp.Helpers;
using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KayaApp.Models
{

    public class SatisSthModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }



        [PrimaryKey, AutoIncrement]
        public int sth_id
        {
            get;
            set;
        }

        public DateTime sth_tarih { get; set; }
        //public string sth_evrak { get; set; }

        public string sth_cari { get; set; }

        public string sth_birim_ad { get; set; }
        public int sth_birim_pntr { get; set; }

        public string sth_stok_kod { get; set; }

        public string sth_stok_isim { get; set; }

        //********************************************************

        private double _sth_miktar;
        public double sth_miktar
        {
            get
            {

                return _sth_miktar;
            }
            set
            {

                _sth_miktar = value;

                var carpim = Math.Round((sth_miktar * sth_fiyat), 3);
                //kayaround
                sth_tutar_gosterge = carpim.ToString();



                // OnPropertyChanged("sth_fiyat");
            }
        }

        //********************************************************
        private string _sth_miktar_gosterge;

        public string sth_miktar_gosterge
        {
            get
            {
                return NumericConverter.StringDecor(_sth_miktar_gosterge);
            }
            set
            {

                if (string.IsNullOrEmpty(_sth_miktar_gosterge))
                {
                    _sth_miktar_gosterge = "0";
                }
                //if (CumlSalesPage.SALESVMzz != null)
                //{
                //    CumlSalesPage.SALESVMzz.CalculateSum.Execute(sth_miktar_gosterge);
                //}
                //if (DetayliSatisPage.DetaySatVMZZ != null)
                //{
                //    DetayliSatisPage.DetaySatVMZZ.CalculateSum.Execute(sth_miktar_gosterge);
                //}
                //if (SarfCikisFisiPage.SarfCikisVMZZ != null)
                //{
                //    SarfCikisFisiPage.SarfCikisVMZZ.CalculateSum.Execute(sth_miktar_gosterge);
                //}

                _sth_miktar_gosterge = value;

                //  sth_miktar = NumericConverter.StringToDouble(NumericConverter.StringDecor(value));
                sth_miktar = NumericConverter.StringToDouble(sth_miktar_gosterge);

                OnPropertyChanged("sth_miktar_gosterge");
            }
        }


        //********************************************************

        //********************************************************
        private string _sth_fiyat_gosterge;

        public string sth_fiyat_gosterge
        {
            get
            {
                return NumericConverter.StringDecor(_sth_fiyat_gosterge);
            }
            set
            {
                _sth_fiyat_gosterge = value;
                sth_fiyat = NumericConverter.StringToDouble(NumericConverter.StringDecor(value));
                OnPropertyChanged("sth_fiyat_gosterge");
            }
        }


        //********************************************************

        //********************************************************
        private string _sth_tutar_gosterge;

        public string sth_tutar_gosterge
        {
            get
            {
                return _sth_tutar_gosterge.Replace(",", ".");
            }
            set
            {


                _sth_tutar_gosterge = value;
                sth_tutar = NumericConverter.StringToDouble(value);

                //if (CumlSalesPage.SALESVMzz != null)
                //{
                //    CumlSalesPage.SALESVMzz.CalculateSum.Execute(_sth_tutar_gosterge);
                //}

                //if (DetayliSatisPage.DetaySatVMZZ != null)
                //{
                //    DetayliSatisPage.DetaySatVMZZ.CalculateSum.Execute(_sth_tutar_gosterge);
                //}
                //if (SarfCikisFisiPage.SarfCikisVMZZ != null)
                //{
                //    SarfCikisFisiPage.SarfCikisVMZZ.CalculateSum.Execute(_sth_tutar_gosterge);
                //}



                OnPropertyChanged("sth_tutar_gosterge");
            }
        }


        //********************************************************
        private double _sth_tutar;

        public double sth_tutar
        {
            get
            {
                return _sth_tutar;
            }
            set
            {
                _sth_tutar = value;
            }
        }
        private double _sth_vergi_burut;

        public double sth_vergi_burut
        {
            get { return _sth_vergi_burut; }
            set { _sth_vergi_burut = value; }
        }


        //********************************************************

        private double _sth_fiyat;

        public double sth_fiyat
        {

            get { return _sth_fiyat; }
            set
            {
                _sth_fiyat = value;
                var carpim = Math.Round((sth_miktar * sth_fiyat), 3);
                //kayaround
                sth_tutar_gosterge = carpim.ToString();
                //  OnPropertyChanged();

            }
        }

        //********************************************************

        public double sth_vryuzde { get; set; }  //vryuzde 8

        // public double sth_vergi { get; set; } //vergi tutari  17azn

        private double _sth_vergi;

        public double sth_vergi
        {
            get
            {
                return _sth_vergi;  /*(sth_tutar * sth_vryuzde / 100);*///
            }
            set
            {
                _sth_vergi = value; /*(sth_tutar * sth_vryuzde / 100);*/ //
            }
        }
        public int sth_vergi_pntr { get; set; } // VERGI_NO 4 

        public double sth_iskonto1 { get; set; }

        //public double sth_iskonto2 { get; set; }
        private double _sth_iskonto2;

        public double sth_iskonto2
        {
            get { return _sth_iskonto2; }
            set
            {
                _sth_iskonto2 = value;
                OnPropertyChanged();
            }
        }

        private string _sth_iskonto2_info;

        public string sth_iskonto2_info
        {
            get { return _sth_iskonto2_info; }
            set
            {
                _sth_iskonto2_info = value;
                OnPropertyChanged();
            }
        }


        public double sth_iskonto3 { get; set; }

        private string _sth_srm_merkezi;
        public string sth_srm_merkezi
        {
            get
            {
                if (_sth_srm_merkezi == null)
                {
                    _sth_srm_merkezi = "";
                }
                return _sth_srm_merkezi;
            }
            set { _sth_srm_merkezi = value; }
        }
        public string sth_proje { get; set; }
        public int sth_depo { get; set; }
        public int sth_fiyat_liste_no { get; set; }
        public string sth_username_seri { get; set; }  //evrak seri no zimbirtasindan dolayi boyle bi sacmaliga girdim...

        public int sth_evraktip { get; set; }
        public int sth_tip { get; set; }
        public int sth_cins { get; set; }
        public int sth_cari_cins { get; set; }
        public bool sth_is_sent { get; set; }
        public int sth_normal_iade { get; set; }
        public int sth_doviz_cins { get; set; }
        public double sth_har_doviz_kur { get; set; }

        private string _sth_doviz_ismi;
        public string sth_doviz_ismi
        {
            get
            {
                if (_sth_doviz_ismi == null)
                {
                    _sth_doviz_ismi = "";
                }
                return _sth_doviz_ismi;
            }
            set
            {
                _sth_doviz_ismi = value;
                OnPropertyChanged();
            }
        }
        public int sth_cikis_depo_no { get; set; }
        public int sth_giris_depo_no { get; set; }
        public string sth_resim_url { get; set; }
        public string sth_fat_baglanti { get; set; }
        public int sth_islemkodu { get; set; }
        public int sth_firma { get; set; }
        public int sth_sube { get; set; }
        public int mikro_user_id { get; set; }
        public string sth_renk_beden_seri_baglanti { get; set; }
        public int sth_mikronfaturaid { get; set; }
        public int sth_odeme_op { get; set; }
        public string sth_isemri_gider_kodu { get; set; }
        public double sth_maliyet_ana { get; set; }
        public double sth_maliyet_alternatif { get; set; }
        public double sth_maliyet_orjinal { get; set; }
        public string sth_masraf_gider_adi { get; set; }

        private string _Renk_beden_full_bilgi;
        public string Renk_beden_full_bilgi
        {
            get { return _Renk_beden_full_bilgi; }
            set
            {
                _Renk_beden_full_bilgi = value;
                OnPropertyChanged();
            }
        }
        public string sth_parti_kodu { get; set; }
        public int sth_lot_no { get; set; }

        public bool isbedavalikampanya { get; set; }

    }
}
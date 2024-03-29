﻿using KayaApp.Helpers;
using KayaApp.Language;
using SQLite;
using System;
using System.Collections.ObjectModel;

namespace KayaApp.Models
{

    public class StockModel : BaseViewModel
    {
        // [PrimaryKey, AutoIncrement]

        //  public int Sto_local_RECNO { get; set; }

        [PrimaryKey]
        public int sto_RECno { get; set; }
        public int sto_RECid_RECno { get; set; }
        public string sto_kod { get; set; }
        //public string sto_isim { get; set; }
        private string _sto_isim;

        public string sto_isim
        {
            get { return _sto_isim; }
            set
            {
                _sto_isim = value;
                INotifyPropertyChanged();
            }
        }

        private string _sto_indirimbilgisi;

        public string sto_indirimbilgisi
        {
            get { return _sto_indirimbilgisi; }
            set
            {
                _sto_indirimbilgisi = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<string> _sto_bedavadurumu;
        [Ignore]

        public ObservableCollection<string> sto_bedavadurumu
        {
            get
            {
                if (_sto_bedavadurumu == null)
                {
                    sto_bedavadurumu = new ObservableCollection<string> { "Yok" };

                }
                return _sto_bedavadurumu;
            }
            set
            {
                _sto_bedavadurumu = value;
                INotifyPropertyChanged();
            }
        }

        private string _selectedKampanyabedavaitem;

        public string selectedKampanyabedavaitem
        {
            get
            {
                if (_selectedKampanyabedavaitem == null)
                {
                    _selectedKampanyabedavaitem = AppResources.Yok;
                }
                return _selectedKampanyabedavaitem;
            }
            set
            {
                if (value != null)
                {
                    _selectedKampanyabedavaitem = value;
                    INotifyPropertyChanged();
                }

            }
        }

        private bool _kampanyavisible;
        public bool kampanyavisible
        {
            get
            {
                return _kampanyavisible;
            }
            set
            {
                _kampanyavisible = value;
                INotifyPropertyChanged();
            }
        }

        public string sto_kisa_ismi { get; set; }
        public int sto_doviz_cinsi { get; set; }

        public string sto_doviz_ad { get; set; }
        public string sto_birim1_ad { get; set; }
        public double sto_birim1_katsayi { get; set; }
        public string sto_birim2_ad { get; set; }
        public double sto_birim2_katsayi { get; set; }
        public string sto_kategori_kodu { get; set; }
        public string sto_kategori_ismi { get; set; }
        public string sto_altgrup_kod { get; set; }
        public string sto_altgrup_ismi { get; set; }
        public string sto_anagrup_kod { get; set; }
        public string sto_anagrup_ismi { get; set; }
        public string sto_uretici_kodu { get; set; }
        public string sto_uretici_ismi { get; set; }
        public string sto_sektor_kodu { get; set; }
        public string sto_sektor_ismi { get; set; }
        public string sto_reyon_kodu { get; set; }
        public string sto_reyon_ismi { get; set; }
        public string sto_ambalaj_kodu { get; set; }
        public string sto_ambalaj_ismi { get; set; }
        public string sto_marka_kodu { get; set; }
        public string sto_marka_ismi { get; set; }
        public string sto_beden_kodu { get; set; }
        public string sto_beden_ismi { get; set; }
        public string sto_renk_kodu { get; set; }
        public string sto_renk_ismi { get; set; }
        public string sto_model_kodu { get; set; }
        public string sto_model_ismi { get; set; }
        public string sto_hammadde_kodu { get; set; }
        public string sto_hammadde_ismi { get; set; }

        public bool sto_bedenli_takip { get; set; }

        public bool sto_renkDetayli { get; set; }

        public bool sto_pasif_fl { get; set; }

        public bool sto_eksiyedusebilir_fl { get; set; }

        public double sto_fiyat { get; set; }

        private string _sto_fiyat_gosterge;

        public string sto_fiyat_gosterge
        {
            get
            {

                return sto_fiyat.ToString().Replace(',', '.');
                //  return _sto_fiyat_gosterge;
            }
            set { _sto_fiyat_gosterge = value; }
        }



        private double _sto_eldeki_miktar;

        public double sto_eldeki_miktar
        {
            get
            {

                return _sto_eldeki_miktar;
            }
            set { _sto_eldeki_miktar = value; }
        }

        public double sto_perakende_vergi { get; set; }
        public double sto_toptan_vergi { get; set; }
        public int VERGI_NO { get; set; }
        public string vradi { get; set; }
        public double vryuzde { get; set; }

        private string _fiyat_plus_yuzde;

        public string fiyat_plus_yuzde
        {
            get
            {
                double final_price = Math.Round(sto_fiyat + (sto_fiyat * vryuzde / 100), 2);
                //return sto_fiyat.ToString() + "  " + vradi + "  =" + final_price.ToString() + AppResources.MoneyCurrency;
                return sto_fiyat.ToString() + "  +" + vradi + " " + sto_doviz_ad;

            }
            private set { _fiyat_plus_yuzde = value; }
        }


        private bool _IsVisibleVisualize;

        public bool IsVisibleVisualize
        {
            get { return _IsVisibleVisualize; }
            set
            {
                _IsVisibleVisualize = value;
            }
        }
        public string stok_resim_url { get; set; }

        public int stok_islemkodu { get; set; }

        public int sto_detay_takip { get; set; }

        //private double _sto_miktar;

        //public double sto_miktar
        //{
        //    get { return _sto_miktar; }
        //    set
        //    {
        //        _sto_miktar = value;
        //        INotifyPropertyChanged();
        //    }
        //}

        private string _sto_miktar;

        public string sto_miktar
        {
            get
            {
                if (_sto_miktar == null)
                {
                    _sto_miktar = "0";
                }
                return _sto_miktar;
            }
            set
            {
                _sto_miktar = value;
                INotifyPropertyChanged();
            }
        }


    }
}
using Acr.UserDialogs;
using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Language;
using KayaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace KayaApp.Views.CUSTOMERS
{
    public class CustomerAddVM : BaseViewModel
    {
        LISTMANAGER _LSTMANAGER;
        public ICommand SaveCariCommand { get; set; }



        public CustomerAddVM()
        {
            _LSTMANAGER = DataClass._LSTMANAGER;
            SaveCariCommand = new Command(SaveCariCommandGO);

            Cari_Isim = "";
            Cari_Soyisim = "";
            Cari_Tel = "";
            Cari_Vergi_Daire = "";
            Cari_Vergi_No = "";
            Cari_Email = "";
            Adres_Cadde = "";
            Adres_AptDaire = "";
            Adres_Il = "";
            Adres_Ilce = "";
            Adres_PostaKod = "";
            Enlem = 0;
            Boylam = 0;



        }

        #region Lists
        private ObservableCollection<KurIsimleriFullKurusModel> _KurIsimleriFullKurus;

        public ObservableCollection<KurIsimleriFullKurusModel> KurIsimleriFullKurus
        {
            get
            {
                if (_KurIsimleriFullKurus == null)
                {

                    _KurIsimleriFullKurus = _LSTMANAGER.KurIsimleriFullKurus;
                }
                return _KurIsimleriFullKurus;
            }
            set { _KurIsimleriFullKurus = value; }
        }

        private ObservableCollection<StokSektorlariModel> _Cari_Sektor_List;

        public ObservableCollection<StokSektorlariModel> Cari_Sektor_List
        {
            get
            {
                if (_Cari_Sektor_List == null)
                {

                    _Cari_Sektor_List = _LSTMANAGER.STOK_SEKTORLARI_LIST;
                }
                return _Cari_Sektor_List;
            }
            set { _Cari_Sektor_List = value; }
        }

        private ObservableCollection<CariHesapBolgeleriModel> _Cari_Bolgeleri_List;

        public ObservableCollection<CariHesapBolgeleriModel> Cari_Bolgeleri_List
        {
            get
            {
                if (_Cari_Bolgeleri_List == null)
                {

                    _Cari_Bolgeleri_List = _LSTMANAGER.CARI_HESAP_BOLGELERI;
                }
                return _Cari_Bolgeleri_List;
            }
            set { _Cari_Bolgeleri_List = value; }
        }

        private ObservableCollection<CariHesapGruplariModel> _Cari_Gruplari_List;

        public ObservableCollection<CariHesapGruplariModel> Cari_Gruplari_List
        {
            get
            {
                if (_Cari_Gruplari_List == null)
                {

                    _Cari_Gruplari_List = _LSTMANAGER.CARI_HESAP_GRUPLARI;
                }
                return _Cari_Gruplari_List;
            }
            set { _Cari_Gruplari_List = value; }
        }

        private ObservableCollection<CariPersonelTanimlariModel> _Cari_Temsilci_List;

        public ObservableCollection<CariPersonelTanimlariModel> Cari_Temsilci_List
        {
            get
            {
                if (_Cari_Temsilci_List == null)
                {

                    _Cari_Temsilci_List = _LSTMANAGER.CARI_PERSONEL_TANIMLARI_LIST;
                }
                return _Cari_Temsilci_List;
            }
            set { _Cari_Temsilci_List = value; }
        }

        private ObservableCollection<StokListeTanimlamalariModel> _Fiyat_Tanimlamalari;

        public ObservableCollection<StokListeTanimlamalariModel> Fiyat_Tanimlamalari
        {
            get
            {
                if (_Fiyat_Tanimlamalari == null)
                {

                    _Fiyat_Tanimlamalari = _LSTMANAGER.STOKLISTETANIMLAMALARILISTE;
                }
                return _Fiyat_Tanimlamalari;
            }
            set { _Fiyat_Tanimlamalari = value; }
        }
        #endregion

        #region selectedItems

        private KurIsimleriFullKurusModel _selected_para1;

        public KurIsimleriFullKurusModel selected_para1
        {
            get
            {
                if (_selected_para1 == null)
                {
                    _selected_para1 = _LSTMANAGER.KurIsimleriFullKurus[0];
                }
                return _selected_para1;
            }
            set
            {
                _selected_para1 = value;
            }
        }


        private KurIsimleriFullKurusModel _selected_para2;

        public KurIsimleriFullKurusModel selected_para2
        {
            get
            {
                if (_selected_para2 == null)
                {
                    _selected_para2 = _LSTMANAGER.KurIsimleriFullKurus[0];
                }
                return _selected_para2;
            }
            set
            {
                _selected_para2 = value;
            }
        }


        private KurIsimleriFullKurusModel _selected_para3;

        public KurIsimleriFullKurusModel selected_para3
        {
            get
            {
                if (_selected_para3 == null)
                {
                    _selected_para3 = _LSTMANAGER.KurIsimleriFullKurus[0];
                }
                return _selected_para3;
            }
            set
            {
                _selected_para3 = value;
            }
        }

        private StokSektorlariModel _SelectedSektor;

        public StokSektorlariModel SelectedSektor
        {
            get
            {
                if (_SelectedSektor == null)
                {
                    _SelectedSektor = new StokSektorlariModel();
                    _SelectedSektor.sktr_kod = "";
                }
                return _SelectedSektor;
            }
            set { _SelectedSektor = value; }
        }

        private CariHesapBolgeleriModel _SelectedBolge;

        public CariHesapBolgeleriModel SelectedBolge
        {
            get
            {
                if (_SelectedBolge == null)
                {
                    _SelectedBolge = new CariHesapBolgeleriModel();
                    _SelectedBolge.bol_kod = "";
                }
                return _SelectedBolge;
            }
            set { _SelectedBolge = value; }
        }

        private CariHesapGruplariModel _SelectedGrup;

        public CariHesapGruplariModel SelectedGrup
        {
            get
            {
                if (_SelectedGrup == null)
                {
                    _SelectedGrup = new CariHesapGruplariModel();
                    _SelectedGrup.crg_kod = "";
                }
                return _SelectedGrup;
            }
            set { _SelectedGrup = value; }
        }

        private CariPersonelTanimlariModel _SelectedPersonel;

        public CariPersonelTanimlariModel SelectedPersonel
        {
            get
            {
                if (_SelectedPersonel == null)
                {
                    _SelectedPersonel = new CariPersonelTanimlariModel();
                    _SelectedPersonel.cari_per_kod = "";
                }
                return _SelectedPersonel;
            }
            set { _SelectedPersonel = value; }
        }

        public StokListeTanimlamalariModel selectedFiyatListe { get; set; }


        #endregion


        #region properties

        public string Cari_Isim { get; set; }
        public string Cari_Soyisim { get; set; }
        public string Cari_Tel { get; set; }
        public string Cari_Vergi_Daire { get; set; }
        public string Cari_Vergi_No { get; set; }
        public string Cari_Email { get; set; }
        public string Adres_Cadde { get; set; }
        public string Adres_AptDaire { get; set; }
        public string Adres_Il { get; set; }
        public string Adres_Ilce { get; set; }
        public string Adres_PostaKod { get; set; }

        public float Enlem { get; set; }
        public float Boylam { get; set; }

        #endregion



        private async void SaveCariCommandGO(object obj)
        {
            try
            {


                if (!string.IsNullOrEmpty(Cari_Isim))
                {
                    UserDialogs.Instance.ShowLoading(AppResources.BilgiEkrani_YUKLENIYOR, MaskType.None);

                    List<CustomerModel> new_customer = new List<CustomerModel>();


                    new_customer.Add(new CustomerModel
                    {
                        cari_unvan1 = Cari_Isim,
                        cari_unvan2 = Cari_Soyisim,
                        cari_CepTel = Cari_Tel,
                        cari_vdaire_adi = Cari_Vergi_Daire,
                        cari_vdaire_no = Cari_Vergi_No,
                        cari_EMail = Cari_Email,
                        cari_doviz1 = selected_para1.KUR_NUMARASI,
                        cari_doviz2 = selected_para2.KUR_NUMARASI,
                        cari_doviz3 = selected_para3.KUR_NUMARASI,
                        cari_sektor_kodu = SelectedSektor.sktr_kod,
                        cari_bolge_kodu = SelectedBolge.bol_kod,
                        cari_grup_kodu = SelectedGrup.crg_kod,
                        cari_temsilci_kodu = SelectedPersonel.cari_per_kod,
                        cari_wwwadresi = "",
                        //ADRESS TANIMLARI
                        Adr_cadde = Adres_Cadde,
                        Adr_sokak = Adres_AptDaire,
                        Adr_il = Adres_Il,
                        Adr_ilce = Adres_Ilce,
                        Adr_Posta = Adres_PostaKod,
                        Adr_enlem = 0,
                        Adr_boylam = 0

                    });


                    var urlCARI = SabitUrl.SendCustomer(_LSTMANAGER.ACTIVECOMPANY.COMPANY_IP.ToString(), _LSTMANAGER.ACTIVECOMPANY.COMPANY_PORT.ToString(), _LSTMANAGER.ACTIVECOMPANY.COMPANY_DB_NAME);

                    if (urlCARI != null)
                    {
                        var durumFATURA = await ApiBaglan<CustomerModel>.VeriGonder(urlCARI, new_customer);

                    }

                    await DataClass.GetData(_LSTMANAGER.ACTIVECOMPANY, _LSTMANAGER.ACTIVEUSER);
                    UserDialogs.Instance.HideLoading();
                }



                await HelpME.SayfaKapat();
                await HelpME.SayfaKapat();

            }
            catch (Exception ex)
            {

                await HelpME.MessageShow("Cari Kayit Hatasi", ex.Message, "OK");
            }

        }
    }
}
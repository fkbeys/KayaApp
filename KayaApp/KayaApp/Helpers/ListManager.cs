using KayaApp.GetData;
using KayaApp.Models;
using KayaApp.Models.GetDataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace KayaApp.Helpers
{
    public class LISTMANAGER : BaseViewModel
    {

        public static LISTMANAGER Instance { get; set; } = new LISTMANAGER();

        public LISTMANAGER()
        {
            Getdata();
        }

        private async Task Getdata()
        {

            //if (STOCKLIST.Count == 0 && CUSTOMERLIST.Count == 0)
            //{

            //    List<StockModel> stokum = await LocalSQL<StockModel>.GETLISTALL();
            //    STOCKLIST = new ObservableCollection<StockModel>(stokum);


            //    List<CustomerModel> carim = await LocalSQL<CustomerModel>.GETLISTALL();
            //    CUSTOMERLIST = new ObservableCollection<CustomerModel>(carim);

            //    List<BarcodeModel> barkodum = await LocalSQL<BarcodeModel>.GETLISTALL();
            //    BARCODELIST = new ObservableCollection<BarcodeModel>(barkodum);

            //    List<MasrafModel> Masrafim = await LocalSQL<MasrafModel>.GETLISTALL();
            //    MASRAFLIST = new ObservableCollection<MasrafModel>(Masrafim);

                
            //}


        }

        private ObservableCollection<KurIsimleriFullKurusModel> _KurIsimleriFullKurus;
        public ObservableCollection<KurIsimleriFullKurusModel> KurIsimleriFullKurus
        {
            get
            {
                if (_KurIsimleriFullKurus == null)
                {
                    _KurIsimleriFullKurus = new ObservableCollection<KurIsimleriFullKurusModel>();
                }

                return _KurIsimleriFullKurus;
            }

            set
            {
                _KurIsimleriFullKurus = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StokSektorlariModel> _STOK_SEKTORLARI_LIST;
        public ObservableCollection<StokSektorlariModel> STOK_SEKTORLARI_LIST
        {
            get
            {
                if (_STOK_SEKTORLARI_LIST == null)
                {
                    _STOK_SEKTORLARI_LIST = new ObservableCollection<StokSektorlariModel>();
                }

                return _STOK_SEKTORLARI_LIST;
            }

            set
            {
                _STOK_SEKTORLARI_LIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<CariHesapBolgeleriModel> _CARI_HESAP_BOLGELERI;
        public ObservableCollection<CariHesapBolgeleriModel> CARI_HESAP_BOLGELERI
        {
            get
            {
                if (_CARI_HESAP_BOLGELERI == null)
                {
                    _CARI_HESAP_BOLGELERI = new ObservableCollection<CariHesapBolgeleriModel>();
                }

                return _CARI_HESAP_BOLGELERI;
            }

            set
            {
                _CARI_HESAP_BOLGELERI = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<CariHesapGruplariModel> _CARI_HESAP_GRUPLARI;
        public ObservableCollection<CariHesapGruplariModel> CARI_HESAP_GRUPLARI
        {
            get
            {
                if (_CARI_HESAP_GRUPLARI == null)
                {
                    _CARI_HESAP_GRUPLARI = new ObservableCollection<CariHesapGruplariModel>();
                }

                return _CARI_HESAP_GRUPLARI;
            }

            set
            {
                _CARI_HESAP_GRUPLARI = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<CariPersonelTanimlariModel> _CARI_PERSONEL_TANIMLARI_LIST;
        public ObservableCollection<CariPersonelTanimlariModel> CARI_PERSONEL_TANIMLARI_LIST
        {
            get
            {
                if (_CARI_PERSONEL_TANIMLARI_LIST == null)
                {
                    _CARI_PERSONEL_TANIMLARI_LIST = new ObservableCollection<CariPersonelTanimlariModel>();
                }

                return _CARI_PERSONEL_TANIMLARI_LIST;
            }

            set
            {
                _CARI_PERSONEL_TANIMLARI_LIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<MasraflarFatModel> _YAPILANMASRAFLIST;
        public ObservableCollection<MasraflarFatModel> YAPILANMASRAFLIST
        {
            get
            {
                if (_YAPILANMASRAFLIST == null)
                {
                    _YAPILANMASRAFLIST = new ObservableCollection<MasraflarFatModel>();
                }

                return _YAPILANMASRAFLIST;
            }

            set
            {
                _YAPILANMASRAFLIST = value;
                INotifyPropertyChanged();
            }
        }

        private UsersModel _ACTIVEUSER;
        public UsersModel ACTIVEUSER
        {
            get
            {
                if (_ACTIVEUSER == null)
                {
                    _ACTIVEUSER = new UsersModel();
                }

                return _ACTIVEUSER;
            }
            set
            {
                _ACTIVEUSER = value;
                INotifyPropertyChanged();
            }
        }

        private CompanyModel _ACTIVECOMPANY;
        public CompanyModel ACTIVECOMPANY
        {
            get
            {
                if (_ACTIVECOMPANY == null)
                {
                    _ACTIVECOMPANY = new CompanyModel();
                }

                return _ACTIVECOMPANY;
            }
            set
            {
                _ACTIVECOMPANY = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<DepoIsimleriModel> _DEPOISIMLERILIST;
        public ObservableCollection<DepoIsimleriModel> DEPOISIMLERILIST
        {
            get
            {
                if (_DEPOISIMLERILIST == null)
                {
                    _DEPOISIMLERILIST = new ObservableCollection<DepoIsimleriModel>();
                }

                return _DEPOISIMLERILIST;//.Where(x=>x.dep_tipi !=15).ToList();
                // dep_tip=15 nakliye deposu demekdir
            }

            set
            {
                _DEPOISIMLERILIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<DovizKurlariModel> _KURLARLISTE;
        public ObservableCollection<DovizKurlariModel> KURLARLISTE
        {
            get
            {
                if (_KURLARLISTE == null)
                {
                    _KURLARLISTE = new ObservableCollection<DovizKurlariModel>();
                }
                return _KURLARLISTE;
            }
            set
            {
                _KURLARLISTE = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StokListeTanimlamalariModel> _STOKLISTETANIMLAMALARILISTE;
        public ObservableCollection<StokListeTanimlamalariModel> STOKLISTETANIMLAMALARILISTE
        {
            get
            {
                if (_STOKLISTETANIMLAMALARILISTE == null)
                {
                    _STOKLISTETANIMLAMALARILISTE = new ObservableCollection<StokListeTanimlamalariModel>();
                }

                return _STOKLISTETANIMLAMALARILISTE;
            }

            set
            {
                _STOKLISTETANIMLAMALARILISTE = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StokFiyatlariModel> _STOKFIYATLARI;
        public ObservableCollection<StokFiyatlariModel> STOKFIYATLARI
        {
            get
            {
                if (_STOKFIYATLARI == null)
                {
                    _STOKFIYATLARI = new ObservableCollection<StokFiyatlariModel>();
                }

                return _STOKFIYATLARI;
            }

            set
            {
                _STOKFIYATLARI = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<MasrafModel> _MASRAFLIST;
        public ObservableCollection<MasrafModel> MASRAFLIST
        {
            get
            {
                if (_MASRAFLIST == null)
                {
                    _MASRAFLIST = new ObservableCollection<MasrafModel>();
                }

                return _MASRAFLIST;
            }

            set
            {
                _MASRAFLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<NormalAlinanSiparisSthModel> _ORDERLIST;
        public ObservableCollection<NormalAlinanSiparisSthModel> ORDERLIST
        {
            get
            {
                if (_ORDERLIST == null)
                {
                    _ORDERLIST = new ObservableCollection<NormalAlinanSiparisSthModel>();
                }

                return _ORDERLIST;
            }

            set
            {

                _ORDERLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<ProformaSthModel> _PROFORMALIST;
        public ObservableCollection<ProformaSthModel> PROFORMALIST
        {
            get
            {
                if (_PROFORMALIST == null)
                {
                    _PROFORMALIST = new ObservableCollection<ProformaSthModel>();
                }

                return _PROFORMALIST;
            }
            set
            {
                _PROFORMALIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<SayimSonuclariSthModel> _SAYIMSONUCLARILIST;
        public ObservableCollection<SayimSonuclariSthModel> SAYIMSONUCLARILIST
        {
            get
            {
                if (_SAYIMSONUCLARILIST == null)
                {
                    _SAYIMSONUCLARILIST = new ObservableCollection<SayimSonuclariSthModel>();
                }

                return _SAYIMSONUCLARILIST;
            }
            set
            {
                _SAYIMSONUCLARILIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<AlisSthModelXXX> _BUYLIST;
        public ObservableCollection<AlisSthModelXXX> BUYLIST
        {
            get
            {
                if (_BUYLIST == null)
                {
                    _BUYLIST = new ObservableCollection<AlisSthModelXXX>();
                }
                return _BUYLIST;
            }
            set
            {
                _BUYLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<DepolarArasiSiparisSthModel> _DEPOLAR_ARASI_SIPARISLIST;
        public ObservableCollection<DepolarArasiSiparisSthModel> DEPOLAR_ARASI_SIPARISLIST
        {
            get
            {
                if (_DEPOLAR_ARASI_SIPARISLIST == null)
                {
                    _DEPOLAR_ARASI_SIPARISLIST = new ObservableCollection<DepolarArasiSiparisSthModel>();
                }

                return _DEPOLAR_ARASI_SIPARISLIST;
            }
            set
            {
                _DEPOLAR_ARASI_SIPARISLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<DepolarArasiNakliyeSthModel> _DEPOLAR_ARASI_NAKLIYELIST;
        public ObservableCollection<DepolarArasiNakliyeSthModel> DEPOLAR_ARASI_NAKLIYELIST
        {
            get
            {
                if (_DEPOLAR_ARASI_NAKLIYELIST == null)
                {
                    _DEPOLAR_ARASI_NAKLIYELIST = new ObservableCollection<DepolarArasiNakliyeSthModel>();
                }

                return _DEPOLAR_ARASI_NAKLIYELIST;
            }
            set
            {
                _DEPOLAR_ARASI_NAKLIYELIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<DepolarArasiSevkSthModel> _DEPOLARARASITRFLIST;
        public ObservableCollection<DepolarArasiSevkSthModel> DEPOLARARASITRFLIST
        {
            get
            {
                if (_DEPOLARARASITRFLIST == null)
                {
                    _DEPOLARARASITRFLIST = new ObservableCollection<DepolarArasiSevkSthModel>();
                }

                return _DEPOLARARASITRFLIST;
            }

            set
            {
                _DEPOLARARASITRFLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<AlisIrsaliyesiSthModel> _ALISIRSALIYESILIST;
        public ObservableCollection<AlisIrsaliyesiSthModel> ALISIRSALIYESILIST
        {
            get
            {
                if (_ALISIRSALIYESILIST == null)
                {
                    _ALISIRSALIYESILIST = new ObservableCollection<AlisIrsaliyesiSthModel>();
                }

                return _ALISIRSALIYESILIST;
            }

            set
            {
                _ALISIRSALIYESILIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<SatisIrsaliyesiSthModel> _SATISIRSALIYESILIST;
        public ObservableCollection<SatisIrsaliyesiSthModel> SATISIRSALIYESILIST
        {
            get
            {
                if (_SATISIRSALIYESILIST == null)
                {
                    _SATISIRSALIYESILIST = new ObservableCollection<SatisIrsaliyesiSthModel>();
                }

                return _SATISIRSALIYESILIST;
            }

            set
            {
                _SATISIRSALIYESILIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<SatisSthModel> _SALESLIST;
        public ObservableCollection<SatisSthModel> SALESLIST
        {
            get
            {
                if (_SALESLIST == null)
                {
                    _SALESLIST = new ObservableCollection<SatisSthModel>();
                }

                return _SALESLIST;
            }

            set
            {

                _SALESLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<OdemeYontemiModel> _ODEMEYONTEMLERI;
        public ObservableCollection<OdemeYontemiModel> ODEMEYONTEMLERI
        {
            get
            {
                if (_ODEMEYONTEMLERI == null)
                {
                    _ODEMEYONTEMLERI = new ObservableCollection<OdemeYontemiModel>();
                    ODEMEYONTEMLERI.Add(new OdemeYontemiModel { Odeme_Id = 0, Odeme_Hesap_Kodu = ACTIVEUSER.USERS_DEFAULT_KASA, Odeme_Hesap_Ismi = "Nakit Kasa" });
                    ODEMEYONTEMLERI.Add(new OdemeYontemiModel { Odeme_Id = 1, Odeme_Hesap_Kodu = ACTIVEUSER.USERS_DEFAULT_BANKA, Odeme_Hesap_Ismi = "Musteri KrediKarti" });
                    ODEMEYONTEMLERI.Add(new OdemeYontemiModel { Odeme_Id = 2, Odeme_Hesap_Kodu = ACTIVEUSER.USERS_DEFAULT_CEKKASA, Odeme_Hesap_Ismi = "Musteri Ceki" });
                    ODEMEYONTEMLERI.Add(new OdemeYontemiModel { Odeme_Id = 3, Odeme_Hesap_Kodu = ACTIVEUSER.USERS_DEFAULT_SENETKASA, Odeme_Hesap_Ismi = "Musteri Senedi" });
                }
                return _ODEMEYONTEMLERI;
            }
            set
            {
                _ODEMEYONTEMLERI = value;
            }
        }

        private ObservableCollection<BarcodeModel> _BARCODELIST;
        public ObservableCollection<BarcodeModel> BARCODELIST
        {
            get { return _BARCODELIST; }
            set { _BARCODELIST = value; }
        }

        private ObservableCollection<StockModel> _STOCKLIST;
        public ObservableCollection<StockModel> STOCKLIST
        {
            get
            {
                if (_STOCKLIST == null)
                {
                    _STOCKLIST = new ObservableCollection<StockModel>();
                }
                return _STOCKLIST;


            }
            set
            {
                _STOCKLIST = value;
            }
        }

        private ObservableCollection<CustomerModel> _CUSTOMERLIST;
        public ObservableCollection<CustomerModel> CUSTOMERLIST
        {
            get
            {
                if (_CUSTOMERLIST == null)
                {
                    _CUSTOMERLIST = new ObservableCollection<CustomerModel>();
                }
                return _CUSTOMERLIST;
            }
            set
            {


                _CUSTOMERLIST = value;
            }
        }

        private ObservableCollection<FirmalarModel> _FirmalarList;
        public ObservableCollection<FirmalarModel> FirmalarList
        {
            get
            {
                if (_FirmalarList == null)
                {
                    _FirmalarList = new ObservableCollection<FirmalarModel>();
                }

                return _FirmalarList;
            }

            set
            {
                _FirmalarList = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<SubelerModel> _SubelerList;
        public ObservableCollection<SubelerModel> SubelerList
        {
            get
            {
                if (_SubelerList == null)
                {
                    _SubelerList = new ObservableCollection<SubelerModel>();
                }

                return _SubelerList;
            }

            set
            {
                _SubelerList = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<RenkModel> _Renkler;
        public ObservableCollection<RenkModel> Renkler
        {
            get
            {
                if (_Renkler == null)
                {
                    _Renkler = new ObservableCollection<RenkModel>();
                }

                return _Renkler;
            }

            set
            {
                _Renkler = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<BedenModel> _Bedenler;
        public ObservableCollection<BedenModel> Bedenler
        {
            get
            {
                if (_Bedenler == null)
                {
                    _Bedenler = new ObservableCollection<BedenModel>();
                }

                return _Bedenler;
            }

            set
            {
                _Bedenler = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<ProjeModel> _Projeler;
        public ObservableCollection<ProjeModel> Projeler
        {
            get
            {
                if (_Projeler == null)
                {
                    _Projeler = new ObservableCollection<ProjeModel>();
                }

                return _Projeler;
            }

            set
            {
                _Projeler = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<SorumlulukModel> _Sorumluluklar;
        public ObservableCollection<SorumlulukModel> Sorumluluklar
        {
            get
            {
                if (_Sorumluluklar == null)
                {
                    _Sorumluluklar = new ObservableCollection<SorumlulukModel>();
                }

                return _Sorumluluklar;
            }

            set
            {
                _Sorumluluklar = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<BankaModel> _Bankalar;
        public ObservableCollection<BankaModel> Bankalar
        {
            get
            {
                if (_Bankalar == null)
                {
                    _Bankalar = new ObservableCollection<BankaModel>();
                }

                return _Bankalar;
            }

            set
            {
                _Bankalar = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<KasaModel> _Kasalar;
        public ObservableCollection<KasaModel> Kasalar
        {
            get
            {
                if (_Kasalar == null)
                {
                    _Kasalar = new ObservableCollection<KasaModel>();
                }

                return _Kasalar;
            }

            set
            {
                _Kasalar = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<OdemePlanlariModel> _OdemePlanlari;
        public ObservableCollection<OdemePlanlariModel> OdemePlanlari
        {
            get
            {
                if (_OdemePlanlari == null)
                {
                    _OdemePlanlari = new ObservableCollection<OdemePlanlariModel>();
                }

                return _OdemePlanlari;
            }

            set
            {
                _OdemePlanlari = value;
                INotifyPropertyChanged();
            }
        }


        private ObservableCollection<Normal_Iade_Model> _Normal_Iade;
        public ObservableCollection<Normal_Iade_Model> Normal_Iade
        {
            get
            {
                if (_Normal_Iade == null)
                {
                    _Normal_Iade = new ObservableCollection<Normal_Iade_Model>();
                    _Normal_Iade.Add(new Normal_Iade_Model { Normal_Iade_ID = 0, Normal_Iade = "Normal" });
                    _Normal_Iade.Add(new Normal_Iade_Model { Normal_Iade_ID = 1, Normal_Iade = "Iade" });

                }

                return _Normal_Iade;
            }

            set { _Normal_Iade = value; }
        }

        private ObservableCollection<Acik_Kapali_Model> _Acik_Kapali;
        public ObservableCollection<Acik_Kapali_Model> Acik_Kapali
        {
            get
            {
                if (_Acik_Kapali == null)
                {
                    _Acik_Kapali = new ObservableCollection<Acik_Kapali_Model>();

                    ////kullanici bilgisi cektigimiz zaman, gelen default kasa ve banka bilgilerini burada kullaniyoruz
                    //Acik_Kapali.Add(new Acik_Kapali_Model { Acik_Kapali_ID = 0, Kapama_Sekli = "Acik Hesap", Kapama_Sekli_kodu = "" });

                    //Acik_Kapali.Add(new Acik_Kapali_Model { Acik_Kapali_ID = 1, Kapama_Sekli = "Kasadan Kapanacak", Kapama_Sekli_kodu = ACTIVEUSER.USERS_DEFAULT_KASA });

                    //Acik_Kapali.Add(new Acik_Kapali_Model { Acik_Kapali_ID = 2, Kapama_Sekli = "Bankadan Kapanacak", Kapama_Sekli_kodu = ACTIVEUSER.USERS_DEFAULT_BANKA });



                }

                return _Acik_Kapali;
            }

            set { _Acik_Kapali = value; }
        }

        private ObservableCollection<SatisSthModel> _DETAYLISALESLIST;
        public ObservableCollection<SatisSthModel> DETAYLISALESLIST
        {
            get
            {
                if (_DETAYLISALESLIST == null)
                {
                    _DETAYLISALESLIST = new ObservableCollection<SatisSthModel>();
                }

                return _DETAYLISALESLIST;
            }

            set
            {

                _DETAYLISALESLIST = value;
                INotifyPropertyChanged();
            }
        }


        private ObservableCollection<SatisSthModel> _SarfCikisList;
        public ObservableCollection<SatisSthModel> SarfCikisList
        {
            get
            {
                if (_SarfCikisList == null)
                {
                    _SarfCikisList = new ObservableCollection<SatisSthModel>();
                }

                return _SarfCikisList;
            }

            set
            {

                _SarfCikisList = value;
                INotifyPropertyChanged();
            }
        }




        private List<OlusanRenkBedenSeriHareketleriModel> _DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI;

        public List<OlusanRenkBedenSeriHareketleriModel> DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI
        {
            get
            {
                if (_DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI == null)
                {
                    _DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI = new List<OlusanRenkBedenSeriHareketleriModel>();
                }
                return _DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI;
            }
            set { _DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI = value; }
        }


        private List<OlusanRenkBedenSeriHareketleriModel> _SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI;

        public List<OlusanRenkBedenSeriHareketleriModel> SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI
        {
            get
            {
                if (_SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI == null)
                {
                    _SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI = new List<OlusanRenkBedenSeriHareketleriModel>();
                }
                return _SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI;
            }
            set { _SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI = value; }
        }

        private ObservableCollection<PartiLotModel> _PartiLotList;
        public ObservableCollection<PartiLotModel> PartiLotList
        {
            get
            {
                if (_PartiLotList == null)
                {
                    _PartiLotList = new ObservableCollection<PartiLotModel>();
                }
                return _PartiLotList;
            }
            set
            {
                _PartiLotList = value;
                INotifyPropertyChanged();
            }
        }


        private ObservableCollection<KampanyalarModel> _KampanyalarList;
        public ObservableCollection<KampanyalarModel> KampanyalarList
        {
            get
            {
                if (_KampanyalarList == null)
                {
                    _KampanyalarList = new ObservableCollection<KampanyalarModel>();
                }
                return _KampanyalarList;
            }
            set
            {
                _KampanyalarList = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<IzinlerModel> _IzinlerList;
        public ObservableCollection<IzinlerModel> IzinlerList
        {
            get
            {
                if (_IzinlerList == null)
                {
                    _IzinlerList = new ObservableCollection<IzinlerModel>();
                }
                return _IzinlerList;
            }
            set
            {
                _IzinlerList = value;
                INotifyPropertyChanged();
            }
        }


        private ObservableCollection<SatisSartlariModel> _SATISSARTLARI;
        public ObservableCollection<SatisSartlariModel> SATISSARTLARI
        {
            get
            {
                if (_SATISSARTLARI == null)
                {
                    _SATISSARTLARI = new ObservableCollection<SatisSartlariModel>();
                }

                return _SATISSARTLARI;
            }

            set
            {
                _SATISSARTLARI = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StokPaketleriModel> _STOKPAKETLERI;
        public ObservableCollection<StokPaketleriModel> STOKPAKETLERI
        {
            get
            {
                if (_STOKPAKETLERI == null)
                {
                    _STOKPAKETLERI = new ObservableCollection<StokPaketleriModel>();
                }

                return _STOKPAKETLERI;
            }

            set
            {
                _STOKPAKETLERI = value;
                INotifyPropertyChanged();
            }
        }
        

    }
}
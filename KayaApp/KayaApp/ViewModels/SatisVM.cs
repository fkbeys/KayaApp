using Acr.UserDialogs;
using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Language;
using KayaApp.Methods;
using KayaApp.Models;
using KayaApp.Models.DataShowModels;
using KayaApp.Models.GetDataModels;
using KayaApp.Views.POPUP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Mobile;

namespace KayaApp.ViewModels
{
    public class SatisVM : BaseViewModel
    {
        readonly LISTMANAGER _LSTMANAGER;
        public static bool AktarimTaraftanGeliyorum = false;
        private static int stoklistyardimcisi = 0;

        #region commands
        public ICommand RenkBedenUP1 { get; set; }
        public ICommand RenkBedenUP2 { get; set; }
        public ICommand RenkBedenUP3 { get; set; }
        public ICommand RenkBedenUP4 { get; set; }
        public ICommand RenkBedenUP5 { get; set; }
        public ICommand RenkBedenUP6 { get; set; }
        public ICommand RenkBedenUP7 { get; set; }
        public ICommand RenkBedenUP8 { get; set; }
        public ICommand RenkBedenUP9 { get; set; }
        public ICommand RenkBedenUP10 { get; set; }
        public ICommand RenkBedenDOWN1 { get; set; }
        public ICommand RenkBedenDOWN2 { get; set; }
        public ICommand RenkBedenDOWN3 { get; set; }
        public ICommand RenkBedenDOWN4 { get; set; }
        public ICommand RenkBedenDOWN5 { get; set; }
        public ICommand RenkBedenDOWN6 { get; set; }
        public ICommand RenkBedenDOWN7 { get; set; }
        public ICommand RenkBedenDOWN8 { get; set; }
        public ICommand RenkBedenDOWN9 { get; set; }
        public ICommand RenkBedenDOWN10 { get; set; }

        public ICommand SeriNoUP1 { get; set; }
        public ICommand SeriNoUP2 { get; set; }
        public ICommand SeriNoUP3 { get; set; }
        public ICommand SeriNoUP4 { get; set; }
        public ICommand SeriNoUP5 { get; set; }
        public ICommand SeriNoUP6 { get; set; }

        public ICommand SeriNoDOWN1 { get; set; }
        public ICommand SeriNoDOWN2 { get; set; }
        public ICommand SeriNoDOWN3 { get; set; }
        public ICommand SeriNoDOWN4 { get; set; }
        public ICommand SeriNoDOWN5 { get; set; }
        public ICommand SeriNoDOWN6 { get; set; }
        public ICommand EkleStockButton { get; set; }

        public ICommand BtnTemizlikYap { get; set; }
        public ICommand BtnKaydet { get; set; }
        public ICommand EditSTH { get; set; }
        public ICommand DeleteSTH { get; set; }
        public ICommand BtnCariGoster { get; set; }
        public ICommand BtnStokGoster { get; set; }
        public ICommand CalculateSum { get; set; }
        public ICommand Amount_Increase { get; set; }
        public ICommand Amount_Decrease { get; set; }
        public ICommand CameraBarcode { get; set; }
        public ICommand BarcodeReaderCompletedCommand { get; protected set; }

        public ICommand StokListSirala { get; set; }

        public ICommand StokListFiltre { get; set; }

        public ICommand FiltreTiklamaGorunurlugu { get; set; }

        public ICommand FilitreUygula { get; set; }
        public ICommand FilitreTemizle { get; set; }

        public ICommand EvrakCagirBtn { get; set; }

        public ICommand SelectedStockPaketi { get; set; }

        public ICommand Amount_Decrease_Sade { get; set; }
        public ICommand Amount_Increase_Sade { get; set; }
        public ICommand Stock_Add_Sade { get; set; }

        #endregion
        
        //ctor
        public SatisVM()
        {
            _LSTMANAGER = DataClass._LSTMANAGER;

            BtnCariGoster = new Command(BtnCariGosterGO);
            BtnStokGoster = new Command(BtnStokGosterGO);
            CalculateSum = new Command(CalculateSumGO);

            BtnTemizlikYap = new Command(BtnTemizlikYapGO);

            Amount_Increase = new Command(Amount_IncreaseGO);
            Amount_Decrease = new Command(Amount_DecreaseGO);

            EditSTH = new Command(EditSTHGOAsync);
            DeleteSTH = new Command(DeleteSTHGO);

            EkleStockButton = new Command(EkleStockButtonGO);

            BtnKaydet = new Command(BtnKaydetGO);

            CameraBarcode = new Command(CameraBarcodeGO);
            BarcodeReaderCompletedCommand = new Command(_ => BarcodeReaderCompletedGO(_));


            RenkBedenUP1 = new Command(RenkBedenUP1GO);
            RenkBedenUP2 = new Command(RenkBedenUP2GO);
            RenkBedenUP3 = new Command(RenkBedenUP3GO);
            RenkBedenUP4 = new Command(RenkBedenUP4GO);
            RenkBedenUP5 = new Command(RenkBedenUP5GO);
            RenkBedenUP6 = new Command(RenkBedenUP6GO);
            RenkBedenUP7 = new Command(RenkBedenUP7GO);
            RenkBedenUP8 = new Command(RenkBedenUP8GO);
            RenkBedenUP9 = new Command(RenkBedenUP9GO);
            RenkBedenUP10 = new Command(RenkBedenUP10GO);

            RenkBedenDOWN1 = new Command(RenkBedenDOWN1GO);
            RenkBedenDOWN2 = new Command(RenkBedenDOWN2GO);
            RenkBedenDOWN3 = new Command(RenkBedenDOWN3GO);
            RenkBedenDOWN4 = new Command(RenkBedenDOWN4GO);
            RenkBedenDOWN5 = new Command(RenkBedenDOWN5GO);
            RenkBedenDOWN6 = new Command(RenkBedenDOWN6GO);
            RenkBedenDOWN7 = new Command(RenkBedenDOWN7GO);
            RenkBedenDOWN8 = new Command(RenkBedenDOWN8GO);
            RenkBedenDOWN9 = new Command(RenkBedenDOWN9GO);
            RenkBedenDOWN10 = new Command(RenkBedenDOWN10GO);

            SeriNoUP1 = new Command(SeriNoUP1GO);
            SeriNoUP2 = new Command(SeriNoUP2GO);
            SeriNoUP3 = new Command(SeriNoUP3GO);
            SeriNoUP4 = new Command(SeriNoUP4GO);
            SeriNoUP5 = new Command(SeriNoUP5GO);
            SeriNoUP6 = new Command(SeriNoUP6GO);

            SeriNoDOWN1 = new Command(SeriNoDOWN1GO);
            SeriNoDOWN2 = new Command(SeriNoDOWN2GO);
            SeriNoDOWN3 = new Command(SeriNoDOWN3GO);
            SeriNoDOWN4 = new Command(SeriNoDOWN4GO);
            SeriNoDOWN5 = new Command(SeriNoDOWN5GO);
            SeriNoDOWN6 = new Command(SeriNoDOWN6GO);

            StokListSirala = new Command(StokListSiralaGO);
            StokListFiltre = new Command(StokListFiltreGO);


            FilitreUygula = new Command(FilitreUygulaGO);
            FilitreTemizle = new Command(FilitreTemizleGO);

            EvrakCagirBtn = new Command(EvrakCagirBtnGO);

            SelectedStockPaketi = new Command(SelectedStockPaketiGO);

            Amount_Decrease_Sade = new Command(Amount_Decrease_SadeGO);
            Amount_Increase_Sade = new Command(Amount_Increase_SadeGO);

            Stock_Add_Sade = new Command(Stock_Add_SadeGO);

            Firmalar_list = _LSTMANAGER.FirmalarList;
            Subeler_list = _LSTMANAGER.SubelerList;
            Depolar_List = _LSTMANAGER.DEPOISIMLERILIST;
            Projeler_List = _LSTMANAGER.Projeler;
            Sorumluluk_List = _LSTMANAGER.Sorumluluklar;
            Fiyat_Listesi = _LSTMANAGER.STOKLISTETANIMLAMALARILISTE;
            Normal_Iade = _LSTMANAGER.Normal_Iade;
            DovizKurlari = _LSTMANAGER.KURLARLISTE;
            OdemePlanlari_List = _LSTMANAGER.OdemePlanlari;
            Acik_Kapali = new ObservableCollection<Acik_Kapali_Model>(_LSTMANAGER.Acik_Kapali.OrderBy(x => x.Acik_Kapali_ID));

            SelectedFirma = _LSTMANAGER.FirmalarList.Where(x => x.fir_sirano == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_FIRMA).FirstOrDefault();
            SelectedSube = _LSTMANAGER.SubelerList.Where(x => x.Sube_no == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_SUBE).FirstOrDefault();
            SelectedNormalIade = _LSTMANAGER.Normal_Iade[0];
            SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_KAYNAKDEPO).FirstOrDefault();
            SelectedFiyatListesi = _LSTMANAGER.STOKLISTETANIMLAMALARILISTE.Where(x => x.sfl_sirano == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_FIYATLISTESI).FirstOrDefault();
            SelectedDovizKuru = _LSTMANAGER.KURLARLISTE[0];
            SelectedProje = _LSTMANAGER.Projeler.Where(x => x.pro_kodu == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_PROJE).FirstOrDefault();
            SelectedSorumluluk = _LSTMANAGER.Sorumluluklar.Where(x => x.som_kod == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_SRM).FirstOrDefault();
            SelectedFiyatListesi = _LSTMANAGER.STOKLISTETANIMLAMALARILISTE.Where(x => x.sfl_sirano == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_FIYATLISTESI).FirstOrDefault();
            SelectedOdemePlani = _LSTMANAGER.OdemePlanlari[0];
            SelectedAcikKapali = _LSTMANAGER.Acik_Kapali.Where(x => x.Acik_Kapali_ID == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_ODEMEYON).FirstOrDefault();

            Tarih = DateTime.Today;

            SearchCustomerText = "";
            SearchStockText = "";

            RenkIsVisible = false;
            SerinoIsVisible = false;

            tutar = "0";
            isVisibleGRID = true;
            PartiLotList = _LSTMANAGER.PartiLotList;


        }

        #region GO METHODS
        private async void Amount_Decrease_SadeGO(object obj)
        {
            try
            {
                StockModel Stokinfo = (StockModel)obj;
                double.TryParse(Stokinfo.sto_miktar.Replace('.', ','), out double miktar);
                if (miktar > 1)
                {
                    miktar--;
                }
                Stokinfo.sto_miktar = miktar.ToString().Replace(',', '.');

            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("Stok miktar Decrease Hatası:", ex.Message, "Ok");

            }


        }

        private async void Amount_Increase_SadeGO(object obj)
        {
            try
            {
                StockModel Stokinfo = (StockModel)obj;
                double.TryParse(Stokinfo.sto_miktar.Replace('.', ','), out double miktar);
                miktar++;
                Stokinfo.sto_miktar = miktar.ToString().Replace(',', '.');
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("Stok miktar Increase Hatası:", ex.Message, "Ok");

            }


        }
        private async void Stock_Add_SadeGO(object obj)
        {
            try
            {
                StockModel Stokinfo = (StockModel)obj;

                if (Stokinfo.sto_miktar == "0") return;


                var hareketvarmi = DetayliSalesList.Where(x => x.sth_stok_kod == Stokinfo.sto_kod).FirstOrDefault();

                if (hareketvarmi == null)
                {
                    DetayliSalesList.Add
                 (
                 new SatisSthModel
                 {
                     sth_fiyat_gosterge = Stokinfo.sto_fiyat.ToString(),
                     sth_miktar_gosterge = Stokinfo.sto_miktar,
                     sth_stok_kod = Stokinfo.sto_kod,
                     sth_stok_isim = Stokinfo.sto_isim,
                     sth_birim_ad = Stokinfo.sto_birim1_ad,
                     sth_tarih = DateTime.Now.Date,
                     sth_vergi_pntr = Stokinfo.VERGI_NO,
                     sth_vryuzde = Stokinfo.vryuzde,
                     sth_doviz_cins = SelectedDovizKuru.Kur_no,
                     sth_har_doviz_kur = NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1),
                     sth_doviz_ismi = SelectedDovizKuru.Kur_sembol,
                     sth_resim_url = Stokinfo.stok_resim_url,
                     sth_renk_beden_seri_baglanti = "",
                     Renk_beden_full_bilgi = "",
                     sth_parti_kodu = "",
                     sth_lot_no = 0,
                     sth_cari = SelectedCustomerModel.cari_kod,
                 });

                }
                else
                {
                    double.TryParse(Stokinfo.sto_miktar.Replace('.', ','), out double miktar);
                    hareketvarmi.sth_miktar += miktar;
                    hareketvarmi.sth_miktar_gosterge = hareketvarmi.sth_miktar.ToString();


                }


                CalculateSumGO(this);



            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("Stock_Add_SadeGO Hatası:", ex.Message, "Ok");
            }

        }

        //Paket tanimlarindan bir paket secince bu calisiyor
        private async void SelectedStockPaketiGO(object obj)
        {
            try
            {
                var gelenbilgi = (StokPaketleriHeaders)obj;
                var paketbul = _LSTMANAGER.STOKPAKETLERI.Where(x => x.pak_kod == gelenbilgi.pak_kod).ToList();
                if (paketbul.Any())
                {


                    var birdenfazla_veya_bedelsiz_stoklar = paketbul.Where(x => x.pak_detay_tip == 1 && x.pak_ve_veya == 1).ToList();

                    if (birdenfazla_veya_bedelsiz_stoklar.Count > 1)
                    {
                        foreach (var item in birdenfazla_veya_bedelsiz_stoklar)
                        {
                            var stokbilgisi = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pak_stokkod);

                            if (stokbilgisi.Any())
                            {
                                item.pak_stokisim = stokbilgisi.FirstOrDefault().sto_isim;
                            }
                        }


                        TEMPPaketTanimlariVeya_bedava_stoklist = new ObservableCollection<StokPaketleriModel>(birdenfazla_veya_bedelsiz_stoklar);

                        await HelpME.PopAc(new StokPaketleriVeyaEkraniPage(this));


                        //veya +bedelsiz stoklardan sadece 1 tane sectirecegimiz ekrani aciyoruz.
                        //actigimiz ekranda kullanici hangi kaleme basarsa, onun *veya sini *ve yapip, 
                        //stok hareket ekledigimiz yere gonderiyoruz.
                        //orda kendisi ayarlicak herseyi...
                    }
                    else
                    {
                        paketislemlerinindevami(paketbul);
                    }


                }

            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("Stok Paketi Ekleme Hatasi", ex.Message, "OK");

            }

        }

        //bildigin gibi, paket olayinda veya li urunler meselesinden dolayi, await ile bi pop aciyoruz. o pop u sistem beklemedigi icin
        //mecburen method u 2 ye bolmek zorunda kaldim. Acilan pencerede,veya lardan 1 tanesi seciliyor. ve bu devam metoduna satis listesine eklenecek kayitlar geliyor...
        private async void paketislemlerinindevami(List<StokPaketleriModel> gelenpaketbilgileri)
        {


            var bedelliler = gelenpaketbilgileri.Where(x => x.pak_detay_tip == 0).ToList();
            double toplam_miktar_carpi_fiyat = 0;
            double toplamyuzdeler = 0;
            foreach (var item in bedelliler)
            {
                var stok = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pak_stokkod);
                if (stok.Any())
                {
                    toplamyuzdeler += stok.First().vryuzde * item.pak_miktar;
                    toplam_miktar_carpi_fiyat += stok.First().sto_fiyat * item.pak_miktar;
                }
            }



            var islemegireceklerinsayisi = gelenpaketbilgileri.Where(x => x.pak_detay_tip == 0).Sum(x => x.pak_miktar);
            toplamyuzdeler = toplamyuzdeler / islemegireceklerinsayisi;

            foreach (var item in gelenpaketbilgileri)
            {
                //eger renk beden bos ise direk listeye ekliyoruz.
                //if (item.pak_renkbeden == "")
                //{

                var tt = gelenpaketbilgileri.Where(x => x.pak_detay_tip == 0).Sum(x => x.pak_miktar);

                double itemcount = tt;
                //pak_detay_tip  =0  bedelli 
                //pak_detay_tip  =1  bedelsiz 

                var stok_bilgisi = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pak_stokkod).FirstOrDefault();
                var kur_bilgisi = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == item.pak_doviz_cins).FirstOrDefault();


                double iskonto2 = 0;
                double vergi = 0;
                double fiyat = 0;


                if (item.pak_vergidahilfl == 0 && item.pak_detay_tip == 0)
                {
                    //COK TEHLIKELI KOD, YAPMAK 2-3 GUN ALDI. KRITIK HESAPLAMALAR VAR.
                    //SILME SAKIN
                    //pak_vergidahilfl =0 yani vergiler dahil demek. fiyattan vergiyi dusmemizlazim.

                    double bu_stokun_genel_stok_fiyat_carpi_miktar_orani = (stok_bilgisi.sto_fiyat * item.pak_miktar) / toplam_miktar_carpi_fiyat;

                    double toplam_fiyat_cik_vergi = (item.pak_fiyat * 100) / (100 + toplamyuzdeler);
                    var ss = toplam_fiyat_cik_vergi * bu_stokun_genel_stok_fiyat_carpi_miktar_orani;

                    fiyat = ss / item.pak_miktar;
                    vergi = (fiyat * item.pak_miktar) * stok_bilgisi.vryuzde / 100;
                    double ikisitoplam = fiyat + vergi;
                }
                else if (item.pak_vergidahilfl == 1 && item.pak_detay_tip == 0)
                {
                    //pak_vergidahilfl =1 yani vergiler haric demek. boyle olursa, ustune ilave vergiyi biz hesapliyoruz
                    vergi = (item.pak_fiyat / itemcount) * stok_bilgisi.vryuzde / 100;
                    fiyat = (item.pak_fiyat / itemcount); // - (item.pak_fiyat / itemcount);                        
                }



                ////dogumgunum
                //if (item.pak_vergidahilfl == 0 && item.pak_detay_tip==0)
                //{
                //    //pak_vergidahilfl =0 yani vergiler dahil demek. fiyattan vergiyi dusmemizlazim.

                //    var toplam_fiyat_cik_vergi = (item.pak_fiyat * 100) / (100 + toplamyuzdeler);

                //    fiyat = toplam_fiyat_cik_vergi / itemcount;
                //    vergi = fiyat * stok_bilgisi.vryuzde/100* item.pak_miktar ; 
                //    double ikisitoplam = fiyat + vergi; 
                //}
                //else if (item.pak_vergidahilfl == 1 && item.pak_detay_tip == 0)
                //{
                //    //pak_vergidahilfl =1 yani vergiler haric demek. boyle olursa, ustune ilave vergiyi biz hesapliyoruz
                //    vergi = (item.pak_fiyat / itemcount)*stok_bilgisi.vryuzde/100;
                //    fiyat = (item.pak_fiyat / itemcount); // - (item.pak_fiyat / itemcount);                        
                //}

                string renkbedenguid = Guid.NewGuid().ToString();

                DetayliSalesList.Add(new SatisSthModel
                {
                    sth_fiyat_gosterge = fiyat.ToString(),

                    sth_miktar_gosterge = item.pak_miktar.ToString(),
                    sth_stok_kod = item.pak_stokkod,
                    sth_stok_isim = stok_bilgisi.sto_isim,
                    sth_birim_ad = stok_bilgisi.sto_birim1_ad,
                    sth_tarih = DateTime.Now.Date,
                    sth_vergi_pntr = stok_bilgisi.VERGI_NO,
                    sth_vergi = vergi,
                    sth_vryuzde = stok_bilgisi.vryuzde,
                    sth_doviz_cins = item.pak_doviz_cins,
                    sth_har_doviz_kur = NumericConverter.StringToDouble(kur_bilgisi.Kur_fiyat1),
                    sth_doviz_ismi = kur_bilgisi.Kur_sembol,
                    sth_resim_url = stok_bilgisi.stok_resim_url,
                    sth_renk_beden_seri_baglanti = renkbedenguid,
                    Renk_beden_full_bilgi = "PAKET",
                    sth_parti_kodu = "",
                    sth_iskonto2 = iskonto2,
                    sth_lot_no = 0,
                    sth_cari = SelectedCustomerModel.cari_kod
                });

                if (item.pak_renkbeden != "")
                {
                    List<OlusanRenkBedenSeriHareketleriModel> GidecekListe = new List<OlusanRenkBedenSeriHareketleriModel>();

                    var renkbeden = item.pak_renkbeden.Split(';');
                    var renkbedenmiktar = item.pak_renkbeden_miktar.Split(';');

                    for (int i = 0; i < renkbeden.Count(); i++)
                    {


                        var renk_beden_converted_ints = NumericConverter.RenkBedenNumarasiniRenkBedenObjesineDondur(renkbeden[i].ToString());



                        var renkbul = _LSTMANAGER.Renkler.Where(x => x.rnk_kodu == stok_bilgisi.sto_renk_kodu && x.rnk_IndicatorName == "rnk_kirilim_" + renk_beden_converted_ints.renk_kirilimi).ToList();
                        var bedenbul = _LSTMANAGER.Bedenler.Where(x => x.bdn_kodu == stok_bilgisi.sto_beden_kodu && x.bdn_IndicatorName == "bdn_kirilim_" + renk_beden_converted_ints.beden_kirilimi).ToList();



                        var olusan_renk_beden_har = new OlusanRenkBedenSeriHareketleriModel
                        {
                            Olusan_Stok_kodu = item.pak_stokkod,
                            Olusan_Renk_Indicatoru = renkbul.First().rnk_IndicatorName,
                            Olusan_Beden_Indicatoru = bedenbul.First().bdn_IndicatorName,
                            Olusan_RenkBeden_Miktar = renkbedenmiktar[i],
                            Olusan_Serino = "",
                            Olusan_Baglantisi_sth = renkbedenguid,
                            Olusan_Serino_Miktar = "",
                            Olusan_SiraNo = i + 1,
                            Olusan_Parti = "",
                            Olusan_Lot = 0,
                        };

                        _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Add(olusan_renk_beden_har);


                    }
                    foreach (var itemss in renkbedenmiktar)
                    {

                    }



                }

                //}
                //else
                //{

                //    await HelpME.MessageShow("Uyari", "Suan Renk Beden olayini yapmiyoruz.sonra yapcaz..", "OK");

                //}

            }
            await HelpME.MessageShow("Ok", "Paket Eklendi", "OK");
            //throw new NotImplementedException();

            CalculateSumGO(this);
        }

        private async void EvrakCagirBtnGO(object obj)
        {

            await HelpME.PopAc(new EvrakCagirPopupPage());

        }

        private async void FilitreUygulaGO(object obj)
        {
            if (!StockFilter.Any()) return;

            List<string> filtre0 = new List<string>();
            List<string> filtre1 = new List<string>();
            List<string> filtre2 = new List<string>();
            List<string> filtre3 = new List<string>();
            List<string> filtre4 = new List<string>();
            List<string> filtre5 = new List<string>();

            foreach (var item in StockFilter)
            {
                //if (!item.Filter_Items.Any()) return;

                foreach (var item_fil in item.Filter_Items.Where(x => x.filteritem_isselected))
                {
                    //var ss1 = item_fil.filteritem_nereyeait;
                    //var ss2 = item_fil.filteritem_aciklama;

                    switch (item_fil.filteritem_nereyeait)
                    {
                        case 0:
                            filtre0.Add(item_fil.filteritem_aciklama);
                            break;
                        case 1:
                            filtre1.Add(item_fil.filteritem_aciklama);
                            break;
                        case 2:
                            filtre2.Add(item_fil.filteritem_aciklama);
                            break;
                        case 3:
                            filtre3.Add(item_fil.filteritem_aciklama);
                            break;
                        case 4:
                            filtre4.Add(item_fil.filteritem_aciklama);
                            break;
                        case 5:
                            filtre5.Add(item_fil.filteritem_aciklama);
                            break;



                        default:
                            break;
                    }

                }

            }

            StockList = new ObservableCollection<StockModel>(_LSTMANAGER.STOCKLIST

                .Where(x => filtre0.Contains(x.sto_marka_ismi) || !filtre0.Any())
                .Where(x => filtre1.Contains(x.sto_anagrup_ismi) || !filtre1.Any())
                .Where(x => filtre2.Contains(x.sto_altgrup_ismi) || !filtre2.Any())
                .Where(x => filtre3.Contains(x.sto_uretici_ismi) || !filtre3.Any())
                .Where(x => filtre4.Contains(x.sto_kategori_ismi) || !filtre4.Any())
                .Where(x => filtre5.Contains(x.sto_reyon_ismi) || !filtre5.Any())

                );


            await HelpME.PopKapat();
        }
        private async void FilitreTemizleGO(object obj)
        {
            foreach (var item in StockFilter)
            {
                item.FilterHeaderIsVisible = false;
                foreach (var itemxxx in item.Filter_Items)
                {
                    itemxxx.filteritem_isselected = false;

                }

            }

            StockList = new ObservableCollection<StockModel>(_LSTMANAGER.STOCKLIST);
            await HelpME.PopKapat();
        }

        #endregion

        private void EditSTHGOAsync(object obj)
        {
            if (obj == null) return;

            if (obj is SatisSthModel)
            {


                var gelenSthHar = (SatisSthModel)obj;

                SelectedStockModel = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == gelenSthHar.sth_stok_kod).FirstOrDefault();

                MainMiktar = gelenSthHar.sth_miktar_gosterge;
                MainFiyat = gelenSthHar.sth_fiyat_gosterge;
                MainTutar = gelenSthHar.sth_tutar_gosterge;



                var renkbedenseridegerleri = _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Where(x => x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                try
                {
                    //sinan2
                    //parti 
                    if (SelectedStockModel.sto_detay_takip == 1)
                    {
                        PartiTxt = renkbedenseridegerleri[0].Olusan_Parti;
                    }
                    else
                        if (SelectedStockModel.sto_detay_takip == 2)
                    {
                        PartiTxt = renkbedenseridegerleri[0].Olusan_Parti;
                        LotTxt = renkbedenseridegerleri[0].Olusan_Lot.ToString();
                    }
                    else

                     if (SelectedStockModel.sto_detay_takip == 3) // seri no takip
                    {

                        var seritext1 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 1 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (seritext1.Count > 0)
                        {
                            Serinotext1 = seritext1.FirstOrDefault().Olusan_Serino;
                            SeriNoMiktar1 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 1 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_Serino_Miktar;
                        }

                        var seritext2 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 2 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (seritext2.Count > 0)
                        {
                            Serinotext2 = seritext2.FirstOrDefault().Olusan_Serino;
                            SeriNoMiktar2 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 2 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_Serino_Miktar;
                        }

                        var seritext3 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 3 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (seritext3.Count > 0)
                        {
                            Serinotext3 = seritext3.FirstOrDefault().Olusan_Serino;
                            SeriNoMiktar3 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 3 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_Serino_Miktar;
                        }

                        var seritext4 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 4 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (seritext4.Count > 0)
                        {
                            Serinotext4 = seritext4.FirstOrDefault().Olusan_Serino;
                            SeriNoMiktar4 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 4 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_Serino_Miktar;
                        }

                        var seritext5 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 5 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (seritext5.Count > 0)
                        {
                            Serinotext5 = seritext5.FirstOrDefault().Olusan_Serino;
                            SeriNoMiktar5 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 5 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_Serino_Miktar;
                        }

                        var seritext6 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 6 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (seritext6.Count > 0)
                        {
                            Serinotext6 = seritext6.FirstOrDefault().Olusan_Serino;
                            SeriNoMiktar6 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 6 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_Serino_Miktar;
                        }
                    }

                    if (SelectedStockModel.sto_renkDetayli) //renk var beden yok
                    {
                        string SectigimStogunRenkKartelasi = SelectedStockModel.sto_renk_kodu;

                        //renk1
                        var renktext1 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 1 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext1.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext1.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK1 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar1 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 1 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk2
                        var renktext2 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 2 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext2.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext2.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK2 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar2 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 2 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk3
                        var renktext3 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 3 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext3.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext3.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK3 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar3 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 3 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk4
                        var renktext4 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 4 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext4.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext4.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK4 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar4 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 4 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk5
                        var renktext5 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 5 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext5.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext5.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK5 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar5 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 5 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk6
                        var renktext6 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 6 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext6.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext6.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK6 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar6 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 6 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk7
                        var renktext7 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 7 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext7.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext7.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK7 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar7 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 7 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk8
                        var renktext8 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 8 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext8.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext8.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK8 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar8 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 8 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk9
                        var renktext9 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 9 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext9.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext9.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK9 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar9 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 9 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //renk10
                        var renktext10 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 10 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (renktext10.Count > 0)
                        {
                            var gelenRenkIndicatoru = renktext10.FirstOrDefault().Olusan_Renk_Indicatoru;
                            SelectedRENK10 = _LSTMANAGER.Renkler.Where(x => x.rnk_IndicatorName == gelenRenkIndicatoru && x.rnk_kodu == SectigimStogunRenkKartelasi).FirstOrDefault();

                            RenkBedenMiktar10 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 10 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }


                    }
                    if (SelectedStockModel.sto_bedenli_takip) //beden var renk yok
                    {
                        string SectigimStogunBedenKartelasi = SelectedStockModel.sto_beden_kodu;
                        //Beden1
                        var bedentext1 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 1 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext1.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext1.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden1 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar1 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 1 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden2
                        var bedentext2 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 2 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext2.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext2.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden2 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar2 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 2 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden3
                        var bedentext3 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 3 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext3.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext3.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden3 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar3 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 3 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden4
                        var bedentext4 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 4 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext4.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext4.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden4 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar4 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 4 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden5
                        var bedentext5 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 5 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext5.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext5.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden5 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar5 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 5 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden6
                        var bedentext6 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 6 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext6.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext6.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden6 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar6 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 6 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden7
                        var bedentext7 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 7 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext7.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext7.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden7 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar7 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 7 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden8
                        var bedentext8 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 8 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext8.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext8.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden8 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar8 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 8 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden9
                        var bedentext9 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 9 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext9.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext9.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden9 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar9 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 9 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }

                        //Beden10
                        var bedentext10 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 10 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).ToList();
                        if (bedentext10.Count > 0)
                        {
                            var gelenBedenkIndicatoru = bedentext10.FirstOrDefault().Olusan_Beden_Indicatoru;
                            SelectedBeden10 = _LSTMANAGER.Bedenler.Where(x => x.bdn_IndicatorName == gelenBedenkIndicatoru && x.bdn_kodu == SectigimStogunBedenKartelasi).FirstOrDefault();

                            RenkBedenMiktar10 = renkbedenseridegerleri.Where(x => x.Olusan_SiraNo == 10 && x.Olusan_Baglantisi_sth == gelenSthHar.sth_renk_beden_seri_baglanti).FirstOrDefault().Olusan_RenkBeden_Miktar;
                        }
                    }

                }
                catch (Exception ex)
                {
                    HelpME.MessageShow("Error", "Renk ile ilgili bir sorun olustu, lutfen yoneticinize durumu bildiriniz..." + ex, "ok");

                }



            }
        }

        private async void BarcodeReaderCompletedGO(object param)
        {
            //Barcode Done butonu
            try
            {
                var okunandeger = BarkodReaderText;

                if (okunandeger != "")
                {
                    var gelenbarkod = _LSTMANAGER.BARCODELIST.Where(x => x.bar_kodu == okunandeger).FirstOrDefault();

                    if (gelenbarkod != null)
                    {
                        var gereklistok = _LSTMANAGER.STOCKLIST.Where(c => c.sto_kod == gelenbarkod.bar_stokkodu).FirstOrDefault();

                        if (gereklistok != null)
                        {
                            SelectedStockModel = gereklistok;
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("No Stock found", "No Barcode Found in the Database...", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("No Barcode", "No Barcode Found in the Database...", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            BarkodReaderText = "";

        }

        private void DeleteSTHGO(object obj)
        {
            if (obj == null) return;

            if (obj is SatisSthModel)
            {
                var gelendeger = (SatisSthModel)obj;
                DetayliSalesList.Remove(gelendeger);
                CalculateSumGO(this);
            }
        }

        private async void BtnKaydetGO(object obj)
        {

            try
            {
                if (DetayliSalesList.Count == 0) return;

                if (SelectedCustomerModel == null) { await HelpME.MessageShow("Uyari", "Lutfen Cari Seciniz", "OK"); return; }

                if (tutar == "0") { await HelpME.MessageShow("Uyari", "Tutar Sifir Olamaz", "OK"); return; }

                var tutarsifirlar = DetayliSalesList.Where(x => x.sth_miktar <= 0).ToList();
                foreach (var item in tutarsifirlar)
                {
                    var res = await App.Current.MainPage.DisplayAlert("Zero", "Bazi stok miktarlari sifir. Silmek istiyormusunuz?", "Ok", "Cancel");

                    if (res)
                    {
                        DetayliSalesList.Remove(item);
                    }
                    else return;
                }


                #region INDIRIM DUZENLEME MERKEZI
                double hedef_tutar = NumericConverter.StringToDouble(tutar); //199.99

                double ham_tutar = DetayliSalesList.Sum(x => x.sth_tutar); //169.48

                double yeni_indirim_toplam_tl = 0;

                double yeni_vergi_toplam = 0;

                if (GenelIndirimTL != "0" || GenelIndirimYUZDE != "0")
                {
                    foreach (var item in DetayliSalesList)
                    {

                        //varan1
                        item.sth_iskonto2 = 0;
                        /////////////////////////////////////


                        double Carpan = 0;

                        //KAFAM YANDI BURDA TAM 2 GUN UGRASTIM.. COK KRITIK KOD. SAKIN KARISMA
                        Carpan = (item.sth_tutar + item.sth_vergi_burut) / (BurutTutar); //ORJINALI BU SAKIN BOZMA CIDDI  

                        double Yeni_Tutar = Carpan * hedef_tutar;
                        double Yeni_Son_Fiyat = (Yeni_Tutar * 100) / (100 + item.sth_vryuzde);

                        double isk1 = item.sth_tutar - Yeni_Son_Fiyat;
                        double vrg = (Yeni_Son_Fiyat * item.sth_vryuzde) / 100;



                        if (isk1 > 0.01)
                        {
                            item.sth_iskonto1 = Math.Round(isk1, 5);
                        }


                        if (vrg > 0.01)
                        {
                            item.sth_vergi = Math.Round(vrg, 5);
                        }
                        yeni_indirim_toplam_tl += item.sth_tutar - Yeni_Son_Fiyat;

                        yeni_vergi_toplam += (Yeni_Son_Fiyat * item.sth_vryuzde) / 100;

                        if (yeni_indirim_toplam_tl < 0.01)
                        {
                            yeni_indirim_toplam_tl = 0;
                        }
                        if (yeni_vergi_toplam < 0.01)
                        {
                            yeni_vergi_toplam = 0;
                        }

                        if (item.sth_iskonto2 > 0)
                        {
                            item.sth_iskonto1 = 0;
                        }

                    }
                }



                #endregion




                UserDialogs.Instance.ShowLoading(AppResources.dialog_logginginplzwait, MaskType.None);

                isVisibleGRID = false;

                string myfat_cari_kod = SelectedCustomerModel.cari_kod;

                double fat_topam_plus_vergi = DetayliSalesList.Sum(x => x.sth_tutar) + DetayliSalesList.Sum(x => x.sth_vergi);

                double fat_toplam = DetayliSalesList.Sum(x => x.sth_tutar);

                double vergi1 = 0;
                double vergi2 = 0;
                double vergi3 = 0;
                double vergi4 = 0;
                double vergi5 = 0;
                double vergi6 = 0;
                double vergi7 = 0;
                double vergi8 = 0;
                double vergi9 = 0;
                double vergi10 = 0;

                for (int i = 0; i < DetayliSalesList.Count; i++)
                {
                    int deger = DetayliSalesList[i].sth_vergi_pntr;
                    var StokBilgi = _LSTMANAGER.STOCKLIST.Where(S => S.sto_kod == DetayliSalesList[i].sth_stok_kod).FirstOrDefault();
                    int vergi_karsilastirmasi = StokBilgi.VERGI_NO;


                    if (vergi_karsilastirmasi == 2)
                    {
                        vergi2 += DetayliSalesList[i].sth_vergi;
                    }
                    else
                     if (vergi_karsilastirmasi == 3)
                    {
                        vergi3 += DetayliSalesList[i].sth_vergi;
                    }
                    else
                   if (vergi_karsilastirmasi == 4)
                    {

                        vergi4 += DetayliSalesList[i].sth_vergi;

                    }
                    else
                    if (vergi_karsilastirmasi == 5)
                    {
                        vergi5 += DetayliSalesList[i].sth_vergi;
                    }
                    else
                     if (vergi_karsilastirmasi == 6)
                    {
                        vergi6 += DetayliSalesList[i].sth_vergi;
                    }
                    else
                   if (vergi_karsilastirmasi == 7)
                    {
                        vergi7 += DetayliSalesList[i].sth_vergi;
                    }
                    else
                     if (vergi_karsilastirmasi == 8)
                    {
                        vergi8 += DetayliSalesList[i].sth_vergi;
                    }
                    else
                   if (vergi_karsilastirmasi == 9)
                    {
                        vergi9 += DetayliSalesList[i].sth_vergi;
                    }
                    if (vergi_karsilastirmasi == 10)
                    {
                        vergi10 += DetayliSalesList[i].sth_vergi;
                    }
                }


                int xfat_cari_cins = 0;
                int xfat_tpoz = 0;
                string xfat_cari_kod = "";
                int xfat_grupno = 0;

                switch (SelectedAcikKapali.Acik_Kapali_ID)
                {
                    //ACIK HESAP 
                    case 0:
                        xfat_cari_cins = 0;
                        xfat_tpoz = 0;
                        xfat_cari_kod = myfat_cari_kod;
                        break;

                    //kasa dan kapanacak
                    case 1:
                        xfat_cari_cins = 4;
                        xfat_tpoz = 1;
                        xfat_cari_kod = _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_KASA;
                        break;

                    //bankadan kapanacak
                    case 2:
                        xfat_cari_cins = 2;
                        xfat_tpoz = 1;
                        xfat_cari_kod = _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_BANKA;
                        xfat_grupno = 1;
                        break;

                    default:
                        return;
                }


                string islem_baglanti_guidi = Guid.NewGuid().ToString();
                List<SatisFatModel> faturalar = new List<SatisFatModel>();
                faturalar.Add(new SatisFatModel
                {

                    fat_cari_cins = xfat_cari_cins,
                    fat_tpoz = xfat_tpoz,
                    fat_cari_kod = xfat_cari_kod,
                    fat_grupno = xfat_grupno,

                    fat_firmano = SelectedFirma.fir_sirano,
                    fat_subeno = SelectedSube.Sube_no,

                    fat_tarih = Tarih,
                    fat_meblag = NumericConverter.StringToDouble(tutar),
                    fat_aratoplam = fat_toplam,
                    fat_personel = _LSTMANAGER.ACTIVEUSER.USERS_NAME,
                    fat_proje = SelectedProje.pro_kodu,
                    fat_srm_mrkzi = SelectedSorumluluk.som_kod,
                    fat_vergi1 = vergi1,
                    fat_vergi2 = vergi2,
                    fat_vergi3 = vergi3,
                    fat_vergi4 = vergi4,
                    fat_vergi5 = vergi5,
                    fat_vergi6 = vergi6,
                    fat_vergi7 = vergi7,
                    fat_vergi8 = vergi8,
                    fat_vergi9 = vergi9,
                    fat_vergi10 = vergi10,
                    fat_evrak_seri = _LSTMANAGER.ACTIVEUSER.USERS_SHORT_NAME,
                    fat_tip = 0,
                    fat_evrak_tip = 63,
                    fat_aciklama = "Detayli Satis -MIKRON ERP",
                    fat_normal_Iade = SelectedNormalIade.Normal_Iade_ID,
                    fat_kasa_hizkod = "",  //userin kasa kodu olmali
                    fat_kasa_hizmet = 0,
                    fat_d_cins = SelectedDovizKuru.Kur_no,
                    fat_d_kur = NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1),
                    fat_cinsi = 6,  //
                    fat_ft_iskonto1 = yeni_indirim_toplam_tl,
                    fat_sth_baglanti = islem_baglanti_guidi,
                    fat_islemkodu = 1,
                    fat_firma = SelectedFirma.fir_sirano,
                    fat_sube = SelectedSube.Sube_no,
                    mikro_user_id = _LSTMANAGER.ACTIVEUSER.USERS_MIKROID,
                    fat_vade = SelectedOdemePlani.odp_no,
                    fatura_acik_kasa_banka_belirteci = SelectedAcikKapali.Acik_Kapali_ID,

                });

                int sonuc_Fatura_okey = 0;
                int sonuc_STH_okey = 0;

                for (int i = 0; i < DetayliSalesList.Count; i++)
                {
                    DetayliSalesList[i].sth_cari = SelectedCustomerModel.cari_kod;
                    DetayliSalesList[i].sth_giris_depo_no = SelectedDepo.dep_no;
                    DetayliSalesList[i].sth_cikis_depo_no = SelectedDepo.dep_no;
                    DetayliSalesList[i].sth_fiyat_liste_no = _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_FIYATLISTESI;
                    DetayliSalesList[i].sth_username_seri = _LSTMANAGER.ACTIVEUSER.USERS_SHORT_NAME;
                    DetayliSalesList[i].sth_evraktip = 4;
                    DetayliSalesList[i].sth_tip = 1;
                    DetayliSalesList[i].sth_fat_baglanti = islem_baglanti_guidi;
                    DetayliSalesList[i].sth_islemkodu = 1;
                    DetayliSalesList[i].sth_firma = SelectedFirma.fir_sirano;
                    DetayliSalesList[i].sth_sube = SelectedSube.Sube_no;
                    DetayliSalesList[i].mikro_user_id = _LSTMANAGER.ACTIVEUSER.USERS_MIKROID;
                    DetayliSalesList[i].sth_mikronfaturaid = 1;
                    DetayliSalesList[i].sth_normal_iade = SelectedNormalIade.Normal_Iade_ID;
                    DetayliSalesList[i].sth_odeme_op = SelectedOdemePlani.odp_no;
                    DetayliSalesList[i].sth_fiyat_liste_no = SelectedFiyatListesi.sfl_sirano;
                    DetayliSalesList[i].sth_srm_merkezi = SelectedSorumluluk.som_kod;
                    DetayliSalesList[i].sth_proje = SelectedProje.pro_kodu;
                    DetayliSalesList[i].sth_tarih = Tarih;

                }



                //FATURA VE STOK HAREKETLERINI TELEFONA KAYDEDIYORUZ. AKTARIM OLSA DA OLMASADA BIZIM PROBLEMIMIZ DEGIL...
                sonuc_Fatura_okey = await LocalSQL<SatisFatModel>.DBINSERTALL(faturalar);
                sonuc_STH_okey = await LocalSQL<SatisSthModel>.DBINSERTALL(DetayliSalesList.ToList());
                var renkbedenseriliste = _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.ToList();

                foreach (var item in renkbedenseriliste)
                {
                    item.Olusan_Baglantisi_fat = islem_baglanti_guidi;
                }

                //renk beden temizligi
                var tumRenkHareketleri = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.GETLISTALL();
                foreach (var item in DetayliSalesList)
                {
                    var BizeAitRenkHareketleri = tumRenkHareketleri.Where(x => x.Olusan_Baglantisi_sth == item.sth_renk_beden_seri_baglanti).ToList();
                    foreach (var itemxxx in BizeAitRenkHareketleri)
                    {
                        await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.DELETEROW(itemxxx);
                    }
                }

                if (renkbedenseriliste.Count > 0)
                {
                    await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.DBINSERTALL(renkbedenseriliste);
                }
                //KAYDETTI

                bool durumFATURA = false;

                if (sonuc_Fatura_okey <= 0 || sonuc_STH_okey <= 0)
                {
                    await HelpME.MessageShow("HATA", "Faturayi Telefona kaydetme isleminde hata olustu.Telefonunuzda saklama alanı azalmış olabilir.Tekrar deneyiniz", "Ok");
                    return;
                }


                List<KirilimliSth> krlmsth = new List<KirilimliSth>();


                krlmsth.Add(new KirilimliSth { SthHareketTablosu = DetayliSalesList.ToList(), RenkBedenSeriDetayTablosu = renkbedenseriliste });

                durumFATURA = await SendData.SendDetayliSatisFaturasi(krlmsth, faturalar);

                var ssi = await LocalSQL<SatisFatModel>.DBIslem("SELECT * FROM SatisFatModel ORDER BY fat_id DESC LIMIT 1 ");
                var son_id = ssi.ToList()[0].fat_id;

                List<AktarimModel> AktarimLogOlustur = new List<AktarimModel>();
                AktarimLogOlustur.Add(new AktarimModel
                {
                    Aktarim_Tarih = DateTime.Now,
                    Aktarim_IslemRecNo = son_id,
                    Aktarim_IslemKodu = 1,
                    Aktarim_IslemAdi = AppResources.xSatisFaturasi_1,
                    Aktarim_Sent = durumFATURA,
                    Aktarim_Cari_Kod = myfat_cari_kod,
                    Aktarim_Tutar = NumericConverter.StringToDouble(tutar),
                    Aktarim_Baglanti_guid = islem_baglanti_guidi,
                    Aktarim_IndirimTL = GenelIndirimTL,
                    Aktarim_IndirimYuzde = GenelIndirimYUZDE,
                });

                await LocalSQL<AktarimModel>.DBINSERTALL(AktarimLogOlustur);

                DetayliSalesList.Clear();
                temizlikisleri();
                SelectedCustomerModel = null;

                //gonderilmeyen kayit varmi yokmu diye bakiyoruz
                await SendData.SEND_UNSENT();

                UserDialogs.Instance.ShowLoading("Yeni Kayitlar Aliniyor", MaskType.Gradient);
                await DataClass.GetData(_LSTMANAGER.ACTIVECOMPANY, _LSTMANAGER.ACTIVEUSER);
                await HelpME.SayfaKapat();

                isVisibleGRID = true;
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {

                await HelpME.MessageShow("Evrak Kayit Hatasi", ex.Message, "ok");
            }

        }
        private async void StokListFiltreGO(object obj)
        {
            await HelpME.PopAc(new StockFilterPage());
        }

        private void StokListSiralaGO(object obj)
        {//ablax
            if (stoklistyardimcisi % 2 == 0)
            {
                StockList = new ObservableCollection<StockModel>(StockList.OrderByDescending(x => x.sto_isim).ToList());
            }
            else
            {
                StockList = new ObservableCollection<StockModel>(StockList.OrderBy(x => x.sto_isim).ToList());
            }
            stoklistyardimcisi++;

        }

        private ObservableCollection<StokPaketleriModel> _TEMPPaketTanimlariVeya_bedava_stoklist;

        public ObservableCollection<StokPaketleriModel> TEMPPaketTanimlariVeya_bedava_stoklist
        {
            get
            {
                if (_TEMPPaketTanimlariVeya_bedava_stoklist == null)
                {
                    _TEMPPaketTanimlariVeya_bedava_stoklist = new ObservableCollection<StokPaketleriModel>();
                }
                return _TEMPPaketTanimlariVeya_bedava_stoklist;
            }
            set
            {
                _TEMPPaketTanimlariVeya_bedava_stoklist = value;
            }
        }

        private StokPaketleriModel _TEMPSelected_PaketTanimlariVeya_bedava_stok;

        public StokPaketleriModel TEMPSelected_PaketTanimlariVeya_bedava_stok
        {
            get
            {
                return _TEMPSelected_PaketTanimlariVeya_bedava_stok;
            }
            set
            {
                _TEMPSelected_PaketTanimlariVeya_bedava_stok = value;
                if (_TEMPSelected_PaketTanimlariVeya_bedava_stok != null)
                {
                    var analist = _LSTMANAGER.STOKPAKETLERI.Where(x => x.pak_kod == _TEMPSelected_PaketTanimlariVeya_bedava_stok.pak_kod).ToList();
                    if (analist.Any())
                    {
                        var cikarmamgerekenler = analist.Where(x => x.pak_ve_veya == 1).ToList();

                        foreach (var item in cikarmamgerekenler)
                        {
                            analist.Remove(item);
                        }
                        analist.Add(_TEMPSelected_PaketTanimlariVeya_bedava_stok);

                        paketislemlerinindevami(analist);
                        HelpME.PopKapat();

                    }
                }
            }
        }
         

     
        private List<StockFilterModel> _StockFilter;

        public List<StockFilterModel> StockFilter
        {
            get
            {
                if (_StockFilter == null)
                {

                    if (StockList.Any())
                    {
                        _StockFilter = new List<StockFilterModel>();

                        _StockFilter.Add(new StockFilterModel
                        {
                            FilterHeaderName = "Markalara göre filtrele",
                            FilterHeaderIsVisible = false

                        });

                        var markaisimleri = StockList.ToList().GroupBy(x => x.sto_marka_ismi).ToList().Where(x => x.Key != "");



                        if (markaisimleri.Any())
                        {
                            foreach (var item in markaisimleri)
                            {
                                _StockFilter[0].Filter_Items.Add(new FilterItems { filteritem_isselected = false, filteritem_aciklama = item.Key, filteritem_nereyeait = 0 });
                            }
                        }

                        _StockFilter.Add(new StockFilterModel
                        {
                            FilterHeaderName = "Ana gruba göre filtrele",
                            FilterHeaderIsVisible = false

                        });
                        var anagrupisimleri = StockList.ToList().GroupBy(x => x.sto_anagrup_ismi).ToList().Where(x => x.Key != "");

                        if (anagrupisimleri.Any())
                        {
                            foreach (var item in anagrupisimleri)
                            {
                                _StockFilter[1].Filter_Items.Add(new FilterItems { filteritem_isselected = false, filteritem_aciklama = item.Key, filteritem_nereyeait = 1 });
                            }
                        }


                        _StockFilter.Add(new StockFilterModel
                        {
                            FilterHeaderName = "Alt gruba göre filtrele",
                            FilterHeaderIsVisible = false

                        });
                        var altgrupisimleri = StockList.ToList().GroupBy(x => x.sto_altgrup_ismi).ToList().Where(x => x.Key != "");

                        if (altgrupisimleri.Any())
                        {
                            foreach (var item in altgrupisimleri)
                            {
                                _StockFilter[2].Filter_Items.Add(new FilterItems { filteritem_isselected = false, filteritem_aciklama = item.Key, filteritem_nereyeait = 2 });
                            }
                        }


                        _StockFilter.Add(new StockFilterModel
                        {
                            FilterHeaderName = "Üreticilere göre filtrele",
                            FilterHeaderIsVisible = false

                        });
                        var ureticiisimleri = StockList.ToList().GroupBy(x => x.sto_uretici_ismi).ToList().Where(x => x.Key != "");

                        if (ureticiisimleri.Any())
                        {
                            foreach (var item in ureticiisimleri)
                            {
                                _StockFilter[3].Filter_Items.Add(new FilterItems { filteritem_isselected = false, filteritem_aciklama = item.Key, filteritem_nereyeait = 3 });
                            }
                        }


                        _StockFilter.Add(new StockFilterModel
                        {
                            FilterHeaderName = "Kategorilere göre filtrele",
                            FilterHeaderIsVisible = false

                        });
                        var kategoriisimleri = StockList.ToList().GroupBy(x => x.sto_kategori_ismi).ToList().Where(x => x.Key != "");

                        if (kategoriisimleri.Any())
                        {
                            foreach (var item in kategoriisimleri)
                            {
                                _StockFilter[4].Filter_Items.Add(new FilterItems { filteritem_isselected = false, filteritem_aciklama = item.Key, filteritem_nereyeait = 4 });
                            }
                        }


                        _StockFilter.Add(new StockFilterModel
                        {
                            FilterHeaderName = "Reyonlara göre filtrele",
                            FilterHeaderIsVisible = false

                        });
                        var reyonisimleri = StockList.ToList().GroupBy(x => x.sto_reyon_ismi).ToList().Where(x => x.Key != "");

                        if (reyonisimleri.Any())
                        {
                            foreach (var item in reyonisimleri)
                            {
                                _StockFilter[5].Filter_Items.Add(new FilterItems { filteritem_isselected = false, filteritem_aciklama = item.Key, filteritem_nereyeait = 5 });
                            }
                        }

                    }
                }
                return _StockFilter;
            }
            set
            {
                _StockFilter = value;
                INotifyPropertyChanged();
            }
        }

        private StockFilterModel _selectedStockFilter;

        public StockFilterModel selectedStockFilter
        {
            get
            {
                return _selectedStockFilter;
            }
            set
            {
                //_selectedStockFilter.FilterHeaderIsVisible = true;
                _selectedStockFilter = value;
                if (value != null)
                {

                    if (_selectedStockFilter.FilterHeaderIsVisible)
                    {
                        _selectedStockFilter.FilterHeaderIsVisible = false;
                    }
                    else
                    {
                        foreach (var item in StockFilter)
                        {
                            item.FilterHeaderIsVisible = false;
                        }
                        _selectedStockFilter.FilterHeaderIsVisible = true;
                    }

                }

                INotifyPropertyChanged();
            }
        }

        private FilterItems _SelectedFilterItem;

        public FilterItems SelectedFilterItem
        {
            get
            {
                return _SelectedFilterItem;
            }
            set
            {
                _SelectedFilterItem = value;
            }
        }

    

        private KasaModel _SelectedKasa;
        public KasaModel SelectedKasa
        {
            get { return _SelectedKasa; }
            set
            {
                _SelectedKasa = value;
                INotifyPropertyChanged();
            }
        }

        private BankaModel _SelectedBanka;
        public BankaModel SelectedBanka
        {
            get { return _SelectedBanka; }
            set
            {
                _SelectedBanka = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<KasaModel> _Kasalar;

        public ObservableCollection<KasaModel> Kasalar
        {
            get { return _Kasalar; }
            set
            {
                _Kasalar = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<BankaModel> _Bankalar;

        public ObservableCollection<BankaModel> Bankalar
        {
            get { return _Bankalar; }
            set
            {
                _Bankalar = value;
                INotifyPropertyChanged();
            }
        }

      
        private void temizlikisleri()
        {
            if (DetayliSalesList.Count == 0 && DetayliSalesList.Sum(x => x.sth_tutar) <= 0)
            {
                GenelIndirimTL = "0";
                GenelIndirimYUZDE = "0";
                BurutTutar = 0;
                tutar = "0";
            }
        }

        private bool _isVisibleGRID;
        public bool isVisibleGRID
        {
            get { return _isVisibleGRID; }
            set
            {
                _isVisibleGRID = value;
                INotifyPropertyChanged();
            }
        }
        private void BtnTemizlikYapGO(object obj)
        {
            GenelIndirimYUZDE = "0";
            GenelIndirimTL = "0";
            DetayliSalesList.Clear();
            CalculateSumGO(obj);
        }

        private async void EkleStockButtonGO(object obj)
        {
            //garip2
            if (NumericConverter.StringToDouble(MainMiktar) <= 0)
            {
                await HelpME.MessageShow("Miktar Hatasi", "Miktar sifir Veya Sifirdan Kucuk Olamaz", "ok");
                return;
            }
            if (NumericConverter.StringToDouble(MainTutar) <= 0)
            {
                await HelpME.MessageShow("Tutar Hatasi", "Tutar Sifir Veya Sifirdan Kucuk Olamaz", "ok");
                return;
            }

            int Olusan_Hareket_No = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK1, SelectedBeden1);

            List<OlusanRenkBedenSeriHareketleriModel> GidecekListe = new List<OlusanRenkBedenSeriHareketleriModel>();
            string stokgun_renk_beden_serino_aciklamasi = "";

            string FinalParti = "";
            string FinalLot = "";
            //stok renk beden detayli veya serino detayli ise bu kriterlerden gecicek, aksi halde, direk satis listesine eklenecek.
            if (SelectedStockModel.sto_bedenli_takip || SelectedStockModel.sto_renkDetayli || SelectedStockModel.sto_detay_takip == 3 || SelectedStockModel.sto_detay_takip == 1 || SelectedStockModel.sto_detay_takip == 2)
            {
                int renkbedensonuc1 = 0;
                int renkbedensonuc2 = 0;
                int renkbedensonuc3 = 0;
                int renkbedensonuc4 = 0;
                int renkbedensonuc5 = 0;
                int renkbedensonuc6 = 0;
                int renkbedensonuc7 = 0;
                int renkbedensonuc8 = 0;
                int renkbedensonuc9 = 0;
                int renkbedensonuc10 = 0;

                if (SelectedParti == null)
                {
                    FinalParti = PartiTxt;
                    FinalLot = LotTxt;
                }
                else
                {
                    FinalParti = SelectedParti.pl_partikodu;
                    FinalLot = SelectedLot.ToString();

                }
                if (FinalParti == null) FinalParti = "";
                if (FinalLot == null) FinalLot = "";

                if (SelectedStockModel.sto_detay_takip == 1) FinalLot = " ";



                try
                {
                    if (NumericConverter.StringToDouble(RenkBedenMiktar1) > 0 || NumericConverter.StringToDouble(SeriNoMiktar1) > 0 || (!string.IsNullOrWhiteSpace(FinalParti) && FinalLot != ""))
                    {
                        if (SelectedRENK1.rnk_IndicatorName != "" || SelectedBeden1.bdn_IndicatorName != "" || Serinotext1 != "" ||
                           !string.IsNullOrWhiteSpace(FinalParti) || FinalLot != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar1) > 0 || NumericConverter.StringToDouble(SeriNoMiktar1) > 0 || !string.IsNullOrWhiteSpace(FinalParti) || FinalLot != "")
                            {
                                renkbedensonuc1 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK1, SelectedBeden1);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel
                                {
                                    Olusan_Stok_kodu = SelectedStockModel.sto_kod,
                                    Olusan_Renk_Indicatoru = SelectedRENK1.rnk_IndicatorName,
                                    Olusan_Beden_Indicatoru = SelectedBeden1.bdn_IndicatorName,
                                    Olusan_RenkBeden_Miktar = RenkBedenMiktar1,
                                    Olusan_Serino = Serinotext1,
                                    Olusan_Serino_Miktar = SeriNoMiktar1,
                                    Olusan_SiraNo = 1,
                                    Olusan_Parti = FinalParti,
                                    Olusan_Lot = NumericConverter.StringToInt(FinalLot),
                                });

                                stokgun_renk_beden_serino_aciklamasi = SelectedRENK1.rnk_IndicatorValue + " " + SelectedBeden1.bdn_IndicatorValue + Serinotext1 + FinalParti + " " + FinalLot.ToString() + " ; ";

                            }
                        }
                        else
                        {
                            RenkBedenMiktar1 = "0";
                            SeriNoMiktar1 = "0";
                        }

                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar2) > 0 || NumericConverter.StringToDouble(SeriNoMiktar2) > 0)
                    {
                        if (SelectedRENK2.rnk_IndicatorName != "" || SelectedBeden2.bdn_IndicatorName != "" || Serinotext2 != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar2) > 0 || NumericConverter.StringToDouble(SeriNoMiktar2) > 0)
                            {
                                renkbedensonuc2 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK2, SelectedBeden2);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK2.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden2.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar2, Olusan_Serino = Serinotext2, Olusan_Serino_Miktar = SeriNoMiktar2, Olusan_SiraNo = 2 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK2.rnk_IndicatorValue + " " + SelectedBeden2.bdn_IndicatorValue + Serinotext2 + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar2 = "0";
                            SeriNoMiktar2 = "0";
                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar3) > 0 || NumericConverter.StringToDouble(SeriNoMiktar3) > 0)
                    {
                        if (SelectedRENK3.rnk_IndicatorName != "" || SelectedBeden3.bdn_IndicatorName != "" || Serinotext3 != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar3) > 0 || NumericConverter.StringToDouble(SeriNoMiktar3) > 0)
                            {
                                renkbedensonuc3 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK3, SelectedBeden3);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK3.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden3.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar3, Olusan_Serino = Serinotext3, Olusan_Serino_Miktar = SeriNoMiktar3, Olusan_SiraNo = 3 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK3.rnk_IndicatorValue + " " + SelectedBeden3.bdn_IndicatorValue + Serinotext3 + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar3 = "0";
                            SeriNoMiktar3 = "0";
                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar4) > 0 || NumericConverter.StringToDouble(SeriNoMiktar4) > 0)
                    {
                        if (SelectedRENK4.rnk_IndicatorName != "" || SelectedBeden4.bdn_IndicatorName != "" || Serinotext4 != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar4) > 0 || NumericConverter.StringToDouble(SeriNoMiktar4) > 0)
                            {
                                renkbedensonuc4 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK4, SelectedBeden4);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK4.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden4.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar4, Olusan_Serino = Serinotext4, Olusan_Serino_Miktar = SeriNoMiktar4, Olusan_SiraNo = 4 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK4.rnk_IndicatorValue + " " + SelectedBeden4.bdn_IndicatorValue + Serinotext4 + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar4 = "0";
                            SeriNoMiktar4 = "0";
                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar5) > 0 || NumericConverter.StringToDouble(SeriNoMiktar5) > 0)
                    {
                        if (SelectedRENK5.rnk_IndicatorName != "" || SelectedBeden5.bdn_IndicatorName != "" || Serinotext5 != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar5) > 0 || NumericConverter.StringToDouble(SeriNoMiktar5) > 0)
                            {
                                renkbedensonuc5 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK5, SelectedBeden5);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK5.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden5.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar5, Olusan_Serino = Serinotext5, Olusan_Serino_Miktar = SeriNoMiktar5, Olusan_SiraNo = 5 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK5.rnk_IndicatorValue + " " + SelectedBeden5.bdn_IndicatorValue + Serinotext5 + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar5 = "0";
                            SeriNoMiktar5 = "0";
                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar6) > 0 || NumericConverter.StringToDouble(SeriNoMiktar6) > 0)
                    {
                        if (SelectedRENK6.rnk_IndicatorName != "" || SelectedBeden6.bdn_IndicatorName != "" || Serinotext6 != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar6) > 0 || NumericConverter.StringToDouble(SeriNoMiktar6) > 0)
                            {
                                renkbedensonuc6 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK6, SelectedBeden6);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK6.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden6.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar6, Olusan_Serino = Serinotext6, Olusan_Serino_Miktar = SeriNoMiktar6, Olusan_SiraNo = 6 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK6.rnk_IndicatorValue + " " + SelectedBeden6.bdn_IndicatorValue + Serinotext6 + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar6 = "0";
                            SeriNoMiktar6 = "0";
                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar7) > 0)
                    {
                        if (SelectedRENK7.rnk_IndicatorName != "" || SelectedBeden7.bdn_IndicatorName != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar7) > 0)
                            {
                                renkbedensonuc7 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK7, SelectedBeden7);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK7.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden7.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar7, Olusan_Serino = "", Olusan_SiraNo = 7 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK7.rnk_IndicatorValue + " " + SelectedBeden7.bdn_IndicatorValue + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar7 = "0";

                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar8) > 0)
                    {
                        if (SelectedRENK8.rnk_IndicatorName != "" || SelectedBeden8.bdn_IndicatorName != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar8) > 0)
                            {
                                renkbedensonuc8 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK8, SelectedBeden8);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK8.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden8.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar8, Olusan_Serino = "", Olusan_SiraNo = 8 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK8.rnk_IndicatorValue + " " + SelectedBeden8.bdn_IndicatorValue + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar8 = "0";

                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar9) > 0)
                    {
                        if (SelectedRENK9.rnk_IndicatorName != "" || SelectedBeden9.bdn_IndicatorName != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar9) > 0)
                            {
                                renkbedensonuc9 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK9, SelectedBeden9);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK9.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden9.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar9, Olusan_Serino = "", Olusan_SiraNo = 9 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK9.rnk_IndicatorValue + " " + SelectedBeden9.bdn_IndicatorValue + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar9 = "0";

                        }
                    }
                    if (NumericConverter.StringToDouble(RenkBedenMiktar10) > 0)
                    {
                        if (SelectedRENK10.rnk_IndicatorName != "" || SelectedBeden10.bdn_IndicatorName != "")
                        {
                            if (NumericConverter.StringToDouble(RenkBedenMiktar10) > 0)
                            {
                                renkbedensonuc10 = NumericConverter.RenkBedenModeltoIntConvertor(SelectedRENK10, SelectedBeden10);
                                GidecekListe.Add(new OlusanRenkBedenSeriHareketleriModel { Olusan_Stok_kodu = SelectedStockModel.sto_kod, Olusan_Renk_Indicatoru = SelectedRENK10.rnk_IndicatorName, Olusan_Beden_Indicatoru = SelectedBeden10.bdn_IndicatorName, Olusan_RenkBeden_Miktar = RenkBedenMiktar10, Olusan_Serino = "", Olusan_SiraNo = 10 });
                                stokgun_renk_beden_serino_aciklamasi += SelectedRENK10.rnk_IndicatorValue + " " + SelectedBeden10.bdn_IndicatorValue + " ; ";
                            }
                        }
                        else
                        {
                            RenkBedenMiktar10 = "0";

                        }
                    }
                }
                catch (Exception ex)
                {
                    await HelpME.MessageShow("error", ex.Message, "OK");
                }
                if (GidecekListe.Count == 0)
                {
                    await HelpME.MessageShow("Detay Hatasi", "Lutfen Stok Detayi Giriniz", "OK");
                    return;
                }

                #region Benzerlik kontrolu
                //mesela bazi kullanicilar beyaz xl i 2 farkli yerde kullaniyor. bunun karsisini almak icin, boyle bir yontem uyguluyoruz.
                // distinct ile normal liste aynimi degilmi diye bakiyoruz...

                if (SelectedStockModel.sto_renkDetayli || SelectedStockModel.sto_bedenli_takip)
                {

                    List<int> benzerlikkontrol = new List<int>();

                    if (renkbedensonuc1 != 0) benzerlikkontrol.Add(renkbedensonuc1);
                    if (renkbedensonuc2 != 0) benzerlikkontrol.Add(renkbedensonuc2);
                    if (renkbedensonuc3 != 0) benzerlikkontrol.Add(renkbedensonuc3);
                    if (renkbedensonuc4 != 0) benzerlikkontrol.Add(renkbedensonuc4);
                    if (renkbedensonuc5 != 0) benzerlikkontrol.Add(renkbedensonuc5);
                    if (renkbedensonuc6 != 0) benzerlikkontrol.Add(renkbedensonuc6);
                    if (renkbedensonuc7 != 0) benzerlikkontrol.Add(renkbedensonuc7);
                    if (renkbedensonuc8 != 0) benzerlikkontrol.Add(renkbedensonuc8);
                    if (renkbedensonuc9 != 0) benzerlikkontrol.Add(renkbedensonuc9);
                    if (renkbedensonuc10 != 0) benzerlikkontrol.Add(renkbedensonuc10);

                    var dist = benzerlikkontrol.Distinct().Count();

                    bool isUnique = dist == benzerlikkontrol.Count();
                    if (!isUnique)
                    {
                        await HelpME.MessageShow("Warning", "Renk beden hareketleri benzersiz olmali, ayni kayitlar kabul edilemez...", "OK");
                        return;
                    }
                }
                #endregion

                //renk bilgisini, stok bazli yaziyoruz ki kullanici ne renk beden secmis onu gorsun
            }

            string Myguid = Guid.NewGuid().ToString();
            //bu renk beden hareketlerini tutan tabloda, bu stogun onceden yapilmis hareketleri varsa siliyor.yenisiyle guncelliyoruz...
            var stokbazliliste = _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Where(x => x.Olusan_Stok_kodu == SelectedStockModel.sto_kod).ToList();
            foreach (var item in stokbazliliste)
            {
                _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Remove(item);
            }

            foreach (var item in GidecekListe)
            {
                item.Olusan_Baglantisi_sth = Myguid;
                _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Add(item);
            }
            //garip4
            var mevcutsatislist = DetayliSalesList.Where(x => x.sth_stok_kod == SelectedStockModel.sto_kod).ToList();

            //eger stokhareketinde zaten bu stoktan 2 tane varsa, bu demektir ki, bu kampanyaile alakali bi stok, bu yuzden kampanyali hareketleri sifirliyoruz.
            //bu tur uyanikliklarin onune gecmeliyiz.
            if (mevcutsatislist.Count > 1)
            {
                foreach (var item in mevcutsatislist)
                {
                    DetayliSalesList.Remove(item);
                }
            }
            if (mevcutsatislist.Count == 1)
            {
                mevcutsatislist[0].sth_fiyat_gosterge = MainFiyat;
                mevcutsatislist[0].sth_miktar_gosterge = MainMiktar;
                mevcutsatislist[0].sth_stok_kod = SelectedStockModel.sto_kod;
                mevcutsatislist[0].sth_stok_isim = SelectedStockModel.sto_isim;
                mevcutsatislist[0].sth_birim_ad = SelectedStockModel.sto_birim1_ad;
                mevcutsatislist[0].sth_tarih = DateTime.Now.Date;
                mevcutsatislist[0].sth_vergi_pntr = SelectedStockModel.VERGI_NO;
                mevcutsatislist[0].sth_vryuzde = SelectedStockModel.vryuzde;
                mevcutsatislist[0].sth_doviz_cins = SelectedDovizKuru.Kur_no;
                mevcutsatislist[0].sth_har_doviz_kur = NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1);
                mevcutsatislist[0].sth_doviz_ismi = SelectedDovizKuru.Kur_sembol;
                mevcutsatislist[0].sth_resim_url = SelectedStockModel.stok_resim_url;
                mevcutsatislist[0].sth_renk_beden_seri_baglanti = Myguid;
                mevcutsatislist[0].Renk_beden_full_bilgi = stokgun_renk_beden_serino_aciklamasi;
                mevcutsatislist[0].sth_parti_kodu = FinalParti;
                mevcutsatislist[0].sth_lot_no = NumericConverter.StringToInt(FinalLot);
                mevcutsatislist[0].sth_cari = SelectedCustomerModel.cari_kod;

            }
            else
            {

                DetayliSalesList.Add
                    (
                    new SatisSthModel
                    {
                        sth_fiyat_gosterge = MainFiyat,
                        sth_miktar_gosterge = MainMiktar,
                        sth_stok_kod = SelectedStockModel.sto_kod,
                        sth_stok_isim = SelectedStockModel.sto_isim,
                        sth_birim_ad = SelectedStockModel.sto_birim1_ad,
                        sth_tarih = DateTime.Now.Date,
                        sth_vergi_pntr = SelectedStockModel.VERGI_NO,
                        sth_vryuzde = SelectedStockModel.vryuzde,
                        sth_doviz_cins = SelectedDovizKuru.Kur_no,
                        sth_har_doviz_kur = NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1),
                        sth_doviz_ismi = SelectedDovizKuru.Kur_sembol,
                        sth_resim_url = SelectedStockModel.stok_resim_url,
                        sth_renk_beden_seri_baglanti = Myguid,
                        Renk_beden_full_bilgi = stokgun_renk_beden_serino_aciklamasi,
                        sth_parti_kodu = FinalParti,
                        sth_lot_no = NumericConverter.StringToInt(FinalLot),
                        sth_cari = SelectedCustomerModel.cari_kod,
                    });
            }
            FinalParti = "";
            FinalLot = "";
            SelectedParti = null;
            SelectedLot = "";
            PartiTxt = "";
            LotTxt = "";
            await HelpME.PopKapat();
            //CalculateSumGO(this);
            CalculateSumGO(this);
        }
        private void satissartlariuygula()
        {
            try
            {
                if (_LSTMANAGER.SATISSARTLARI.ToList().Any())
                {

                    StokFiyatGuncelle();

                    foreach (var item in _LSTMANAGER.SATISSARTLARI.ToList())
                    {
                        foreach (var itemstoklar in _LSTMANAGER.STOCKLIST.ToList())
                        {
                            int depokotnrol = 0;
                            if (item.sat_depo_no == 0)
                                depokotnrol = SelectedDepo.dep_no;
                            else depokotnrol = item.sat_depo_no;

                            if (

                       item.sat_basla_tarih <= DateTime.Now
                       && item.sat_bitis_tarih >= DateTime.Now
                       && item.sat_cari_kod == SelectedCustomerModel.cari_kod
                       && depokotnrol == SelectedDepo.dep_no
                       && item.sat_doviz_cinsi == SelectedDovizKuru.Kur_no
                       && item.sat_odeme_plan == SelectedOdemePlani.odp_no
                       && item.sat_stok_kod == itemstoklar.sto_kod
                       )
                            {
                                //abla
                                itemstoklar.sto_fiyat = Math.Round(item.sat_brut_fiyat, 2);
                                itemstoklar.sto_indirimbilgisi = "Satış Şartı:" + Math.Round((item.sat_brut_fiyat - item.sat_sonfiyat), 2).ToString();
                            }
                        }

                        foreach (var itemsth in DetayliSalesList.ToList())
                        {

                            int depokotnrol = 0;
                            if (item.sat_depo_no == 0)
                                depokotnrol = SelectedDepo.dep_no;
                            else depokotnrol = item.sat_depo_no;

                            if (

                           item.sat_basla_tarih <= DateTime.Now
                           && item.sat_bitis_tarih >= DateTime.Now
                           && item.sat_cari_kod == SelectedCustomerModel.cari_kod
                           && depokotnrol == SelectedDepo.dep_no
                           && item.sat_doviz_cinsi == SelectedDovizKuru.Kur_no
                           && item.sat_odeme_plan == SelectedOdemePlani.odp_no
                           && item.sat_stok_kod == itemsth.sth_stok_kod
                           )
                            {
                                itemsth.sth_fiyat = Math.Round(item.sat_brut_fiyat, 2);
                                itemsth.sth_iskonto2 = Math.Round((item.sat_brut_fiyat - item.sat_sonfiyat) * itemsth.sth_miktar, 2);
                                itemsth.sth_iskonto2_info = "Satış Şartı: "; //+ itemsth.sth_iskonto2.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                HelpME.MessageShow("Satis Sartlari Hata", ex.Message, "Ok");
            }

        }

        private async void kampanyauygula()
        {

            if (SelectedCustomerModel == null || SelectedDepo == null || SelectedDovizKuru == null || SelectedOdemePlani == null) return;

            try
            {
                if (_LSTMANAGER.KampanyalarList.ToList().Any())
                {

                    foreach (var itemsxxsx in _LSTMANAGER.STOCKLIST.ToList())
                    {
                        itemsxxsx.sto_bedavadurumu.Clear();
                        itemsxxsx.sto_indirimbilgisi = "";
                        itemsxxsx.kampanyavisible = false;
                    }
                    foreach (var item in DetayliSalesList.ToList())
                    {
                        if (!item.isbedavalikampanya)
                        {
                            item.sth_iskonto2 = 0;
                            item.sth_iskonto2_info = "";
                        }
                    }

                    var toplamtutars = DetayliSalesList.Sum(x => x.sth_tutar) / NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1);
                    var toplammiktars = DetayliSalesList.Sum(x => x.sth_miktar);

                    foreach (var item in _LSTMANAGER.KampanyalarList)
                    {

                        List<string> carikodlar = item.KAMP_CARI_KODLAR.Split(';').ToList();
                        List<string> carigruplar = item.KAMP_CARI_GRUPLAR.Split(';').ToList();
                        List<string> carisektorlar = item.KAMP_CARI_SEKTORLAR.Split(';').ToList();
                        List<string> caribolgeler = item.KAMP_CARI_BOLGELER.Split(';').ToList();
                        List<string> caritemsilciler = item.KAMP_CARI_TEMSILCI.Split(';').ToList();
                        List<string> odemeplanlari = item.KAMP_CARI_ODEMEPLANI.Split(';').ToList();
                        List<string> projeler = item.KAMP_CARI_PROJE.Split(';').ToList();
                        List<string> srmler = item.KAMP_CARI_SRM.Split(';').ToList();
                        List<string> odemeyontemleri = item.KAMP_CARI_ODEMEYONTEMI.Split(';').ToList();
                        List<string> stoklar = item.KAMP_STOKLAR.Split(';').ToList();
                        List<string> stokkategorileri = item.KAMP_STOKLAR_KATEGORI.Split(';').ToList();
                        List<string> stokanagruplari = item.KAMP_STOKLAR_ANAGRUP.Split(';').ToList();
                        List<string> stokaltgruplari = item.KAMP_STOKLAR_ALTGRUP.Split(';').ToList();
                        List<string> stokureticileri = item.KAMP_STOKLAR_URETICI.Split(';').ToList();
                        List<string> stoksektorlari = item.KAMP_STOKLAR_SEKTOR.Split(';').ToList();
                        List<string> stokreyonlari = item.KAMP_STOKLAR_REYON.Split(';').ToList();
                        List<string> stokambalajlari = item.KAMP_STOKLAR_AMBALAJ.Split(';').ToList();
                        List<string> stokmarkalari = item.KAMP_STOKLAR_MARKA.Split(';').ToList();
                        List<string> fiyatlisteleri = item.KAMP_FIYATLISTELERI.Split(';').ToList();
                        var minimumtutar = item.KAMP_MINUMUM_TUTAR;
                        var minimummiktar = item.KAMP_MIMINUM_MIKTAR;
                        var alana1 = item.KAMP_IF_MIKTAR1;
                        var alana2 = item.KAMP_IF_MIKTAR2;
                        var alana3 = item.KAMP_IF_MIKTAR3;
                        var alana4 = item.KAMP_IF_MIKTAR4;
                        var alana5 = item.KAMP_IF_MIKTAR5;
                        var bedava1 = item.KAMP_THEN_MIKTAR1;
                        var bedava2 = item.KAMP_THEN_MIKTAR2;
                        var bedava3 = item.KAMP_THEN_MIKTAR3;
                        var bedava4 = item.KAMP_THEN_MIKTAR4;
                        var bedava5 = item.KAMP_THEN_MIKTAR5;

                        var gecerliolanfaturalar = item.KAMP_UYGULANACAK_FATLAR.Split(';');

                        #region listekontrol
                        if (item.KAMP_CARI_KODLAR == "")
                        {
                            carikodlar.Clear();
                        }
                        if (item.KAMP_CARI_GRUPLAR == "")
                        {
                            carigruplar.Clear();
                        }
                        if (item.KAMP_CARI_SEKTORLAR == "")
                        {
                            carisektorlar.Clear();
                        }
                        if (item.KAMP_CARI_BOLGELER == "")
                        {
                            caribolgeler.Clear();
                        }
                        if (item.KAMP_CARI_TEMSILCI == "")
                        {
                            caritemsilciler.Clear();
                        }
                        if (item.KAMP_CARI_ODEMEPLANI == "")
                        {
                            odemeplanlari.Clear();
                        }
                        if (item.KAMP_CARI_PROJE == "")
                        {
                            projeler.Clear();
                        }
                        if (item.KAMP_CARI_SRM == "")
                        {
                            srmler.Clear();
                        }
                        if (item.KAMP_CARI_ODEMEYONTEMI == "")
                        {
                            odemeyontemleri.Clear();
                        }
                        if (item.KAMP_STOKLAR == "")
                        {
                            stoklar.Clear();
                        }
                        if (item.KAMP_STOKLAR_KATEGORI == "")
                        {
                            stokkategorileri.Clear();
                        }
                        if (item.KAMP_STOKLAR_ANAGRUP == "")
                        {
                            stokanagruplari.Clear();
                        }
                        if (item.KAMP_STOKLAR_ALTGRUP == "")
                        {
                            stokaltgruplari.Clear();
                        }
                        if (item.KAMP_STOKLAR_URETICI == "")
                        {
                            stokureticileri.Clear();
                        }
                        if (item.KAMP_STOKLAR_SEKTOR == "")
                        {
                            stoksektorlari.Clear();
                        }
                        if (item.KAMP_STOKLAR_REYON == "")
                        {
                            stokreyonlari.Clear();
                        }
                        if (item.KAMP_STOKLAR_AMBALAJ == "")
                        {
                            stokambalajlari.Clear();
                        }
                        if (item.KAMP_STOKLAR_MARKA == "")
                        {
                            stokmarkalari.Clear();
                        }
                        if (item.KAMP_FIYATLISTELERI == "")
                        {
                            fiyatlisteleri.Clear();
                        }

                        #endregion

                        foreach (var itemsth in DetayliSalesList.ToList())
                        {

                            if (itemsth.sth_tutar <= item.KAMP_MINUMUM_TUTAR / NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1) || itemsth.sth_miktar <= item.KAMP_MIMINUM_MIKTAR)
                            {
                                itemsth.sth_iskonto2 = 0;
                                itemsth.sth_iskonto2_info = "";
                            }
                            else
                            {
                                //GARIP5
                                var stockinfo = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == itemsth.sth_stok_kod).FirstOrDefault();

                                if (
                                         (!gecerliolanfaturalar.Any() || gecerliolanfaturalar.Contains("0"))
                                      && (!carikodlar.Any() || carikodlar.Contains(SelectedCustomerModel.cari_kod))
                                      && (!carigruplar.Any() || carigruplar.Contains(SelectedCustomerModel.cari_grup_kodu))
                                      && (!carisektorlar.Any() || carisektorlar.Contains(SelectedCustomerModel.cari_sektor_kodu))
                                      && (!caribolgeler.Any() || caribolgeler.Contains(SelectedCustomerModel.cari_bolge_kodu))
                                      && (!caritemsilciler.Any() || caritemsilciler.Contains(SelectedCustomerModel.cari_temsilci_kodu))
                                      && (!odemeplanlari.Any() || odemeplanlari.Contains(SelectedOdemePlani.odp_no.ToString()))
                                      && (!projeler.Any() || projeler.Contains(SelectedProje.pro_kodu))
                                      && (!srmler.Any() || srmler.Contains(SelectedSorumluluk.som_kod))
                                      && (!odemeyontemleri.Any() || odemeyontemleri.Contains(SelectedOdemePlani.odp_no.ToString()))
                                      && (!stoklar.Any() || stoklar.Contains(itemsth.sth_stok_kod))
                                      && (!stokkategorileri.Any() || stokkategorileri.Contains(stockinfo.sto_kategori_kodu))
                                      && (!stokanagruplari.Any() || stokanagruplari.Contains(stockinfo.sto_anagrup_kod))
                                      && (!stokaltgruplari.Any() || stokaltgruplari.Contains(stockinfo.sto_altgrup_kod))
                                      && (!stokureticileri.Any() || stokureticileri.Contains(stockinfo.sto_uretici_kodu))
                                      && (!stoksektorlari.Any() || stoksektorlari.Contains(stockinfo.sto_sektor_kodu))
                                      && (!stokreyonlari.Any() || stokreyonlari.Contains(stockinfo.sto_reyon_kodu))
                                      && (!stokambalajlari.Any() || stokambalajlari.Contains(stockinfo.sto_ambalaj_kodu))
                                      && (!stokmarkalari.Any() || stokmarkalari.Contains(stockinfo.sto_marka_kodu))
                                       && (!fiyatlisteleri.Any() || fiyatlisteleri.Contains(SelectedFiyatListesi.sfl_sirano.ToString()))

                                  )
                                {
                                    if (item.KAMP_YUZDESEL > 0 || item.KAMP_TUTAR > 0)
                                    {


                                        if (item.KAMP_YUZDESEL != 0)
                                        {
                                            itemsth.sth_iskonto2 = Math.Round(stockinfo.sto_fiyat * item.KAMP_YUZDESEL / 100 * itemsth.sth_miktar / NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1), 2);
                                            itemsth.sth_iskonto2_info = "(%" + item.KAMP_YUZDESEL.ToString() + ")";
                                        }
                                        else if (item.KAMP_TUTAR != 0)
                                        {
                                            itemsth.sth_iskonto2 = Math.Round(stockinfo.sto_fiyat - item.KAMP_TUTAR / NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1), 2);
                                        }
                                    }


                                }
                                else
                                //burda cok dikkatli olmaliyim.
                                // eger bir stokhareketi, 10 alana 2 bedava kampanyasina uymuyorsa, bunu runtime zamani listeden kaldirmamiz gerekli. 
                                // aksi halde kullanicilar hile yapabilir. bunun onune gecmemiz lazim

                                 if (item.KAMP_IF_MIKTAR1 > 0 || item.KAMP_IF_MIKTAR2 > 0 || item.KAMP_IF_MIKTAR3 > 0 || item.KAMP_IF_MIKTAR4 > 0 || item.KAMP_IF_MIKTAR5 > 0)
                                {


                                    if (SelectedFirma != null && SelectedSube != null && SelectedCustomerModel != null && SelectedDepo != null && SelectedProje != null && SelectedSorumluluk != null
                                        && SelectedFiyatListesi != null && SelectedOdemePlani != null && SelectedAcikKapali != null
                                        && SelectedDovizKuru != null)
                                    {
                                        //bu stok hareketinde 2 tane varmi ona bakiyoruz.

                                        var birstoktan2tanevarmi = from p in DetayliSalesList.Where(xx => xx.sth_stok_kod == itemsth.sth_stok_kod).GroupBy(p => p.sth_stok_kod)
                                                                   select new
                                                                   {
                                                                       count = p.Count(),
                                                                       p.First().sth_stok_kod,
                                                                   };
                                        //eger varsa bu 2 stok hareketini silmeliyiz,
                                        //cunku kampanya sartlarina uymuyor. 
                                        foreach (var itemikitanevarmichk in birstoktan2tanevarmi)
                                        {
                                            if (itemikitanevarmichk.count == 2)
                                            {
                                                var silinsin = DetayliSalesList.Where(x => x.sth_stok_kod == itemikitanevarmichk.sth_stok_kod).ToList();

                                                foreach (var itemsilinsin in silinsin)
                                                {
                                                    DetayliSalesList.Remove(itemsilinsin);

                                                }
                                                HelpME.MessageShow("Uyari", "Kampanya tanimlarina uymayan stok hareketleri silindi...", "ok");
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        foreach (var itemstokkarti in _LSTMANAGER.STOCKLIST)
                        {
                            if (
                                       (!gecerliolanfaturalar.Any() || gecerliolanfaturalar.Contains("0"))
                                    && (!carikodlar.Any() || carikodlar.Contains(SelectedCustomerModel.cari_kod))
                                    && (!carigruplar.Any() || carigruplar.Contains(SelectedCustomerModel.cari_grup_kodu))
                                    && (!carisektorlar.Any() || carisektorlar.Contains(SelectedCustomerModel.cari_sektor_kodu))
                                    && (!caribolgeler.Any() || caribolgeler.Contains(SelectedCustomerModel.cari_bolge_kodu))
                                    && (!caritemsilciler.Any() || caritemsilciler.Contains(SelectedCustomerModel.cari_temsilci_kodu))
                                    && (!odemeplanlari.Any() || odemeplanlari.Contains(SelectedOdemePlani.odp_no.ToString()))
                                    && (!projeler.Any() || projeler.Contains(SelectedProje.pro_kodu))
                                    && (!srmler.Any() || srmler.Contains(SelectedSorumluluk.som_kod))
                                    && (!odemeyontemleri.Any() || odemeyontemleri.Contains(SelectedOdemePlani.odp_no.ToString()))
                                    && (!stoklar.Any() || stoklar.Contains(itemstokkarti.sto_kod))
                                    && (!stokkategorileri.Any() || stokkategorileri.Contains(itemstokkarti.sto_kategori_kodu))
                                    && (!stokanagruplari.Any() || stokanagruplari.Contains(itemstokkarti.sto_anagrup_kod))
                                    && (!stokaltgruplari.Any() || stokaltgruplari.Contains(itemstokkarti.sto_altgrup_kod))
                                    && (!stokureticileri.Any() || stokureticileri.Contains(itemstokkarti.sto_uretici_kodu))
                                    && (!stoksektorlari.Any() || stoksektorlari.Contains(itemstokkarti.sto_sektor_kodu))
                                    && (!stokreyonlari.Any() || stokreyonlari.Contains(itemstokkarti.sto_reyon_kodu))
                                    && (!stokambalajlari.Any() || stokambalajlari.Contains(itemstokkarti.sto_ambalaj_kodu))
                                    && (!stokmarkalari.Any() || stokmarkalari.Contains(itemstokkarti.sto_marka_kodu))
                                     && (!fiyatlisteleri.Any() || fiyatlisteleri.Contains(SelectedFiyatListesi.sfl_sirano.ToString()))
                                    && toplamtutars >= item.KAMP_MINUMUM_TUTAR && toplammiktars >= item.KAMP_MINUMUM_TUTAR
                                )
                            {

                                if (item.KAMP_IF_MIKTAR1 > 0 || item.KAMP_IF_MIKTAR2 > 0 || item.KAMP_IF_MIKTAR3 > 0 || item.KAMP_IF_MIKTAR4 > 0 || item.KAMP_IF_MIKTAR5 > 0)
                                {
                                    itemstokkarti.sto_bedavadurumu.Add(AppResources.Yok);
                                    itemstokkarti.sto_bedavadurumu.Add(item.KAMP_IF_MIKTAR1.ToString() + " + " + item.KAMP_THEN_MIKTAR1);
                                    itemstokkarti.sto_bedavadurumu.Add(item.KAMP_IF_MIKTAR2.ToString() + " + " + item.KAMP_THEN_MIKTAR2);
                                    itemstokkarti.sto_bedavadurumu.Add(item.KAMP_IF_MIKTAR3.ToString() + " + " + item.KAMP_THEN_MIKTAR3);
                                    itemstokkarti.sto_bedavadurumu.Add(item.KAMP_IF_MIKTAR4.ToString() + " + " + item.KAMP_THEN_MIKTAR4);
                                    itemstokkarti.sto_bedavadurumu.Add(item.KAMP_IF_MIKTAR5.ToString() + " + " + item.KAMP_THEN_MIKTAR5);
                                    itemstokkarti.kampanyavisible = true;
                                }
                                else if (item.KAMP_TUTAR > 0)
                                {
                                    itemstokkarti.sto_indirimbilgisi = item.KAMP_TUTAR.ToString() + itemstokkarti.sto_doviz_ad;
                                }
                                else if (item.KAMP_YUZDESEL > 0)
                                {
                                    itemstokkarti.sto_indirimbilgisi = item.KAMP_YUZDESEL.ToString() + " %";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("error", "Kampanya hatasi " + ex.Message, "ok");
            }
        }
        private void SumRenkBedenSeriNoMiktarlari()
        {
            MainMiktar = (NumericConverter.StringToDouble(RenkBedenMiktar1) + NumericConverter.StringToDouble(RenkBedenMiktar2) + NumericConverter.StringToDouble(RenkBedenMiktar3) + NumericConverter.StringToDouble(RenkBedenMiktar4) + NumericConverter.StringToDouble(RenkBedenMiktar5) + NumericConverter.StringToDouble(RenkBedenMiktar6) + NumericConverter.StringToDouble(RenkBedenMiktar7) + NumericConverter.StringToDouble(RenkBedenMiktar8) + NumericConverter.StringToDouble(RenkBedenMiktar9) + NumericConverter.StringToDouble(RenkBedenMiktar10) + NumericConverter.StringToDouble(SeriNoMiktar1) + NumericConverter.StringToDouble(SeriNoMiktar2) + NumericConverter.StringToDouble(SeriNoMiktar3) + NumericConverter.StringToDouble(SeriNoMiktar4) + NumericConverter.StringToDouble(SeriNoMiktar5) + NumericConverter.StringToDouble(SeriNoMiktar6)).ToString();
        }

        private double _YuzdeToTutar;
        public double YuzdeToTutar
        {
            get { return _YuzdeToTutar; }
            set { _YuzdeToTutar = value; }
        }

        private string _GenelIndirimYUZDE;
        public string GenelIndirimYUZDE
        {
            get
            {
                if (_GenelIndirimYUZDE == null)
                {
                    _GenelIndirimYUZDE = "0";
                }
                if (NumericConverter.StringToDouble(_GenelIndirimYUZDE) > 99)
                {
                    _GenelIndirimYUZDE = "99";
                }
                YuzdeToTutar = NumericConverter.StringToDouble(_GenelIndirimYUZDE) * BurutTutar / 100;
                return NumericConverter.StringDecor(_GenelIndirimYUZDE);
            }
            set
            {
                if (NumericConverter.StringToDouble(_GenelIndirimYUZDE) > 99)
                {
                    _GenelIndirimYUZDE = "99";
                }
                _GenelIndirimYUZDE = NumericConverter.StringDecor(value);
                CalculateSumGO(_GenelIndirimYUZDE);
                YuzdeToTutar = NumericConverter.StringToDouble(_GenelIndirimYUZDE) * BurutTutar / 100;

                INotifyPropertyChanged();
            }
        }

        private double _BurutTutar;
        public double BurutTutar
        {
            get
            {
                return _BurutTutar;
            }
            set
            {
                _BurutTutar = value;
                INotifyPropertyChanged();
            }
        }

        private string _GenelIndirimTL;
        public string GenelIndirimTL
        {
            get
            {
                if (_GenelIndirimTL == null)
                {
                    _GenelIndirimTL = "0";
                }
                return NumericConverter.StringDecor(_GenelIndirimTL);
            }
            set
            {
                _GenelIndirimTL = NumericConverter.StringDecor(value);

                CalculateSumGO(_GenelIndirimTL);
                INotifyPropertyChanged();
            }
        }
        private void CalculateSumGO(object obj)
        {
            if (SelectedFirma == null || SelectedSube == null || SelectedCustomerModel == null || SelectedDepo == null || SelectedProje == null || SelectedSorumluluk == null
                                         || SelectedFiyatListesi == null || SelectedOdemePlani == null || SelectedAcikKapali == null
                                         || SelectedDovizKuru == null) return;
            kampanyauygula();
            satissartlariuygula();

            foreach (var item in DetayliSalesList)
            {
                if (NumericConverter.StringToDouble(GenelIndirimTL) != 0 || NumericConverter.StringToDouble(GenelIndirimYUZDE) != 0)
                {
                    item.sth_iskonto2 = 0;
                    item.sth_iskonto2_info = "";
                }
                item.sth_vergi_burut = item.sth_tutar * item.sth_vryuzde / 100;

                item.sth_vergi = (
                         item.sth_tutar - item.sth_iskonto2
                       - (item.sth_tutar * NumericConverter.StringToDouble(GenelIndirimYUZDE) / 100)
                       )
                       * item.sth_vryuzde
                       / 100;

                var eldeki_mik = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().sto_eldeki_miktar;
            }
            double netx2 = 0;

            var vergi_toplami = DetayliSalesList.Sum(x => x.sth_vergi);

            var tutar_toplami = DetayliSalesList.Sum(x => x.sth_tutar);

            var isk2 = DetayliSalesList.Sum(x => x.sth_iskonto2);

            var netx1 = tutar_toplami - (tutar_toplami * NumericConverter.StringToDouble(GenelIndirimYUZDE) / 100) + vergi_toplami;

            if (netx1 > 0)
            {
                netx2 = (netx1 - NumericConverter.StringToDouble(GenelIndirimTL) - isk2);
            }
            if (netx2 <= 0)
            {

                tutar = "0";
            }
            else
            {
                tutar = Math.Round(netx2, 2).ToString();
            }

            BurutTutar = DetayliSalesList.Sum(x => x.sth_tutar) + DetayliSalesList.Sum(Z => Z.sth_vergi_burut);
            KalemAdeti = DetayliSalesList.Count;
            TopalmStokAdeti = DetayliSalesList.Sum(x => x.sth_miktar);
            BarkodReaderText = "";
        }
        async public Task<string> ScannerKAYA(bool flashOn)
        {
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();

            scanner.BottomText = "Barkodun dik ve Kirmizi cizgi hizasinda olduğundan emin olun.";
            ZXing.Result result = null;
            scanner.AutoFocus();
            TimeSpan ts = new TimeSpan(0, 0, 0, 1, 0);
            Device.StartTimer(ts, () =>
            {
                if (result == null)
                {
                    scanner.AutoFocus();
                    if (flashOn)
                    {
                        scanner.Torch(true);
                    }
                    return true;
                }
                return false;
            });

            try
            {

                result = await scanner.Scan();

                if (result != null)
                {
                    return result.Text;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error:", ex.Message, "ok");
                return string.Empty;
            }

        }
        private async void CameraBarcodeGO(object obj)
        {
            //Barcode_Islemi_yapiliyor = true;

            try
            {
                var okunandeger = await ScannerKAYA(false);

                if (okunandeger != "")
                {
                    var gelenbarkod = _LSTMANAGER.BARCODELIST.Where(x => x.bar_kodu == okunandeger).FirstOrDefault();

                    if (gelenbarkod != null)
                    {
                        var gereklistok = _LSTMANAGER.STOCKLIST.Where(c => c.sto_kod == gelenbarkod.bar_stokkodu).FirstOrDefault();

                        if (gereklistok != null)
                        {
                            SelectedStockModel = gereklistok;
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("No Stock found", "No Barcode Found in the Database...", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("No Barcode", "No Barcode Found in the Database...", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            //Barcode_Islemi_yapiliyor = false;
        }

        private string _BarkodReaderText;
        public string BarkodReaderText
        {
            get { return _BarkodReaderText; }
            set
            {
                _BarkodReaderText = value;
                INotifyPropertyChanged();
            }
        }

        private double _TopalmStokAdeti;
        public double TopalmStokAdeti
        {
            get
            {
                return DetayliSalesList.Sum(x => x.sth_miktar);
            }
            set
            {
                _TopalmStokAdeti = value;
                INotifyPropertyChanged();
            }
        }

        private int _KalemAdeti;

        public int KalemAdeti
        {
            get
            {
                return DetayliSalesList.Count;
            }
            set
            {
                _KalemAdeti = value;
                INotifyPropertyChanged();
            }
        }

        private string _tutar;
        public string tutar
        {
            get
            {
                if (_tutar == null)
                {
                    tutar = "";
                }
                return _tutar.Replace(",", ".");
            }

            set
            {
                _tutar = value.Replace(",", ".");
                //INotifyPropertyChanged("tutar");
                INotifyPropertyChanged();
            }
        }
        private void SeriNoDOWN6GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext6 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar6);
            if (sayi > 0)
            {
                sayi--;
                SeriNoMiktar6 = sayi.ToString();
            }

            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoDOWN5GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext5 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar5);
            if (sayi > 0)
            {
                sayi--;
                SeriNoMiktar5 = sayi.ToString();
            }
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoDOWN4GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext4 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar4);
            if (sayi > 0)
            {
                sayi--;
                SeriNoMiktar4 = sayi.ToString();
            }
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoDOWN3GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext3 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar3);
            if (sayi > 0)
            {
                sayi--;
                SeriNoMiktar3 = sayi.ToString();
            }
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoDOWN2GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext2 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar2);
            if (sayi > 0)
            {
                sayi--;
                SeriNoMiktar2 = sayi.ToString();
            }
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoDOWN1GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext1 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar1);
            if (sayi > 0)
            {
                sayi--;
                SeriNoMiktar1 = sayi.ToString();
            }
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoUP6GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext6 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar6);
            sayi++;
            SeriNoMiktar6 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoUP5GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext5 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar5);

            sayi++;
            SeriNoMiktar5 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoUP4GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext4 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar4);
            sayi++;
            SeriNoMiktar4 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoUP3GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext3 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar3);
            sayi++;
            SeriNoMiktar3 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoUP2GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext2 == "") return;

            }
            double sayi = NumericConverter.StringToDouble(SeriNoMiktar2);
            sayi++;
            SeriNoMiktar2 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }
        private void SeriNoUP1GO(object obj)
        {
            if (SelectedStockModel.sto_detay_takip == 3)
            {
                if (Serinotext1 == "") return;

            }

            double sayi = NumericConverter.StringToDouble(SeriNoMiktar1);
            sayi++;
            SeriNoMiktar1 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }
        private void Amount_DecreaseGO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli || SelectedStockModel.sto_bedenli_takip || SelectedStockModel.sto_detay_takip == 3)
                return;


            double MIKKKK = NumericConverter.StringToDouble(MainMiktar);
            if (MIKKKK > 0)
            {

                MIKKKK--;
                MainMiktar = MIKKKK.ToString();
            }
        }
        private void Amount_IncreaseGO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli || SelectedStockModel.sto_bedenli_takip || SelectedStockModel.sto_detay_takip == 3)
                return;


            double MIKKKK = NumericConverter.StringToDouble(MainMiktar);
            MIKKKK++;
            MainMiktar = MIKKKK.ToString();

        }
        private async void BtnStokGosterGO(object obj)
        {
            SearchStockText = "";
            await HelpME.PopAc(new BuyStockSelectPopUp(this));
        }
        private async void BtnCariGosterGO(object obj)
        {

            SearchCustomerText = "";
            await HelpME.PopAc(new BuyCustomerSelectPopUp(this));
        }

        #region RENKBEDEN MIKTAR ISLEMLERI 

        private void RenkBedenDOWN10GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK10.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden10.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden10.bdn_IndicatorName == "" || SelectedRENK10.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar10);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar10 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN9GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK9.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden9.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden9.bdn_IndicatorName == "" || SelectedRENK9.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar9);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar9 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN8GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK8.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden8.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden8.bdn_IndicatorName == "" || SelectedRENK8.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar8);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar8 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN7GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK7.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden7.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden7.bdn_IndicatorName == "" || SelectedRENK7.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar7);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar7 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN6GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK6.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden6.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden6.bdn_IndicatorName == "" || SelectedRENK6.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar6);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar6 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN5GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK5.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden5.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden5.bdn_IndicatorName == "" || SelectedRENK5.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar5);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar5 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN4GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK4.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden4.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden4.bdn_IndicatorName == "" || SelectedRENK4.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar4);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar4 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN3GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK3.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden3.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden3.bdn_IndicatorName == "" || SelectedRENK3.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar3);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar3 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN2GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK2.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden2.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden2.bdn_IndicatorName == "" || SelectedRENK2.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar2);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar2 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenDOWN1GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK1.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden1.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden1.bdn_IndicatorName == "" || SelectedRENK1.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar1);
            if (sayi > 0)
            {
                sayi--;
                RenkBedenMiktar1 = sayi.ToString();
                SumRenkBedenSeriNoMiktarlari();
            }
        }

        private void RenkBedenUP10GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK10.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden10.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden10.bdn_IndicatorName == "" || SelectedRENK10.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar10);
            sayi++;
            RenkBedenMiktar10 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP9GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK9.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden9.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden9.bdn_IndicatorName == "" || SelectedRENK9.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar9);
            sayi++;
            RenkBedenMiktar9 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP8GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK8.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden8.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden8.bdn_IndicatorName == "" || SelectedRENK8.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar8);
            sayi++;
            RenkBedenMiktar8 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP7GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK7.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden7.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden7.bdn_IndicatorName == "" || SelectedRENK7.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar7);
            sayi++;
            RenkBedenMiktar7 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP6GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK6.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden6.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden6.bdn_IndicatorName == "" || SelectedRENK6.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar6);
            sayi++;
            RenkBedenMiktar6 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP5GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK5.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden5.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden5.bdn_IndicatorName == "" || SelectedRENK5.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar5);
            sayi++;
            RenkBedenMiktar5 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP4GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK4.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden4.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden4.bdn_IndicatorName == "" || SelectedRENK4.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar4);
            sayi++;
            RenkBedenMiktar4 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP3GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK3.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden3.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden3.bdn_IndicatorName == "" || SelectedRENK3.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar3);
            sayi++;
            RenkBedenMiktar3 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }

        private void RenkBedenUP2GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK2.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden2.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden2.bdn_IndicatorName == "" || SelectedRENK2.rnk_IndicatorName == "") return;
            }
            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar2);
            sayi++;
            RenkBedenMiktar2 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }




        private void RenkBedenUP1GO(object obj)
        {
            if (SelectedStockModel.sto_renkDetayli)
            {
                if (SelectedRENK1.rnk_IndicatorName == "") return;

            }
            if (SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden1.bdn_IndicatorName == "") return;
            }
            if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)
            {
                if (SelectedBeden1.bdn_IndicatorName == "" || SelectedRENK1.rnk_IndicatorName == "") return;
            }

            double sayi = NumericConverter.StringToDouble(RenkBedenMiktar1);
            sayi++;
            RenkBedenMiktar1 = sayi.ToString();
            SumRenkBedenSeriNoMiktarlari();
        }






        private string _MainMiktar;

        public string MainMiktar
        {
            get
            {
                if (_MainMiktar == null)
                {
                    _MainTutar = "0";
                }
                return NumericConverter.StringDecor(_MainMiktar);
            }
            set
            {
                _MainMiktar = NumericConverter.StringDecor(value);
                if (MainMiktar != null || MainFiyat != null)
                {
                    var mikmm = NumericConverter.StringToDouble(MainMiktar);
                    var fiyat = NumericConverter.StringToDouble(MainFiyat);
                    var islem = mikmm * fiyat;
                    MainTutar = islem.ToString();
                }
                INotifyPropertyChanged();
            }
        }

        private string _MainFiyat;

        public string MainFiyat
        {
            get
            {
                if (_MainFiyat == null)
                {
                    _MainFiyat = "0";
                }
                return NumericConverter.StringDecor(_MainFiyat);
            }
            set
            {
                _MainFiyat = NumericConverter.StringDecor(value);

                if (MainMiktar != null || MainFiyat != null)
                {
                    var mikmm = NumericConverter.StringToDouble(MainMiktar);
                    var fiyat = NumericConverter.StringToDouble(MainFiyat);
                    var islem = mikmm * fiyat;
                    MainTutar = islem.ToString();
                }
                INotifyPropertyChanged();
            }
        }

        private string _MainTutar;

        public string MainTutar
        {
            get
            {
                if (_MainTutar == null)
                {
                    _MainTutar = "0";
                }

                return NumericConverter.StringDecor(_MainTutar);
            }
            set
            {
                _MainTutar = value;

                INotifyPropertyChanged();
            }
        }




        private string _RenkBedenMiktar1;
        public string RenkBedenMiktar1
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar1); }
            set
            {
                _RenkBedenMiktar1 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }


        private string _RenkBedenMiktar2;
        public string RenkBedenMiktar2
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar2); }
            set
            {
                _RenkBedenMiktar2 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar3;
        public string RenkBedenMiktar3
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar3); }
            set
            {
                _RenkBedenMiktar3 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar4;
        public string RenkBedenMiktar4
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar4); }
            set
            {
                _RenkBedenMiktar4 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar5;
        public string RenkBedenMiktar5
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar5); }
            set
            {
                _RenkBedenMiktar5 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar6;
        public string RenkBedenMiktar6
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar6); }
            set
            {
                _RenkBedenMiktar6 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar7;
        public string RenkBedenMiktar7
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar7); }
            set
            {
                _RenkBedenMiktar7 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar8;
        public string RenkBedenMiktar8
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar8); }
            set
            {
                _RenkBedenMiktar8 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _RenkBedenMiktar9;
        public string RenkBedenMiktar9
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar9); }
            set
            {
                _RenkBedenMiktar9 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }

        private string _RenkBedenMiktar10;
        public string RenkBedenMiktar10
        {
            get { return NumericConverter.StringDecor(_RenkBedenMiktar10); }
            set
            {
                _RenkBedenMiktar10 = value;
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }


        private string _SeriNoMiktar1;
        public string SeriNoMiktar1
        {
            get { return NumericConverter.StringToIntStringValue(_SeriNoMiktar1); }
            set
            {
                _SeriNoMiktar1 = NumericConverter.StringToIntStringValue(value);
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }

        private string _SeriNoMiktar2;
        public string SeriNoMiktar2
        {
            get { return NumericConverter.StringToIntStringValue(_SeriNoMiktar2); }
            set
            {
                _SeriNoMiktar2 = NumericConverter.StringToIntStringValue(value);
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _SeriNoMiktar3;
        public string SeriNoMiktar3
        {
            get { return NumericConverter.StringToIntStringValue(_SeriNoMiktar3); }
            set
            {
                _SeriNoMiktar3 = NumericConverter.StringToIntStringValue(value);
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }

        private string _SeriNoMiktar4;
        public string SeriNoMiktar4
        {
            get { return NumericConverter.StringToIntStringValue(_SeriNoMiktar4); }
            set
            {
                _SeriNoMiktar4 = NumericConverter.StringToIntStringValue(value);
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }
        private string _SeriNoMiktar5;
        public string SeriNoMiktar5
        {
            get { return NumericConverter.StringToIntStringValue(_SeriNoMiktar5); }
            set
            {
                _SeriNoMiktar5 = NumericConverter.StringToIntStringValue(value);
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }

        private string _SeriNoMiktar6;
        public string SeriNoMiktar6
        {
            get { return NumericConverter.StringToIntStringValue(_SeriNoMiktar6); }
            set
            {
                _SeriNoMiktar6 = NumericConverter.StringToIntStringValue(value);
                SumRenkBedenSeriNoMiktarlari();
                INotifyPropertyChanged();
            }
        }


        #endregion

      
        #region Properties 
        public ObservableCollection<DovizKurlariModel> DovizKurlari { get; set; }

        private ObservableCollection<CustomerModel> _CustomerList;
        public ObservableCollection<CustomerModel> CustomerList
        {
            get
            {
                return _CustomerList;
            }
            set
            {
                _CustomerList = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StockModel> _StockList;
        public ObservableCollection<StockModel> StockList
        {
            get { return _StockList; }
            set
            {
                _StockList = value;
                StockList_sade = _StockList;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StockModel> _StockList_sade;
        public ObservableCollection<StockModel> StockList_sade
        {
            get
            {
                if (_StockList_sade == null)
                {
                    _StockList_sade = new ObservableCollection<StockModel>(_LSTMANAGER.STOCKLIST.Where(x => x.sto_detay_takip == 0 && x.sto_bedenli_takip == false && x.sto_renkDetayli == false));

                }

                return new ObservableCollection<StockModel>(StockList.Where(x => x.sto_detay_takip == 0 && x.sto_bedenli_takip == false && x.sto_renkDetayli == false));

            }
            set
            {
                _StockList_sade = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<StokPaketleriModel> _StokPaketleriDetailList;

        public ObservableCollection<StokPaketleriModel> StokPaketleriDetailList
        {
            get
            {
                if (_StokPaketleriDetailList == null)
                {
                    _StokPaketleriDetailList = _LSTMANAGER.STOKPAKETLERI;
                }

                return _StokPaketleriDetailList;
            }
            set { _StokPaketleriDetailList = value; }
        }

        private ObservableCollection<StokPaketleriHeaders> _StokPaketleriHeaders;

        public ObservableCollection<StokPaketleriHeaders> StokPaketleriHeaders
        {
            get
            {
                if (_StokPaketleriHeaders == null && _LSTMANAGER.STOKPAKETLERI != null)
                {
                    if (_LSTMANAGER.STOKPAKETLERI.Any())
                    {

                        var headers = _LSTMANAGER.STOKPAKETLERI.GroupBy(x => new { x.pak_kod, x.pak_ismi, x.pak_fiyat, x.pak_doviz_cins });
                        _StokPaketleriHeaders = new ObservableCollection<StokPaketleriHeaders>();
                        foreach (var item in headers)
                        {
                            var kurbilgisi = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == item.Key.pak_doviz_cins);

                            if (kurbilgisi.Any())
                            {
                                _StokPaketleriHeaders.Add(new StokPaketleriHeaders
                                {
                                    pak_kod = item.Key.pak_kod,
                                    pak_ismi = item.Key.pak_ismi,
                                    pak_fiyat = item.Key.pak_fiyat,
                                    pak_carpan = "1",
                                    pak_doviz_cins = kurbilgisi.FirstOrDefault().Kur_sembol

                                });
                            }


                        }


                    }

                }

                return _StokPaketleriHeaders;
            }
            set { _StokPaketleriHeaders = value; }
        }


        private ObservableCollection<SatisSthModel> _DetayliSalesList;
        public ObservableCollection<SatisSthModel> DetayliSalesList
        {
            get
            {
                if (_DetayliSalesList == null)
                {
                    _DetayliSalesList = _LSTMANAGER.DETAYLISALESLIST;
                }
                return _DetayliSalesList;
            }
            set
            {
                _DetayliSalesList = value;
                INotifyPropertyChanged();
            }
        }

        private DateTime _Tarih;
        public DateTime Tarih
        {
            get { return _Tarih; }
            set
            {
                _Tarih = value;
                INotifyPropertyChanged();
            }
        }
        public ObservableCollection<FirmalarModel> Firmalar_list { get; set; }
        public ObservableCollection<SubelerModel> Subeler_list { get; set; }
        public ObservableCollection<DepoIsimleriModel> Depolar_List { get; set; }
        public ObservableCollection<ProjeModel> Projeler_List { get; set; }
        public ObservableCollection<SorumlulukModel> Sorumluluk_List { get; set; }
        public ObservableCollection<OdemePlanlariModel> OdemePlanlari_List { get; set; }
        public ObservableCollection<StokListeTanimlamalariModel> Fiyat_Listesi { get; set; }
        public ObservableCollection<Normal_Iade_Model> Normal_Iade { get; set; }
        public ObservableCollection<Acik_Kapali_Model> Acik_Kapali { get; set; }

        private FirmalarModel _SelectedFirma;
        public FirmalarModel SelectedFirma
        {
            get { return _SelectedFirma; }
            set
            {
                _SelectedFirma = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private SubelerModel _SelectedSube;
        public SubelerModel SelectedSube
        {
            get
            {
                return _SelectedSube;
            }
            set
            {
                _SelectedSube = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private DepoIsimleriModel _SelectedDepo;
        public DepoIsimleriModel SelectedDepo
        {
            get { return _SelectedDepo; }
            set
            {
                _SelectedDepo = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private ProjeModel _SelectedProje;
        public ProjeModel SelectedProje
        {
            get
            {
                if (_SelectedProje == null)
                {
                    _SelectedProje = new ProjeModel { pro_adi = "", pro_kodu = "" };
                }
                return _SelectedProje;
            }
            set
            {
                _SelectedProje = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private SorumlulukModel _SelectedSorumluluk;
        public SorumlulukModel SelectedSorumluluk
        {
            get
            {
                if (_SelectedSorumluluk == null)
                {
                    _SelectedSorumluluk = new SorumlulukModel { som_isim = "", som_kod = "" };
                }
                return _SelectedSorumluluk;
            }
            set
            {
                _SelectedSorumluluk = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private OdemePlanlariModel _SelectedOdemePlani;
        public OdemePlanlariModel SelectedOdemePlani
        {
            get
            {
                if (_SelectedOdemePlani == null)
                {
                    _SelectedOdemePlani = new OdemePlanlariModel { odp_no = 0, odp_adi = AppResources.Nakit };
                }
                return _SelectedOdemePlani;
            }
            set
            {
                _SelectedOdemePlani = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private StokListeTanimlamalariModel _SelectedFiyatListesi;
        public StokListeTanimlamalariModel SelectedFiyatListesi
        {
            get { return _SelectedFiyatListesi; }
            set
            {
                _SelectedFiyatListesi = value;


                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }
        private void StokFiyatGuncelle()
        {
            if (_SelectedFiyatListesi != null)
            {
                try
                {
                    if (!_LSTMANAGER.STOCKLIST.Any() || SelectedFiyatListesi == null) return;

                    foreach (var item in _LSTMANAGER.STOCKLIST.ToList())
                    {

                        var fiyat_getir = _LSTMANAGER.STOKFIYATLARI.Where(x => x.sfiyat_stokkod == item.sto_kod && x.sfiyat_listesirano == SelectedFiyatListesi.sfl_sirano);
                        if (fiyat_getir.Any())
                        {
                            item.sto_fiyat = fiyat_getir.FirstOrDefault().sfiyat_fiyati;
                        }
                        else
                        {
                            item.sto_fiyat = 0;
                        }

                    }
                }
                catch (Exception ex)
                {

                    HelpME.MessageShow("Stok FiyatListe dagit", ex.Message, "Ok");
                }
            }
        }

        private Normal_Iade_Model _SelectedNormalIade;
        public Normal_Iade_Model SelectedNormalIade
        {
            get { return _SelectedNormalIade; }
            set
            {
                _SelectedNormalIade = value;
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private Acik_Kapali_Model _SelectedAcikKapali;
        public Acik_Kapali_Model SelectedAcikKapali
        {
            get { return _SelectedAcikKapali; }
            set
            {
                _SelectedAcikKapali = value;
                switch (_SelectedAcikKapali.Acik_Kapali_ID)
                {
                    case 0:
                        Kasalar = null;
                        SelectedKasa = null;
                        Bankalar = null;
                        SelectedBanka = null;
                        isKasaVisible = false;
                        isBankaVisible = false;
                        break;
                    case 1:
                        Kasalar = _LSTMANAGER.Kasalar;
                        SelectedKasa = _LSTMANAGER.Kasalar.Where(x => x.kas_kod == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_KASA).FirstOrDefault();
                        Bankalar = null;
                        SelectedBanka = null;
                        isKasaVisible = true;
                        isBankaVisible = false;
                        break;
                    case 2:
                        Kasalar = null;
                        SelectedKasa = null;
                        Bankalar = _LSTMANAGER.Bankalar;
                        SelectedBanka = _LSTMANAGER.Bankalar.Where(x => x.ban_kod == _LSTMANAGER.ACTIVEUSER.USERS_DEFAULT_BANKA).FirstOrDefault();
                        isKasaVisible = false;
                        isBankaVisible = true;
                        break;


                    default:
                        break;
                }
                CalculateSumGO(this);
                INotifyPropertyChanged();
            }
        }

        private bool _isKasaVisible;
        public bool isKasaVisible
        {
            get { return _isKasaVisible; }
            set
            {
                _isKasaVisible = value;
                INotifyPropertyChanged();
            }
        }

        private bool _isBankaVisible;
        public bool isBankaVisible
        {
            get { return _isBankaVisible; }
            set
            {
                _isBankaVisible = value;
                INotifyPropertyChanged();
            }
        }

        private CustomerModel _SelectedCustomerModel;
        public CustomerModel SelectedCustomerModel
        {
            get
            {
                if (_SelectedCustomerModel == null)
                {



                    if (DetayliSalesList.Count > 0)
                    {
                        _SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == DetayliSalesList[0].sth_cari).FirstOrDefault();

                    }
                    else
                    {
                        _SelectedCustomerModel = new CustomerModel { cari_kod = "" };
                    }


                }
                return _SelectedCustomerModel;
            }
            set
            {
                try
                {
                    _SelectedCustomerModel = value;
                    INotifyPropertyChanged();
                    HelpME.PopKapat();
                    if (_SelectedCustomerModel != null)
                    {
                        SelectedDovizKuru = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == _SelectedCustomerModel.cari_doviz1).FirstOrDefault();

                        //onceden cari secilmis ise, ve biz o cari yi degistirmek istersek, stok hareketlerindeki cari bolumunu de guncellememiz gerekiyor.
                        //yoksa bussuru problem
                        foreach (var item in DetayliSalesList.ToList())
                        {
                            item.sth_cari = _SelectedCustomerModel.cari_kod;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private string _SearchCustomerText;
        public string SearchCustomerText
        {
            get
            {
                if (_SearchCustomerText == null) return "";

                return _SearchCustomerText;
            }
            set
            {
                try
                {
                    _SearchCustomerText = value;
                    var lsit = new ObservableCollection<CustomerModel>(SearchClass.SearchCustomerCls(_SearchCustomerText));
                    CustomerList = lsit;
                }
                catch (Exception)
                {

                }
            }
        }

        private ObservableCollection<RenkModel> _SelectedRenkforaStock;

        public ObservableCollection<RenkModel> SelectedRenkforaStock
        {
            get
            {
                if (_SelectedRenkforaStock == null)
                {
                    _SelectedRenkforaStock = new ObservableCollection<RenkModel>();


                }
                return _SelectedRenkforaStock;
            }
            set
            {
                _SelectedRenkforaStock = value;
            }
        }


        private ObservableCollection<BedenModel> _SelectedBedenforaStock;

        public ObservableCollection<BedenModel> SelectedBedenforaStock
        {
            get
            {
                if (_SelectedBedenforaStock == null)
                {
                    _SelectedBedenforaStock = new ObservableCollection<BedenModel>();

                }
                return _SelectedBedenforaStock;
            }
            set
            {
                _SelectedBedenforaStock = value;
            }
        }

        private bool _SeriNoisEnabled1;
        public bool SeriNoisEnabled1
        {
            get { return _SeriNoisEnabled1; }
            set
            {
                _SeriNoisEnabled1 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _SeriNoisEnabled2;
        public bool SeriNoisEnabled2
        {
            get { return _SeriNoisEnabled2; }
            set
            {
                _SeriNoisEnabled2 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _SeriNoisEnabled3;
        public bool SeriNoisEnabled3
        {
            get { return _SeriNoisEnabled3; }
            set
            {
                _SeriNoisEnabled3 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _SeriNoisEnabled4;
        public bool SeriNoisEnabled4
        {
            get { return _SeriNoisEnabled4; }
            set
            {
                _SeriNoisEnabled4 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _SeriNoisEnabled5;
        public bool SeriNoisEnabled5
        {
            get { return _SeriNoisEnabled5; }
            set
            {
                _SeriNoisEnabled5 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _SeriNoisEnabled6;
        public bool SeriNoisEnabled6
        {
            get { return _SeriNoisEnabled6; }
            set
            {
                _SeriNoisEnabled6 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled1;
        public bool RenkBedenMiktarIsEnabled1
        {
            get
            {
                return _RenkBedenMiktarIsEnabled1;
            }
            set
            {
                _RenkBedenMiktarIsEnabled1 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled2;
        public bool RenkBedenMiktarIsEnabled2
        {
            get
            {
                return _RenkBedenMiktarIsEnabled2;
            }
            set
            {
                _RenkBedenMiktarIsEnabled2 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled3;
        public bool RenkBedenMiktarIsEnabled3
        {
            get
            {
                return _RenkBedenMiktarIsEnabled3;
            }
            set
            {
                _RenkBedenMiktarIsEnabled3 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled4;
        public bool RenkBedenMiktarIsEnabled4
        {
            get
            {
                return _RenkBedenMiktarIsEnabled4;
            }
            set
            {
                _RenkBedenMiktarIsEnabled4 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled5;
        public bool RenkBedenMiktarIsEnabled5
        {
            get
            {
                return _RenkBedenMiktarIsEnabled5;
            }
            set
            {
                _RenkBedenMiktarIsEnabled5 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled6;
        public bool RenkBedenMiktarIsEnabled6
        {
            get
            {
                return _RenkBedenMiktarIsEnabled6;
            }
            set
            {
                _RenkBedenMiktarIsEnabled6 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled7;
        public bool RenkBedenMiktarIsEnabled7
        {
            get
            {
                return _RenkBedenMiktarIsEnabled7;
            }
            set
            {
                _RenkBedenMiktarIsEnabled7 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled8;
        public bool RenkBedenMiktarIsEnabled8
        {
            get
            {
                return _RenkBedenMiktarIsEnabled8;
            }
            set
            {
                _RenkBedenMiktarIsEnabled8 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled9;
        public bool RenkBedenMiktarIsEnabled9
        {
            get
            {
                return _RenkBedenMiktarIsEnabled9;
            }
            set
            {
                _RenkBedenMiktarIsEnabled9 = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkBedenMiktarIsEnabled10;
        public bool RenkBedenMiktarIsEnabled10
        {
            get
            {
                return _RenkBedenMiktarIsEnabled10;
            }
            set
            {
                _RenkBedenMiktarIsEnabled10 = value;
                INotifyPropertyChanged();
            }
        }

        private RenkModel _SelectedRENK1;
        public RenkModel SelectedRENK1
        {
            get
            {
                if (_SelectedRENK1 == null)
                {
                    RenkBedenMiktar1 = "0";
                    _SelectedRENK1 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK1;
            }
            set
            {
                _SelectedRENK1 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK1 != null && _SelectedRENK1.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }
                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK1.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar1 = "0";
                            RenkBedenMiktarIsEnabled1 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled1 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK1.rnk_IndicatorName == "" || SelectedBeden1.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar1 = "0";
                            RenkBedenMiktarIsEnabled1 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled1 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK2;
        public RenkModel SelectedRENK2
        {
            get
            {
                if (_SelectedRENK2 == null)
                {
                    _SelectedRENK2 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK2;
            }
            set
            {
                _SelectedRENK2 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK2 != null && _SelectedRENK2.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }


                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK2.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar2 = "0";
                            RenkBedenMiktarIsEnabled2 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled2 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK2.rnk_IndicatorName == "" || SelectedBeden2.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar2 = "0";
                            RenkBedenMiktarIsEnabled2 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled2 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK3;
        public RenkModel SelectedRENK3
        {
            get
            {
                if (_SelectedRENK3 == null)
                {
                    _SelectedRENK3 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK3;
            }
            set
            {
                _SelectedRENK3 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK3 != null && _SelectedRENK3.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }
                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK3.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar3 = "0";
                            RenkBedenMiktarIsEnabled3 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled3 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK3.rnk_IndicatorName == "" || SelectedBeden3.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar3 = "0";
                            RenkBedenMiktarIsEnabled3 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled3 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK4;
        public RenkModel SelectedRENK4
        {
            get
            {
                if (_SelectedRENK4 == null)
                {
                    _SelectedRENK4 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK4;
            }
            set
            {
                _SelectedRENK4 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK4 != null && _SelectedRENK4.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }
                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK4.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar4 = "0";
                            RenkBedenMiktarIsEnabled4 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled4 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK4.rnk_IndicatorName == "" || SelectedBeden4.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar4 = "0";
                            RenkBedenMiktarIsEnabled4 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled4 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK5;
        public RenkModel SelectedRENK5
        {
            get
            {
                if (_SelectedRENK5 == null)
                {
                    _SelectedRENK5 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK5;
            }
            set
            {
                _SelectedRENK5 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK5 != null && _SelectedRENK5.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }
                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK5.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar5 = "0";
                            RenkBedenMiktarIsEnabled5 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled5 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK5.rnk_IndicatorName == "" || SelectedBeden5.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar5 = "0";
                            RenkBedenMiktarIsEnabled5 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled5 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK6;
        public RenkModel SelectedRENK6
        {
            get
            {
                if (_SelectedRENK6 == null)
                {
                    _SelectedRENK6 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK6;
            }
            set
            {
                _SelectedRENK6 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK6 != null && _SelectedRENK6.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK6.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar6 = "0";
                            RenkBedenMiktarIsEnabled6 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled6 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK6.rnk_IndicatorName == "" || SelectedBeden6.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar6 = "0";
                            RenkBedenMiktarIsEnabled6 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled6 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK7;
        public RenkModel SelectedRENK7
        {
            get
            {
                if (_SelectedRENK7 == null)
                {
                    _SelectedRENK7 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK7;
            }
            set
            {
                _SelectedRENK7 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK7 != null && _SelectedRENK7.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK7.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar7 = "0";
                            RenkBedenMiktarIsEnabled7 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled7 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK7.rnk_IndicatorName == "" || SelectedBeden7.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar7 = "0";
                            RenkBedenMiktarIsEnabled7 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled7 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK8;
        public RenkModel SelectedRENK8
        {
            get
            {
                if (_SelectedRENK8 == null)
                {
                    _SelectedRENK8 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK8;
            }
            set
            {
                _SelectedRENK8 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK8 != null && _SelectedRENK8.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK8.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar8 = "0";
                            RenkBedenMiktarIsEnabled8 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled8 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK8.rnk_IndicatorName == "" || SelectedBeden8.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar8 = "0";
                            RenkBedenMiktarIsEnabled8 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled8 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK9;
        public RenkModel SelectedRENK9
        {
            get
            {
                if (_SelectedRENK9 == null)
                {
                    _SelectedRENK9 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK9;
            }
            set
            {
                _SelectedRENK9 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK9 != null && _SelectedRENK9.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK9.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar9 = "0";
                            RenkBedenMiktarIsEnabled9 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled9 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK9.rnk_IndicatorName == "" || SelectedBeden9.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar9 = "0";
                            RenkBedenMiktarIsEnabled9 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled9 = true;
                        }
                    }

                }

            }
        }

        private RenkModel _SelectedRENK10;
        public RenkModel SelectedRENK10
        {
            get
            {
                if (_SelectedRENK10 == null)
                {
                    _SelectedRENK10 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };
                }
                return _SelectedRENK10;
            }
            set
            {
                _SelectedRENK10 = value;

                if (SelectedRenkforaStock.Count > 0)
                {
                    if (_SelectedRENK10 != null && _SelectedRENK10.rnk_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {

                        if (_SelectedRENK10.rnk_IndicatorName == "")
                        {
                            RenkBedenMiktar10 = "0";
                            RenkBedenMiktarIsEnabled10 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled10 = true;
                        }
                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {


                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK10.rnk_IndicatorName == "" || SelectedBeden10.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar10 = "0";
                            RenkBedenMiktarIsEnabled10 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled10 = true;
                        }
                    }

                }

            }
        }

        private BedenModel _SelectedBeden1;
        public BedenModel SelectedBeden1
        {
            get
            {
                if (_SelectedBeden1 == null)
                {
                    _SelectedBeden1 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden1;
            }
            set
            {
                _SelectedBeden1 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden1 != null && _SelectedBeden1.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden1.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar1 = "0";
                            RenkBedenMiktarIsEnabled1 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled1 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK1.rnk_IndicatorName == "" || SelectedBeden1.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar1 = "0";
                            RenkBedenMiktarIsEnabled1 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled1 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden2;
        public BedenModel SelectedBeden2
        {
            get
            {
                if (_SelectedBeden2 == null)
                {
                    _SelectedBeden2 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden2;
            }
            set
            {
                _SelectedBeden2 = value;
                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden2 != null && _SelectedBeden2.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden2.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar2 = "0";
                            RenkBedenMiktarIsEnabled2 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled2 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK2.rnk_IndicatorName == "" || SelectedBeden2.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar2 = "0";
                            RenkBedenMiktarIsEnabled2 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled2 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden3;
        public BedenModel SelectedBeden3
        {
            get
            {
                if (_SelectedBeden3 == null)
                {
                    _SelectedBeden3 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden3;
            }
            set
            {
                _SelectedBeden3 = value;
                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden3 != null && _SelectedBeden3.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden3.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar3 = "0";
                            RenkBedenMiktarIsEnabled3 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled3 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK3.rnk_IndicatorName == "" || SelectedBeden3.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar3 = "0";
                            RenkBedenMiktarIsEnabled3 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled3 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden4;
        public BedenModel SelectedBeden4
        {
            get
            {
                if (_SelectedBeden4 == null)
                {
                    _SelectedBeden4 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden4;
            }
            set
            {
                _SelectedBeden4 = value;
                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden4 != null && _SelectedBeden4.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden4.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar4 = "0";
                            RenkBedenMiktarIsEnabled4 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled4 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK4.rnk_IndicatorName == "" || SelectedBeden4.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar4 = "0";
                            RenkBedenMiktarIsEnabled4 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled4 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden5;
        public BedenModel SelectedBeden5
        {
            get
            {
                if (_SelectedBeden5 == null)
                {
                    _SelectedBeden5 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden5;
            }
            set
            {
                _SelectedBeden5 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden5 != null && _SelectedBeden5.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden5.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar5 = "0";
                            RenkBedenMiktarIsEnabled5 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled5 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK5.rnk_IndicatorName == "" || SelectedBeden5.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar5 = "0";
                            RenkBedenMiktarIsEnabled5 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled5 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden6;
        public BedenModel SelectedBeden6
        {
            get
            {
                if (_SelectedBeden6 == null)
                {
                    _SelectedBeden6 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden6;
            }
            set
            {
                _SelectedBeden6 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden6 != null && _SelectedBeden6.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden6.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar6 = "0";
                            RenkBedenMiktarIsEnabled6 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled6 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK6.rnk_IndicatorName == "" || SelectedBeden6.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar6 = "0";
                            RenkBedenMiktarIsEnabled6 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled6 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden7;
        public BedenModel SelectedBeden7
        {
            get
            {
                if (_SelectedBeden7 == null)
                {
                    _SelectedBeden7 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden7;
            }
            set
            {
                _SelectedBeden7 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden7 != null && _SelectedBeden7.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden7.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar7 = "0";
                            RenkBedenMiktarIsEnabled7 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled7 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK7.rnk_IndicatorName == "" || SelectedBeden7.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar7 = "0";
                            RenkBedenMiktarIsEnabled7 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled7 = true;
                        }
                    }

                }

            }
        }

        private BedenModel _SelectedBeden8;
        public BedenModel SelectedBeden8
        {
            get
            {
                if (_SelectedBeden8 == null)
                {
                    _SelectedBeden8 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden8;
            }
            set
            {
                _SelectedBeden8 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden8 != null && _SelectedBeden8.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden8.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar8 = "0";
                            RenkBedenMiktarIsEnabled8 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled8 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK8.rnk_IndicatorName == "" || SelectedBeden8.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar8 = "0";
                            RenkBedenMiktarIsEnabled8 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled8 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden9;
        public BedenModel SelectedBeden9
        {
            get
            {
                if (_SelectedBeden9 == null)
                {
                    _SelectedBeden9 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden9;
            }
            set
            {
                _SelectedBeden9 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden9 != null && _SelectedBeden9.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden9.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar9 = "0";
                            RenkBedenMiktarIsEnabled9 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled9 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK9.rnk_IndicatorName == "" || SelectedBeden9.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar9 = "0";
                            RenkBedenMiktarIsEnabled9 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled9 = true;
                        }
                    }

                }
            }
        }

        private BedenModel _SelectedBeden10;
        public BedenModel SelectedBeden10
        {
            get
            {
                if (_SelectedBeden10 == null)
                {
                    _SelectedBeden10 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };
                }
                return _SelectedBeden10;
            }
            set
            {
                _SelectedBeden10 = value;

                if (SelectedBedenforaStock.Count > 0)
                {
                    if (_SelectedBeden10 != null && _SelectedBeden10.bdn_IndicatorName != "")
                    {
                        INotifyPropertyChanged();
                    }

                    if (SelectedStockModel.sto_renkDetayli && !SelectedStockModel.sto_bedenli_takip)//sadece renk detayliysa
                    {


                    }
                    if (!SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip)//sadece beden detayliysa
                    {
                        if (_SelectedBeden10.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar10 = "0";
                            RenkBedenMiktarIsEnabled10 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled10 = true;
                        }

                    }
                    if (SelectedStockModel.sto_renkDetayli && SelectedStockModel.sto_bedenli_takip) //hem renk hem beden detayliysa
                    {

                        if (_SelectedRENK10.rnk_IndicatorName == "" || SelectedBeden10.bdn_IndicatorName == "")
                        {
                            RenkBedenMiktar10 = "0";
                            RenkBedenMiktarIsEnabled10 = false;
                        }
                        else
                        {
                            RenkBedenMiktarIsEnabled10 = true;
                        }
                    }

                }
            }
        }

        private string _Serinotext1;
        public string Serinotext1
        {
            get
            {
                if (_Serinotext1 == null)
                {
                    _Serinotext1 = "";
                }
                return _Serinotext1;
            }
            set
            {
                _Serinotext1 = value;
                if (_Serinotext1 == "")
                {
                    SeriNoMiktar1 = "0";
                    SeriNoisEnabled1 = false;
                }
                else
                {
                    SeriNoisEnabled1 = true;
                }
                INotifyPropertyChanged();
            }
        }

        private string _Serinotext2;
        public string Serinotext2
        {
            get
            {
                if (_Serinotext2 == null)
                {
                    _Serinotext2 = "";
                }
                return _Serinotext2;
            }
            set
            {
                _Serinotext2 = value;
                if (_Serinotext2 == "")
                {
                    SeriNoMiktar2 = "0";
                    SeriNoisEnabled2 = false;
                }
                else
                {
                    SeriNoisEnabled2 = true;
                }
                INotifyPropertyChanged();
            }
        }

        private string _Serinotext3;
        public string Serinotext3
        {
            get
            {
                if (_Serinotext3 == null)
                {
                    _Serinotext3 = "";
                }
                return _Serinotext3;
            }
            set
            {
                _Serinotext3 = value;
                if (_Serinotext3 == "")
                {
                    SeriNoMiktar3 = "0";
                    SeriNoisEnabled3 = false;
                }
                else
                {
                    SeriNoisEnabled3 = true;
                }
                INotifyPropertyChanged();
            }
        }

        private string _Serinotext4;
        public string Serinotext4
        {
            get
            {
                if (_Serinotext4 == null)
                {
                    _Serinotext4 = "";
                }
                return _Serinotext4;
            }
            set
            {
                _Serinotext4 = value;
                if (_Serinotext4 == "")
                {
                    SeriNoMiktar4 = "0";
                    SeriNoisEnabled4 = false;
                }
                else
                {
                    SeriNoisEnabled4 = true;
                }
                INotifyPropertyChanged();
            }
        }

        private string _Serinotext5;
        public string Serinotext5
        {
            get
            {
                if (_Serinotext5 == null)
                {
                    _Serinotext5 = "";
                }
                return _Serinotext5;
            }
            set
            {
                _Serinotext5 = value;
                if (_Serinotext5 == "")
                {
                    SeriNoMiktar5 = "0";
                    SeriNoisEnabled5 = false;
                }
                else
                {
                    SeriNoisEnabled5 = true;
                }
                INotifyPropertyChanged();
            }
        }

        private string _Serinotext6;
        public string Serinotext6
        {
            get
            {
                if (_Serinotext6 == null)
                {
                    _Serinotext6 = "";
                }
                return _Serinotext6;
            }
            set
            {
                _Serinotext6 = value;
                if (_Serinotext6 == "")
                {
                    SeriNoMiktar6 = "0";
                    SeriNoisEnabled6 = false;
                }
                else
                {
                    SeriNoisEnabled6 = true;
                }
                INotifyPropertyChanged();
            }
        }
        private ObservableCollection<PartiLotModel> _PartiLotList;
        public ObservableCollection<PartiLotModel> PartiLotList
        {
            get { return _PartiLotList; }
            set
            {
                _PartiLotList = value;
                INotifyPropertyChanged();
            }
        }

        private PartiLotModel _SelectedParti;

        public PartiLotModel SelectedParti
        {
            get
            {
                return _SelectedParti;
            }
            set
            {
                _SelectedParti = value;
                if (_SelectedParti != null)
                {
                    var PRList2 = _LSTMANAGER.PartiLotList.Where(x => x.pl_stokkodu == _SelectedStockModel.sto_kod && x.pl_partikodu == _SelectedParti.pl_partikodu);
                    List<string> myLot = new List<string>();
                    var prlotlist2 = PRList2.GroupBy(m => m.pl_lotno);
                    foreach (var item in prlotlist2)
                    {
                        myLot.Add(item.Key.ToString());
                    }
                    LotList = new ObservableCollection<string>(myLot);
                    PartiTxt = "";
                    LotTxt = "";

                }
                INotifyPropertyChanged();


            }
        }

        private string _PartiTxt;
        public string PartiTxt
        {
            get { return _PartiTxt; }
            set
            {
                _PartiTxt = value;
                if (!string.IsNullOrWhiteSpace(_PartiTxt))
                {
                    SelectedParti = null;
                    SelectedLot = "";
                    INotifyPropertyChanged("SelectedParti");
                    INotifyPropertyChanged("SelectedLot");

                }
                INotifyPropertyChanged();

            }
        }

        private string _LotTxt;
        public string LotTxt
        {
            get
            {
                return _LotTxt;
            }
            set
            {
                _LotTxt = value;
                if (!string.IsNullOrWhiteSpace(_LotTxt))
                {
                    SelectedParti = null;
                    SelectedLot = "";
                    INotifyPropertyChanged("SelectedParti");
                    INotifyPropertyChanged("SelectedLot");
                }
                INotifyPropertyChanged();
            }
        }
        
        private string _SelectedLot;
        public string SelectedLot
        {

            get
            {
                if (_SelectedLot == null)
                {
                    _SelectedLot = "";
                }
                return _SelectedLot;
            }
            set
            {
                _SelectedLot = value;
            }
        }

        private ObservableCollection<string> _LotList;

        public ObservableCollection<string> LotList
        {
            get
            {
                return _LotList;
            }
            set
            {
                _LotList = value;
                INotifyPropertyChanged();
            }
        }

        private StockModel _SelectedStockModel;
        public StockModel SelectedStockModel
        {
            get { return _SelectedStockModel; }
            set
            {
                _SelectedStockModel = value;

                try
                {


                    if (_SelectedStockModel != null)
                    {


                        //eger kampanya secilmis ise, mesela 5 alana 1 bedava secimi yapilmis, ve stok ozellik olarak renk beden seri no ozelligi tasimiyorsa, basarili bir sekilde detaylisatis listemize sth olarak ekliyoruz
                        if (_SelectedStockModel.selectedKampanyabedavaitem.ToString() != AppResources.Yok && _SelectedStockModel.selectedKampanyabedavaitem != null && !_SelectedStockModel.sto_renkDetayli && !_SelectedStockModel.sto_bedenli_takip && _SelectedStockModel.sto_detay_takip == 0)
                        {
                            //garip3



                            //bu stok kartinin sth taki tum hareketlerini siliyoruz.
                            foreach (var item in DetayliSalesList.ToList())
                            {
                                if (item.sth_stok_kod == _SelectedStockModel.sto_kod)
                                {
                                    DetayliSalesList.Remove(item);
                                }
                            }

                            // kampanya tutari ve bedava verilecek miktar
                            var gelenkampanyamiktarlari = _SelectedStockModel.selectedKampanyabedavaitem.Split('+');
                            DetayliSalesList.Add
                              (
                              new SatisSthModel
                              {
                                  sth_fiyat_gosterge = _SelectedStockModel.sto_fiyat.ToString(),
                                  sth_miktar_gosterge = gelenkampanyamiktarlari[0],
                                  sth_stok_kod = SelectedStockModel.sto_kod,
                                  sth_stok_isim = SelectedStockModel.sto_isim,
                                  sth_birim_ad = SelectedStockModel.sto_birim1_ad,
                                  sth_tarih = DateTime.Now.Date,
                                  sth_vergi_pntr = SelectedStockModel.VERGI_NO,
                                  sth_vryuzde = SelectedStockModel.vryuzde,
                                  sth_doviz_cins = SelectedDovizKuru.Kur_no,
                                  sth_har_doviz_kur = NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1),
                                  sth_doviz_ismi = SelectedDovizKuru.Kur_sembol,
                                  sth_resim_url = SelectedStockModel.stok_resim_url,
                                  sth_cari = SelectedCustomerModel.cari_kod,
                                  isbedavalikampanya = true,
                              }); ;


                            DetayliSalesList.Add
                              (
                              new SatisSthModel
                              {
                                  sth_fiyat_gosterge = _SelectedStockModel.sto_fiyat.ToString(),
                                  sth_miktar_gosterge = gelenkampanyamiktarlari[1],
                                  sth_stok_kod = SelectedStockModel.sto_kod,
                                  sth_stok_isim = SelectedStockModel.sto_isim,
                                  sth_birim_ad = SelectedStockModel.sto_birim1_ad,
                                  sth_tarih = DateTime.Now.Date,
                                  sth_vergi_pntr = SelectedStockModel.VERGI_NO,
                                  sth_vryuzde = SelectedStockModel.vryuzde,
                                  sth_doviz_cins = SelectedDovizKuru.Kur_no,
                                  sth_har_doviz_kur = NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1),
                                  sth_doviz_ismi = SelectedDovizKuru.Kur_sembol,
                                  sth_resim_url = SelectedStockModel.stok_resim_url,
                                  sth_iskonto2 = _SelectedStockModel.sto_fiyat * NumericConverter.StringToDouble(gelenkampanyamiktarlari[1]) / NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1),
                                  sth_iskonto2_info = @"(%100)",
                                  sth_cari = SelectedCustomerModel.cari_kod,
                                  isbedavalikampanya = true,

                              }); ;

                            CalculateSumGO(this);


                            HelpME.MessageShow("ok", "Kampanya Eklendi" + _SelectedStockModel.selectedKampanyabedavaitem.ToString(), "ok");



                            return;
                        }



                        MainFiyat = Math.Round((_SelectedStockModel.sto_fiyat / NumericConverter.StringToDouble(SelectedDovizKuru.Kur_fiyat1)), 2).ToString();
                        RenkIsVisible = false;
                        SerinoIsVisible = false;
                        MainMiktarIsEnabled = true;

                        MainMiktar = "0";
                        RenkBedenMiktar1 = "0";
                        RenkBedenMiktar2 = "0";
                        RenkBedenMiktar3 = "0";
                        RenkBedenMiktar4 = "0";
                        RenkBedenMiktar5 = "0";
                        RenkBedenMiktar6 = "0";
                        RenkBedenMiktar7 = "0";
                        RenkBedenMiktar8 = "0";
                        RenkBedenMiktar9 = "0";
                        RenkBedenMiktar10 = "0";

                        SeriNoMiktar1 = "0";
                        SeriNoMiktar2 = "0";
                        SeriNoMiktar3 = "0";
                        SeriNoMiktar4 = "0";
                        SeriNoMiktar5 = "0";
                        SeriNoMiktar6 = "0";

                        Serinotext1 = "";
                        Serinotext2 = "";
                        Serinotext3 = "";
                        Serinotext4 = "";
                        Serinotext5 = "";
                        Serinotext6 = "";

                        SelectedRENK1 = SelectedRENK2 = SelectedRENK3 = SelectedRENK4 = SelectedRENK5 = SelectedRENK6 = SelectedRENK7 = SelectedRENK8 = SelectedRENK9 = SelectedRENK10 = new RenkModel { rnk_IndicatorName = "", rnk_IndicatorValue = "", rnk_kodu = "" };


                        SelectedBeden1 = SelectedBeden2 = SelectedBeden3 = SelectedBeden4 = SelectedBeden5 = SelectedBeden6 = SelectedBeden7 = SelectedBeden8 = SelectedBeden9 = SelectedBeden10 = new BedenModel { bdn_IndicatorName = "", bdn_IndicatorValue = "", bdn_kodu = "" };


                        MainMiktar = "1";
                        if (_SelectedStockModel.sto_renkDetayli || _SelectedStockModel.sto_bedenli_takip)
                        {
                            SelectedRenkforaStock.Clear();
                            SelectedBedenforaStock.Clear();

                            RenkIsVisible = true;
                            MainMiktarIsEnabled = false;

                            var selectedrenklerforastock = _LSTMANAGER.Renkler.Where(X => X.rnk_kodu == SelectedStockModel.sto_renk_kodu).ToList();
                            if (selectedrenklerforastock != null)
                            {
                                if (selectedrenklerforastock.Count > 0)
                                {

                                    SelectedRenkforaStock.Add(new RenkModel { rnk_IndicatorValue = "", rnk_IndicatorName = "", rnk_kodu = "" });
                                    foreach (var item in selectedrenklerforastock)
                                    {
                                        SelectedRenkforaStock.Add(item);
                                    }
                                }
                            }


                            var selectedBedenlerforastock = _LSTMANAGER.Bedenler.Where(X => X.bdn_kodu == SelectedStockModel.sto_beden_kodu).ToList();
                            if (selectedBedenlerforastock != null)
                            {
                                if (selectedBedenlerforastock.Count > 0)
                                {

                                    SelectedBedenforaStock.Add(new BedenModel { bdn_IndicatorValue = "", bdn_IndicatorName = "", bdn_kodu = "" });
                                    foreach (var item in selectedBedenlerforastock)
                                    {
                                        SelectedBedenforaStock.Add(item);
                                    }
                                }
                            }

                        }


                        switch (_SelectedStockModel.sto_detay_takip)
                        {
                            case 0: //normal stok. fakat renk detayi varmi yokmu ona bakmak lazim
                                LotIsVisible = false;
                                PartiIsVisible = false;
                                //RenkIsVisible = false;
                                SerinoIsVisible = false;

                                break;
                            case 1: // parti bazinda takip
                                //sinanbeg
                                PartiIsVisible = true;


                                var PRList = _LSTMANAGER.PartiLotList.Where(x => x.pl_stokkodu == _SelectedStockModel.sto_kod);

                                var parti = PRList.GroupBy(m => m.pl_partikodu);
                                ObservableCollection<PartiLotModel> myparti = new ObservableCollection<PartiLotModel>();
                                foreach (var item in parti)
                                {
                                    myparti.Add(new PartiLotModel { pl_partikodu = item.Key });
                                }
                                PartiLotList = new ObservableCollection<PartiLotModel>(myparti);

                                // SelectedParti = PRList.FirstOrDefault();



                                LotIsVisible = false;
                                RenkIsVisible = false;
                                SerinoIsVisible = false;

                                break;

                            case 2: //parti ve lot bazinda takip 

                                LotIsVisible = true;

                                PartiIsVisible = false;
                                RenkIsVisible = false;
                                SerinoIsVisible = false;


                                var PRList2 = _LSTMANAGER.PartiLotList.Where(x => x.pl_stokkodu == _SelectedStockModel.sto_kod);

                                var parti2 = PRList2.GroupBy(m => m.pl_partikodu);
                                ObservableCollection<PartiLotModel> myparti2 = new ObservableCollection<PartiLotModel>();
                                foreach (var item in parti2)
                                {
                                    myparti2.Add(new PartiLotModel { pl_partikodu = item.Key });
                                }

                                PartiLotList = new ObservableCollection<PartiLotModel>(myparti2);
                                // SelectedParti = PRList2.FirstOrDefault();




                                break;

                            case 3: // seri no lu takip 
                                SerinoIsVisible = true;
                                MainMiktarIsEnabled = false;
                                LotIsVisible = false;
                                PartiIsVisible = false;
                                MainMiktar = "0";

                                break;
                            default:
                                LotIsVisible = false;
                                PartiIsVisible = false;
                                RenkIsVisible = false;
                                SerinoIsVisible = false;
                                MainMiktarIsEnabled = false;
                                break;

                        }

                        //garip
                        HelpME.PopAc(new StockADDNEW(this));

                    }
                }
                catch (Exception ex)
                {

                    HelpME.MessageShow("error", "bir hata meydana geldi:" + ex.Message, "ok");
                }

                INotifyPropertyChanged();
            }
        }

        private DovizKurlariModel _SelectedDovizKuru;
        public DovizKurlariModel SelectedDovizKuru
        {
            get
            {
                if (_SelectedDovizKuru == null)
                {
                    _SelectedDovizKuru = _LSTMANAGER.KURLARLISTE[0];
                }
                return _SelectedDovizKuru;
            }
            set
            {
                _SelectedDovizKuru = value;
                if (_SelectedDovizKuru != null)
                {
                    GenelIndirimTL = "0";
                    GenelIndirimYUZDE = "0";


                    foreach (var item in DetayliSalesList)
                    {
                        double stockfiyati = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().sto_fiyat;
                        if (!AktarimTaraftanGeliyorum)
                        {
                            item.sth_iskonto1 = 0;
                            item.sth_iskonto2 = 0;
                            item.sth_fiyat = Math.Round(stockfiyati / NumericConverter.StringToDouble(_SelectedDovizKuru.Kur_fiyat1), 2);
                            item.sth_fiyat_gosterge = item.sth_fiyat.ToString();
                            item.sth_doviz_ismi = _SelectedDovizKuru.Kur_sembol;
                            CalculateSumGO(this);
                        }



                    }
                }

                INotifyPropertyChanged();
            }
        }

        private string _SearchStockText;
        public string SearchStockText
        {
            get { return _SearchStockText; }
            set
            {
                _SearchStockText = value;
                INotifyPropertyChanged();
                var stcklist = new ObservableCollection<StockModel>(SearchClass.SearchStockCls(_SearchStockText));
                StockList = stcklist;

            }
        }

        private bool _MainMiktarIsEnabled;
        public bool MainMiktarIsEnabled
        {
            get { return _MainMiktarIsEnabled; }
            set
            {
                _MainMiktarIsEnabled = value;
                INotifyPropertyChanged();
            }
        }

        private bool _RenkIsVisible;

        public bool RenkIsVisible
        {
            get { return _RenkIsVisible; }
            set
            {
                _RenkIsVisible = value;

            }
        }

        private bool _SerinoIsVisible;

        public bool SerinoIsVisible
        {
            get { return _SerinoIsVisible; }
            set
            {
                _SerinoIsVisible = value;

            }
        }

        private bool _PartiIsVisible;

        public bool PartiIsVisible
        {
            get { return _PartiIsVisible; }
            set
            {
                _PartiIsVisible = value;
            }
        }

        private bool _LotIsVisible;

        public bool LotIsVisible
        {
            get { return _LotIsVisible; }
            set
            {
                _LotIsVisible = value;
            }
        }

        #endregion

    }
}

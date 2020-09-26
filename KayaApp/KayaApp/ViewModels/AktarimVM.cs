using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Models;
using KayaApp.ViewModels;
using KayaApp.Views.PURCHASE;
using KayaApp.Views.SALES;
using KayaApp.Views.SIPARISLER;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace KayaApp.Views.REPORT
{
    public class AktarimVM : BaseViewModel
    {
        public static bool EditeGidiyorum;

        LISTMANAGER _LSTMANAGER;
        public ICommand KompleHerseyiSil { get; set; }
        public ICommand DeleteTheInovice { get; set; }
        public ICommand DetailLook { get; set; }
        public ICommand EditCommand { get; set; }
        public AktarimVM()
        {
            _LSTMANAGER = DataClass._LSTMANAGER;
            DeleteTheInovice = new Command(DeleteTheInoviceGO);
            DetailLook = new Command(DetailLookGO);
            KompleHerseyiSil = new Command(HerseySilGO);

            EditCommand = new Command(EditCommandGO);
            DataCek();
            EditeGidiyorum = false;
        }
        private async void EditCommandGO(object obj)
        {
            if (obj == null) return;
            if (!(obj is AktarimModel)) return;

            var gelendeger = (AktarimModel)obj;

            switch (gelendeger.Aktarim_IslemKodu)
            {
                #region SATIS FATURASI
                case 1:
                    try
                    {

                        //instance alma durumu. cok onemli...
                        SatisVM ss = new SatisVM();
                        SatisFaturasiPage satissayfasi = new SatisFaturasiPage();

                        await HelpME.SayfaKapat();
                        await HelpME.SayfaKapat();

                        await Application.Current.MainPage.Navigation.PushAsync(satissayfasi);

                        SatisFaturasiPage.SATVMZ.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();

                        _LSTMANAGER.DETAYLISALESLIST.Clear();

                        var SatisFatList = await LocalSQL<SatisFatModel>.GETLISTALL();
                        var secimFatura = SatisFatList.Where(x => x.fat_sth_baglanti == gelendeger.Aktarim_Baglanti_guid).FirstOrDefault();

                        var SatisSth = await LocalSQL<SatisSthModel>.GETLISTALL();
                        var selectedstocks = SatisSth.Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid);

                          
                        var renkbedenler = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.GETLISTALL();
                        var selectedrenkbedens = renkbedenler.Where(x => x.Olusan_Baglantisi_fat == secimFatura.fat_sth_baglanti );
                        _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI = new List<OlusanRenkBedenSeriHareketleriModel>(selectedrenkbedens);


                        SatisVM.AktarimTaraftanGeliyorum = true;

                        foreach (var item in selectedstocks.ToList())
                        {
                            ss.DetayliSalesList.Add(item);
                            // await LocalSQL<SatisSthModel>.DELETEROW(item);
                        }

                        SatisFaturasiPage.SATVMZ.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                        SatisFaturasiPage.SATVMZ.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;


                        SatisFaturasiPage.SATVMZ.SelectedDovizKuru = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == secimFatura.fat_d_cins).FirstOrDefault();
                        SatisFaturasiPage.SATVMZ.SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks.ToList()[0].sth_cikis_depo_no).FirstOrDefault();

                        SatisVM.AktarimTaraftanGeliyorum = false;


                        //   await LocalSQL<SatisFatModel>.DELETEROW(secimFatura);
                        //await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    }

                    catch (Exception ex)
                    {
                        await HelpME.MessageShow("hata", ex.Message, "ok");
                    }

                    break;
                #endregion

                #region ALIS FATURASI
                case 2:
                    try
                    {

                        //instance alma durumu. cok onemli...
                        AlisVM ss = new AlisVM();
                        AlisFaturasiPage alissayfasi = new AlisFaturasiPage();

                        await HelpME.SayfaKapat();
                        await HelpME.SayfaKapat();

                        await Application.Current.MainPage.Navigation.PushAsync(alissayfasi);

                        AlisFaturasiPage.ALVMZ.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();

                        _LSTMANAGER.BUYLIST.Clear();

                        var AlisFatList = await LocalSQL<AlisFatModel>.GETLISTALL();
                        var secimFatura = AlisFatList.Where(x => x.fat_sth_baglanti == gelendeger.Aktarim_Baglanti_guid).FirstOrDefault();

                        var AlisSth = await LocalSQL<AlisSthModel>.GETLISTALL();
                        var selectedstocks = AlisSth.Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid);
                       
                        var renkbedenler = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.GETLISTALL();
                        var selectedrenkbedens = renkbedenler.Where(x => x.Olusan_Baglantisi_fat == secimFatura.fat_sth_baglanti);
                        _LSTMANAGER.ALISFATURASI_RENK_BEDEN_SERI_HAREKETLERI = new List<OlusanRenkBedenSeriHareketleriModel>(selectedrenkbedens);

                        AlisVM.AktarimTaraftanGeliyorum = true;

                        foreach (var item in selectedstocks.ToList())
                        {
                            ss.BuyList.Add(item);
                            // await LocalSQL<SatisSthModel>.DELETEROW(item);
                        }

                        AlisFaturasiPage.ALVMZ.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                        AlisFaturasiPage.ALVMZ.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;


                        AlisFaturasiPage.ALVMZ.SelectedDovizKuru = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == secimFatura.fat_d_cins).FirstOrDefault();
                        AlisFaturasiPage.ALVMZ.SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks.ToList()[0].sth_cikis_depo_no).FirstOrDefault();

                        AlisVM.AktarimTaraftanGeliyorum = false;


                        //   await LocalSQL<SatisFatModel>.DELETEROW(secimFatura);
                        //await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    }

                    catch (Exception ex)
                    {
                        await HelpME.MessageShow("hata", ex.Message, "ok");
                    }
                   
                    break;
                #endregion

                #region Normal Alinan Siparis
                case 3:

                    try
                    {

                        //instance alma durumu. cok onemli...
                        NormalSiparislerVM ss = new NormalSiparislerVM();
                        NormalAlinanSiparisPage NormalAlinanSiparisPagex = new NormalAlinanSiparisPage();

                      
                        _LSTMANAGER.ORDERLIST.Clear();

                        var NormalAlinanSiparisSth = await LocalSQL<NormalAlinanSiparisFatModel>.GETLISTALL();
                        var selectedstocks = NormalAlinanSiparisSth.Where(x => x.sip_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();



                        var renkbedenler = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.GETLISTALL();
                        var selectedrenkbedens = renkbedenler.Where(x => x.Olusan_Baglantisi_fat == selectedstocks[0].sip_islem_baglanti);
                        _LSTMANAGER.NORMALALINANSIPARIS_RENK_BEDEN_SERI_HAREKETLERI = new List<OlusanRenkBedenSeriHareketleriModel>(selectedrenkbedens);

                        ////cok tehlikeli kod. rastgele calisan bisey silmek lazim
                        //foreach (var item in _LSTMANAGER.NORMALALINANSIPARIS_RENK_BEDEN_SERI_HAREKETLERI)
                        //{
                        //    item.Olusan_Baglantisi_sth = item.Olusan_Baglantisi_fat;
                        //}
                        ////cok tehlikeli kod. rastgele calisan bisey silmek lazim


                        await HelpME.SayfaKapat();
                        await HelpME.SayfaKapat();
                        await Application.Current.MainPage.Navigation.PushAsync(NormalAlinanSiparisPagex);


                        NormalSiparislerVM.AktarimTaraftanGeliyorum = true;

                        foreach (var item in selectedstocks.ToList())
                        {
                            NormalAlinanSiparisSthModel NormAlinanSiparisSTHH = new NormalAlinanSiparisSthModel
                            {
                                sth_resim_url = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sip_stok_kod).FirstOrDefault().stok_resim_url,
                                sth_birim_ad = item.sip_birim_ad,
                                sth_tarih = item.sip_tarih,
                                sth_cari = item.sip_cari_kod,
                                sth_tutar = item.sip_tutar,
                                sth_stok_kod = item.sip_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sip_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat_gosterge = item.sip_birim_fiyat.ToString(),
                                sth_miktar_gosterge = item.sip_miktar.ToString(),
                                sth_iskonto1 = item.sip_iskonto1,
                                sth_vergi_pntr = item.sip_vergi_pntr,
                                sth_vergi = item.sip_vergi,
                                sth_doviz_cins = item.sip_doviz_cinsi,
                                sth_har_doviz_kur = item.sip_doviz_kuru,
                                sth_teslim_tarih = item.sip_teslim_tarih,
                                sth_cikis_depo_no = item.sip_depo_no,
                                sth_fiyat_liste_no = item.sip_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sip_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = item.sip_doviz_ismi,
                                Renk_beden_full_bilgi=item.Renk_beden_full_bilgi,
                                sth_renk_beden_seri_baglanti=item.sip_islem_baglanti,
                                sth_fat_baglanti = item.sip_islem_baglanti,

                            };

                            ss.OrderList.Add(NormAlinanSiparisSTHH);
                          //  await LocalSQL<NormalAlinanSiparisFatModel>.DELETEROW(item);
                        }
                        NormalAlinanSiparisPage.NormalSiparisVMZ.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                        NormalAlinanSiparisPage.NormalSiparisVMZ.SelectedDovizKuru = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == selectedstocks[0].sip_doviz_cinsi).FirstOrDefault();
                        NormalAlinanSiparisPage.NormalSiparisVMZ.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                        NormalAlinanSiparisPage.NormalSiparisVMZ.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;

                        NormalSiparislerVM.AktarimTaraftanGeliyorum = false;

                       // await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    }

                    catch (Exception ex)
                    {
                        await HelpME.MessageShow("hata", ex.Message, "ok");
                    }


                    break;
                #endregion

                #region Proforma Alinan Siparis
                case 4:

                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    ProformaVM ss = new ProformaVM();
                    //    ProformaAlinanSiparis ProformaAlinanSiparisPage = new ProformaAlinanSiparis();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(ProformaAlinanSiparisPage);

                    //    _LSTMANAGER.PROFORMALIST.Clear();

                    //    var ProformaAlinanSiparisSth = await LocalSQL<ProformaFatModel>.GETLISTALL();
                    //    var selectedstocks = ProformaAlinanSiparisSth.Where(x => x.pro_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    ProformaVM.AktarimTaraftanGeliyorum = true;

                    //    foreach (var item in selectedstocks.ToList())
                    //    {
                    //        ProformaSthModel ProformaAlinanSiparisSTHH = new ProformaSthModel
                    //        {
                    //            sth_birim_ad = item.pro_birim_ad,
                    //            sth_tarih = item.pro_tarih,
                    //            sth_tutar = item.pro_tutar,
                    //            sth_stok_kod = item.pro_stok_kod,
                    //            sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pro_stok_kod).FirstOrDefault().sto_isim,
                    //            sth_fiyat_gosterge = item.pro_birim_fiyat.ToString(),
                    //            sth_miktar_gosterge = item.pro_miktar.ToString(),
                    //            sth_iskonto1 = item.pro_iskonto1,
                    //            sth_vergi_pntr = item.pro_vergi_pntr,
                    //            sth_vergi = item.pro_vergi,
                    //            sth_doviz_cins = item.pro_dovizcinsi,
                    //            sth_har_doviz_kur = item.pro_dovizkuru,
                    //            sth_teslim_tarih = item.pro_teslim_tarih,
                    //            sth_cikis_depo_no = item.pro_depo_no,
                    //            sth_fiyat_liste_no = item.pro_fiyat_liste_no,
                    //            sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pro_stok_kod).FirstOrDefault().vryuzde,
                    //            sth_doviz_ismi = item.pro_doviz_ismi,
                    //        };

                    //        ss.ProformaSTHList.Add(ProformaAlinanSiparisSTHH);
                    //        // await LocalSQL<ProformaFatModel>.DELETEROW(item);
                    //    }

                    //    ProformaAlinanSiparis.PROFORMAVMzz.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    ProformaAlinanSiparis.PROFORMAVMzz.SelectedDovizKurlari = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == selectedstocks[0].pro_dovizcinsi).FirstOrDefault();
                    //    ProformaAlinanSiparis.PROFORMAVMzz.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                    //    ProformaAlinanSiparis.PROFORMAVMzz.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;

                    //    ProformaVM.AktarimTaraftanGeliyorum = false;

                    //    //await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    //}

                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;
                #endregion

                #region Tahsilat
                case 5:

                    //try
                    //{
                    //    //instance alma durumu. cok onemli...
                    //    MoneyVM ss = new MoneyVM();
                    //    KasaTahsilatFisi TahsilatPage = new KasaTahsilatFisi();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(TahsilatPage);

                    //    var Tahsilatlar = await LocalSQL<TahsilatFatModel>.GETLISTALL();
                    //    var selectedsTahsilat = Tahsilatlar.Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    var SelectedOdemeYontemi = Bul.TahsilattanOdemeYontemiBul(selectedsTahsilat[0]);

                    //    KasaTahsilatFisi.MONEYVMTahsilatzz.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    KasaTahsilatFisi.MONEYVMTahsilatzz.SelectedOdemeYontemi = SelectedOdemeYontemi;
                    //    KasaTahsilatFisi.MONEYVMTahsilatzz.Tahsilat_Tutar = selectedsTahsilat[0].fat_meblag.ToString();
                    //    KasaTahsilatFisi.MONEYVMTahsilatzz.Tahsilat_Aciklama = selectedsTahsilat[0].fat_aciklama;
                    //    KasaTahsilatFisi.MONEYVMTahsilatzz.SelectedDate = selectedsTahsilat[0].fat_vade_tarihi;

                    //}
                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}



                    break;
                #endregion

                #region Odeme
                case 6:

                    //try
                    //{
                    //    //instance alma durumu. cok onemli...
                    //    MoneyVM ss = new MoneyVM();
                    //    KasaTediyeMakbuzu OdemePage = new KasaTediyeMakbuzu();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(OdemePage);

                    //    var Odemeler = await LocalSQL<OdemeFatModel>.GETLISTALL();
                    //    var selectedsOdeme = Odemeler.Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();



                    //    KasaTediyeMakbuzu.MONEYVMTediyezz.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    KasaTediyeMakbuzu.MONEYVMTediyezz.Odeme_Tutar = selectedsOdeme[0].fat_meblag.ToString();
                    //    KasaTediyeMakbuzu.MONEYVMTediyezz.Odeme_Aciklama = selectedsOdeme[0].fat_aciklama;
                    //    KasaTediyeMakbuzu.MONEYVMTediyezz.SelectedOdemeDate = selectedsOdeme[0].fat_tarih;

                    //}
                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}


                    break;
                #endregion

                #region Masraflar
                case 7:

                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    MoneyVM ss = new MoneyVM();
                    //    KasaMasrafFisi MasraflarPage = new KasaMasrafFisi();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(MasraflarPage);

                    //    _LSTMANAGER.YAPILANMASRAFLIST.Clear();

                    //    var MasrafKalemleri = await LocalSQL<MasraflarFatModel>.GETLISTALL();
                    //    var selectedstocks = MasrafKalemleri.Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    foreach (var item in selectedstocks)
                    //    {
                    //        ss.YapilanMasrafList.Add(item);
                    //    }


                    //    KasaMasrafFisi.MONEYVMMasrafzz.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    KasaMasrafFisi.MONEYVMMasrafzz.SelectedMasrafDate = selectedstocks[0].fat_tarih;



                    //}

                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;
                #endregion

                #region Satis Irsaliyesi
                case 8:
                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    SatisIrsaliyesiVM ss = new SatisIrsaliyesiVM();
                    //    SatisIrsaliyesiPage SatisIrsaliyesimyPage = new SatisIrsaliyesiPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(SatisIrsaliyesimyPage);

                    //    _LSTMANAGER.SATISIRSALIYESILIST.Clear();

                    //    var SatisIrsaliyesiPageSth = await LocalSQL<SatisIrsaliyesiSthModel>.GETLISTALL();
                    //    var selectedstocks = SatisIrsaliyesiPageSth.Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    SatisIrsaliyesiVM.AktarimTaraftanGeliyorum = true;

                    //    foreach (var item in selectedstocks.ToList())
                    //    {
                    //        ss.SatisIrsaliyeList.Add(item);
                    //    }

                    //    SatisIrsaliyesiPage.SatIrsaliyeVMZ.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    SatisIrsaliyesiPage.SatIrsaliyeVMZ.SelectedDovizKurlari = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == selectedstocks[0].sth_doviz_cins).FirstOrDefault();
                    //    SatisIrsaliyesiPage.SatIrsaliyeVMZ.SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_cikis_depo_no).FirstOrDefault();


                    //    SatisIrsaliyesiPage.SatIrsaliyeVMZ.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                    //    SatisIrsaliyesiPage.SatIrsaliyeVMZ.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;


                    //    SatisIrsaliyesiVM.AktarimTaraftanGeliyorum = false;
                    //}
                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;
                #endregion

                #region Alis Irsaliyesi
                case 9:

                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    AlisIrsaliyesiVM ss = new AlisIrsaliyesiVM();
                    //    AlisIrsaliyesiPage AlisIrsaliyesimyPage = new AlisIrsaliyesiPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(AlisIrsaliyesimyPage);

                    //    _LSTMANAGER.ALISIRSALIYESILIST.Clear();

                    //    var AlisIrsaliyesiPageSth = await LocalSQL<AlisIrsaliyesiSthModel>.GETLISTALL();
                    //    var selectedstocks = AlisIrsaliyesiPageSth.Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    AlisIrsaliyesiVM.AktarimTaraftanGeliyorum = true;


                    //    foreach (var item in selectedstocks.ToList())
                    //    {
                    //        ss.AlisIrsaliyeList.Add(item);
                    //    }

                    //    AlisIrsaliyesiPage.alisIrsaliyeVMZ.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    AlisIrsaliyesiPage.alisIrsaliyeVMZ.SelectedDovizKurlari = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == selectedstocks[0].sth_doviz_cins).FirstOrDefault();
                    //    AlisIrsaliyesiPage.alisIrsaliyeVMZ.SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_giris_depo_no).FirstOrDefault();


                    //    AlisIrsaliyesiPage.alisIrsaliyeVMZ.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                    //    AlisIrsaliyesiPage.alisIrsaliyeVMZ.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;


                    //    AlisIrsaliyesiVM.AktarimTaraftanGeliyorum = false;
                    //}
                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}


                    break;
                #endregion

                #region Depolar Arasi Sevk Trnsfr
                case 10:
                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    DepolarArasiTransferVM ss = new DepolarArasiTransferVM();
                    //    DepolarArasiTransferPage DepolarArasiTransfermyPage = new DepolarArasiTransferPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(DepolarArasiTransfermyPage);

                    //    _LSTMANAGER.DEPOLARARASITRFLIST.Clear();

                    //    var DepolarArasiTransferPageSth = await LocalSQL<DepolarArasiSevkSthModel>.GETLISTALL();
                    //    var selectedstocks = new ObservableCollection<DepolarArasiSevkSthModel>(DepolarArasiTransferPageSth.Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid));

                    //    foreach (var item in selectedstocks)
                    //    {
                    //        ss.DepolarArasiTransferList.Add(item);
                    //    }
                    //    DepolarArasiTransferPage.DepArTRFVMZ.SelectedKaynakDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_cikis_depo_no).FirstOrDefault();
                    //    DepolarArasiTransferPage.DepArTRFVMZ.SelectedHedefDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_giris_depo_no).FirstOrDefault();

                    //    // DepolarArasiTransferVM.AktarimTaraftanGeliyorum = false;
                    //}
                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}


                    break;
                #endregion

                #region Depolar Arasi Siparis
                case 11:

                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    DepolarArasiSiparisVM ss = new DepolarArasiSiparisVM();
                    //    DepolarArasiSiparisPage DepolarArasiSiparisPage = new DepolarArasiSiparisPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(DepolarArasiSiparisPage);

                    //    _LSTMANAGER.DEPOLAR_ARASI_SIPARISLIST.Clear();

                    //    var DepolarArasiSiparisSth = await LocalSQL<DepolarArasiSiparisFatModel>.GETLISTALL();
                    //    var selectedstocks = DepolarArasiSiparisSth.Where(x => x.ssip_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    //  DepolarArasiSiparisVM.AktarimTaraftanGeliyorum = true;

                    //    foreach (var item in selectedstocks.ToList())
                    //    {
                    //        DepolarArasiSiparisSthModel DepolarArasiSiparisSTHH = new DepolarArasiSiparisSthModel
                    //        {
                    //            sth_resim_url = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.ssip_stok_kod).FirstOrDefault().stok_resim_url,
                    //            sth_birim_ad = item.ssip_birim_ad,
                    //            sth_tarih = item.ssip_tarih,
                    //            sth_tutar = item.ssip_tutar,
                    //            sth_stok_kod = item.ssip_stok_kod,
                    //            sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.ssip_stok_kod).FirstOrDefault().sto_isim,
                    //            sth_fiyat_gosterge = item.ssip_b_fiyat.ToString(),
                    //            sth_miktar_gosterge = item.ssip_miktar.ToString(),
                    //            sth_iskonto1 = 0,
                    //            sth_vergi_pntr = 0,
                    //            sth_vergi = 0,
                    //            sth_doviz_cins = 0,
                    //            sth_har_doviz_kur = 0,
                    //            sth_teslim_tarih = item.ssip_teslim_tarih,
                    //            sth_cikis_depo_no = item.ssip_cikdepo,
                    //            sth_fiyat_liste_no = item.ssip_girdepo,
                    //            sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.ssip_stok_kod).FirstOrDefault().vryuzde,

                    //        };
                    //        ss.DepolarArasiSiparisList.Add(DepolarArasiSiparisSTHH);
                    //        //  await LocalSQL<DepolarArasiSiparisFatModel>.DELETEROW(item);
                    //    }



                    //    DepolarArasiSiparisPage.DepolarAraSiparisVMZ.TeslimTarihi = selectedstocks[0].ssip_teslim_tarih;
                    //    DepolarArasiSiparisPage.DepolarAraSiparisVMZ.SelectedKaynakDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].ssip_cikdepo).FirstOrDefault();
                    //    DepolarArasiSiparisPage.DepolarAraSiparisVMZ.SelectedHedefDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].ssip_girdepo).FirstOrDefault();


                    //    // DepolarArasiSiparisVM.AktarimTaraftanGeliyorum = false;

                    //    // await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    //}

                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;
                #endregion

                #region Depolar Arasi Nakliye
                case 12:

                    //try
                    //{
                    //    //instance alma durumu. cok onemli...
                    //    DepolarArasiNakliyeVM ss = new DepolarArasiNakliyeVM();
                    //    DepolarArasiNakliyePage DepolarArasiNakliyemyPage = new DepolarArasiNakliyePage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(DepolarArasiNakliyemyPage);

                    //    _LSTMANAGER.DEPOLAR_ARASI_NAKLIYELIST.Clear();

                    //    var DepolarArasiNakliyePageSth = await LocalSQL<DepolarArasiNakliyeSthModel>.GETLISTALL();
                    //    var selectedstocks = (DepolarArasiNakliyePageSth.Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid)).ToList();

                    //    foreach (var item in selectedstocks)
                    //    {
                    //        ss.DepolarArasiNakliyeList.Add(item);
                    //    }
                    //    DepolarArasiNakliyePage.DepArNakVMZZZ.TeslimTarihi = selectedstocks[0].sth_teslim_tarih;
                    //    DepolarArasiNakliyePage.DepArNakVMZZZ.SelectedKaynakDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_cikis_depo_no).FirstOrDefault();
                    //    DepolarArasiNakliyePage.DepArNakVMZZZ.SelectedHedefDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_nakliyedeposu).FirstOrDefault();
                    //    DepolarArasiNakliyePage.DepArNakVMZZZ.SelectedNakliyeDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sth_giris_depo_no).FirstOrDefault();

                    //    // DepolarArasiTransferVM.AktarimTaraftanGeliyorum = false;
                    //}
                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;
                #endregion

                #region Sayim Sonuclari Giris Fisi
                case 13:
                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    SayimSonuclariVM ss = new SayimSonuclariVM();
                    //    SayimSonuclariPage SayimSonuclariPage = new SayimSonuclariPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaAc(SayimSonuclariPage);

                    //    _LSTMANAGER.SAYIMSONUCLARILIST.Clear();

                    //    var SayimSonuclariFATs = await LocalSQL<SayimSonuclariFatModel>.GETLISTALL();
                    //    var selectedstocks = SayimSonuclariFATs.Where(x => x.sym_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    OrderVM.AktarimTaraftanGeliyorum = true;

                    //    foreach (var item in selectedstocks.ToList())
                    //    {
                    //        SayimSonuclariSthModel SayimSonuclariSTHHHH = new SayimSonuclariSthModel
                    //        {
                    //            sth_resim_url = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sym_stokkod).FirstOrDefault().stok_resim_url,
                    //            sth_birim_ad = item.sym_birim_ad,
                    //            sth_tarih = item.sym_tarih,
                    //            sth_stok_kod = item.sym_stokkod,
                    //            sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sym_stokkod).FirstOrDefault().sto_isim,
                    //            sth_miktar_gosterge = item.sym_miktar.ToString(),
                    //            sth_cikis_depo_no = item.sym_depo,
                    //            sth_giris_depo_no = item.sym_depo,
                    //            sth_reyon_kodu_sayim = item.sym_reyonkodu

                    //        };

                    //        ss.SayimSonuclariSTH.Add(SayimSonuclariSTHHHH);
                    //        // await LocalSQL<SayimSonuclariFatModel>.DELETEROW(item);
                    //    }



                    //    SayimSonuclariPage.SayimSonVMZ.SayimTarihi = selectedstocks[0].sym_tarih;
                    //    SayimSonuclariPage.SayimSonVMZ.SelectedDepoIsmi = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks[0].sym_depo).FirstOrDefault();

                    //    //    await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    //}

                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;
                #endregion

                #region Detayli SATIS FATURAS
                case 14:
                    //try
                    //{

                    //    //instance alma durumu. cok onemli...
                    //    DetayliSatisVM ss = new DetayliSatisVM();

                    //    DetayliSatisPage DETAYLIsatissayfasi = new DetayliSatisPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();
                    //    await Application.Current.MainPage.Navigation.PushAsync(DETAYLIsatissayfasi);


                    //    _LSTMANAGER.DETAYLISALESLIST.Clear();
                    //    _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Clear();
                    //    //zaza

                    //    DetayliSatisVM.AktarimTaraftanGeliyorum = true;

                    //    var DetayliSatisFatList = await LocalSQL<SatisFatModel>.GETLISTALL();
                    //    var secimFatura = DetayliSatisFatList.Where(x => x.fat_sth_baglanti == gelendeger.Aktarim_Baglanti_guid).FirstOrDefault();

                    //    var SatisSth = await LocalSQL<SatisSthModel>.GETLISTALL();
                    //    var selectedstocks = SatisSth.Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid);

                    //    var TumRenkBedenDetaylari = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.GETLISTALL();


                    //    foreach (var item in selectedstocks.ToList())
                    //    {
                    //        var stokaaktardetay = TumRenkBedenDetaylari.Where(x => x.Olusan_Baglantisi_sth == item.sth_renk_beden_seri_baglanti).ToList();
                    //        if (stokaaktardetay.Count > 0)
                    //        {
                    //            foreach (var itemxx in stokaaktardetay)
                    //            {
                    //                _LSTMANAGER.DETAYLI_SATIS_RENK_BEDEN_SERI_HAREKETLERI.Add(itemxx);
                    //            }
                    //        }



                    //        ss.DetayliSalesList.Add(item);
                    //        // await LocalSQL<SatisSthModel>.DELETEROW(item);
                    //    }


                    //    DetayliSatisPage.DetaySatVMZZ.Tarih = secimFatura.fat_tarih;
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedFirma = _LSTMANAGER.FirmalarList.Where(x => x.fir_sirano == secimFatura.fat_firma).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedSube = _LSTMANAGER.SubelerList.Where(x => x.Sube_no == secimFatura.fat_sube).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedCustomerModel = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == gelendeger.Aktarim_Cari_Kod).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedNormalIade = _LSTMANAGER.Normal_Iade.Where(x => x.Normal_Iade_ID == secimFatura.fat_normal_Iade).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks.ToList()[0].sth_cikis_depo_no).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedProje = _LSTMANAGER.Projeler.Where(x => x.pro_kodu == selectedstocks.ToList()[0].sth_proje).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedSorumluluk = _LSTMANAGER.Sorumluluklar.Where(x => x.som_kod == selectedstocks.ToList()[0].sth_srm_merkezi).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedFiyatListesi = _LSTMANAGER.STOKLISTETANIMLAMALARILISTE.Where(x => x.sfl_sirano == selectedstocks.ToList()[0].sth_fiyat_liste_no).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedAcikKapali = _LSTMANAGER.Acik_Kapali.Where(x => x.Acik_Kapali_ID == secimFatura.fatura_acik_kasa_banka_belirteci).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedOdemePlani = _LSTMANAGER.OdemePlanlari.Where(x => x.odp_no == selectedstocks.ToList()[0].sth_odeme_op).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.SelectedDovizKuru = _LSTMANAGER.KURLARLISTE.Where(x => x.Kur_no == secimFatura.fat_d_cins).FirstOrDefault();
                    //    DetayliSatisPage.DetaySatVMZZ.GenelIndirimYUZDE = gelendeger.Aktarim_IndirimYuzde;
                    //    DetayliSatisPage.DetaySatVMZZ.GenelIndirimTL = gelendeger.Aktarim_IndirimTL;
                    //    DetayliSatisVM.AktarimTaraftanGeliyorum = false;

                    //    //SalesVM.AktarimTaraftanGeliyorum = false;
                    //    //  await LocalSQL<SatisFatModel>.DELETEROW(secimFatura);
                    //    //  await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    //}

                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;

                #endregion

                #region Sarf Cikis Ambar Fisi
                case 15:

                    //try
                    //{
                    //    //instance alma durumu. cok onemli...
                    //    SarfCikisVM ss = new SarfCikisVM();
                    //    SarfCikisFisiPage SarfCikisFisPagex = new SarfCikisFisiPage();

                    //    await HelpME.SayfaKapat();
                    //    await HelpME.SayfaKapat();

                    //    await Application.Current.MainPage.Navigation.PushAsync((SarfCikisFisPagex));

                    //    _LSTMANAGER.SarfCikisList.Clear();
                    //    //instance alma durumu. cok onemli...
                    //    _LSTMANAGER.SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI.Clear();

                    //    SarfCikisVM.AktarimTaraftanGeliyorum = true;


                    //    var SatisSth = await LocalSQL<SatisSthModel>.GETLISTALL();
                    //    var selectedstocks = SatisSth.Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    //    var TumRenkBedenDetaylari = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.GETLISTALL();


                    //    foreach (var item in selectedstocks)
                    //    {
                    //        var stokaaktardetay = TumRenkBedenDetaylari.Where(x => x.Olusan_Baglantisi_sth == item.sth_renk_beden_seri_baglanti).ToList();
                    //        if (stokaaktardetay.Count > 0)
                    //        {
                    //            foreach (var itemxx in stokaaktardetay)
                    //            {
                    //                _LSTMANAGER.SARF_CIKIS_RENK_BEDEN_SERI_HAREKETLERI.Add(itemxx);
                    //            }
                    //        }



                    //        ss.SarfCikisFisiList.Add(item);
                    //        // await LocalSQL<SatisSthModel>.DELETEROW(item);
                    //    }


                    //    SarfCikisFisiPage.SarfCikisVMZZ.Tarih = selectedstocks.ToList()[0].sth_tarih;
                    //    SarfCikisFisiPage.SarfCikisVMZZ.SelectedFirma = _LSTMANAGER.FirmalarList.Where(x => x.fir_sirano == selectedstocks[0].sth_firma).FirstOrDefault();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.SelectedSube = _LSTMANAGER.SubelerList.Where(x => x.Sube_no == selectedstocks[0].sth_sube).FirstOrDefault();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.SelectedDepo = _LSTMANAGER.DEPOISIMLERILIST.Where(x => x.dep_no == selectedstocks.ToList()[0].sth_cikis_depo_no).FirstOrDefault();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.SelectedProje = _LSTMANAGER.Projeler.Where(x => x.pro_kodu == selectedstocks.ToList()[0].sth_proje).FirstOrDefault();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.SelectedSorumluluk = _LSTMANAGER.Sorumluluklar.Where(x => x.som_kod == selectedstocks.ToList()[0].sth_srm_merkezi).FirstOrDefault();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.tutar = selectedstocks.Sum(x => x.sth_tutar).ToString();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.KalemAdeti = selectedstocks.Count();
                    //    SarfCikisFisiPage.SarfCikisVMZZ.TopalmStokAdeti = selectedstocks.Sum(x => x.sth_miktar);

                    //    SarfCikisVM.AktarimTaraftanGeliyorum = false;


                    //    //SalesVM.AktarimTaraftanGeliyorum = false;
                    //    //  await LocalSQL<SatisFatModel>.DELETEROW(secimFatura);
                    //    //  await LocalSQL<AktarimModel>.DELETEROW(gelendeger);

                    //}

                    //catch (Exception ex)
                    //{
                    //    await HelpME.MessageShow("hata", ex.Message, "ok");
                    //}

                    break;


                #endregion


                default:
                    await HelpME.MessageShow("Error", "Beklenmedik Bir Hata Olustu. Lutfen IT durumu bildiriniz...", "OK");
                    break;
            }


        }
        private async void DetailLookGO(object obj)
        {
            if (obj == null) return;
            AktarimModel gelendeger = (AktarimModel)obj;

            if (gelendeger.Aktarim_IslemKodu == 5 || gelendeger.Aktarim_IslemKodu == 6 || gelendeger.Aktarim_IslemKodu == 7)
            {
                await HelpME.PopAc(new AktarimDetailFinansalPage(gelendeger));
            }
            else
            {
                await HelpME.PopAc(new AktarimDetailLookPage(gelendeger));
            }
        }
        private async void HerseySilGO(object obj)
        {
            await LocalSQL<SatisFatModel>.DELETEALL();
            await LocalSQL<SatisSthModel>.DELETEALL();
            await LocalSQL<AlisFatModel>.DELETEALL();
            await LocalSQL<AlisSthModel>.DELETEALL();
            await LocalSQL<NormalAlinanSiparisFatModel>.DELETEALL();
            await LocalSQL<NormalAlinanSiparisSthModel>.DELETEALL();

            await LocalSQL<ProformaFatModel>.DELETEALL();
            await LocalSQL<ProformaSthModel>.DELETEALL();
            await LocalSQL<TahsilatFatModel>.DELETEALL();
            await LocalSQL<OdemeFatModel>.DELETEALL();
            await LocalSQL<MasraflarFatModel>.DELETEALL();
            await LocalSQL<SatisIrsaliyesiSthModel>.DELETEALL();

            await LocalSQL<AlisIrsaliyesiSthModel>.DELETEALL();
            await LocalSQL<DepolarArasiSevkSthModel>.DELETEALL();
            await LocalSQL<DepolarArasiSiparisFatModel>.DELETEALL();
            await LocalSQL<DepolarArasiSiparisSthModel>.DELETEALL();
            await LocalSQL<DepolarArasiNakliyeSthModel>.DELETEALL();
            await LocalSQL<SayimSonuclariFatModel>.DELETEALL();
            await LocalSQL<SayimSonuclariSthModel>.DELETEALL();
            await LocalSQL<AktarimModel>.DELETEALL();
            await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.DELETEALL();
            await HelpME.SayfaKapat();

        }
        private async void DeleteTheInoviceGO(object obj)
        {
            if (obj == null) return;

            try
            {
                AktarimModel gelendeger = (AktarimModel)obj;

                bool sonuc = await Application.Current.MainPage.DisplayAlert("Uyari", "Faturayi Silmek Istediginize eminmisiniz?", "YES", "NO");


                if (sonuc)
                {

                    switch (gelendeger.Aktarim_IslemKodu)
                    {
                        #region Satis Faturasi  
                        case 1:
                        case 14:
                            var SatisFaturayiGetir = await LocalSQL<SatisFatModel>.GETLISTALL();
                            var SatisMyfatura = SatisFaturayiGetir.ToList().Where(x => x.fat_sth_baglanti == gelendeger.Aktarim_Baglanti_guid).FirstOrDefault();

                            var SatisSTHGetir = await LocalSQL<SatisSthModel>.GETLISTALL();
                            var SatisMySTH = SatisSTHGetir.ToList().Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                            int SatisSth_sonuc = 0;
                            var SatisFat_sonuc = await LocalSQL<SatisFatModel>.DELETEROW(SatisMyfatura);
                            foreach (var item in SatisMySTH)
                            {
                                SatisSth_sonuc += await LocalSQL<SatisSthModel>.DELETEROW(item);
                            }

                            if (SatisMySTH.Count == SatisSth_sonuc && SatisFat_sonuc != 0)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Satis Faturasi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }


                            break;
                        #endregion
                        #region alis faturasi  
                        case 2:


                            var AlisFaturayiGetir = await LocalSQL<AlisFatModel>.GETLISTALL();
                            var AlisMyfatura = AlisFaturayiGetir.ToList().Where(x => x.fat_id == gelendeger.Aktarim_IslemRecNo).FirstOrDefault();

                            var AlisSTHGetir = await LocalSQL<AlisSthModel>.GETLISTALL();
                            var AlisMySTH = AlisSTHGetir.ToList().Where(x => x.sth_fat_baglanti == AlisMyfatura.fat_sth_baglanti).ToList();

                            int AlisSth_sonuc = 0;
                            var AlisFat_sonuc = await LocalSQL<AlisFatModel>.DELETEROW(AlisMyfatura);
                            foreach (var item in AlisMySTH)
                            {
                                AlisSth_sonuc += await LocalSQL<AlisSthModel>.DELETEROW(item);
                            }

                            if (AlisMySTH.Count == AlisSth_sonuc && AlisFat_sonuc != 0)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Alis Faturasi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }




                            break;
                        #endregion
                        #region  Normalalinansiparis 
                        case 3:

                            var NormalalinansiparisGetir = await LocalSQL<NormalAlinanSiparisFatModel>.GETLISTALL();
                            var NormalalinansiparisMYsth = NormalalinansiparisGetir.ToList().Where(x => x.sip_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int NormalalinansiparisSth_sonuc = 0;

                            foreach (var item in NormalalinansiparisMYsth)
                            {
                                NormalalinansiparisSth_sonuc += await LocalSQL<NormalAlinanSiparisFatModel>.DELETEROW(item);
                            }

                            if (NormalalinansiparisMYsth.Count == NormalalinansiparisSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Normal Alinan Siparis evragi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;

                        #endregion
                        #region Proforma Alinan Siparis
                        case 4:


                            var ProformasiparisGetir = await LocalSQL<ProformaFatModel>.GETLISTALL();
                            var ProformasiparisMYsth = ProformasiparisGetir.ToList().Where(x => x.pro_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int ProformasiparisSth_sonuc = 0;

                            foreach (var item in ProformasiparisMYsth)
                            {
                                ProformasiparisSth_sonuc += await LocalSQL<ProformaFatModel>.DELETEROW(item);
                            }

                            if (ProformasiparisMYsth.Count == ProformasiparisSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Proforma Alinan Siparis silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;
                        #endregion
                        #region Tahsilat
                        case 5: //Tahsilat

                            var TahsilatGetir = await LocalSQL<TahsilatFatModel>.GETLISTALL();
                            var TahsilatFat = TahsilatGetir.ToList().Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int TahsilatFat_sonuc = 0;

                            foreach (var item in TahsilatFat)
                            {
                                TahsilatFat_sonuc += await LocalSQL<TahsilatFatModel>.DELETEROW(item);
                            }

                            if (TahsilatFat.Count == TahsilatFat_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Kasa Tahsilat evragi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;
                        #endregion
                        #region Kasa Odeme Fisi
                        case 6:

                            var OdemeGetir = await LocalSQL<OdemeFatModel>.GETLISTALL();
                            var OdemeFat = OdemeGetir.ToList().Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int OdemeFat_sonuc = 0;

                            foreach (var item in OdemeFat)
                            {
                                OdemeFat_sonuc += await LocalSQL<OdemeFatModel>.DELETEROW(item);
                            }

                            if (OdemeFat.Count == OdemeFat_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Kasa Odeme Fisi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }
                            break;
                        #endregion
                        #region Masraflar
                        case 7: //Masraflar
                            var MasrafGetir = await LocalSQL<MasraflarFatModel>.GETLISTALL();
                            var MasrafFat = MasrafGetir.ToList().Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int MasrafFat_sonuc = 0;

                            foreach (var item in MasrafFat)
                            {
                                MasrafFat_sonuc += await LocalSQL<MasraflarFatModel>.DELETEROW(item);
                            }

                            if (MasrafFat.Count == MasrafFat_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Kasa Masraf Fisi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }
                            break;
                        #endregion
                        #region Satis Irsaliyesi
                        case 8: //SatisIrsaliyesi
                            var SatisIrsaliyesiGetir = await LocalSQL<SatisIrsaliyesiSthModel>.GETLISTALL();
                            var SatisIrsaliyesiSth = SatisIrsaliyesiGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int SatisIrsaliyesiSth_sonuc = 0;

                            foreach (var item in SatisIrsaliyesiSth)
                            {
                                SatisIrsaliyesiSth_sonuc += await LocalSQL<SatisIrsaliyesiSthModel>.DELETEROW(item);
                            }

                            if (SatisIrsaliyesiSth.Count == SatisIrsaliyesiSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Satis Irsaliyesi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }
                            break;
                        #endregion
                        #region Alis Irsaliyesi
                        case 9:
                            var AlisIrsaliyesiGetir = await LocalSQL<AlisIrsaliyesiSthModel>.GETLISTALL();
                            var AlisIrsaliyesiSth = AlisIrsaliyesiGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int AlisIrsaliyesiSth_sonuc = 0;

                            foreach (var item in AlisIrsaliyesiSth)
                            {
                                AlisIrsaliyesiSth_sonuc += await LocalSQL<AlisIrsaliyesiSthModel>.DELETEROW(item);
                            }

                            if (AlisIrsaliyesiSth.Count == AlisIrsaliyesiSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Alis Irsaliyesi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }
                            break;
                        #endregion
                        #region   DepolarArasiSevk 
                        case 10:
                            var DepolarArasiSevkGetir = await LocalSQL<DepolarArasiSevkSthModel>.GETLISTALL();
                            var DepolarArasiSevkSth = DepolarArasiSevkGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int DepolarArasiSevkSth_sonuc = 0;

                            foreach (var item in DepolarArasiSevkSth)
                            {
                                DepolarArasiSevkSth_sonuc += await LocalSQL<DepolarArasiSevkSthModel>.DELETEROW(item);
                            }

                            if (DepolarArasiSevkSth.Count == DepolarArasiSevkSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "DepolarArasi Sevk evragi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;
                        #endregion
                        #region   DepolarArasiSiparis
                        case 11://
                            var DepolarArasiSiparisGetir = await LocalSQL<DepolarArasiSiparisFatModel>.GETLISTALL();
                            var DepolarArasiSiparisFat = DepolarArasiSiparisGetir.ToList().Where(x => x.ssip_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int DepolarArasiSiparisFat_sonuc = 0;

                            foreach (var item in DepolarArasiSiparisFat)
                            {
                                DepolarArasiSiparisFat_sonuc += await LocalSQL<DepolarArasiSiparisFatModel>.DELETEROW(item);
                            }

                            if (DepolarArasiSiparisFat.Count == DepolarArasiSiparisFat_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "DepolarArasi Siparis evragi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;
                        #endregion
                        #region   DepolarArasiNakliye
                        case 12://
                            var DepolarArasiNakliyeGetir = await LocalSQL<DepolarArasiNakliyeSthModel>.GETLISTALL();
                            var DepolarArasiNakliyeSth = DepolarArasiNakliyeGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int DepolarArasiNakliyeSth_sonuc = 0;

                            foreach (var item in DepolarArasiNakliyeSth)
                            {
                                DepolarArasiNakliyeSth_sonuc += await LocalSQL<DepolarArasiNakliyeSthModel>.DELETEROW(item);
                            }

                            if (DepolarArasiNakliyeSth.Count == DepolarArasiNakliyeSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "DepolarArasiNakliye evragi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;
                        #endregion
                        #region    SayimSonuclari Giris Fisi
                        case 13://
                            var SayimSonuclariGetir = await LocalSQL<SayimSonuclariFatModel>.GETLISTALL();
                            var SayimSonuclariSth = SayimSonuclariGetir.ToList().Where(x => x.sym_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                            int SayimSonuclariSth_sonuc = 0;

                            foreach (var item in SayimSonuclariSth)
                            {
                                SayimSonuclariSth_sonuc += await LocalSQL<SayimSonuclariFatModel>.DELETEROW(item);
                            }

                            if (SayimSonuclariSth.Count == SayimSonuclariSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Sayim silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }

                            break;
                        #endregion 
                        #region Sarf Cikis Fisi 
                        case 15:
                            var SarfCikisSTHGetir = await LocalSQL<SatisSthModel>.GETLISTALL();
                            var SarfCikisSTH = SarfCikisSTHGetir.ToList().Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                            int SarfCikisSth_sonuc = 0;


                            foreach (var item in SarfCikisSTH)
                            {
                                SarfCikisSth_sonuc += await LocalSQL<SatisSthModel>.DELETEROW(item);
                            }

                            if (SarfCikisSTH.Count == SarfCikisSth_sonuc)
                            {
                                ListeTemizle(gelendeger);
                            }
                            else
                            {
                                await HelpME.MessageShow("Error", "Satis Faturasi silme islemi sirasinda bir hata olustu. Lutfen IT Yoneticinizle bu konuyu gorusunuz...", "OK");
                            }
                            break;
                        #endregion

                        default:
                            await HelpME.MessageShow("Hata", "Olagan disi bir durum sozkonusu. Lutfen IT Yoneticinize konuyu bildirin", "OK");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("Delete Error", "Silme islemi sirasinda bir hata olustu :" + ex.Message, "OK");
            }
        }
        private async void ListeTemizle(AktarimModel aktrm)
        {
            await LocalSQL<AktarimModel>.DELETEROW(aktrm);

            if (aktrm.Aktarim_Sent == true)
            {
                Gonderilenler_Liste.Remove(aktrm);
            }
            else
            {
                Hatalilar_Liste.Remove(aktrm);
            }
        }
        public async void DataCek()
        {
            try
            {
                var TumIslemler = await LocalSQL<AktarimModel>.GETLISTALL();

                foreach (var item in TumIslemler)
                {
                    var Customerlist = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_kod == item.Aktarim_Cari_Kod).ToList();
                    if (Customerlist.Count > 0)
                    {

                        item.Aktarim_Cari_Isim = Customerlist.FirstOrDefault().cari_unvan1;
                    }

                }

                Gonderilenler_Liste = new ObservableCollection<AktarimModel>(TumIslemler.ToList().Where(x => x.Aktarim_Sent == true).OrderByDescending(x => x.Local_Id_Aktarim));

                Hatalilar_Liste = new ObservableCollection<AktarimModel>(TumIslemler.ToList().Where(x => x.Aktarim_Sent == false).OrderByDescending(x => x.Local_Id_Aktarim));

            }
            catch (Exception ex)
            {

                await HelpME.MessageShow("error", ex.Message, "ok");
            }

        }

        private AktarimModel _Selected_Aktarim;
        public AktarimModel Selected_Aktarim
        {
            get
            {
                if (_Selected_Aktarim == null)
                {
                    _Selected_Aktarim = new AktarimModel();
                }
                return _Selected_Aktarim;
            }
            set
            {
                if (value != null)
                {



                }


                _Selected_Aktarim = value;
            }
        }

        private ObservableCollection<AktarimModel> _Hatalilar_Liste;
        public ObservableCollection<AktarimModel> Hatalilar_Liste
        {
            get
            {
                if (_Hatalilar_Liste == null)
                {
                    _Hatalilar_Liste = new ObservableCollection<AktarimModel>();
                }
                return _Hatalilar_Liste;
            }
            set
            {
                _Hatalilar_Liste = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<AktarimModel> _Gonderilenler_Liste;
        public ObservableCollection<AktarimModel> Gonderilenler_Liste
        {
            get
            {
                if (_Gonderilenler_Liste == null)
                {
                    _Gonderilenler_Liste = new ObservableCollection<AktarimModel>();
                }
                return _Gonderilenler_Liste;
            }
            set
            {
                _Gonderilenler_Liste = value;
                INotifyPropertyChanged();
            }
        }
    }
}
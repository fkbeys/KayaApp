using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.REPORT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AktarimDetailLookPage : PopupPage
    {
        LISTMANAGER _LSTMANAGER;
        public AktarimDetailLookPage(AktarimModel gelendeger)
        {
            InitializeComponent();
            _LSTMANAGER = DataClass._LSTMANAGER;
            GelenDatayaGoreFormGoster(gelendeger);
        }
        private async void GelenDatayaGoreFormGoster(AktarimModel gelendeger)
        {
            #region islemler

            switch (gelendeger.Aktarim_IslemKodu)
            {
                #region Satis Faturasi  
                case 1:
                case 14:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var SatisFaturayiGetir = await LocalSQL<SatisFatModel>.GETLISTALL();
                        var SatisMyfatura = SatisFaturayiGetir.ToList().Where(x => x.fat_id == gelendeger.Aktarim_IslemRecNo).FirstOrDefault();

                        var SatisSTHGetir = await LocalSQL<SatisSthModel>.GETLISTALL();
                        var SatisMySTH = SatisSTHGetir.ToList().Where(x => x.sth_fat_baglanti == SatisMyfatura.fat_sth_baglanti).ToList();

                        GeneralFat GenelFaturaOnizleme = new GeneralFat();

                        foreach (var jitem in SatisMyfatura.GetType().GetProperties())
                        {
                            var PropertiAdini = jitem.Name.ToString();

                            var HedefProperti = GenelFaturaOnizleme.GetType().GetProperty(PropertiAdini);

                            HedefProperti.SetValue(GenelFaturaOnizleme, SatisMyfatura.GetType().GetProperty(PropertiAdini).GetValue(SatisMyfatura));
                        }

                        //cok karisik bi kod. 
                        //bizim farkli STH modellerimizin icindeki degerleri GeneralSTH modeline ceviriyor.
                        //propertileri tek tek geziyo. isimleri ayni olanlari birbirine esitliyo. cikiyo. basit yani
                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in SatisMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH();
                            foreach (var jitem in item.GetType().GetProperties())
                            {
                                var PropertiAdini = jitem.Name.ToString();

                                var HedefProperti = GenelStokHareket.GetType().GetProperty(PropertiAdini);

                                HedefProperti.SetValue(GenelStokHareket, item.GetType().GetProperty(PropertiAdini).GetValue(item));
                            }
                            GidecekSTHListe.Add(GenelStokHareket);
                        }

                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        LblTarih.Text = SatisMySTH[0].sth_tarih.ToString("dd-MM-yyyy"); // gelendeger.Aktarim_Tarih.ToString("MM -dd-yyyy");

                    }
                    catch (Exception ex)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi" + ex, "OK");
                    }


                    break;



                #endregion
                #region alis faturasi  
                case 2:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var AlisFaturayiGetir = await LocalSQL<AlisFatModel>.GETLISTALL();
                        var AlisMyfatura = AlisFaturayiGetir.ToList().Where(x => x.fat_id == gelendeger.Aktarim_IslemRecNo).FirstOrDefault();


                        var AlisSTHGetir = await LocalSQL<AlisSthModel>.GETLISTALL();
                        var AlisMySTH = AlisSTHGetir.ToList().Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        var ss = await LocalSQL<DepolarArasiNakliyeSthModel>.GETLISTALL();
                        var zz = ss.Where(x => x.sth_is_sent == true);


                        GeneralFat GenelFaturaOnizleme = new GeneralFat();

                        foreach (var jitem in AlisMyfatura.GetType().GetProperties())
                        {
                            var PropertiAdini = jitem.Name.ToString();

                            var HedefProperti = GenelFaturaOnizleme.GetType().GetProperty(PropertiAdini);

                            HedefProperti.SetValue(GenelFaturaOnizleme, AlisMyfatura.GetType().GetProperty(PropertiAdini).GetValue(AlisMyfatura));
                        }

                        //cok karisik bi kod. 
                        //bizim farkli STH modellerimizin icindeki degerleri GeneralSTH modeline ceviriyor.
                        //propertileri tek tek geziyo. isimleri ayni olanlari birbirine esitliyo. cikiyo. basit yani
                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in AlisMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH();
                            foreach (var jitem in item.GetType().GetProperties())
                            {
                                var PropertiAdini = jitem.Name.ToString();

                                var HedefProperti = GenelStokHareket.GetType().GetProperty(PropertiAdini);

                                HedefProperti.SetValue(GenelStokHareket, item.GetType().GetProperty(PropertiAdini).GetValue(item));
                            }
                            GidecekSTHListe.Add(GenelStokHareket);
                        }

                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblGirisDepo.Text = GidecekSTHListe[0].sth_giris_depo_no.ToString();

                        LblTarih.Text = AlisMySTH[0].sth_tarih.ToString("dd-MM-yyyy");
                    }
                    catch (Exception ex)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi" + ex.Message, "OK");
                    }





                    break;
                #endregion
                #region  Normalalinansiparis 
                case 3:
                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var SatisSTHGetir = await LocalSQL<NormalAlinanSiparisFatModel>.GETLISTALL();
                        var SatisMySTH = SatisSTHGetir.ToList().Where(x => x.sip_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in SatisMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.sip_birim_ad,
                                sth_tarih = item.sip_tarih,
                                sth_cari = item.sip_cari_kod,
                                sth_tutar = item.sip_tutar,
                                sth_stok_kod = item.sip_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sip_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.sip_birim_fiyat,
                                sth_miktar = item.sip_miktar,
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
                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }

                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);

                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);

                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);

                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        LblTarih.Text = SatisMySTH[0].sip_tarih.ToString("dd-MM-yyyy");
                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }



                    break;

                #endregion
                #region Proforma Alinan Siparis
                case 4:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var SatisSTHGetir = await LocalSQL<ProformaFatModel>.GETLISTALL();
                        var SatisMySTH = SatisSTHGetir.ToList().Where(x => x.pro_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in SatisMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.pro_birim_ad,
                                sth_tarih = item.pro_tarih,
                                sth_tutar = item.pro_tutar,
                                sth_stok_kod = item.pro_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pro_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.pro_birim_fiyat,
                                sth_miktar = item.pro_miktar,
                                sth_iskonto1 = item.pro_iskonto1,
                                sth_vergi_pntr = item.pro_vergi_pntr,
                                sth_vergi = item.pro_vergi,
                                sth_doviz_cins = item.pro_dovizcinsi,
                                sth_har_doviz_kur = item.pro_dovizkuru,
                                sth_teslim_tarih = item.pro_teslim_tarih,
                                sth_cikis_depo_no = item.pro_depo_no,
                                sth_fiyat_liste_no = item.pro_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.pro_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = item.pro_doviz_ismi,
                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }

                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        LblTarih.Text = SatisMySTH[0].pro_tarih.ToString("dd-MM-yyyy");
                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }


                    break;
                #endregion
                #region Tahsilat
                case 5: //Tahsilat



                    break;
                #endregion
                #region Kasa Odeme Fisi
                case 6:

                    break;
                #endregion
                #region Masraflar
                case 7: //Masraflar

                    break;
                #endregion
                #region Satis Irsaliyesi
                case 8: //SatisIrsaliyesi

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var SatisIrsaliyesiSTHGetir = await LocalSQL<SatisIrsaliyesiSthModel>.GETLISTALL();
                        var SatisIrsaliyesiMySTH = SatisIrsaliyesiSTHGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in SatisIrsaliyesiMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.sth_birim_ad,
                                sth_tarih = item.sth_tarih,
                                sth_tutar = item.sth_tutar,
                                sth_stok_kod = item.sth_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.sth_fiyat,
                                sth_miktar = item.sth_miktar,
                                sth_iskonto1 = item.sth_iskonto1,
                                sth_vergi_pntr = item.sth_vergi_pntr,
                                sth_vergi = item.sth_vergi,
                                sth_doviz_cins = item.sth_doviz_cins,
                                sth_har_doviz_kur = item.sth_har_doviz_kur,
                                sth_teslim_tarih = item.sth_teslim_tarih,
                                sth_cikis_depo_no = item.sth_cikis_depo_no,
                                sth_fiyat_liste_no = item.sth_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = item.sth_doviz_ismi,

                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }



                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();


                        LblTarih.Text = SatisIrsaliyesiMySTH[0].sth_tarih.ToString("dd-MM-yyyy");

                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }


                    break;
                #endregion
                #region Alis Irsaliyesi
                case 9:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var AlisIrsaliyesiSTHGetir = await LocalSQL<AlisIrsaliyesiSthModel>.GETLISTALL();
                        var AlisIrsaliyesiMySTH = AlisIrsaliyesiSTHGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in AlisIrsaliyesiMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.sth_birim_ad,
                                sth_tarih = item.sth_tarih,
                                sth_tutar = item.sth_tutar,
                                sth_stok_kod = item.sth_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.sth_fiyat,
                                sth_miktar = item.sth_miktar,
                                sth_iskonto1 = item.sth_iskonto1,
                                sth_vergi_pntr = item.sth_vergi_pntr,
                                sth_vergi = item.sth_vergi,
                                sth_doviz_cins = item.sth_doviz_cins,
                                sth_har_doviz_kur = item.sth_har_doviz_kur,
                                sth_teslim_tarih = item.sth_teslim_tarih,
                                sth_cikis_depo_no = item.sth_cikis_depo_no,
                                sth_fiyat_liste_no = item.sth_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = item.sth_doviz_ismi,

                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }



                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblGirisDepo.Text = GidecekSTHListe[0].sth_giris_depo_no.ToString();

                        LblTarih.Text = AlisIrsaliyesiMySTH[0].sth_tarih.ToString("dd-MM-yyyy");
                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }
                    break;

                #endregion
                #region   DepolarArasiSevk 
                case 10:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var DepolarArasiSevkSTHGetir = await LocalSQL<DepolarArasiSevkSthModel>.GETLISTALL();
                        var DepolarArasiSevkMySTH = DepolarArasiSevkSTHGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in DepolarArasiSevkMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.sth_birim_ad,
                                sth_tarih = item.sth_tarih,
                                sth_tutar = item.sth_tutar,
                                sth_stok_kod = item.sth_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.sth_fiyat,
                                sth_miktar = item.sth_miktar,
                                sth_iskonto1 = item.sth_iskonto1,
                                sth_vergi_pntr = item.sth_vergi_pntr,
                                sth_vergi = item.sth_vergi,
                                sth_doviz_cins = item.sth_doviz_cins,
                                sth_har_doviz_kur = item.sth_har_doviz_kur,
                                sth_teslim_tarih = item.sth_teslim_tarih,
                                sth_cikis_depo_no = item.sth_cikis_depo_no,
                                sth_giris_depo_no = item.sth_giris_depo_no,
                                sth_fiyat_liste_no = item.sth_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = item.sth_doviz_ismi,

                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }



                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblGirisDepo.Text = GidecekSTHListe[0].sth_giris_depo_no.ToString();

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        LblTarih.Text = DepolarArasiSevkMySTH[0].sth_tarih.ToString("dd-MM-yyyy");
                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }

                    break;
                #endregion
                #region   DepolarArasiSiparis
                case 11://

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var DepolarArasiSiparisSTHGetir = await LocalSQL<DepolarArasiSiparisFatModel>.GETLISTALL();
                        var DepolarArasiSiparisMySTH = DepolarArasiSiparisSTHGetir.ToList().Where(x => x.ssip_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in DepolarArasiSiparisMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.ssip_birim_ad,
                                sth_tarih = item.ssip_tarih,
                                sth_tutar = item.ssip_tutar,
                                sth_stok_kod = item.ssip_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.ssip_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.ssip_b_fiyat,
                                sth_miktar = item.ssip_miktar,
                                sth_iskonto1 = 0,
                                sth_vergi_pntr = 0,
                                sth_vergi = 0,
                                sth_doviz_cins = 0,
                                sth_har_doviz_kur = 1,
                                sth_teslim_tarih = item.ssip_teslim_tarih,
                                sth_cikis_depo_no = item.ssip_cikdepo,
                                sth_giris_depo_no = item.ssip_girdepo,
                                sth_fiyat_liste_no = item.ssip_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.ssip_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = _LSTMANAGER.KURLARLISTE[0].Kur_sembol,

                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }



                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblGirisDepo.Text = GidecekSTHListe[0].sth_giris_depo_no.ToString();

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        // LblTarih.Text = gelendeger.Aktarim_Tarih.ToString("MM-dd-yyyy");
                        LblTarih.Text = DepolarArasiSiparisMySTH[0].ssip_tarih.ToString("dd-MM-yyyy");

                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }



                    break;
                #endregion
                #region   DepolarArasiNakliye
                case 12://


                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var DepolarArasiNakliyeSTHGetir = await LocalSQL<DepolarArasiNakliyeSthModel>.GETLISTALL();
                        var DepolarArasiNakliyeMySTH = DepolarArasiNakliyeSTHGetir.ToList().Where(x => x.sth_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in DepolarArasiNakliyeMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.sth_birim_ad,
                                sth_tarih = item.sth_tarih,
                                sth_tutar = item.sth_tutar,
                                sth_stok_kod = item.sth_stok_kod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().sto_isim,
                                sth_fiyat = item.sth_fiyat,
                                sth_miktar = item.sth_miktar,
                                sth_iskonto1 = item.sth_iskonto1,
                                sth_vergi_pntr = item.sth_vergi_pntr,
                                sth_vergi = item.sth_vergi,
                                sth_doviz_cins = item.sth_doviz_cins,
                                sth_har_doviz_kur = item.sth_har_doviz_kur,
                                sth_teslim_tarih = item.sth_teslim_tarih,
                                sth_cikis_depo_no = item.sth_cikis_depo_no,
                                sth_giris_depo_no = item.sth_giris_depo_no,
                                sth_fiyat_liste_no = item.sth_fiyat_liste_no,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sth_stok_kod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = item.sth_doviz_ismi,

                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }



                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblGirisDepo.Text = GidecekSTHListe[0].sth_giris_depo_no.ToString();

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        // LblTarih.Text = gelendeger.Aktarim_Tarih.ToString("MM-dd-yyyy");
                        LblTarih.Text = DepolarArasiNakliyeMySTH[0].sth_tarih.ToString("dd-MM-yyyy");

                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }

                    break;
                #endregion
                #region    SayimSonuclari Giris Fisi
                case 13:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;
                        var SayimSonuclariSTHGetir = await LocalSQL<SayimSonuclariFatModel>.GETLISTALL();
                        var SayimSonuclariMySTH = SayimSonuclariSTHGetir.ToList().Where(x => x.sym_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();
                        foreach (var item in SayimSonuclariMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH
                            {
                                sth_birim_ad = item.sym_birim_ad,
                                sth_tarih = item.sym_tarih,
                                sth_tutar = 0,
                                sth_stok_kod = item.sym_stokkod,
                                sth_stok_isim = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sym_stokkod).FirstOrDefault().sto_isim,
                                sth_fiyat = 0,
                                sth_miktar = item.sym_miktar,
                                sth_iskonto1 = 0,
                                sth_vergi_pntr = 0,
                                sth_vergi = 0,
                                sth_doviz_cins = 0,
                                sth_har_doviz_kur = 1,
                                sth_teslim_tarih = item.sym_tarih,
                                sth_cikis_depo_no = item.sym_depo,
                                sth_giris_depo_no = item.sym_depo,
                                sth_fiyat_liste_no = 0,
                                sth_vryuzde = _LSTMANAGER.STOCKLIST.Where(x => x.sto_kod == item.sym_stokkod).FirstOrDefault().vryuzde,
                                sth_doviz_ismi = _LSTMANAGER.KURLARLISTE[0].Kur_sembol,

                            };

                            GidecekSTHListe.Add(GenelStokHareket);
                        }



                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblGirisDepo.Text = GidecekSTHListe[0].sth_giris_depo_no.ToString();

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        //LblTarih.Text = gelendeger.Aktarim_Tarih.ToString("MM-dd-yyyy");
                        LblTarih.Text = SayimSonuclariMySTH[0].sym_tarih.ToString("dd-MM-yyyy");
                    }
                    catch (Exception)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi", "OK");
                    }



                    break;
                #endregion
                #region Sarf Cikis Fisi

                case 15:

                    try
                    {
                        LblFaturaIsmi.Text = gelendeger.Aktarim_IslemAdi;

                        var SatisSTHGetir = await LocalSQL<SatisSthModel>.GETLISTALL();
                        var SatisMySTH = SatisSTHGetir.ToList().Where(x => x.sth_fat_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();


                        //cok karisik bi kod. 
                        //bizim farkli STH modellerimizin icindeki degerleri GeneralSTH modeline ceviriyor.
                        //propertileri tek tek geziyo. isimleri ayni olanlari birbirine esitliyo. cikiyo. basit yani
                        List<GeneralSTH> GidecekSTHListe = new List<GeneralSTH>();

                        foreach (var item in SatisMySTH)
                        {
                            GeneralSTH GenelStokHareket = new GeneralSTH();
                            foreach (var jitem in item.GetType().GetProperties())
                            {
                                var PropertiAdini = jitem.Name.ToString();

                                var HedefProperti = GenelStokHareket.GetType().GetProperty(PropertiAdini);

                                HedefProperti.SetValue(GenelStokHareket, item.GetType().GetProperty(PropertiAdini).GetValue(item));
                            }
                            GidecekSTHListe.Add(GenelStokHareket);
                        }

                        GenelSTHList.ItemsSource = GidecekSTHListe;

                        LblCariIsim.Text = gelendeger.Aktarim_Cari_Isim;

                        double burut_tutar = Math.Round(GidecekSTHListe.Sum(x => x.sth_tutar_vergili), 2);
                        LblBurutTutar.Text = burut_tutar.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;


                        double toplam_stok_adedi = Math.Round(GidecekSTHListe.Sum(x => x.sth_miktar), 2);
                        LblTopalmStokAdeti.Text = toplam_stok_adedi.ToString();

                        LblKalemAdeti.Text = GidecekSTHListe.Count.ToString();

                        double vergi_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_vergi), 2);
                        double indirim_toplami = Math.Round(GidecekSTHListe.Sum(x => x.sth_iskonto1), 2);

                        LblIndirimTutar.Text = indirim_toplami.ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        if (GidecekSTHListe.Sum(x => x.sth_iskonto1) > 0.1)
                        {
                            LblIndirimYuzde.Text = Math.Round(indirim_toplami * 100 / burut_tutar, 2).ToString() + " %";
                        }

                        LblToplamTutar.Text = Math.Round(burut_tutar - indirim_toplami, 2).ToString() + " " + GidecekSTHListe[0].sth_doviz_ismi;

                        LblCikisDepo.Text = GidecekSTHListe[0].sth_cikis_depo_no.ToString();

                        LblTarih.Text = SatisMySTH[0].sth_tarih.ToString("dd-MM-yyyy");

                    }
                    catch (Exception ex)
                    {

                        await HelpME.MessageShow("Hata", "Fatura incele bolumunde bir hata meydana geldi" + ex, "OK");
                    }


                    break;

                #endregion

                #endregion
                default:
                    await HelpME.MessageShow("Hata", "Olagan disi bir durum sozkonusu. Lutfen IT Yoneticinize konuyu bildirin", "OK");
                    break;


            }

        }
    }
}
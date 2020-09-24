using KayaApp.Helpers;
using KayaApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayaApp.GetData
{
    public static class SendData
    {
        public static async Task<bool> SEND_UNSENT()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //  UserDialogs.Instance.ShowLoading("Eski Gonderilmeyenler Gonderiliyor", MaskType.None); 
                await CheckSatisFaturas();
                await CheckSarfCikisFisi();
                // UserDialogs.Instance.HideLoading();
            }

            return true;
        }

        //Satis Faturasinda Gonderilmeyen Kayit varmi diye bakiyoruz. varsa, SendDetayliSatisFaturasi metoduyla gonderimimizi yapiyoruz. ve fatura,sth ve aktarim bolumlerine aktarildi diye not dusuyoruz.
        public static async Task<bool> CheckSatisFaturas()
        {
            try
            {
                var Gonderilmeyen_Faturalar = await LocalSQL<SatisFatModel>.DBIslem("SELECT * from SatisFatModel where fat_sent=0");

                if (Gonderilmeyen_Faturalar.Count > 0)
                {

                    foreach (var item in Gonderilmeyen_Faturalar)
                    {
                        List<KirilimliSth> krlmsth = new List<KirilimliSth>();

                        string cumle = "select * from SatisSthModel WHERE sth_fat_baglanti='" + item.fat_sth_baglanti + "'";
                        var STHlar = await LocalSQL<SatisSthModel>.DBIslem(cumle);
                        var RenkBedenler = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.DBIslem("select * from OlusanRenkBedenSeriHareketleriModel where Olusan_Baglantisi_fat='" + item.fat_sth_baglanti + "'");

                        krlmsth.Add(new KirilimliSth { SthHareketTablosu = STHlar.ToList(), RenkBedenSeriDetayTablosu = RenkBedenler });

                        List<SatisFatModel> gidecekFat = new List<SatisFatModel>();
                        gidecekFat.Add(item);
                        await SendDetayliSatisFaturasi(krlmsth, gidecekFat);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// Gonderilmeyen sarf cikis fisi varmi yokmu diye database e bakiyoruz. varsa, gonderiyoruz. 
        public static async Task<bool> CheckSarfCikisFisi()
        {
            try
            {
                var Gonderilmeyen_Sarflar = await LocalSQL<AktarimModel>.DBIslem("SELECT * from AktarimModel  where Aktarim_Sent=0 and Aktarim_IslemKodu=15");

                if (Gonderilmeyen_Sarflar.Count > 0)
                {

                    foreach (var item in Gonderilmeyen_Sarflar)
                    {
                        List<KirilimliSth> krlmsth = new List<KirilimliSth>();

                        string cumle = "select * from SatisSthModel WHERE sth_fat_baglanti='" + item.Aktarim_Baglanti_guid + "'";
                        var STHlar = await LocalSQL<SatisSthModel>.DBIslem(cumle);

                        List<OlusanRenkBedenSeriHareketleriModel> RenkBedenler = new List<OlusanRenkBedenSeriHareketleriModel>();
                        foreach (var itemSTH in STHlar)
                        {

                            var Sthim = await LocalSQL<OlusanRenkBedenSeriHareketleriModel>.DBIslem("select * from OlusanRenkBedenSeriHareketleriModel where Olusan_Baglantisi_sth='" + itemSTH.sth_renk_beden_seri_baglanti + "'");

                            foreach (var itemRNK in Sthim.ToList())
                            {
                                RenkBedenler.Add(itemRNK);
                            }
                        }

                        krlmsth.Add(new KirilimliSth { SthHareketTablosu = STHlar.ToList(), RenkBedenSeriDetayTablosu = RenkBedenler });

                        await SendSarfCikisFisi(krlmsth);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static async Task<bool> SendDetayliSatisFaturasi(List<KirilimliSth> Kirilimli, List<SatisFatModel> fatura)
        {
            var CompanyInfo = DataClass._LSTMANAGER.ACTIVECOMPANY;

            if (!CrossConnectivity.Current.IsConnected)
            {
                await HelpME.MessageShow("Veri Gonderilemedi", "Satis Faturasi Gonderilemedi.Internet Baglantinizda Problem Var. Lutfen Once internete bagli oldugunuzdan emin olunz.Dahasonra Tekrar Deneyiniz...", "OK");
                return false;
            }
            try
            {
                var urlFATURA = SabitUrl.SendInvoice(CompanyInfo.COMPANY_IP.ToString(), CompanyInfo.COMPANY_PORT.ToString(), CompanyInfo.COMPANY_DB_NAME);

                var urlSTH = SabitUrl.NEWSendSTH(CompanyInfo.COMPANY_IP.ToString(), CompanyInfo.COMPANY_PORT.ToString(), CompanyInfo.COMPANY_DB_NAME);

                if (urlFATURA != null && urlSTH != null)
                {
                    var ISbir = await ApiBaglan<SatisFatModel>.VeriGonder(urlFATURA, fatura);
                    var ISiki = await ApiBaglan<KirilimliSth>.VeriGonder(urlSTH, Kirilimli);
                    if (ISbir && ISiki)
                    {
                        await LocalSQL<SatisFatModel>.DBIslem("UPDATE SatisFatModel set fat_sent=1 where fat_id=" + fatura[0].fat_id);
                        await LocalSQL<AktarimModel>.DBIslem("UPDATE AktarimModel set Aktarim_Sent=1 where Aktarim_Baglanti_guid='" + fatura[0].fat_sth_baglanti + "'");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("SEND DATA ERROR", "The system couldnt send the data to server..." + ex, "OK");
            }
            return false;
        }

        public static async Task<bool> AlisFaturasi(List<KirilimliSth> Kirilimli, List<AlisFatModel> fatura)
        {
            var CompanyInfo = DataClass._LSTMANAGER.ACTIVECOMPANY;

            if (!CrossConnectivity.Current.IsConnected)
            {
                await HelpME.MessageShow("Veri Gonderilemedi", "Alis Faturasi Gonderilemedi.Internet Baglantinizda Problem Var. Lutfen Once internete bagli oldugunuzdan emin olunz.Dahasonra Tekrar Deneyiniz...", "OK");
                return false;
            }
            try
            {
                var urlFATURA = SabitUrl.SendInvoice(CompanyInfo.COMPANY_IP.ToString(), CompanyInfo.COMPANY_PORT.ToString(), CompanyInfo.COMPANY_DB_NAME);

                var urlSTH = SabitUrl.NEWSendSTH(CompanyInfo.COMPANY_IP.ToString(), CompanyInfo.COMPANY_PORT.ToString(), CompanyInfo.COMPANY_DB_NAME);

                if (urlFATURA != null && urlSTH != null)
                {
                    var ISbir = await ApiBaglan<AlisFatModel>.VeriGonder(urlFATURA, fatura);
                    var ISiki = await ApiBaglan<KirilimliSth>.VeriGonder(urlSTH, Kirilimli);
                    if (ISbir && ISiki)
                    {
                        await LocalSQL<AlisFatModel>.DBIslem("UPDATE AlisFatModel set fat_sent=1 where fat_id=" + fatura[0].fat_id);
                        await LocalSQL<AktarimModel>.DBIslem("UPDATE AktarimModel set Aktarim_Sent=1 where Aktarim_Baglanti_guid='" + fatura[0].fat_sth_baglanti + "'");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("SEND DATA ERROR", "The system couldnt send the data to server..." + ex, "OK");
            }
            return false;
        }

        public static async Task<bool> SendSarfCikisFisi(List<KirilimliSth> Kirilimli)
        {

            var CompanyInfo = DataClass._LSTMANAGER.ACTIVECOMPANY;

            if (!CrossConnectivity.Current.IsConnected)
            {
                await HelpME.MessageShow("Veri Gonderilemedi", "Sarf Cikis Fisi Gonderilemedi.Internet Baglantinizda Problem Var. " +
                    "Lutfen Once internete bagli oldugunuzdan emin olunz.Dahasonra Tekrar Deneyiniz...", "OK");
                return false;
            }
            try
            {
                var urlSTH = SabitUrl.NEWSendSTH(CompanyInfo.COMPANY_IP.ToString(), CompanyInfo.COMPANY_PORT.ToString(), CompanyInfo.COMPANY_DB_NAME);

                if (urlSTH != null)
                {
                    //iş iki
                    var ISiki = await ApiBaglan<KirilimliSth>.VeriGonder(urlSTH, Kirilimli);

                    if (ISiki)
                    {
                        await LocalSQL<AktarimModel>.DBIslem("UPDATE AktarimModel set Aktarim_Sent=1 where Aktarim_Baglanti_guid='" + Kirilimli[0].SthHareketTablosu[0].sth_fat_baglanti + "'");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("SEND DATA ERROR", "Sarf Cikis Ambar Fisi Error:The system couldnt send the data to server..." + ex, "OK");
            }
            return false;
        }
    }
}

using KayaApp.Helpers;
using KayaApp.Language;
using KayaApp.Models;
using KayaApp.Models.DataModels;
using KayaApp.Models.GetDataModels;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayaApp.GetData
{
    public static class DataClass
    {
        public static LISTMANAGER _LSTMANAGER;
        public static async Task<LISTMANAGER> GetData(CompanyModel Mycompany, UsersModel MyUser)
        {
            if (_LSTMANAGER == null)
            {
                _LSTMANAGER = new LISTMANAGER();
            }

            if (CrossConnectivity.Current.IsConnected)
            {

                int SyncID = 0;
                var son = await LocalSQL<SyncModel>.GETLISTALL();
                if (son.Count > 0)
                {
                    int.TryParse(son.ToList().FirstOrDefault().LastSyncID.ToString(), out SyncID);
                }

                #region  URL Tanimlamalari
                var urlx = SabitUrl.GetLastsyncID(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME);

                var url0 = SabitUrl.SilinenKayitlar_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url1 = SabitUrl.Stockurl_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), MyUser.USERS_DEFAULT_FIYATLISTESI, Mycompany.COMPANY_DB_NAME, MyUser.USERS_DEFAULT_KAYNAKDEPO, SyncID);

                var url2 = SabitUrl.CustomerURL_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url3 = SabitUrl.BarcodeURL_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url4 = SabitUrl.MasrafURL_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url5 = SabitUrl.DepoIsimleriURL_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url6 = SabitUrl.DovizKurlariURL_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url7 = SabitUrl.StokListeFiyatTanimlamalariURL_(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url8 = SabitUrl.Stok_Sektorlari(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url9 = SabitUrl.Cari_Hesap_Bolgeleri(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url10 = SabitUrl.Cari_Hesap_Guruplari(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url11 = SabitUrl.Cari_Personel_Tanimlari(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url12 = SabitUrl.KurIsimleriFull(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url13 = SabitUrl.Firmalar(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url14 = SabitUrl.Subeler(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url15 = SabitUrl.Renkler(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url16 = SabitUrl.Bedenler(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url17 = SabitUrl.SorumlulukMerk(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url18 = SabitUrl.Projeler(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url19 = SabitUrl.Bankalar(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url20 = SabitUrl.Kasalar(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url21 = SabitUrl.ODEMEPLANLARI(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url22 = SabitUrl.CARIBAKIYELER(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url23 = SabitUrl.STOKMIKTARLARI(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, MyUser.USERS_DEFAULT_KAYNAKDEPO, SyncID);

                var url24 = SabitUrl.PARTILOT(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url25 = SabitUrl.STOKRESIMLERILIST(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url26 = SabitUrl.KAMPANYALAR(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID);

                var url27 = SabitUrl.IZINLER(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, SyncID, MyUser.USERS_ID);

                #endregion
                //-----------------------------------------------------------------------------------------------------
                #region VeriAlimi Yapiliyor

                var durumLastSyncID = await ApiBaglan<SyncModel>.VeriListeAl(urlx);

                var durumSilinenKayitlar = await ApiBaglan<SilinenKayitlar>.VeriListeAl(url0);

                var durumSTOCK = await ApiBaglan<StockModel>.VeriListeAl(url1);

                var durumCARI = await ApiBaglan<CustomerModel>.VeriListeAl(url2);

                var durumBARCODE = await ApiBaglan<BarcodeModel>.VeriListeAl(url3);

                var durumMasraf = await ApiBaglan<MasrafModel>.VeriListeAl(url4);

                var durumDepoIsimleri = await ApiBaglan<DepoIsimleriModel>.VeriListeAl(url5);

                var durumKurlar = await ApiBaglan<DovizKurlariModel>.VeriListeAl(url6);

                var durumStokFiyatListeTanm = await ApiBaglan<StokListeTanimlamalariModel>.VeriListeAl(url7);

                var durumStokSektorlari = await ApiBaglan<StokSektorlariModel>.VeriListeAl(url8);

                var durumCariHesapBolgeleri = await ApiBaglan<CariHesapBolgeleriModel>.VeriListeAl(url9);

                var durumCariHesapGruplari = await ApiBaglan<CariHesapGruplariModel>.VeriListeAl(url10);

                var durumCariPersonelTanimlari = await ApiBaglan<CariPersonelTanimlariModel>.VeriListeAl(url11);

                var durumKurIsimleriFull = await ApiBaglan<KurIsimleriFullKurusModel>.VeriListeAl(url12);

                var durumFirmalar = await ApiBaglan<FirmalarModel>.VeriListeAl(url13);

                var durumSubeler = await ApiBaglan<SubelerModel>.VeriListeAl(url14);

                var durumRenkler = await ApiBaglan<RenkModel>.VeriListeAl(url15);

                var durumBedenler = await ApiBaglan<BedenModel>.VeriListeAl(url16);

                var durumSorumluluk = await ApiBaglan<SorumlulukModel>.VeriListeAl(url17);

                var durumProjeler = await ApiBaglan<ProjeModel>.VeriListeAl(url18);

                var durumBankalar = await ApiBaglan<BankaModel>.VeriListeAl(url19);

                var durumKasalar = await ApiBaglan<KasaModel>.VeriListeAl(url20);

                var durumOdemePlanlari = await ApiBaglan<OdemePlanlariModel>.VeriListeAl(url21);

                var durumCariBakiyeler = await ApiBaglan<CariBakiyelerModel>.VeriListeAl(url22);

                var durumStokMiktarlari = await ApiBaglan<StokMiktarlariModel>.VeriListeAl(url23);

                var durumPartiLot = await ApiBaglan<PartiLotModel>.VeriListeAl(url24);

                var durumStokResimleriList = await ApiBaglan<StokResimleriModel>.VeriListeAl(url25);

                var durumKampanyalar = await ApiBaglan<KampanyalarModel>.VeriListeAl(url26);

                var durumIzinler = await ApiBaglan<IzinlerModel>.VeriListeAl(url27);

                #endregion


                #region silme kontrolu
                if (durumSilinenKayitlar.Count > 0)
                {
                    //1-CARI_HESAPLAR    CustomerModel  sil
                    var silinecekCustomerIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 1).ToList();
                    if (silinecekCustomerIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekCustomerIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<CustomerModel>.DBIslem("DELETE FROM CustomerModel where cari_RECno in (" + IDLER + ") ");
                    }

                    //2-CARI_HESAP_HAREKETLERI   CariBakiyelerModel
                    var silinecekCariBakiyelerModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 2).ToList();
                    if (silinecekCariBakiyelerModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekCariBakiyelerModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<CariBakiyelerModel>.DBIslem("DELETE FROM CariBakiyelerModel where cari_RECno in (" + IDLER + ") ");
                    }

                    //3-STOK_HAREKETLERI   StokMiktarlariModel
                    var silinecekStokMiktarlariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 3).ToList();
                    if (silinecekStokMiktarlariModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekStokMiktarlariModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<StokMiktarlariModel>.DBIslem("DELETE FROM StokMiktarlariModel where sto_RECno in (" + IDLER + ") ");
                    }


                    //4-STOKLAR    StockModel
                    var silinecekStockModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 4).ToList();
                    if (silinecekStockModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekStockModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<StockModel>.DBIslem("DELETE FROM StockModel where sto_RECno in (" + IDLER + ") ");
                    }

                    //5-BARKOD_TANIMLARI    BarcodeModel
                    var silinecekBarcodeModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 5).ToList();
                    if (silinecekBarcodeModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekBarcodeModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<BarcodeModel>.DBIslem("DELETE FROM BarcodeModel where bar_RECno in (" + IDLER + ") ");
                    }

                    //6-MASRAF_HESAPLARI    MasrafModel
                    var silinecekMasrafModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 6).ToList();
                    if (silinecekMasrafModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekMasrafModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<MasrafModel>.DBIslem("DELETE FROM MasrafModel where his_RECno in (" + IDLER + ") ");
                    }

                    //7-DEPOLAR      DepoIsimleriModel
                    var silinecekDepoIsimleriModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 7).ToList();
                    if (silinecekDepoIsimleriModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekDepoIsimleriModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<DepoIsimleriModel>.DBIslem("DELETE FROM DepoIsimleriModel where dep_RECno in (" + IDLER + ") ");
                    }

                    //8-STOK_SATIS_FIYAT_LISTE_TANIMLARI   StokListeTanimlamalariModel
                    var silinecekStokListeTanimlamalariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 8).ToList();
                    if (silinecekStokListeTanimlamalariModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekStokListeTanimlamalariModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<StokListeTanimlamalariModel>.DBIslem("DELETE FROM StokListeTanimlamalariModel where sfl_RECno in (" + IDLER + ") ");
                    }

                    //9-STOK_SEKTORLERI     StokSektorlariModel
                    var silinecekStokSektorlariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 9).ToList();
                    if (silinecekStokSektorlariModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekStokSektorlariModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<StokSektorlariModel>.DBIslem("DELETE FROM StokSektorlariModel where sktr_RECno in (" + IDLER + ") ");
                    }

                    //10-CARI_HESAP_BOLGELERI       CariHesapBolgeleriModel
                    var silinecekCariHesapBolgeleriModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 10).ToList();
                    if (silinecekCariHesapBolgeleriModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekCariHesapBolgeleriModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<CariHesapBolgeleriModel>.DBIslem("DELETE FROM CariHesapBolgeleriModel where bol_RECno in (" + IDLER + ") ");
                    }

                    //11-CARI_HESAP_GRUPLARI        CariHesapGruplariModel
                    var silinecekCariHesapGruplariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 11).ToList();
                    if (silinecekCariHesapGruplariModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekCariHesapGruplariModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<CariHesapGruplariModel>.DBIslem("DELETE FROM CariHesapGruplariModel where crg_RECno in (" + IDLER + ") ");
                    }
                    //12-CARI_PERSONEL_TANIMLARI    CariPersonelTanimlariModel
                    var silinecekCariPersonelTanimlariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 12).ToList();
                    if (silinecekCariPersonelTanimlariModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekCariPersonelTanimlariModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<CariPersonelTanimlariModel>.DBIslem("DELETE FROM CariPersonelTanimlariModel where cari_per_RECno in (" + IDLER + ") ");
                    }

                    //13-STOK_RENK_TANIMLARI    RenkModel
                    var silinecekRenkModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 13).ToList();
                    if (silinecekRenkModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekRenkModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<RenkModel>.DBIslem("DELETE FROM RenkModel where rnk_RECno in (" + IDLER + ") ");
                    }


                    //14-STOK_BEDEN_TANIMLARI   BedenModel
                    var silinecekBedenModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 14).ToList();
                    if (silinecekBedenModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekBedenModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<BedenModel>.DBIslem("DELETE FROM BedenModel where bdn_RECno in (" + IDLER + ") ");
                    }



                    //15-PROJELER  sil  ProjeModel
                    var silinecekProjeModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 15).ToList();
                    if (silinecekProjeModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekProjeModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<ProjeModel>.DBIslem("DELETE FROM ProjeModel where pro_RECno in (" + IDLER + ") ");
                    }


                    //16-SORUMLULUK_MERKEZLERI sil  SorumlulukModel
                    var silinecekSorumlulukModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 16).ToList();
                    if (silinecekSorumlulukModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekSorumlulukModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<SorumlulukModel>.DBIslem("DELETE FROM SorumlulukModel where som_RECno in (" + IDLER + ") ");
                    }


                    //17-KASALAR   sil      KasaModel
                    var silinecekKasaModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 17).ToList();
                    if (silinecekKasaModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekKasaModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<KasaModel>.DBIslem("DELETE FROM KasaModel where kas_RECno in (" + IDLER + ") ");
                    }


                    //18-BANKALAR sil           BankaModel
                    var silinecekBankaModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 18).ToList();
                    if (silinecekBankaModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekBankaModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<BankaModel>.DBIslem("DELETE FROM BankaModel where ban_RECno in (" + IDLER + ") ");
                    }


                    //19-ODEME_PLANLARI sil     OdemePlanlariModel
                    var silinecekOdemePlanlariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 19).ToList();
                    if (silinecekOdemePlanlariModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekOdemePlanlariModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<OdemePlanlariModel>.DBIslem("DELETE FROM OdemePlanlariModel where odp_RECno in (" + IDLER + ") ");
                    }


                    //20- MikroDB_V15.dbo.DOVIZ_KURLARI     DovizKurlariModel
                    var silinecekDovizKurlariModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 20).ToList();
                    if (silinecekDovizKurlariModelIDleri.Count > 0)
                    {
                        await LocalSQL<DovizKurlariModel>.DELETEALL();
                    }


                    //21-MikroDB_V15.dbo.KUR_ISIMLERI       KurIsimleriFullKurusModel
                    var silinecekKurIsimleriFullKurusModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 21).ToList();
                    if (silinecekKurIsimleriFullKurusModelIDleri.Count > 0)
                    {
                        await LocalSQL<KurIsimleriFullKurusModel>.DELETEALL();
                    }


                    //22-FIRMALAR       FirmalarModel
                    var silinecekFirmalarModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 22).ToList();
                    if (silinecekFirmalarModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekFirmalarModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<FirmalarModel>.DBIslem("DELETE FROM FirmalarModel where fir_RECno in (" + IDLER + ") ");
                    }
                    //23 - SUBELER      SubelerModel
                    var silinecekSubelerModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 23).ToList();
                    if (silinecekSubelerModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekSubelerModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<SubelerModel>.DBIslem("DELETE FROM SubelerModel where Sube_RECno in (" + IDLER + ") ");
                    }

                    //23 - PARTILAT      PartiLotModel
                    var silinecekPartiLOTModelIDleri = durumSilinenKayitlar.Where(x => x.TabloID == 24).ToList();
                    if (silinecekPartiLOTModelIDleri.Count > 0)
                    {
                        StringBuilder IDLER = new StringBuilder();
                        foreach (var item in silinecekPartiLOTModelIDleri)
                        {
                            IDLER.Append(item.IslemRECno + ",");
                        }
                        IDLER.Remove(IDLER.Length - 1, 1);
                        await LocalSQL<PartiLotModel>.DBIslem("DELETE FROM PartiLotModel where pl_RECno in (" + IDLER + ") ");
                    }



                }
                #endregion

                //her kayit cektigimizde mecburen dovizkurlarini ve kur isimlerini cekmek zorundayim. yapacak bise yok cok karisik.beynim yandi
                //ayrica kullanici izinlerini de her seferinde aliyoruz. takip id si koysak bile, cok fazla kayit oluyor. o yuzden en iyi sey budur.

                await LocalSQL<DovizKurlariModel>.DELETEALL();
                await LocalSQL<KurIsimleriFullKurusModel>.DELETEALL();
                await LocalSQL<IzinlerModel>.DELETEALL();
                  
                //her data aktariminda doviz kurlari ve kur isimlerini silip, tekrardan yeni veri insert ediyorz
                //bunun sebebi ise, kurlar v15 in altinda tutuluyor. ayrica yeni bir doviz kaydi eklendigi zaman, sync tablosuna dunya kadar kayit atiyor. 
                //bildigin bas agrisi. o yuzden en guzel yontem budur...

                await LocalSQL<DovizKurlariModel>.DELETEALL();
                await LocalSQL<KurIsimleriFullKurusModel>.DELETEALL();



                //cari bakiyeleri ve stok hareketleri guncellemeleri yapiyoruz
                if (durumCARI.Count > 0)
                {
                    foreach (var item in durumCariBakiyeler.ToList())
                    {
                        durumCARI.Where(x => x.cari_kod == item.cari_kod).FirstOrDefault().cari_bakiye = item.cari_bakiye;
                    }
                }

                if (durumSTOCK.Count > 0)
                {
                    foreach (var item in durumStokMiktarlari.ToList())
                    {
                        durumSTOCK.Where(x => x.sto_kod == item.sto_kod).FirstOrDefault().sto_eldeki_miktar = item.sto_eldeki_miktar;
                    }
                }


                //fotograflarla ilgili bir degisiklik vs varsa, burda cash i sifirliyoruz. lazim oldugu zaman, zaten cash otomatik olarak alim yapacaktir.
                if (durumStokResimleriList.Count > 0)
                {
                    foreach (var item in durumStokResimleriList)
                    {
                        //  await ImageService.Instance.InvalidateCacheEntryAsync(item.STOK_RESIMURL, FFImageLoading.Cache.CacheType.All, removeSimilar: true);
                    }
                }

                await LocalSQL<StockModel>.DBINSERTALL(durumSTOCK);
                await LocalSQL<CustomerModel>.DBINSERTALL(durumCARI);
                await LocalSQL<BarcodeModel>.DBINSERTALL(durumBARCODE);
                await LocalSQL<MasrafModel>.DBINSERTALL(durumMasraf);
                await LocalSQL<DepoIsimleriModel>.DBINSERTALL(durumDepoIsimleri);
                await LocalSQL<DovizKurlariModel>.DBINSERTALL(durumKurlar);
                await LocalSQL<StokListeTanimlamalariModel>.DBINSERTALL(durumStokFiyatListeTanm);
                await LocalSQL<StokSektorlariModel>.DBINSERTALL(durumStokSektorlari);
                await LocalSQL<CariHesapBolgeleriModel>.DBINSERTALL(durumCariHesapBolgeleri);
                await LocalSQL<CariHesapGruplariModel>.DBINSERTALL(durumCariHesapGruplari);
                await LocalSQL<CariPersonelTanimlariModel>.DBINSERTALL(durumCariPersonelTanimlari);
                await LocalSQL<KurIsimleriFullKurusModel>.DBINSERTALL(durumKurIsimleriFull);
                await LocalSQL<FirmalarModel>.DBINSERTALL(durumFirmalar);
                await LocalSQL<SubelerModel>.DBINSERTALL(durumSubeler);
                await LocalSQL<RenkModel>.DBINSERTALL(durumRenkler);
                await LocalSQL<BedenModel>.DBINSERTALL(durumBedenler);
                await LocalSQL<ProjeModel>.DBINSERTALL(durumProjeler);
                await LocalSQL<SorumlulukModel>.DBINSERTALL(durumSorumluluk);
                await LocalSQL<BankaModel>.DBINSERTALL(durumBankalar);
                await LocalSQL<KasaModel>.DBINSERTALL(durumKasalar);
                await LocalSQL<OdemePlanlariModel>.DBINSERTALL(durumOdemePlanlari);
                await LocalSQL<CariBakiyelerModel>.DBINSERTALL(durumCariBakiyeler);
                await LocalSQL<StokMiktarlariModel>.DBINSERTALL(durumStokMiktarlari);
                await LocalSQL<PartiLotModel>.DBINSERTALL(durumPartiLot);
                await LocalSQL<KampanyalarModel>.DBINSERTALL(durumKampanyalar);
                await LocalSQL<IzinlerModel>.DBINSERTALL(durumIzinler);

                 
                _LSTMANAGER.ACTIVEUSER = MyUser;
                _LSTMANAGER.ACTIVECOMPANY = Mycompany;

                var STOCKS = await LocalSQL<StockModel>.GETLISTALL();
                _LSTMANAGER.STOCKLIST = new ObservableCollection<StockModel>(STOCKS);

                var CUSTOMERS = await LocalSQL<CustomerModel>.GETLISTALL();
                _LSTMANAGER.CUSTOMERLIST = new ObservableCollection<CustomerModel>(CUSTOMERS);


                var BARCODES = await LocalSQL<BarcodeModel>.GETLISTALL();
                _LSTMANAGER.BARCODELIST = new ObservableCollection<BarcodeModel>(BARCODES);

                var MASRAFS = await LocalSQL<MasrafModel>.GETLISTALL();
                _LSTMANAGER.MASRAFLIST = new ObservableCollection<MasrafModel>(MASRAFS);

                var DEPOS = await LocalSQL<DepoIsimleriModel>.GETLISTALL();
                _LSTMANAGER.DEPOISIMLERILIST = new ObservableCollection<DepoIsimleriModel>(DEPOS);

                //DOVIZ KURLARINI HER SEFERINDE SILIP,YENIDEN INSERT EDIYORUZ
                _LSTMANAGER.KURLARLISTE = new ObservableCollection<DovizKurlariModel>(durumKurlar.ToList());

                var STOK_FIYAT_LISTELERI = await LocalSQL<StokListeTanimlamalariModel>.GETLISTALL();
                _LSTMANAGER.STOKLISTETANIMLAMALARILISTE = new ObservableCollection<StokListeTanimlamalariModel>(STOK_FIYAT_LISTELERI);

                var SEKTORS = await LocalSQL<StokSektorlariModel>.GETLISTALL();
                _LSTMANAGER.STOK_SEKTORLARI_LIST = new ObservableCollection<StokSektorlariModel>(SEKTORS);

                var CARI_BOLGELERS = await LocalSQL<CariHesapBolgeleriModel>.GETLISTALL();
                _LSTMANAGER.CARI_HESAP_BOLGELERI = new ObservableCollection<CariHesapBolgeleriModel>(CARI_BOLGELERS);

                var CARI_GRUPS = await LocalSQL<CariHesapGruplariModel>.GETLISTALL();
                _LSTMANAGER.CARI_HESAP_GRUPLARI = new ObservableCollection<CariHesapGruplariModel>(CARI_GRUPS);

                var CARI_PERSONELS = await LocalSQL<CariPersonelTanimlariModel>.GETLISTALL();
                _LSTMANAGER.CARI_PERSONEL_TANIMLARI_LIST = new ObservableCollection<CariPersonelTanimlariModel>(CARI_PERSONELS);

                //KUR ISIMLERINI HER SEFERINDE SILIP, YENIDEN INSERT EDIYORUZ
                _LSTMANAGER.KurIsimleriFullKurus = new ObservableCollection<KurIsimleriFullKurusModel>(durumKurIsimleriFull.ToList());

                var FIRMAS = await LocalSQL<FirmalarModel>.GETLISTALL();
                _LSTMANAGER.FirmalarList = new ObservableCollection<FirmalarModel>(FIRMAS);

                var SUBES = await LocalSQL<SubelerModel>.GETLISTALL();
                _LSTMANAGER.SubelerList = new ObservableCollection<SubelerModel>(SUBES);

                var RENKS = await LocalSQL<RenkModel>.GETLISTALL();
                _LSTMANAGER.Renkler = new ObservableCollection<RenkModel>(RENKS);

                var BEDENS = await LocalSQL<BedenModel>.GETLISTALL();
                _LSTMANAGER.Bedenler = new ObservableCollection<BedenModel>(BEDENS);

                var PROJES = await LocalSQL<ProjeModel>.GETLISTALL();
                _LSTMANAGER.Projeler = new ObservableCollection<ProjeModel>(PROJES);

                var SORUMLULUKS = await LocalSQL<SorumlulukModel>.GETLISTALL();
                _LSTMANAGER.Sorumluluklar = new ObservableCollection<SorumlulukModel>(SORUMLULUKS);

                var BANKS = await LocalSQL<BankaModel>.GETLISTALL();
                _LSTMANAGER.Bankalar = new ObservableCollection<BankaModel>(BANKS);

                var KASAS = await LocalSQL<KasaModel>.GETLISTALL();
                _LSTMANAGER.Kasalar = new ObservableCollection<KasaModel>(KASAS);

                var ODEMEPLANS = await LocalSQL<OdemePlanlariModel>.GETLISTALL();
                _LSTMANAGER.OdemePlanlari = new ObservableCollection<OdemePlanlariModel>(ODEMEPLANS);


                var PARTILOTS = await LocalSQL<PartiLotModel>.GETLISTALL();
                _LSTMANAGER.PartiLotList = new ObservableCollection<PartiLotModel>(PARTILOTS);

                var KAMPANYALAR = await LocalSQL<KampanyalarModel>.GETLISTALL();
                _LSTMANAGER.KampanyalarList = new ObservableCollection<KampanyalarModel>(KAMPANYALAR);

                var IZINLER = await LocalSQL<IzinlerModel>.GETLISTALL();
                _LSTMANAGER.IzinlerList= new ObservableCollection<IzinlerModel>(IZINLER);

                _LSTMANAGER.Sorumluluklar.Insert(0, new SorumlulukModel { som_isim = "", som_kod = "" });
                _LSTMANAGER.Projeler.Insert(0, new ProjeModel { pro_adi = "", pro_kodu = "" });
                _LSTMANAGER.OdemePlanlari.Insert(0, new OdemePlanlariModel { odp_no = 0, odp_adi = AppResources.Nakit });




                foreach (var item in _LSTMANAGER.STOCKLIST)
                {
                    //stok kartlarina stok resimlerinin url lerini getiriyoruz...
                    item.stok_resim_url = SabitUrl.StokResimleri(Mycompany.COMPANY_IP.ToString(), Mycompany.COMPANY_PORT.ToString(), Mycompany.COMPANY_DB_NAME, item.sto_kod);
                    item.sto_doviz_ad = _LSTMANAGER.KURLARLISTE[0].Kur_sembol;
                    //stok resim cash olayi
                    //await ImageService.Instance.InvalidateCacheEntryAsync(item.stok_resim_url, FFImageLoading.Cache.CacheType.All, removeSimilar: true);
                }

                //biz verialisverisine baslamadan once, SYNC ID yi aliyoruzki, bizim islemimiz sirasinda bir degisiklik olursa,kaybetmeyelim diye.
                //inserti en sona koydumki, eger aktarim sirasinda, bir hata yasarsak, bu koda gelmeyecegi icin tekrar kayit olusturmayacaktir.
                //tekrar eden kayit varmi yokmu diye kontrol eden bir clas yazmamiz lazim
                await LocalSQL<SyncModel>.DELETEALL();
                List<SyncModel> mysync = new List<SyncModel>();
                mysync.Add(new SyncModel { LastSyncID = durumLastSyncID[0].LastSyncID });
                await LocalSQL<SyncModel>.DBINSERTALL(mysync);

            }

            //internet yoksa herseyi oldugu gibi veritabanindan celkip veriyporuz
            else
            {
                _LSTMANAGER.ACTIVEUSER = MyUser;
                _LSTMANAGER.ACTIVECOMPANY = Mycompany;

                var STOCKS = await LocalSQL<StockModel>.GETLISTALL();
                _LSTMANAGER.STOCKLIST = new ObservableCollection<StockModel>(STOCKS);

                var CUSTOMERS = await LocalSQL<CustomerModel>.GETLISTALL();
                _LSTMANAGER.CUSTOMERLIST = new ObservableCollection<CustomerModel>(CUSTOMERS);


                var BARCODES = await LocalSQL<BarcodeModel>.GETLISTALL();
                _LSTMANAGER.BARCODELIST = new ObservableCollection<BarcodeModel>(BARCODES);

                var MASRAFS = await LocalSQL<MasrafModel>.GETLISTALL();
                _LSTMANAGER.MASRAFLIST = new ObservableCollection<MasrafModel>(MASRAFS);

                var DEPOS = await LocalSQL<DepoIsimleriModel>.GETLISTALL();
                _LSTMANAGER.DEPOISIMLERILIST = new ObservableCollection<DepoIsimleriModel>(DEPOS);

                var KURLAR = await LocalSQL<DovizKurlariModel>.GETLISTALL();
                _LSTMANAGER.KURLARLISTE = new ObservableCollection<DovizKurlariModel>(KURLAR.ToList());

                var STOK_FIYAT_LISTELERI = await LocalSQL<StokListeTanimlamalariModel>.GETLISTALL();
                _LSTMANAGER.STOKLISTETANIMLAMALARILISTE = new ObservableCollection<StokListeTanimlamalariModel>(STOK_FIYAT_LISTELERI);

                var SEKTORS = await LocalSQL<StokSektorlariModel>.GETLISTALL();
                _LSTMANAGER.STOK_SEKTORLARI_LIST = new ObservableCollection<StokSektorlariModel>(SEKTORS);

                var CARI_BOLGELERS = await LocalSQL<CariHesapBolgeleriModel>.GETLISTALL();
                _LSTMANAGER.CARI_HESAP_BOLGELERI = new ObservableCollection<CariHesapBolgeleriModel>(CARI_BOLGELERS);

                var CARI_GRUPS = await LocalSQL<CariHesapGruplariModel>.GETLISTALL();
                _LSTMANAGER.CARI_HESAP_GRUPLARI = new ObservableCollection<CariHesapGruplariModel>(CARI_GRUPS);

                var CARI_PERSONELS = await LocalSQL<CariPersonelTanimlariModel>.GETLISTALL();
                _LSTMANAGER.CARI_PERSONEL_TANIMLARI_LIST = new ObservableCollection<CariPersonelTanimlariModel>(CARI_PERSONELS);

                var KUR_ISIMLERI = await LocalSQL<KurIsimleriFullKurusModel>.GETLISTALL();
                _LSTMANAGER.KurIsimleriFullKurus = new ObservableCollection<KurIsimleriFullKurusModel>(KUR_ISIMLERI);

                var FIRMAS = await LocalSQL<FirmalarModel>.GETLISTALL();
                _LSTMANAGER.FirmalarList = new ObservableCollection<FirmalarModel>(FIRMAS);

                var SUBES = await LocalSQL<SubelerModel>.GETLISTALL();
                _LSTMANAGER.SubelerList = new ObservableCollection<SubelerModel>(SUBES);

                var RENKS = await LocalSQL<RenkModel>.GETLISTALL();
                _LSTMANAGER.Renkler = new ObservableCollection<RenkModel>(RENKS);

                var BEDENS = await LocalSQL<BedenModel>.GETLISTALL();
                _LSTMANAGER.Bedenler = new ObservableCollection<BedenModel>(BEDENS);

                var PROJES = await LocalSQL<ProjeModel>.GETLISTALL();
                _LSTMANAGER.Projeler = new ObservableCollection<ProjeModel>(PROJES);

                var SORUMLULUKS = await LocalSQL<SorumlulukModel>.GETLISTALL();
                _LSTMANAGER.Sorumluluklar = new ObservableCollection<SorumlulukModel>(SORUMLULUKS);

                var BANKS = await LocalSQL<BankaModel>.GETLISTALL();
                _LSTMANAGER.Bankalar = new ObservableCollection<BankaModel>(BANKS);

                var KASAS = await LocalSQL<KasaModel>.GETLISTALL();
                _LSTMANAGER.Kasalar = new ObservableCollection<KasaModel>(KASAS);

                var ODEMEPLANS = await LocalSQL<OdemePlanlariModel>.GETLISTALL();
                _LSTMANAGER.OdemePlanlari = new ObservableCollection<OdemePlanlariModel>(ODEMEPLANS);


                var PARTILOTS = await LocalSQL<PartiLotModel>.GETLISTALL();
                _LSTMANAGER.PartiLotList = new ObservableCollection<PartiLotModel>(PARTILOTS);

                var KAMPANYALAR = await LocalSQL<KampanyalarModel>.GETLISTALL();
                _LSTMANAGER.KampanyalarList = new ObservableCollection<KampanyalarModel>(KAMPANYALAR);

                var IZINLER = await LocalSQL<IzinlerModel>.GETLISTALL();
                _LSTMANAGER.IzinlerList = new ObservableCollection<IzinlerModel>(IZINLER);
            }
            return _LSTMANAGER;
        }
    }
}

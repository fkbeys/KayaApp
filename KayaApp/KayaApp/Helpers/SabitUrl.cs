using KayaApp.GetData;
using System;

namespace KayaApp.Helpers
{
    public static class SabitUrl
    {
        public static string SirketBilgileriUrl(string SirketAdi)
        {
            return "http://mikronerp.com/api/values/GetCompanyinfo?compname=" + SirketAdi;
        }
        public static string UserLink(CompanyModel Usercompany, string Username, string Userpass)
        {
            // string encryptedPass = Sifrele.SSifrele(Userpass);
            string link = "http://" + Usercompany.COMPANY_IP + ":" + Usercompany.COMPANY_PORT + "/Values/GetUser?DB=" + Usercompany.COMPANY_DB_NAME + "&username=" + Username + "&pass=" + Userpass + "";
            return link;
        }

        public static string GetLastsyncID(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/GetLastsyncID?DB=" + DB + " ";
        }

        public static string SilinenKayitlar_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/SILINENKAYITLAR?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string Stockurl_(string ip, string port, int price_list, string DB, int depo, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLSTOCKS?fiyat_liste_tanimi=" + price_list + "&DB=" + DB + "&syncID=" + syncID + "";

        }

        public static string CustomerURL_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLCUSTOMERS?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string BarcodeURL_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLBARCODES?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string MasrafURL_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLMASRAF?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string DepoIsimleriURL_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLDEPOISIMLERI?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string DovizKurlariURL_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLKURLAR?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string StokListeFiyatTanimlamalariURL_(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLSTOKLISTEFIYATTANIMLAMALARI?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string SendInvoice(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/FATURASAVE?DB=" + DB + " ";
        }
        public static string SendSTH(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/STHSAVE?DB=" + DB + " ";
        }

        public static string NEWSendSTH(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/NEWSTHSAVE?DB=" + DB + " ";
        }

        public static string SendOrders(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/ORDERSAVE?DB=" + DB + " ";
        }
        public static string SendProforma(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/PROFORMAORDERSAVE?DB=" + DB + " ";
        }
        public static string SendSayim(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/SAYIM_SAVE?DB=" + DB + " ";
        }

        public static string SendDepoArasSiparis(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/DEPOLAR_ARASI_SIPARIS_SAVE?DB=" + DB + " ";
        }

        public static string SendCustomer(string ip, string port, String DB)
        {
            return "http://" + ip + ":" + port + "/Values/CARI_SAVE?DB=" + DB + " ";
        }

        public static string StokResimleri(string ip, string port, String DB, string stok_kod)
        {
            return "http://" + ip + ":" + port + "/Values/GETIMAGES?DB=" + DB + "&stok_kod=" + stok_kod + ".jpg";
        }

        public static string Stok_Sektorlari(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_STOK_SEKTORLERI?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Cari_Hesap_Bolgeleri(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_CARI_HESAP_BOLGELERI?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Cari_Hesap_Guruplari(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_CARI_HESAP_GRUPLARI?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Cari_Personel_Tanimlari(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_CARI_PERSONEL_TANIMLARI?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string KurIsimleriFull(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_KUR_ISIMLERI?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Firmalar(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_FIRMALAR?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Subeler(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_SUBELER?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Renkler(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_RENKLER?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Bedenler(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_BEDENLER?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Projeler(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_PROJELER?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string SorumlulukMerk(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_SORUMLULUK?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Bankalar(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_BANKALAR?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string Kasalar(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_KASALAR?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string ODEMEPLANLARI(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_ODEMEPLANLARI?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string CARIBAKIYELER(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLCARIBAKIYELER?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string STOKMIKTARLARI(string ip, string port, String DB, int depo, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALLSTOKMIKTARLARI? &DB=" + DB + "&depo=" + depo + "&syncID=" + syncID + " ";
        }
        public static string PARTILOT(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_PARTILOT?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string STOKRESIMLERILIST(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_PARTILOT?DB=" + DB + "&syncID=" + syncID + " ";
        }
        public static string KAMPANYALAR(string ip, string port, String DB, int syncID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_KAMPANYALAR?DB=" + DB + "&syncID=" + syncID + " ";
        }

        public static string IZINLER(string ip, string port, String DB, int syncID,int UserID)
        {
            return "http://" + ip + ":" + port + "/Values/GETALL_IZINLER?DB=" + DB + "&syncID=" + syncID + "&UserID=" + UserID + " ";
        }

    }
}

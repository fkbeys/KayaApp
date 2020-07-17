using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Methods;
using KayaApp.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.REPORT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AktarimDetailFinansalPage : PopupPage
    {
        public AktarimDetailFinansalPage(AktarimModel gelendeger)
        {
            InitializeComponent();
            PnlTahsilat.IsVisible = false;
            PnlOdeme.IsVisible = false;
            PnlMasraf.IsVisible = false;
            MasrafList.IsVisible = false;
            datacek(gelendeger);
        }
        private async void datacek(AktarimModel gelendeger)
        {
            switch (gelendeger.Aktarim_IslemKodu)
            {
                #region Tahsilat
                case 5:
                    //tahsilat
                    PnlTahsilat.IsVisible = true;
                    var TahsilatCek = await LocalSQL<TahsilatFatModel>.GETLISTALL();
                    var TahsilatTekbilgi = TahsilatCek.Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();

                    if (TahsilatTekbilgi.Count > 0)
                    {

                        var BulunanTahsilatYontemi = Bul.TahsilattanOdemeYontemiBul(TahsilatTekbilgi[0]);
                        LblTahsilatYontem.Text = BulunanTahsilatYontemi.Odeme_Hesap_Ismi;

                        LblTahsilatTutar.Text = TahsilatTekbilgi[0].fat_meblag.ToString();
                        LblTahsilatVade.Text = TahsilatTekbilgi[0].fat_vade_tarihi.ToString("dd-MM-yyyy");
                        LblTahsilatAciklama.Text = TahsilatTekbilgi[0].fat_aciklama;
                    }




                    break;
                #endregion
                #region Odeme
                case 6:
                    //odeme
                    PnlOdeme.IsVisible = true;
                    var gelenodeme = await LocalSQL<OdemeFatModel>.GETLISTALL();
                    var tekgelenodeme = gelenodeme.Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();
                    if (tekgelenodeme.Count > 0)
                    {

                        LblOdemeOdenenTutar.Text = tekgelenodeme[0].Gosterge_fat_meblag;
                        LblOdemeAciklama.Text = tekgelenodeme[0].fat_aciklama;
                    }

                    break;
                #endregion
                #region Masraf
                case 7:
                    //masraf

                    PnlMasraf.IsVisible = true;
                    MasrafList.IsVisible = true;

                    var TumMasraflar = await LocalSQL<MasraflarFatModel>.GETLISTALL();
                    var GelenMasraflar = TumMasraflar.Where(x => x.fat_islem_baglanti == gelendeger.Aktarim_Baglanti_guid).ToList();
                    var default_doviz_sembol = DataClass._LSTMANAGER.KURLARLISTE[0].Kur_sembol;
                    if (GelenMasraflar.Count > 0)
                    {
                        foreach (var item in GelenMasraflar)
                        {
                            item.fat_doviz_adi = default_doviz_sembol;
                        }
                        MasrafList.ItemsSource = GelenMasraflar;
                        LblMasrafToplami.Text = GelenMasraflar.Sum(x => x.fat_meblag).ToString() + " " + default_doviz_sembol;
                    }







                    break;
                #endregion
                default:
                    await HelpME.MessageShow("Error", "Olagan disi bir hata olustu. lutfen IT Yoneticinize durumu bildiriniz...", "OK");
                    break;
            }
        }
    }
}
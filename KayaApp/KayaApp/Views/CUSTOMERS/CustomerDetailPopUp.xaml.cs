using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.CUSTOMERS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetailPopUp : PopupPage
    {
        LISTMANAGER _LSTMANAGER = DataClass._LSTMANAGER;
        public CustomerDetailPopUp(CustomerModel gelenCustomerModel)
        {
            InitializeComponent();
            try
            {
                var sektor = _LSTMANAGER.STOK_SEKTORLARI_LIST.Where(X => X.sktr_kod == gelenCustomerModel.cari_sektor_kodu).FirstOrDefault();

                if (sektor != null)
                {
                    gelenCustomerModel.cari_sektor_ismi = sektor.sktr_ismi;
                }

                var bolge = _LSTMANAGER.CARI_HESAP_BOLGELERI.Where(X => X.bol_kod == gelenCustomerModel.cari_bolge_kodu).FirstOrDefault();
                if (bolge != null)
                {
                    gelenCustomerModel.cari_bolge_ismi = bolge.bol_ismi;
                }

                var grup = _LSTMANAGER.CARI_HESAP_GRUPLARI.Where(X => X.crg_kod == gelenCustomerModel.cari_grup_kodu).FirstOrDefault();
                if (grup != null)
                {
                    gelenCustomerModel.cari_grup_ismi = grup.crg_isim;
                }

                var temsilci = _LSTMANAGER.CARI_PERSONEL_TANIMLARI_LIST.Where(X => X.cari_per_kod == gelenCustomerModel.cari_temsilci_kodu).FirstOrDefault();
                if (temsilci != null)
                {
                    gelenCustomerModel.cari_temsilci_ismi = temsilci.cari_per_adi;
                }

                var Kurlar = _LSTMANAGER.KurIsimleriFullKurus;

                var para1 = Kurlar.Where(X => X.KUR_NUMARASI == gelenCustomerModel.cari_doviz1).FirstOrDefault();
                if (para1 != null)
                {
                    gelenCustomerModel.cari_dovizName1 = para1.KUR_ISMI;
                    cari_doviz1.Text = gelenCustomerModel.cari_dovizName1.ToString();
                }

                var para2 = Kurlar.Where(X => X.KUR_NUMARASI == gelenCustomerModel.cari_doviz2).FirstOrDefault();
                if (para2 != null)
                {
                    gelenCustomerModel.cari_dovizName2 = para2.KUR_ISMI;
                    cari_doviz2.Text = gelenCustomerModel.cari_dovizName2.ToString();
                }

                var para3 = Kurlar.Where(X => X.KUR_NUMARASI == gelenCustomerModel.cari_doviz3).FirstOrDefault();
                if (para3 != null)
                {
                    gelenCustomerModel.cari_dovizName3 = para3.KUR_ISMI;
                    cari_doviz3.Text = gelenCustomerModel.cari_dovizName3.ToString();
                }

                cari_sektor_ismi.Text = gelenCustomerModel.cari_sektor_ismi;
                cari_bolge_ismi.Text = gelenCustomerModel.cari_bolge_ismi;
                cari_grup_ismi.Text = gelenCustomerModel.cari_grup_ismi;
                cari_temsilci_ismi.Text = gelenCustomerModel.cari_temsilci_ismi;
                cari_vdaire_adi.Text = gelenCustomerModel.cari_vdaire_adi;
                cari_vdaire_no.Text = gelenCustomerModel.cari_vdaire_no;
                cari_VergiKimlikNo.Text = gelenCustomerModel.cari_VergiKimlikNo;
                cari_wwwadresi.Text = gelenCustomerModel.cari_wwwadresi;
                cari_EMail.Text = gelenCustomerModel.cari_EMail;

            }
            catch (Exception ex)
            {

                HelpME.MessageShow("Stock Info Error", ex.Message, "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await HelpME.PopKapat();
        }
    }
}
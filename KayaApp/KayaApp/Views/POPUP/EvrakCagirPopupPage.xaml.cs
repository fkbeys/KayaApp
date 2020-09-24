using KayaApp.ViewModels;
using KayaApp.Views.SALES;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.POPUP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvrakCagirPopupPage : PopupPage
    {
        public EvrakCagirPopupPage(object bindingcontext)
        {
            InitializeComponent();
            BindingContext = bindingcontext;

            try
            {
                if (BindingContext == (AlisVM)bindingcontext)
                {
                    BtnPaket.IsVisible = false;
                    BtnSiparisEvrak.Text = "Alınan Siparişler";
                    BtnSiparisSatir.Text = "Alınan Sipariş Satır";
                }
            }
            catch (Exception)
            {

               
            }
            

            StokPaketleriList.IsVisible = false;
            SipariSatirlariList.IsVisible = false;
            SipariEvraklariList.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            StokPaketleriList.IsVisible = true;
            SipariSatirlariList.IsVisible = false;
            SipariEvraklariList.IsVisible = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            StokPaketleriList.IsVisible = false;
            SipariSatirlariList.IsVisible = true;
            SipariEvraklariList.IsVisible = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            StokPaketleriList.IsVisible = false;
            SipariSatirlariList.IsVisible = false;
            SipariEvraklariList.IsVisible = true;
        }
    }
}
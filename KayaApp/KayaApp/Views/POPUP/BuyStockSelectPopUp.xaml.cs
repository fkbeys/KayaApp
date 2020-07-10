using Android.Content;
using KayaApp.Helpers;
using KayaApp.Views.SALES;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.POPUP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyStockSelectPopUp : PopupPage
    {
        public BuyStockSelectPopUp(object VMNAME)
        {
            InitializeComponent();

            try
            {
                BindingContext = VMNAME;
            }
            catch (Exception ex)
            {

                Hatamesaji("Instance stock hata", "Hata:" + ex.Message);
            } 
    }
        private async void Hatamesaji(string baslik, string mesaj)
        {
            await HelpME.MessageShow(baslik, mesaj, "OK");
        }
    }
}
using KayaApp.Helpers;
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
            StocklistSade.IsVisible = false;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (StocklistMain.IsVisible)
            {
                StocklistMain.IsVisible = false;
                StocklistSade.IsVisible = true;
            }
            else
            {
                StocklistMain.IsVisible = true;
                StocklistSade.IsVisible = false;
            }

        }
    }
}
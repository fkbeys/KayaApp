using KayaApp.Helpers;
using KayaApp.Views.SIPARISLER;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.ORDERS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SiparislerMenuPage : PopupPage
    {
        public SiparislerMenuPage()
        {
            InitializeComponent();
        }

     
        private async void BtnAlinanSiparis_Clicked(object sender, EventArgs e)
        {
            await HelpME.PopKapat(); 
            await Application.Current.MainPage.Navigation.PushAsync(new NormalAlinanSiparisPage());
        }

        private async void BtnProformaAlinanSip_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}
using KayaApp.Helpers;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.REPORT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportMenu : PopupPage
    {
        public ReportMenu()
        {
            InitializeComponent();
        }

       

        private  void BtnAktarimMerkezi_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync((new AktarimMerkezi()));
           // await HelpME.SayfaAc(new AktarimMerkezi());
        }
    }
}
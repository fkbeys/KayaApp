using KayaApp.Helpers;
using KayaApp.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.STOCKS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockDetailPopUp : PopupPage
    {
        public StockDetailPopUp(StockModel GelenStokModel)
        {
            InitializeComponent();
            if (GelenStokModel != null)
            {
                sto_kisa_ismi.Text = GelenStokModel.sto_kisa_ismi;
                sto_anagrup_ismi.Text = GelenStokModel.sto_anagrup_ismi;
                sto_altgrup_ismi.Text = GelenStokModel.sto_altgrup_ismi;
                sto_kategori_ismi.Text = GelenStokModel.sto_kategori_ismi;
                sto_uretici_ismi.Text = GelenStokModel.sto_uretici_ismi;
                sto_sektor_ismi.Text = GelenStokModel.sto_sektor_ismi;
                sto_reyon_ismi.Text = GelenStokModel.sto_reyon_ismi;
                sto_ambalaj_ismi.Text = GelenStokModel.sto_ambalaj_ismi;
                sto_marka_ismi.Text = GelenStokModel.sto_marka_ismi;
                sto_beden_ismi.Text = GelenStokModel.sto_beden_ismi;
                sto_renk_ismi.Text = GelenStokModel.sto_renk_ismi;
                sto_model_ismi.Text = GelenStokModel.sto_model_ismi;
                sto_hammadde_ismi.Text = GelenStokModel.sto_hammadde_ismi;
            }
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
        }
        protected  override bool OnBackButtonPressed()
        {
              HelpME.PopKapat();
           
            return base.OnBackButtonPressed();
        }
    }
}
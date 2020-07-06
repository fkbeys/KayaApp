using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KayaApp.Helpers
{
    public static class HelpME
    {
        public static async Task NavigateTO(ContentPage SSS)
        {
            await Application.Current.MainPage.Navigation.PushAsync(SSS);
        }
        public static async Task MessageShow(string header, string message, string okbutton)
        {
            await Application.Current.MainPage.DisplayAlert(header, message, okbutton);

        }

        public static async Task SayfaAc(ContentPage sayfaC)
        {
            await Application.Current.MainPage.Navigation.PushAsync(sayfaC);


        }
        public static async Task SayfaKapat()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        public static async Task PopAc(PopupPage sayfa)
        {

            await Application.Current.MainPage.Navigation.PushPopupAsync(sayfa, true);
        }
        public static async Task PopKapat()
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
        }
    }
}
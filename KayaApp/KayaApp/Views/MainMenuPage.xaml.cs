using KayaApp.Helpers;
using KayaApp.Views.CUSTOMERS;
using KayaApp.Views.REPORT;
using KayaApp.Views.SALES;
using KayaApp.Views.STOCKS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {

        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            //   await HelpME.MessageShow("bilgi", DataClass._LSTMANAGER.ACTIVEUSER.USERS_NAME, "okk");
            await HelpME.MessageShow("bilgi", GetData.DataClass._LSTMANAGER.Kasalar[0].kas_isim, "okk");

        }

        private async void BtnStock_Clicked(object sender, System.EventArgs e)
        {
            //await BtnStock.ScaleTo(0.975, 200, Easing.Linear);
            //await BtnStock.ScaleTo(1, 200, Easing.Linear);
            await HelpME.SayfaAc(new StockListPage());
        }

        private async void BtnCustomers_Clicked(object sender, System.EventArgs e)
        {
            //await BtnCustomers.ScaleTo(0.975, 200, Easing.Linear);
            //await BtnCustomers.ScaleTo(1, 200, Easing.Linear);
            await HelpME.SayfaAc(new CustomerListPage());
        }

        private async void BtnSalesInvoice_Clicked(object sender, System.EventArgs e)
        {
            //await BtnSalesInvoice.ScaleTo(0.975, 200, Easing.Linear);
            //await BtnSalesInvoice.ScaleTo(1, 200, Easing.Linear); 
            await Application.Current.MainPage.Navigation.PushAsync(new SatisFaturasiPage());
        }

        private async void BtnReports_Clicked(object sender, System.EventArgs e)
        {
            await HelpME.SayfaAc(new ReportMenu());
        }
    }
}
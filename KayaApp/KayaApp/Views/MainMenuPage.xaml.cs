using KayaApp.Helpers;
using KayaApp.Views.CUSTOMERS;
using KayaApp.Views.DEPOLAR;
using KayaApp.Views.FINANS;
using KayaApp.Views.ORDERS;
using KayaApp.Views.PURCHASE;
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
            await BtnStock.ScaleTo(0.975, 200, Easing.Linear);
            await BtnStock.ScaleTo(1, 200, Easing.Linear);
            await HelpME.SayfaAc(new StockListPage());
        }

        private async void BtnCustomers_Clicked(object sender, System.EventArgs e)
        {
             await BtnCustomers.ScaleTo(0.975, 200, Easing.Linear);
             await BtnCustomers.ScaleTo(1, 200, Easing.Linear);
            await HelpME.SayfaAc(new CustomerListPage());
        }

        private async void BtnSalesInvoice_Clicked(object sender, System.EventArgs e)
        {
            await BtnSalesInvoice.ScaleTo(0.975, 200, Easing.Linear);
            await BtnSalesInvoice.ScaleTo(1, 200, Easing.Linear); 
            await Application.Current.MainPage.Navigation.PushAsync(new SatisFaturasiPage());
        }

        private async void BtnReports_Clicked(object sender, System.EventArgs e)
        {
             await HelpME.SayfaAc(new ReportMenu());
            //await HelpME.PopAc(new ReportMenu());
            //await HelpME.PopKapat()
        }

        private async void BtnPurchaseInvoice_Clicked(object sender, System.EventArgs e)
        {
            await BtnPurchaseInvoice.ScaleTo(0.975, 200, Easing.Linear);
            await BtnPurchaseInvoice.ScaleTo(1, 200, Easing.Linear);
            await Application.Current.MainPage.Navigation.PushAsync(new AlisFaturasiPage());
        }

        private async void BtnOrders_Clicked(object sender, System.EventArgs e)
        {
            await HelpME.PopAc(new SiparislerMenuPage());
        }

        private async void BtnWareHouse_Clicked(object sender, System.EventArgs e)
        {
            await HelpME.PopAc(new DepolarMenuPage());
        }

        private async void BtnChash_Clicked(object sender, System.EventArgs e)
        {
            await HelpME.PopAc(new FinansMenuPage());
            
        }
    }
}
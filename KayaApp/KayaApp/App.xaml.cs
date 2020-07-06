using KayaApp.Views;
using Xamarin.Forms;

namespace KayaApp
{
    public partial class App : Application
    {
        public static string databaselocation = string.Empty;

        public App(string dblocation)
        {
            InitializeComponent();
            databaselocation = dblocation;
            MainPage = new NavigationPage(new LoginPage());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

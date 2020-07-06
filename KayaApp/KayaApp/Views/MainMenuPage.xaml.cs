
using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.ViewModels;
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
             await HelpME.MessageShow("bilgi", DataClass._LSTMANAGER.ACTIVEUSER.USERS_NAME, "okk");
            await HelpME.MessageShow("bilgi", LoginVM._LSTMANAGER.ACTIVEUSER.USERS_NAME, "okk");

        }
    }
}
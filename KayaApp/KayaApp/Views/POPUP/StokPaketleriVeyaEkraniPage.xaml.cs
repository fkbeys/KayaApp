using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.POPUP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StokPaketleriVeyaEkraniPage : PopupPage
    {
        public StokPaketleriVeyaEkraniPage(object gonderenbindingcontext)
        {
            InitializeComponent();
            BindingContext = gonderenbindingcontext;
        }
    }
}
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.POPUP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockADDNEW : PopupPage
    {
        public StockADDNEW(object GelenVM)
        {
            InitializeComponent();
            BindingContext = GelenVM;
        }
    }
}
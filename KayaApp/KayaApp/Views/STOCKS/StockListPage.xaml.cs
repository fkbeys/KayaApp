using KayaApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.STOCKS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockListPage : ContentPage
    {
        ShowDataVM showDataVM = new ShowDataVM();
        public StockListPage()
        {
            InitializeComponent();
            BindingContext = showDataVM;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
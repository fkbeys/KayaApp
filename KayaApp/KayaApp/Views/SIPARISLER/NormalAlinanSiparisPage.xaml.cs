using KayaApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.SIPARISLER
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalAlinanSiparisPage : TabbedPage
    {
        public static NormalSiparislerVM NormalSiparisVMZ;
        public NormalAlinanSiparisPage()
        {
            InitializeComponent();
            BindingContext = NormalSiparisVMZ = new NormalSiparislerVM();

            if (NormalSiparisVMZ.SelectedCustomerModel.cari_kod == "")
            {
                NormalSiparisVMZ.BtnCariGoster.Execute(this);
            }
        }
    }
}
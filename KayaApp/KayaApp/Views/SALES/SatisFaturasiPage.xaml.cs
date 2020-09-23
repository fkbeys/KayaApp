using KayaApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.SALES
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SatisFaturasiPage : TabbedPage
    {
        public static SatisVM SATVMZ;
        public SatisFaturasiPage()
        {
            InitializeComponent();

            BindingContext = SATVMZ = new SatisVM();

            if (SATVMZ.SelectedCustomerModel.cari_kod == "")
            {
                SATVMZ.BtnCariGoster.Execute(this);
            }
        }
    }
}
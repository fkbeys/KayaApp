
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.CUSTOMERS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerAddPage : ContentPage
    {
        public static CustomerAddVM CustomerAddVMInstance;
        public CustomerAddPage()
        {
            InitializeComponent();
            BindingContext = CustomerAddVMInstance = new CustomerAddVM();
        }
    }
}
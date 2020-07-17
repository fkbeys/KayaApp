using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.REPORT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AktarimMerkezi : TabbedPage
    {
        AktarimVM AktarimVmzz;
        public AktarimMerkezi()
        {
            InitializeComponent();
            BindingContext = AktarimVmzz = new AktarimVM();
        }
    }
}
using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: Application(UsesCleartextTraffic = true)]
[assembly: ExportFont("RS.ttf", Alias = "MyAwesomeCustomFont")]
[assembly: ExportFont("materialdesignicons-webfont.ttf", Alias = "FontAwsome")]
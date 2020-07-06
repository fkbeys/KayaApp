
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using FFImageLoading;
using FFImageLoading.Forms.Platform;
using System.IO;

namespace KayaApp.Droid
{
    [Activity(Label = "KayaApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region  customstart
            //popup
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            //-----------------------------------------------------------------------------

            //barcode
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            //-----------------------------------------------------------------------------

            //toast message and progress bar plugin
            UserDialogs.Init(this);
            //-----------------------------------------------------------------------------

            //FF IMAGE
            Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            CachedImageRenderer.Init(enableFastRenderer: true);
            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
            };
            ImageService.Instance.Initialize(config);
            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
            //-----------------------------------------------------------------------------

            //database connection string and name
            string dbname = "db.sqlite-mikronerp";
            string folderpathforANDROID = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string constringANDROID = Path.Combine(folderpathforANDROID, dbname);
            //-----------------------------------------------------------------------------
            #endregion


            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App(constringANDROID));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

using Android.App;
using Android.Support.V7.App;

namespace KayaApp.Droid
{
    [Activity(Icon = "@mipmap/icon", Theme = "@style/MyScreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}
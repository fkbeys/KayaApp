using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace KayaApp.iOS.CustomRenderer
{
    public class KayaEntryIOS : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                e.OldElement.Text = e.OldElement.ToString().Replace("", ".");
                e.NewElement.Text = e.NewElement.ToString().Replace("", ".");
            }

        }
    }
}
using Android.Graphics.Drawables;
using Android.Text.Method;
using KayaApp.CustomRenderer;
using KayaApp.Droid.CustomRenderer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(KayaEntry), typeof(KayaEntryDroid))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace KayaApp.Droid.CustomRenderer
{
    [Obsolete]
    public class KayaEntryDroid : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                this.Control.KeyListener = DigitsKeyListener.GetInstance(true, true); // I know this is deprecated, but haven't had time to test the code without this line, I assume it will work without
                this.Control.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagDecimal;
            }



            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(30f);
                // gradientDrawable.SetStroke(1, Android.Graphics.Color.Gray);


                gradientDrawable.SetColor(Android.Graphics.Color.LightGray);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(5, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);

            }
        }


    }
}
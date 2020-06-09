using Android.Content;
using MedicalShredApp.Controls;
using MedicalShredApp.Droid.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace MedicalShredApp.Droid.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var view = (ExtendedEntry)Element;


                if (!view.HasBorder)
                {
                    Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
        }
    }
}

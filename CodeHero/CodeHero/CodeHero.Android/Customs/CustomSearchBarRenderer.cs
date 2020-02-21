using Android.Content;
using Android.Widget;
using CodeHero.Customs;
using CodeHero.Droid.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace CodeHero.Droid.Customs
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
               
                int searchIconId = Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                var searchViewIcon = Control.FindViewById<ImageView>(searchIconId);
                searchViewIcon.SetImageDrawable(null);
            }
        }
    }
}
using Android.Content;
using Android.OS;

namespace System.Maui
{
    public static class FormsMaterial
    {
        public static void Init(Context context, Bundle bundle)
        {
			// my only purpose is to exist so when called
			// this dll doesn't get removed

			VisualMarker.RegisterMaterial();
        }
    }
}
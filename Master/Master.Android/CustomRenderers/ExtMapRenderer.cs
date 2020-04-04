
using Android.Gms.Maps;
using Master.CustomControls;
using Master.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtMapControl), typeof(ExtMapRenderer))]

namespace Master.Droid.CustomRenderers
{
    /// <summary>
    /// Renderer for the xamarin map.
    /// Enable user to get a position by taping on the map.
    /// </summary>
    [System.Obsolete]
    public class ExtMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        // We use a native google map for Android
        private GoogleMap _map;
 
        //public void OnMapReady(GoogleMap googleMap)
        //{
        //    _map = googleMap;
 
        //    if (_map != null)
        //        _map.MapClick += googleMap_MapClick;
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        //{
        //    if (_map != null)
        //        _map.MapClick -= googleMap_MapClick;

        //    base.OnElementChanged(e);

        //    if (Control != null)
        //        ((MapView)Control).GetMapAsync(this);
        //}

        private void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            ((ExtMapControl)Element).OnTap(new Position(e.Point.Latitude, e.Point.Longitude));
        }
    }
}

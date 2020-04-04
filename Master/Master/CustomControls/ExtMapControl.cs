using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Master.CustomControls
{
    public class ExtMapControl : Map
    {
        public event EventHandler<MapTapEventArgs> Tapped;
        public ExtMapControl()
        {

        }
        public ExtMapControl(MapSpan region)
            : base(region)
        {

        }

        public void OnTap(Position coordinate)
        {
            OnTap(new MapTapEventArgs { Position = coordinate });
        }

        protected virtual void OnTap(MapTapEventArgs e)
        {
            var handler = Tapped;

            if (handler != null)
                handler(this, e);
        }
    }
    public class MapTapEventArgs : EventArgs
    {
        public Position Position { get; set; }
    }
}

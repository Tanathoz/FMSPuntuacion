using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace FMSPuntuacion.Controls
{
    public class AdBaner: View
    {
        public enum Sizes { Standardbanner, LargeBanner, MediumRectangle, FullBanner, Leaderboard, SmartBannerPortrait }
        public Sizes Size { get; set; }
        public string AdUnitID { get; set; }

        public AdBaner()
        {
            this.BackgroundColor = Color.White;
            //AdUnitID = adUnitID;
        }
    }
}

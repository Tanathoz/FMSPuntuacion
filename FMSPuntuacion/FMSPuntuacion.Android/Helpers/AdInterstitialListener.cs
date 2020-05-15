using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Gms.Ads;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FMSPuntuacion.Droid.Helpers
{
    public class AdInterstitialListener: AdListener
    {
        readonly InterstitialAd _ad;

        public AdInterstitialListener(InterstitialAd ad)
        {
            _ad = ad;
        }

        public override void OnAdLoaded()
        {
            base.OnAdLoaded();

            if (_ad.IsLoaded)
                _ad.Show();
        }

    }
}
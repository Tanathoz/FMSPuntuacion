using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FMSPuntuacion.Controls;
using FMSPuntuacion.Droid.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AdViewVideoInter))]
namespace FMSPuntuacion.Droid.Helpers
{
    public class AdViewVideoInter : IAdVideoInterstitial
    {

        InterstitialAd interstitialAd;

        public void ShowAdVideo(string adUnit)
        {
            var context = Application.Context;
            interstitialAd = new InterstitialAd(context);
            interstitialAd.AdUnitId = adUnit;

            var listener = new AdInterVideoListener(interstitialAd);
            listener.OnAdLoaded();
            interstitialAd.AdListener = listener;
            var requestBuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestBuilder.Build());
        }
    }
}
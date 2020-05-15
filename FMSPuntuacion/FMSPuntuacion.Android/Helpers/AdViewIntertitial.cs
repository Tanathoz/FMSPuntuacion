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
using FMSPuntuacion.Droid.Helpers;
using FMSPuntuacion.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(AdViewIntertitial))]
namespace FMSPuntuacion.Droid.Helpers
{
    public class AdViewIntertitial : IAdIntestitial
    {
        InterstitialAd interstitialAd;

        public void showAd(string adUnit)
        {
            var context = Application.Context;
            interstitialAd = new InterstitialAd(context);
            interstitialAd.AdUnitId = adUnit;
            var intlistener = new AdInterstitialListener(interstitialAd);
            intlistener.OnAdLoaded();
            interstitialAd.AdListener = intlistener;

            var requestBuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestBuilder.Build());
        }



        //public AdViewIntertitial()
        //{
        //    interstitialAd = new InterstitialAd(Android.App.Application.Context);
        //    interstitialAd.AdUnitId = "ca-app-pub-3940256099942544/1033173712";
        //    LoadAd();
        //}

        //void LoadAd()
        //{
        //    var requestbuilder = new AdRequest.Builder();
        //    interstitialAd.LoadAd(requestbuilder.Build());
        //}

        //public void showAd()
        //{
        //    if (interstitialAd.IsLoaded)
        //    {
        //        interstitialAd.Show();
        //    }
        //    LoadAd();
        //}
    }
}
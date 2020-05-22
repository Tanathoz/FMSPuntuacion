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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FMSPuntuacion.Controls.AdControlView), typeof(FMSPuntuacion.Droid.Helpers.AdViewRenderer))]
namespace FMSPuntuacion.Droid.Helpers
{
    public class AdViewRenderer: ViewRenderer <Controls.AdControlView, AdView>
    {
        string adUnit = "ca-app-pub-3940256099942544/6300978111";
        AdSize adSize = AdSize.Banner;
        AdView adView;

        AdView CreateAdView()
        {
            if ( adView != null)
            {
                return adView;
            }

            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnit;
            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;
            adView.LoadAd(new AdRequest.Builder().Build());
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
            if ( Control == null)
            {
                CreateAdView();
                SetNativeControl(adView);
            }
        }
    }
}
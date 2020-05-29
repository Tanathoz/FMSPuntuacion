using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FMSPuntuacion.Controls;
using FMSPuntuacion.Droid.Helpers;

[assembly: ExportRenderer(typeof(AdBaner), typeof(AdBannerView))]
namespace FMSPuntuacion.Droid.Helpers
{
    public class AdBannerView: ViewRenderer
    {

        //public static void Init()
        //{
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        //{
        //    base.OnElementChanged(e);
        //    //convert the element to the control we want
        //    var adMobElement = Element as AdBaner;

        //    if ((adMobElement != null) && (e.OldElement == null))
        //    {
        //        var ad = new AdView(Context);
        //        ad.AdSize = AdSize.Banner;
        //        ad.AdUnitId = adMobElement.AdUnitID;
        //        var requestbuilder = new AdRequest.Builder();
        //        ad.LoadAd(requestbuilder.Build());
        //        SetNativeControl(ad);
        //    }
        //}


        //Context context;
        //public AdBannerView(Context _context) : base(_context)
        //{
        //    context = _context;
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var adView = new AdView(Context);
                switch ((Element as AdBaner).Size)
                {
                    case AdBaner.Sizes.Standardbanner:
                        adView.AdSize = AdSize.Banner;
                        break;
                    case AdBaner.Sizes.LargeBanner:
                        adView.AdSize = AdSize.LargeBanner;
                        break;
                    case AdBaner.Sizes.MediumRectangle:
                        adView.AdSize = AdSize.MediumRectangle;
                        break;
                    case AdBaner.Sizes.FullBanner:
                        adView.AdSize = AdSize.FullBanner;
                        break;
                    case AdBaner.Sizes.Leaderboard:
                        adView.AdSize = AdSize.Leaderboard;
                        break;
                    case AdBaner.Sizes.SmartBannerPortrait:
                        adView.AdSize = AdSize.SmartBanner;
                        break;
                    default:
                        adView.AdSize = AdSize.Banner;
                        break;
                }
                // TODO: change this id to your admob id  
                adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
                var requestbuilder = new AdRequest.Builder();
                adView.LoadAd(requestbuilder.Build());
                SetNativeControl(adView);
            }
        }

    }
}
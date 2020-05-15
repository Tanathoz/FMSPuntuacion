using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Gms.Ads.Reward;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FMSPuntuacion.Droid.Helpers
{
    public class AdInterVideoListener : AdListener, IRewardedVideoAdListener
    {

        readonly InterstitialAd _ad;

        public AdInterVideoListener(InterstitialAd ad)
        {
            _ad = ad;
            _ad.RewardedVideoAdLoaded += (o, e) => OnRewardedVideoAdLoaded();
            _ad.RewardedVideoAdClosed += (o, e) => OnRewardedVideoAdClosed();

        }


        public override void OnAdLoaded()
        {
            base.OnAdLoaded();
            if (_ad.IsLoaded)
            {
                _ad.Show();
            }

        }

        public override void OnAdFailedToLoad(int errorCode)
        {
            base.OnAdFailedToLoad(errorCode);
        }

        public void OnRewarded(IRewardItem reward)
        {
            throw new NotImplementedException();
        }

        public void OnRewardedVideoAdClosed()
        {
         
        }

        public void OnRewardedVideoAdFailedToLoad(int errorCode)
        {
            throw new NotImplementedException();
        }

        public void OnRewardedVideoAdLeftApplication()
        {
            throw new NotImplementedException();
        }

        public void OnRewardedVideoAdLoaded()
        {
            if (_ad.IsLoaded)
            {
                _ad.Show();
            }
        }

        public void OnRewardedVideoAdOpened()
        {
            throw new NotImplementedException();
        }

        public void OnRewardedVideoStarted()
        {
            throw new NotImplementedException();
        }
    }
}
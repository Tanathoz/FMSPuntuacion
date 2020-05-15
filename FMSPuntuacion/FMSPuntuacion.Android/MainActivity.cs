using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static FMSPuntuacion.Helpers.Settings;
using FMSPuntuacion.Helpers;
using Android.Gms.Ads;

namespace FMSPuntuacion.Droid
{
    [Activity(Theme = "@style/MainTheme",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance = null;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //var tema = FMSPuntuacion.Helpers.Settings.CurrentTheme();
            //switch (tema)
            //{
            //    case Tema.Spain:
            //        SetTheme(Resource.Style.SplashTheme);
            //        break;
            //    case Tema.Mexico:
            //        SetTheme(Resource.Style.MainTheme);
            //        break;
            //    default:
            //        SetTheme(Resource.Style.MainTheme);
            //        break;
            //}


                    base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            //Sample AdMob App ID: ca - app - pub - 3940256099942544~3347511713
            // MobileAds.Initialize(ApplicationContext, "ca-app-pub-3940256099942544/1033173712");
            //MobileAds.Initialize(ApplicationContext, "ca-app-pub-6499029686626513~8551506037");
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            //  this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            LoadApplication(new App());
            Instance = this;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
using FMSPuntuacion.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Opciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class About : ContentPage
	{
        IAdVideoInterstitial adVideo;
        public About ()
		{
			InitializeComponent ();
            adVideo = DependencyService.Get<IAdVideoInterstitial>();
        }

        public void salir(object sender, EventArgs args)
        {
            adVideo.ShowAdVideo("ca-app-pub-3940256099942544/5224354917");         
        }
    }
}
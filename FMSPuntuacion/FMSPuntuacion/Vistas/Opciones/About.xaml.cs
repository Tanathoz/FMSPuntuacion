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
        int contandor;
        public About ()
		{
			InitializeComponent ();
            adVideo = DependencyService.Get<IAdVideoInterstitial>();
            contandor = 0;
        }

        public async void salir(object sender, EventArgs args)
        {
            adVideo.ShowAdVideo("ca-app-pub-3940256099942544/5224354917");
            contandor++;
            if (contandor == 3)
            {
               await Application.Current.MainPage.DisplayAlert("Gracias", "Eres un gran amigo", "OK");
            }
            else if (contandor == 10)
            {
               await Application.Current.MainPage.DisplayAlert("Excelente", "Eres el mejor maldito support que se ha parido", "OK");
            }
        }
    }
}
using FMSPuntuacion.Models;
using FMSPuntuacion.Vistas.Temporada4;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Replica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NombresInicio : ContentPage
	{
		public NombresInicio ()
		{
			InitializeComponent ();
		}

        async void IniciarMinutos(object sender, EventArgs args)
        {
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
            };
            var Minutos = new Minutos();
            Minutos.BindingContext = valores;
            if (valores.player1 == null || valores.player2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga Nombre", "OK");
            }
            else
            {
                await Navigation.PushAsync(Minutos);
            }
        }

        async void IniciarPatrones(object sender, EventArgs args)
        {
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
            };
            var Patrones = new CuatroX4();
            Patrones.BindingContext = valores;
            if (valores.player1 == null || valores.player2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga Nombre", "OK");
            }
            else
            {
                await Navigation.PushAsync(Patrones);
            }
        }

        async void IniciarFMS(object sender, EventArgs args)
        {
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text
            };
            var FormatoFMS = new NewEasy();
            FormatoFMS.BindingContext = valores;
            if (valores.player1 == null || valores.player2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga Nombre", "OK");
            }
            else
            {               
                await Navigation.PushAsync(FormatoFMS);
            }
        }

	}
}
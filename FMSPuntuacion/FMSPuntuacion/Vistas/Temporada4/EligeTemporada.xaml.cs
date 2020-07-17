using FMSPuntuacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Temporada4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EligeTemporada : ContentPage
    {
        public EligeTemporada()
        {
            InitializeComponent();
        }

        async void IniciarFMS(object sender, EventArgs args)
        {
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text
            };
            var FormatoFMS = new EasyMode();
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

        async void IniciarFMS2020(object sender, EventArgs args)
        {
            var valores = new NewCriterios
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
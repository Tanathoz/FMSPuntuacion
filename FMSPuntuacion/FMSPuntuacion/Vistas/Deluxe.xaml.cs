using System;
using FMSPuntuacion.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Deluxe : ContentPage
	{
        public int suma = 0;
        public int sumaP2 = 0;
        public int sumaVuelta2 = 0;
        public int sumaVuelta2P2 = 0;
        public Deluxe ()
		{
			InitializeComponent ();
		}

        public void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";

            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && patron9.SelectedIndex > -1 &&
                patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToInt32(patron1.Items[patron1.SelectedIndex]) + Convert.ToInt32(patron2.Items[patron2.SelectedIndex]) + Convert.ToInt32(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToInt32(patron7.Items[patron7.SelectedIndex]) + Convert.ToInt32(patron8.Items[patron8.SelectedIndex]) + Convert.ToInt32(patron9.Items[patron9.SelectedIndex]) +
                                    Convert.ToInt32(patron10.Items[patron10.SelectedIndex]) + Convert.ToInt32(patron11.Items[patron11.SelectedIndex]) + Convert.ToInt32(patron12.Items[patron12.SelectedIndex]) +
                                    Convert.ToInt32(patron13.Items[patron13.SelectedIndex]) + Convert.ToInt32(patron14.Items[patron14.SelectedIndex]) +
                                    Convert.ToInt32(escena.Items[escena.SelectedIndex]) + Convert.ToInt32(skill.Items[skill.SelectedIndex]) + Convert.ToInt32(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }

        }

        public void SumaPuntosP2(object sender, EventArgs e)
        {
            Total2.Text = "Total : ";
            if (patron4.SelectedIndex > -1 && patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && patron17.SelectedIndex > -1
                && patron18.SelectedIndex > -1 && patron19.SelectedIndex > -1 && patron20.SelectedIndex > -1 && patron21.SelectedIndex > -1 && patron22.SelectedIndex > -1 &&  escena2.SelectedIndex > -1 && skill2.SelectedIndex > -1 && flow2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToInt32(patron4.Items[patron4.SelectedIndex]) + Convert.ToInt32(patron5.Items[patron5.SelectedIndex]) + Convert.ToInt32(patron6.Items[patron6.SelectedIndex]) +
                    Convert.ToInt32(patron15.Items[patron15.SelectedIndex]) + Convert.ToInt32(patron16.Items[patron16.SelectedIndex]) + Convert.ToInt32(patron17.Items[patron17.SelectedIndex]) +
                    Convert.ToInt32(patron18.Items[patron18.SelectedIndex]) + Convert.ToInt32(patron19.Items[patron19.SelectedIndex]) + Convert.ToInt32(patron20.Items[patron20.SelectedIndex]) +
                    Convert.ToInt32(patron21.Items[patron21.SelectedIndex]) + Convert.ToInt32(patron22.Items[patron22.SelectedIndex]) +
                    Convert.ToInt32(escena2.Items[escena2.SelectedIndex]) + Convert.ToInt32(skill2.Items[skill2.SelectedIndex]) + Convert.ToInt32(flow2.Items[flow2.SelectedIndex]);
                Total2.Text += sumaP2.ToString();
            }
        }


        async void GuardarDeluxe(object sender, EventArgs e)
        {
            
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToInt32(SumaSangre.Text) + suma,
                sumaTotalP2 = Convert.ToInt32(SumaSangreP2.Text) + sumaP2,
                sumaDeluxeP1 = suma,
                sumaDeluxeP2 = sumaP2,
                respuestasP1 = Convert.ToInt32(RespuestaP1.Text),
                respuestasP2 = Convert.ToInt32(RespuestaP2.Text),
                suma = Convert.ToInt32(SumaEasy.Text),
                sumaP2 = Convert.ToInt32(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToInt32(HardMode.Text),
                sumaHardModep2 = Convert.ToInt32(HardModeP2.Text),
                sumaTematicaP1 = Convert.ToInt32(TematicaP1.Text),
                sumaTematicaP2 = Convert.ToInt32(TematicaP2.Text),
                sumaPersonajesP1 = Convert.ToInt32(PersonajesP1.Text),
                sumaPersonajesP2 = Convert.ToInt32(PersonajesP2.Text),
                sumaSangreP1 = Convert.ToInt32(SangreP1.Text),
                sumaSangreP2 = Convert.ToInt32(SangreP2.Text)

            };

            if ((valores.sumaTotalP1 - valores.sumaTotalP2) >= 5)
            {
                valores.ganador = Player1.Text;
                valores.replica = false;
            }
            else if ((valores.sumaTotalP2 - valores.sumaTotalP1) >= 5)
            {
                valores.ganador = Player2.Text;
                valores.replica = false;
            }
            else
            {
                valores.ganador = "Réplica, Diferencia de " + Math.Abs(valores.sumaTotalP1 - valores.sumaTotalP2) + " Puntos";
                valores.replica = true;
            }

            valores.lstCalificacionesP2.Add(sumaP2);
            var Resultado = new FMSPuntuacion.Vistas.Resultado();
            Resultado.BindingContext = valores;
            if (suma == 0 || sumaP2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");
            }
            else {
                await Navigation.PushAsync(Resultado);
            }        
        }
    }
}
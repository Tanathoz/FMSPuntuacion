using System;

using FMSPuntuacion.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tematica : ContentPage
	{
        public int suma = 0;
        public int sumaP2 = 0;
        public int sumaVuelta2 = 0;
        public int sumaVuelta2P2 = 0;
        public Tematica ()
		{
			InitializeComponent ();
		}

        public void SumaPuntosVuelta1P1(object sender, EventArgs e)
        {
            
            Total.Text = "Total :";
            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron4.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToInt32(patron1.Items[patron1.SelectedIndex]) + Convert.ToInt32(patron2.Items[patron2.SelectedIndex]) + Convert.ToInt32(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToInt32(patron4.Items[patron4.SelectedIndex]) + 
                                    Convert.ToInt32(escena.Items[escena.SelectedIndex]) + Convert.ToInt32(skill.Items[skill.SelectedIndex]) + Convert.ToInt32(flow.Items[flow.SelectedIndex]);

                Total.Text += suma.ToString();
            }
            
        }


        public void SumaPuntosVuelta2(object sender, EventArgs e)
        {
            Total.Text = "Total :";
            if (patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && escena2.SelectedIndex > -1 && skill2.SelectedIndex > -1 && flow2.SelectedIndex > -1)
            {
                sumaVuelta2 = Convert.ToInt32(patron5.Items[patron5.SelectedIndex]) + Convert.ToInt32(patron6.Items[patron6.SelectedIndex]) + Convert.ToInt32(patron7.Items[patron7.SelectedIndex]) +
                                    Convert.ToInt32(patron8.Items[patron8.SelectedIndex]) +
                                    Convert.ToInt32(escena2.Items[escena2.SelectedIndex]) + Convert.ToInt32(skill2.Items[skill2.SelectedIndex]) + Convert.ToInt32(flow2.Items[flow2.SelectedIndex]);
                sumaVuelta2 += suma;
                Total.Text += sumaVuelta2.ToString();
            }
        }

        public void SumaPuntosVuelta1P2(object sender, EventArgs e)
        {
            
            TotalP2.Text = "Total : ";
            if (patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1  && escena3.SelectedIndex > -1 && skill3.SelectedIndex > -1 && flow3.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToInt32(patron9.Items[patron9.SelectedIndex]) + Convert.ToInt32(patron10.Items[patron10.SelectedIndex]) + Convert.ToInt32(patron11.Items[patron11.SelectedIndex]) +
                    Convert.ToInt32(patron12.Items[patron12.SelectedIndex])  +
                    Convert.ToInt32(escena3.Items[escena3.SelectedIndex]) + Convert.ToInt32(skill3.Items[skill3.SelectedIndex]) + Convert.ToInt32(flow3.Items[flow3.SelectedIndex]);
                    TotalP2.Text += sumaP2.ToString();
            } 
        }

        public void SumaSegundaVuelta2P2(object sender, EventArgs e)
        {
            TotalP2.Text = "Total :";
            if (patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1 && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && escena4.SelectedIndex > -1 && skill4.SelectedIndex > -1 && flow4.SelectedIndex > -1)
            {
                sumaVuelta2P2 = Convert.ToInt32(patron13.Items[patron13.SelectedIndex]) + Convert.ToInt32(patron14.Items[patron14.SelectedIndex]) + Convert.ToInt32(patron15.Items[patron15.SelectedIndex]) +
                                   Convert.ToInt32(patron16.Items[patron16.SelectedIndex]) +
                                   Convert.ToInt32(escena4.Items[escena4.SelectedIndex]) + Convert.ToInt32(skill4.Items[skill4.SelectedIndex]) + Convert.ToInt32(flow4.Items[flow4.SelectedIndex]);
                sumaVuelta2P2 += sumaP2;
                TotalP2.Text += sumaVuelta2P2.ToString();
            }
        }

        async void GuardarTematica(object sender, EventArgs e)
        {
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToInt32(SumaHard.Text)+sumaVuelta2,
                sumaTotalP2 = Convert.ToInt32(SumaHardP2.Text)+sumaVuelta2P2,
                sumaTematicaP1 = sumaVuelta2,
                sumaTematicaP2 = sumaVuelta2P2,
                suma = Convert.ToInt32(SumaEasy.Text),
                sumaP2 = Convert.ToInt32(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToInt32(HardMode.Text),
                sumaHardModep2 = Convert.ToInt32(HardModeP2.Text)
            };
            valores.lstCalificacionesP2.Add(sumaVuelta2P2);
            var personajes = new Personajes();
            personajes.BindingContext = valores;

            if (sumaVuelta2 == 0 || sumaVuelta2P2 == 0)
            {
               await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");
            }
            else
            {
                await Navigation.PushAsync(personajes);
            }

            
        }
    }
}
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
	public partial class SangreNew : ContentPage
	{
        public double suma = 0;
        public double sumaP2 = 0;
        public double sumaVuelta2 = 0;
        public double sumaVuelta2P2 = 0;
        public int respuestaP1 = 0;
        public int respuestaP2 = 0;

        public SangreNew ()
		{
			InitializeComponent ();
		}

        public void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";

            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron4.SelectedIndex > -1 && patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToDouble(patron1.Items[patron1.SelectedIndex]) + Convert.ToDouble(patron2.Items[patron2.SelectedIndex]) + Convert.ToDouble(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToDouble(patron4.Items[patron4.SelectedIndex]) + Convert.ToDouble(patron5.Items[patron5.SelectedIndex]) + Convert.ToDouble(patron6.Items[patron6.SelectedIndex]) +
                                    Convert.ToDouble(escena.Items[escena.SelectedIndex]) + Convert.ToDouble(skill.Items[skill.SelectedIndex]) + Convert.ToDouble(flow.Items[flow.SelectedIndex]);
                Total.Text += suma.ToString();
            }

        }

        public void SumaPuntosP2(object sender, EventArgs e)
        {
            TotalP2.Text = "Total : ";
            respuestaP2 = 0;
            if (patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && escenaP2.SelectedIndex > -1 && skillP2.SelectedIndex > -1 && flowP2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToDouble(patron7.Items[patron7.SelectedIndex]) + Convert.ToDouble(patron8.Items[patron8.SelectedIndex]) + Convert.ToDouble(patron9.Items[patron9.SelectedIndex]) +
                    Convert.ToDouble(patron10.Items[patron10.SelectedIndex]) + Convert.ToDouble(patron11.Items[patron11.SelectedIndex]) + Convert.ToDouble(patron12.Items[patron12.SelectedIndex]) +
                    Convert.ToDouble(escenaP2.Items[escenaP2.SelectedIndex]) + Convert.ToDouble(skillP2.Items[skillP2.SelectedIndex]) + Convert.ToDouble(flowP2.Items[flowP2.SelectedIndex]);
                if (respuesta.Checked)
                    respuestaP2++;
                if (respuesta2.Checked)
                    respuestaP2++;
                if (respuesta3.Checked)
                    respuestaP2++;
                if (respuesta4.Checked)
                    respuestaP2++;
                if (respuesta5.Checked)
                    respuestaP2++;
                if (respuesta6.Checked)
                    respuestaP2++;
                TotalP2.Text += sumaP2.ToString() + "+" + respuestaP2;
            }
        }

        public void SumaPuntosP2Vuelta2(object sender, EventArgs e)
        {
            Total3.Text = "Total :";
            if (patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1 && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && patron17.SelectedIndex > -1 && patron18.SelectedIndex > -1 && escena3.SelectedIndex > -1 && skill3.SelectedIndex > -1 && flow3.SelectedIndex > -1)
            {
                sumaVuelta2P2 = Convert.ToDouble(patron13.Items[patron13.SelectedIndex]) + Convert.ToDouble(patron14.Items[patron14.SelectedIndex]) + Convert.ToDouble(patron15.Items[patron15.SelectedIndex]) +
                                    Convert.ToDouble(patron16.Items[patron16.SelectedIndex]) + Convert.ToDouble(patron17.Items[patron17.SelectedIndex]) + Convert.ToDouble(patron18.Items[patron18.SelectedIndex]) +
                                    Convert.ToDouble(escena3.Items[escena3.SelectedIndex]) + Convert.ToDouble(skill3.Items[skill3.SelectedIndex]) + Convert.ToDouble(flow3.Items[flow3.SelectedIndex]);
                Total3.Text += sumaVuelta2P2.ToString();
            }
        }

        public void SumaPuntosP1Vuelta2(object sender, EventArgs e)
        {
            Total4.Text = "Total :";
            respuestaP1 = 0;
            if (patron19.SelectedIndex > -1 && patron20.SelectedIndex > -1 && patron21.SelectedIndex > -1 && patron22.SelectedIndex > -1 && patron23.SelectedIndex > -1 && patron24.SelectedIndex > -1 && escena4.SelectedIndex > -1 && skill4.SelectedIndex > -1 && flow4.SelectedIndex > -1)
            {
                sumaVuelta2 = Convert.ToDouble(patron19.Items[patron19.SelectedIndex]) + Convert.ToDouble(patron20.Items[patron20.SelectedIndex]) + Convert.ToDouble(patron21.Items[patron21.SelectedIndex]) +
                                    Convert.ToDouble(patron22.Items[patron22.SelectedIndex]) + Convert.ToDouble(patron23.Items[patron23.SelectedIndex]) + Convert.ToDouble(patron24.Items[patron24.SelectedIndex]) +
                                    Convert.ToDouble(escena4.Items[escena4.SelectedIndex]) + Convert.ToDouble(skill4.Items[skill4.SelectedIndex]) + Convert.ToDouble(flow4.Items[flow4.SelectedIndex]);
                if (respuesta7.Checked)
                    respuestaP1++;
                if (respuesta8.Checked)
                    respuestaP1++;
                if (respuesta9.Checked)
                    respuestaP1++;
                if (respuesta10.Checked)
                    respuestaP1++;
                if (respuesta11.Checked)
                    respuestaP1++;
                if (respuesta12.Checked)
                    respuestaP1++;
                Total4.Text += sumaVuelta2.ToString() + "+" + respuestaP1;
            }
        }

        async void GuardarSangre(object sender, EventArgs e)
        {
            var valores = new NewCriterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToDouble(SumaPersonajes.Text) + suma + sumaVuelta2 + respuestaP1,
                sumaTotalP2 = Convert.ToDouble(SumaPersonajesP2.Text) + sumaP2 + sumaVuelta2P2 + respuestaP2,
                sumaSangreP1 = suma + sumaVuelta2 + respuestaP1,
                sumaSangreP2 = sumaP2 + sumaVuelta2P2 + respuestaP2,
                respuestasP1 = respuestaP1,
                respuestasP2 = respuestaP2,
                suma = Convert.ToDouble(SumaEasy.Text),
                sumaP2 = Convert.ToDouble(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToDouble(HardMode.Text),
                sumaHardModep2 = Convert.ToDouble(HardModeP2.Text),
                sumaTematicaP1 = Convert.ToDouble(TematicaP1.Text),
                sumaTematicaP2 = Convert.ToDouble(TematicaP2.Text),
                sumaPersonajesP1 = Convert.ToDouble(PersonajesP1.Text),
                sumaPersonajesP2 = Convert.ToDouble(PersonajesP2.Text)

            };
            var Deluxe = new RondaDeluxe();
            Deluxe.BindingContext = valores;
            if (suma == 0 || sumaP2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");              
            }
            else
            {
                await Navigation.PushAsync(Deluxe);
            }

        }



    }
}
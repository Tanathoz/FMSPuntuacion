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
	public partial class PersonajesNew : ContentPage
	{
        public double sumaPersonajes = 0;
        public double sumaPersonajesP2 = 0;
        public double respuestaP1 = 0;
        public double respuestaP2 = 0;

        public PersonajesNew ()
		{
			InitializeComponent ();
		}

        public void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";
            respuestaP1 = 0;
            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron4.SelectedIndex > -1 && patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                sumaPersonajes = Convert.ToDouble(patron1.Items[patron1.SelectedIndex]) + Convert.ToDouble(patron2.Items[patron2.SelectedIndex]) + Convert.ToDouble(patron3.Items[patron3.SelectedIndex]) +
                                 Convert.ToDouble(patron4.Items[patron4.SelectedIndex]) + Convert.ToDouble(patron5.Items[patron5.SelectedIndex]) + Convert.ToDouble(patron6.Items[patron6.SelectedIndex]) +
                                 Convert.ToDouble(patron7.Items[patron7.SelectedIndex]) + Convert.ToDouble(patron8.Items[patron8.SelectedIndex]) +
                                 Convert.ToDouble(escena.Items[escena.SelectedIndex]) + Convert.ToDouble(skill.Items[skill.SelectedIndex]) + Convert.ToDouble(flow.Items[flow.SelectedIndex]);

                if (respuesta.Checked)
                    respuestaP1++;
                if (respuesta2.Checked)
                    respuestaP1++;
                if (respuesta3.Checked)
                    respuestaP1++;
                if (respuesta4.Checked)
                    respuestaP1++;
                if (respuesta5.Checked)
                    respuestaP1++;
                if (respuesta6.Checked)
                    respuestaP1++;
                if (respuesta7.Checked)
                    respuestaP1++;
                if (respuesta8.Checked)
                    respuestaP1++;
                Total.Text += sumaPersonajes.ToString() + "+" + respuestaP1.ToString();
            }

        }


        public void SumaPuntosP2(object sender, EventArgs e)
        {
            TotalP2.Text = "Total: ";
            respuestaP2 = 0;
            if (patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1 && patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && escenaP2.SelectedIndex > -1 && skillP2.SelectedIndex > -1 && flowP2.SelectedIndex > -1)
            {
                sumaPersonajesP2 = Convert.ToDouble(patron13.Items[patron13.SelectedIndex]) + Convert.ToDouble(patron14.Items[patron14.SelectedIndex]) + Convert.ToDouble(patron9.Items[patron9.SelectedIndex]) +
                    Convert.ToDouble(patron10.Items[patron10.SelectedIndex]) + Convert.ToDouble(patron11.Items[patron11.SelectedIndex]) + Convert.ToDouble(patron12.Items[patron12.SelectedIndex]) +
                    Convert.ToDouble(patron15.Items[patron15.SelectedIndex]) + Convert.ToDouble(patron16.Items[patron16.SelectedIndex]) +
                    Convert.ToDouble(escenaP2.Items[escenaP2.SelectedIndex]) + Convert.ToDouble(skillP2.Items[skillP2.SelectedIndex]) + Convert.ToDouble(flowP2.Items[flowP2.SelectedIndex]);

                if (respuesta13.Checked)
                    respuestaP2++;
                if (respuesta14.Checked)
                    respuestaP2++;
                if (respuesta9.Checked)
                    respuestaP2++;
                if (respuesta10.Checked)
                    respuestaP2++;
                if (respuesta11.Checked)
                    respuestaP2++;
                if (respuesta12.Checked)
                    respuestaP2++;
                if (respuesta15.Checked)
                    respuestaP2++;
                if (respuesta16.Checked)
                    respuestaP2++;
                TotalP2.Text += sumaPersonajesP2.ToString() + "+" + respuestaP2;
            }
        }

        async void GuardarPersonajes(object sender, EventArgs e)
        {
            var valores = new NewCriterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToDouble(SumaTematica.Text) + sumaPersonajes + respuestaP1,
                sumaTotalP2 = Convert.ToDouble(SumaTematicaP2.Text) + sumaPersonajesP2 + respuestaP2,
                suma = Convert.ToDouble(SumaEasy.Text),
                sumaP2 = Convert.ToDouble(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToDouble(HardMode.Text),
                sumaHardModep2 = Convert.ToDouble(HardModeP2.Text),
                sumaTematicaP1 = Convert.ToDouble(TematicaP1.Text),
                sumaTematicaP2 = Convert.ToDouble(TematicaP2.Text),
                sumaPersonajesP1 = sumaPersonajes + respuestaP1,
                sumaPersonajesP2 = sumaPersonajesP2 + respuestaP2
            };
            var Sangre = new SangreNew();
            Sangre.BindingContext = valores;
            if (sumaPersonajes == 0 || sumaPersonajesP2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");
            }
            else
            {
                await Navigation.PushAsync(Sangre);
            }
        }
    }
}
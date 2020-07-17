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
    public partial class RondaDeluxe : ContentPage
    {
        public double suma = 0;
        public double sumaP2 = 0;
        public double sumaVuelta2 = 0;
        public double sumaVuelta2P2 = 0;

        public RondaDeluxe()
        {
            InitializeComponent();
        }

        public void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";

            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && patron9.SelectedIndex > -1 &&
                patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToDouble(patron1.Items[patron1.SelectedIndex]) + Convert.ToDouble(patron2.Items[patron2.SelectedIndex]) + Convert.ToDouble(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToDouble(patron7.Items[patron7.SelectedIndex]) + Convert.ToDouble(patron8.Items[patron8.SelectedIndex]) + Convert.ToDouble(patron9.Items[patron9.SelectedIndex]) +
                                    Convert.ToDouble(patron10.Items[patron10.SelectedIndex]) + Convert.ToDouble(patron11.Items[patron11.SelectedIndex]) + Convert.ToDouble(patron12.Items[patron12.SelectedIndex]) +
                                    Convert.ToDouble(patron13.Items[patron13.SelectedIndex]) + Convert.ToDouble(patron14.Items[patron14.SelectedIndex]) +
                                    Convert.ToDouble(escena.Items[escena.SelectedIndex]) + Convert.ToDouble(skill.Items[skill.SelectedIndex]) + Convert.ToDouble(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }

        }

        public void SumaPuntosP2(object sender, EventArgs e)
        {
            Total2.Text = "Total : ";
            if (patron4.SelectedIndex > -1 && patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && patron17.SelectedIndex > -1
                && patron18.SelectedIndex > -1 && patron19.SelectedIndex > -1 && patron20.SelectedIndex > -1 && patron21.SelectedIndex > -1 && patron22.SelectedIndex > -1 && escena2.SelectedIndex > -1 && skill2.SelectedIndex > -1 && flow2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToDouble(patron4.Items[patron4.SelectedIndex]) + Convert.ToDouble(patron5.Items[patron5.SelectedIndex]) + Convert.ToDouble(patron6.Items[patron6.SelectedIndex]) +
                    Convert.ToDouble(patron15.Items[patron15.SelectedIndex]) + Convert.ToDouble(patron16.Items[patron16.SelectedIndex]) + Convert.ToDouble(patron17.Items[patron17.SelectedIndex]) +
                    Convert.ToDouble(patron18.Items[patron18.SelectedIndex]) + Convert.ToDouble(patron19.Items[patron19.SelectedIndex]) + Convert.ToDouble(patron20.Items[patron20.SelectedIndex]) +
                    Convert.ToDouble(patron21.Items[patron21.SelectedIndex]) + Convert.ToDouble(patron22.Items[patron22.SelectedIndex]) +
                    Convert.ToDouble(escena2.Items[escena2.SelectedIndex]) + Convert.ToDouble(skill2.Items[skill2.SelectedIndex]) + Convert.ToDouble(flow2.Items[flow2.SelectedIndex]);
                Total2.Text += sumaP2.ToString();
            }
        }

        async void GuardarDeluxe(object sender, EventArgs e)
        {

            var valores = new NewCriterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToDouble(SumaSangre.Text) + suma,
                sumaTotalP2 = Convert.ToDouble(SumaSangreP2.Text) + sumaP2,
                sumaDeluxeP1 = suma,
                sumaDeluxeP2 = sumaP2,
                respuestasP1 = Convert.ToInt32(RespuestaP1.Text),
                respuestasP2 = Convert.ToInt32(RespuestaP2.Text),
                suma = Convert.ToDouble(SumaEasy.Text),
                sumaP2 = Convert.ToDouble(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToDouble(HardMode.Text),
                sumaHardModep2 = Convert.ToDouble(HardModeP2.Text),
                sumaTematicaP1 = Convert.ToDouble(TematicaP1.Text),
                sumaTematicaP2 = Convert.ToDouble(TematicaP2.Text),
                sumaPersonajesP1 = Convert.ToDouble(PersonajesP1.Text),
                sumaPersonajesP2 = Convert.ToDouble(PersonajesP2.Text),
                sumaSangreP1 = Convert.ToDouble(SangreP1.Text),
                sumaSangreP2 = Convert.ToDouble(SangreP2.Text)

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

           
            var Resultado = new ResultadoNew();
            Resultado.BindingContext = valores;
            if (suma == 0 || sumaP2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");
            }
            else
            {
                await Navigation.PushAsync(Resultado);
            }
        }

    }
}
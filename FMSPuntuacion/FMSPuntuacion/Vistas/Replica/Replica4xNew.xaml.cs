using FMSPuntuacion.Models;
using FMSPuntuacion.Tablas;
using FMSPuntuacion.Vistas.Temporada4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Replica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Replica4xNew : ContentPage
	{
        public double diferencia { get; set; }
        public string Ganador { get; set; }
        public double totalP1 { get; set; }
        public double totalP2 { get; set; }
        public Resultado4Temp Resultados { get; set; }
        public Resultado4TempViewModel resultadoViewModel;
        public double suma = 0;
        public double sumaP2 = 0;
        public double sumaVuelta2 = 0;
        public double sumaVuelta2P2 = 0;

        public Replica4xNew ()
		{
			InitializeComponent ();
            BindingContext = resultadoViewModel = new Resultado4TempViewModel();
            Resultados = new Resultado4Temp();
        }

        public void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";
            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 &&
                escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToDouble(patron1.Items[patron1.SelectedIndex]) + Convert.ToDouble(patron2.Items[patron2.SelectedIndex]) + Convert.ToDouble(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToDouble(patron4.Items[patron4.SelectedIndex]) + Convert.ToDouble(patron5.Items[patron5.SelectedIndex]) + Convert.ToDouble(patron6.Items[patron6.SelectedIndex]) +
                                    Convert.ToDouble(patron7.Items[patron7.SelectedIndex]) + Convert.ToDouble(patron8.Items[patron8.SelectedIndex]) +
                                    Convert.ToDouble(escena.Items[escena.SelectedIndex]) + Convert.ToDouble(skill.Items[skill.SelectedIndex]) + Convert.ToDouble(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }

            if (suma > sumaP2)
            {
                GanadorTexto.Text = Player1.Text;
            }
            else if (sumaP2 > suma)
            {
                GanadorTexto.Text = Player2.Text;
            }
            else
            {
                GanadorTexto.Text = "Réplica";
            }

        }

        public void SumaPuntosP2(object sender, EventArgs e)
        {
            Total2.Text = "Total : ";
            if (patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1
                && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && escena2.SelectedIndex > -1 && skill2.SelectedIndex > -1 && flow2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToDouble(patron9.Items[patron9.SelectedIndex]) + Convert.ToDouble(patron10.Items[patron10.SelectedIndex]) + Convert.ToDouble(patron11.Items[patron11.SelectedIndex]) +
                    Convert.ToDouble(patron12.Items[patron12.SelectedIndex]) + Convert.ToDouble(patron13.Items[patron13.SelectedIndex]) + Convert.ToDouble(patron14.Items[patron14.SelectedIndex]) +
                    Convert.ToDouble(patron15.Items[patron15.SelectedIndex]) + Convert.ToDouble(patron16.Items[patron16.SelectedIndex]) +
                    Convert.ToDouble(escena2.Items[escena2.SelectedIndex]) + Convert.ToDouble(skill2.Items[skill2.SelectedIndex]) + Convert.ToDouble(flow2.Items[flow2.SelectedIndex]);
                Total2.Text += sumaP2.ToString();
            }

            if (suma > sumaP2)
            {
                GanadorTexto.Text = Player1.Text;
            }
            else if (sumaP2 > suma)
            {
                GanadorTexto.Text = Player2.Text;
            }
            else
            {
                GanadorTexto.Text = "Réplica";
            }
        }

        async void registrarResultado(object sender, EventArgs e)
        {

            Resultados.player1 = Player1.Text;
            Resultados.player2 = Player2.Text;
            Resultados.sitio = Sitio.Text;
            // Resultados.totalPlayer1 = Convert.ToInt32(TotalFinal.Text);
            //Resultados.totalPlayer2 = Convert.ToInt32(TotalFinalP2.Text);

            if (GanadorTexto.Text.Contains("Réplica"))
            {
                Resultados.ganador = "Réplica";
            }
            else
            {
                Resultados.ganador = GanadorTexto.Text;
            }

            Resultados.EasyTotalP1 = Convert.ToDouble(SumaEasy.Text);
            Resultados.HardTotalP1 = Convert.ToDouble(HardMode.Text);
            Resultados.TematicaTotalP1 = Convert.ToDouble(TematicaP1.Text);
            Resultados.PersonajesTotalP1 = Convert.ToDouble(PersonajesP1.Text);
            Resultados.SangreTotalP1 = Convert.ToDouble(SangreP1.Text);
            Resultados.DeluxeTotalP1 = Convert.ToDouble(DeluxeP1.Text);
            Resultados.EasyTotalP2 = Convert.ToDouble(SumaEasyP2.Text);
            Resultados.HardTotalP2 = Convert.ToDouble(HardModeP2.Text);
            Resultados.TematicaTotalP2 = Convert.ToDouble(TematicaP2.Text);
            Resultados.PersonajesTotalP2 = Convert.ToDouble(PersonajesP2.Text);
            Resultados.SangreTotalP2 = Convert.ToDouble(SangreP2.Text);
            Resultados.DeluxeTotalP2 = Convert.ToDouble(DeluxeP2.Text);

            Resultados.fecha = DateTime.Now.Date.ToShortDateString();

            resultadoViewModel.AddItem(Resultados);
            // MessagingCenter.Send(this, "AddItem", Resultados);
            //adVideo.ShowAdVideo("ca-app-pub-3940256099942544/8691691433");
            await Application.Current.MainPage.DisplayAlert("Exito", "Los datos se han guardado correctamente", "OK");
            await Navigation.PopToRootAsync();
            //  var Menu = new MenuOpciones();
            // await Navigation.PushAsync(Menu);
        }

        async void salir(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        public void limpiar(object sender, EventArgs e)
        {
            patron1.SelectedIndex = -1;
            patron2.SelectedIndex = -1;
            patron3.SelectedIndex = -1;
            patron4.SelectedIndex = -1;
            patron5.SelectedIndex = -1;
            patron6.SelectedIndex = -1;
            patron7.SelectedIndex = -1;
            patron8.SelectedIndex = -1;
            escena.SelectedIndex = -1;
            flow.SelectedIndex = -1;
            skill.SelectedIndex = -1;
            //player 2
            patron9.SelectedIndex = -1;
            patron10.SelectedIndex = -1;
            patron11.SelectedIndex = -1;
            patron12.SelectedIndex = -1;
            patron13.SelectedIndex = -1;
            patron14.SelectedIndex = -1;
            patron15.SelectedIndex = -1;
            patron16.SelectedIndex = -1;
            escena2.SelectedIndex = -1;
            flow2.SelectedIndex = -1;
            skill2.SelectedIndex = -1;

            suma = 0;
            sumaP2 = 0;
        }
    }
}
using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
using FMSPuntuacion.Tablas;
using FMSPuntuacion.Vistas.Replica;
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
    public partial class ResultadoNew : ContentPage
    {
        public double diferencia { get; set; }
        public string Ganador { get; set; }
        public double totalP1 { get; set; }
        public double totalP2 { get; set; }
        public Resultado4Temp Resultados { get; set; }
        public Resultado4TempViewModel resultadoViewModel {get; set;}
        IAdVideoInterstitial adVideo;
        public ResultadoNew()
        {
            InitializeComponent();
            adVideo = DependencyService.Get<IAdVideoInterstitial>();
            BindingContext = resultadoViewModel = new Resultado4TempViewModel();
            Resultados = new Resultado4Temp();
        }

        async void registrarResultado(object sender, EventArgs e)
        {

            if (GanadorTexto.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Asegurate de tener un ganador", "OK");
            }
            else
            {
                Resultados.player1 = Player1.Text;
                Resultados.player2 = Player2.Text;
                Resultados.sitio = Sitio.Text;
                Resultados.totalPlayer1 = Convert.ToDouble(TotalFinal.Text);
                Resultados.totalPlayer2 = Convert.ToDouble(TotalFinalP2.Text);

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
                adVideo.ShowAdVideo("ca-app-pub-6499029686626513/3014389692");
                await Application.Current.MainPage.DisplayAlert("Exito", "Los datos se han guardado correctamente", "OK");

                await Navigation.PopToRootAsync();
            }
            //  var Menu = new MenuOpciones();
            // await Navigation.PushAsync(Menu);
        }

        async void salir(object sender, EventArgs args)
        {
            adVideo.ShowAdVideo("ca-app-pub-6499029686626513/3014389692");
            await Navigation.PopToRootAsync();
        }

        async void Votar(object sender, EventArgs args)
        {
            adVideo.ShowAdVideo("ca-app-pub-6499029686626513/3014389692");
            var valores = new NewCriterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToDouble(TotalFinal.Text),
                sumaTotalP2 = Convert.ToDouble(TotalFinalP2.Text),
                //  respuestasP1 = Convert.ToInt32(RespuestaP1.Text),
                //  respuestasP2 = Convert.ToInt32(RespuestaP2.Text),
                suma = Convert.ToDouble(SumaEasy.Text),
                sumaP2 = Convert.ToDouble(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToDouble(HardMode.Text),
                sumaHardModep2 = Convert.ToDouble(HardModeP2.Text),
                sumaTematicaP1 = Convert.ToDouble(TematicaP1.Text),
                sumaTematicaP2 = Convert.ToDouble(TematicaP2.Text),
                sumaPersonajesP1 = Convert.ToDouble(PersonajesP1.Text),
                sumaPersonajesP2 = Convert.ToDouble(PersonajesP2.Text),
                sumaSangreP1 = Convert.ToDouble(SangreP1.Text),
                sumaSangreP2 = Convert.ToDouble(SangreP2.Text),
                sumaDeluxeP1 = Convert.ToDouble(DeluxeP1.Text),
                sumaDeluxeP2 = Convert.ToDouble(DeluxeP2.Text)
            };

            var replica4x = new Replica4xNew();
            replica4x.BindingContext = valores;
            await Navigation.PushAsync(replica4x);
        }

    }
}
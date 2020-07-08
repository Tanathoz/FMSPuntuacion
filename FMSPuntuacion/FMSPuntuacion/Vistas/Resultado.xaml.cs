using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FMSPuntuacion.Tablas;
using FMSPuntuacion.Models;
using FMSPuntuacion.Controls;
using FMSPuntuacion.Vistas.Replica;

namespace FMSPuntuacion.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resultado : ContentPage
    {
        public int diferencia { get; set; }
        public string Ganador { get; set; }
        public int totalP1 { get; set; }
        public int totalP2 { get; set; }
        public Resultados Resultados { get; set; }
        public ResultadoViewModel resultadoViewModel;
       
        IAdVideoInterstitial adVideo;
        public Resultado()
        {
            InitializeComponent();
            adVideo = DependencyService.Get<IAdVideoInterstitial>();
            BindingContext = resultadoViewModel = new ResultadoViewModel();
            Resultados = new Resultados();
          
            
            // CalculaGanador();
            //  conn = DependencyService.Get<ISQLTables>().GetConnection();
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
                Resultados.totalPlayer1 = Convert.ToInt32(TotalFinal.Text);
                Resultados.totalPlayer2 = Convert.ToInt32(TotalFinalP2.Text);

                if (GanadorTexto.Text.Contains("Réplica"))
                {
                    Resultados.ganador = "Réplica";
                }
                else
                {
                    Resultados.ganador = GanadorTexto.Text;
                }

                Resultados.EasyTotalP1 = Convert.ToInt32(SumaEasy.Text);
                Resultados.HardTotalP1 = Convert.ToInt32(HardMode.Text);
                Resultados.TematicaTotalP1 = Convert.ToInt32(TematicaP1.Text);
                Resultados.PersonajesTotalP1 = Convert.ToInt32(PersonajesP1.Text);
                Resultados.SangreTotalP1 = Convert.ToInt32(SangreP1.Text);
                Resultados.DeluxeTotalP1 = Convert.ToInt32(DeluxeP1.Text);
                Resultados.EasyTotalP2 = Convert.ToInt32(SumaEasyP2.Text);
                Resultados.HardTotalP2 = Convert.ToInt32(HardModeP2.Text);
                Resultados.TematicaTotalP2 = Convert.ToInt32(TematicaP2.Text);
                Resultados.PersonajesTotalP2 = Convert.ToInt32(PersonajesP2.Text);
                Resultados.SangreTotalP2 = Convert.ToInt32(SangreP2.Text);
                Resultados.DeluxeTotalP2 = Convert.ToInt32(DeluxeP2.Text);

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
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                sumaTotalP1 = Convert.ToInt32(TotalFinal.Text),
                sumaTotalP2 = Convert.ToInt32(TotalFinalP2.Text),              
              //  respuestasP1 = Convert.ToInt32(RespuestaP1.Text),
              //  respuestasP2 = Convert.ToInt32(RespuestaP2.Text),
                suma = Convert.ToInt32(SumaEasy.Text),
                sumaP2 = Convert.ToInt32(SumaEasyP2.Text),
                sumaHardModeP1 = Convert.ToInt32(HardMode.Text),
                sumaHardModep2 = Convert.ToInt32(HardModeP2.Text),
                sumaTematicaP1 = Convert.ToInt32(TematicaP1.Text),
                sumaTematicaP2 = Convert.ToInt32(TematicaP2.Text),
                sumaPersonajesP1 = Convert.ToInt32(PersonajesP1.Text),
                sumaPersonajesP2 = Convert.ToInt32(PersonajesP2.Text),
                sumaSangreP1 = Convert.ToInt32(SangreP1.Text),
                sumaSangreP2 = Convert.ToInt32(SangreP2.Text),
                sumaDeluxeP1 = Convert.ToInt32(DeluxeP1.Text),
                sumaDeluxeP2 = Convert.ToInt32(DeluxeP2.Text)
            };

            var replica4x = new Replica4x();
            replica4x.BindingContext = valores;
            await Navigation.PushAsync(replica4x);
        }
       
	}
}
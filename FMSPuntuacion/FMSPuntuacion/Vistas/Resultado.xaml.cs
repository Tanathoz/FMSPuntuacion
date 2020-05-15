using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FMSPuntuacion.Tablas;
using FMSPuntuacion.Models;
using FMSPuntuacion.Controls;

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

            Resultados.player1 = Player1.Text;
            Resultados.player2 = Player2.Text;
            Resultados.sitio = Sitio.Text;
            Resultados.totalPlayer1 = Convert.ToInt32(TotalFinal.Text);
            Resultados.totalPlayer2 = Convert.ToInt32(TotalFinalP2.Text);
           
            if (GanadorTexto.Text.Contains("Réplica"))
            {
                Resultados.ganador = "Réplica";
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
            adVideo.ShowAdVideo("ca-app-pub-3940256099942544/8691691433");
            await Application.Current.MainPage.DisplayAlert("Exito", "Los datos se han guardado correctamente", "OK");


            await Navigation.PopToRootAsync();
            //  var Menu = new MenuOpciones();
            // await Navigation.PushAsync(Menu);
        }

        async void salir(object sender, EventArgs args)
        {
            adVideo.ShowAdVideo("ca-app-pub-3940256099942544/8691691433");
            await Navigation.PopToRootAsync();
        }

       
       
	}
}
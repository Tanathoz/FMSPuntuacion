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

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Resultado : ContentPage
	{
        public int diferencia { get; set;}
        public string Ganador { get; set;}
        public int totalP1 { get; set; }
        public int totalP2 { get; set; }
        public Resultados Resultados { get; set;}
        public ResultadoViewModel resultadoViewModel;
        public Resultado ()
		{
			InitializeComponent ();
            BindingContext = resultadoViewModel = new ResultadoViewModel();
            Resultados = new Resultados();
            // CalculaGanador();
          //  conn = DependencyService.Get<ISQLTables>().GetConnection();
		}

        async void  registrarResultado(object sender, EventArgs e)
        {

            Resultados.player1 = Player1.Text;
            Resultados.player2 = Player2.Text;
            Resultados.totalPlayer1 = Convert.ToInt32(TotalFinal.Text);
            Resultados.totalPlayer2 = Convert.ToInt32(TotalFinalP2.Text);
            Resultados.ganador = GanadorTexto.Text;
            Resultados.fecha = DateTime.Now.ToString("u");

            //await conn.InsertAsync(datosRegistrar);
            MessagingCenter.Send(this, "AddItem", Resultados);
            await Application.Current.MainPage.DisplayAlert("Exito", "Los datos se han guardado correctamente", "OK");
            await Navigation.PopToRootAsync();
          //  var Menu = new MenuOpciones();
           // await Navigation.PushAsync(Menu);
        }

       
       
	}
}
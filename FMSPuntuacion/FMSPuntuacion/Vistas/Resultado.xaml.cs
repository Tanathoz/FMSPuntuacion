using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FMSPuntuacion.Tablas;
namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Resultado : ContentPage
	{
        public int diferencia { get; set;}
        public string Ganador { get; set;}
        public int totalP1 { get; set; }
        public int totalP2 { get; set; }
        private SQLiteAsyncConnection conn;
        public Resultado ()
		{
			InitializeComponent ();
            // CalculaGanador();
            conn = DependencyService.Get<ISQLTables>().GetConnection();
		}

        async void  registrarResultado(object sender, EventArgs e)
        {
            var datosRegistrar = new Resultados {
                player1= Player1.Text,
                player2= Player2.Text,
                totalPlayer1 = Convert.ToInt32(TotalFinal.Text),
                totalPlayer2 = Convert.ToInt32(TotalFinalP2.Text),
                ganador = GanadorTexto.Text,
                fecha = DateTime.Now.ToString("u")

            };

            await conn.InsertAsync(datosRegistrar);

            var Menu = new MenuOpciones();
            await Navigation.PushAsync(Menu);
        }

       
       
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using FMSPuntuacion.Tablas;
using System.Collections.ObjectModel;

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultar : ContentPage
	{
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Resultado> TablaResultado;
		public Consultar ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<ISQLTables>().GetConnection();
		}

        protected async override void OnAppearing()
        {
            var ResulRegistros = await conn.Table<Resultado>().ToListAsync();
            TablaResultado = new ObservableCollection<Resultado>(ResulRegistros);
            //gridResultados.DataContext = TablaResultado;
            base.OnAppearing();
        }
	}
}
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
using System.IO;
using FMSPuntuacion.Models;
using FMSPuntuacion.Helpers;
using FMSPuntuacion.Vistas.Replica;

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultar : ContentPage
	{
        
        ResultadoViewModel resultadoViewModel;
		public Consultar ()
		{
			InitializeComponent ();
            BindingContext = resultadoViewModel = new ResultadoViewModel();
            // conn = DependencyService.Get<ISQLTables>().GetConnection();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (resultadoViewModel.Items.Count == 0)
                resultadoViewModel.LoadResultadoCommand.Execute(null);
        }



        //protected async override void OnAppearing()
        //{
        //    //try
        //    //{
        //    //    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BaseResultados.db3");
        //    //    var db = new SQLiteConnection(databasePath);
        //    //    IEnumerable<Resultado> resultados =
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    throw;
        //    //}

        //        var ResulRegistros = await conn.Table<Resultados>().ToListAsync();
        //        TablaResultado = new ObservableCollection<Resultados>(ResulRegistros);
        //        //gridResultados.DataContext = TablaResultado;
        //        ListaResultados.ItemsSource = TablaResultado;
        //        base.OnAppearing();

        //}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Resultados;
            if (item == null)
                return;

            await Navigation.PushAsync(new ResultadoDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ListaResultados.SelectedItem = null;
        }


        public async void EliminarRegistro(object sender, SelectableItemsView args)
        {
            var item = args.SelectedItem as Resultados;
            await Application.Current.MainPage.DisplayAlert("Mensaje de Error", "Estas seguro que quieres eliminar "+item.player2, "OK");
        }

        private void SearchItem(object senderm, EventArgs e)
        {
            string keyword = SearchBar.Text.ToLower();
            ObservableRangeCollection<Resultados> Items = new ObservableRangeCollection<Resultados>();

            if(keyword.Length == 0)
            {
                ListaResultados.ItemsSource = resultadoViewModel.Items;
            }else
            {
                foreach (Resultados resul in resultadoViewModel.Items)
                {
                    if (resul.player1.ToLower().Contains(keyword) || resul.player2.ToLower().Contains(keyword) )
                    {
                        Items.Add(resul);
                    }
                }           
                    ListaResultados.ItemsSource = Items;             
            }
         
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NombresInicio());
        }

        public async void Volver(object sender, EventArgs e) {

            await Navigation.PopToRootAsync();
        }
        public void Restulado_OnClicked()
        {
             Navigation.PushAsync(new Example()); 
        }

	}
}
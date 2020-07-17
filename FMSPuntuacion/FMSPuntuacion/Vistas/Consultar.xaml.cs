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
using FMSPuntuacion.Vistas.Temporada4;

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultar : ContentPage
	{
        
        ResultadoViewModel resultadoViewModel;
        Resultado4TempViewModel resultado4TempViewModel;
        public int index = 0;
      
		public Consultar ()
		{
			InitializeComponent ();
            // BindingContext = resultadoViewModel = new ResultadoViewModel();
            BindingContext = resultado4TempViewModel = new Resultado4TempViewModel();  
            // conn = DependencyService.Get<ISQLTables>().GetConnection();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (resultado4TempViewModel.Items.Count == 0)
                resultado4TempViewModel.LoadResultadoCommand.Execute(null);
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
            if (consulta.SelectedIndex == 0 || consulta.SelectedIndex == -1)
            {
                var item = args.SelectedItem as Resultado4Temp;
                if (item == null)
                    return;
                await Navigation.PushAsync(new Resultado4TempDetail(new Item4TempVM(item)));
                // Manually deselect item
                ListaResultados.SelectedItem = null;
            }else if (consulta.SelectedIndex == 1)
            {
                var item = args.SelectedItem as Resultados;
                if (item == null)
                    return;
                await Navigation.PushAsync(new ResultadoDetailPage(new ItemDetailViewModel(item)));

                // Manually deselect item
                ListaResultados.SelectedItem = null;
            }
          
        }


        public async void EliminarRegistro(object sender, SelectableItemsView args)
        {
            if (consulta.SelectedIndex == 0 || consulta.SelectedIndex == -1)
            {
                var item = args.SelectedItem as Resultado4Temp;
                await Application.Current.MainPage.DisplayAlert("Mensaje de Error", "Estas seguro que quieres eliminar " + item.player1 + "vs" + item.player2, "OK");
            }else if (consulta.SelectedIndex == 1)
            {
                var item = args.SelectedItem as Resultados;
                await Application.Current.MainPage.DisplayAlert("Mensaje de Error", "Estas seguro que quieres eliminar " + item.player1 + "vs" + item.player2, "OK");
            }          
        }

        private void SearchItem(object senderm, EventArgs e)
        {
            string keyword = SearchBar.Text.ToLower();

            if (consulta.SelectedIndex == 0 || consulta.SelectedIndex == -1)
            {
                ObservableRangeCollection<Resultado4Temp> Items = new ObservableRangeCollection<Resultado4Temp>();
                if (keyword.Length == 0)
                {
                    ListaResultados.ItemsSource = resultado4TempViewModel.Items;
                }
                else
                {
                    foreach (Resultado4Temp resul in resultado4TempViewModel.Items)
                    {
                        if (resul.player1.ToLower().Contains(keyword) || resul.player2.ToLower().Contains(keyword))
                        {
                            Items.Add(resul);
                        }
                    }
                    ListaResultados.ItemsSource = Items;
                }
            }

            else if (consulta.SelectedIndex == 1)
            {
                ObservableRangeCollection<Resultados> Items = new ObservableRangeCollection<Resultados>();
                if (keyword.Length == 0)
                {
                    ListaResultados.ItemsSource = resultadoViewModel.Items;
                }
                else
                {
                    foreach (Resultados resul in resultadoViewModel.Items)
                    {
                        if (resul.player1.ToLower().Contains(keyword) || resul.player2.ToLower().Contains(keyword))
                        {
                            Items.Add(resul);
                        }
                    }
                    ListaResultados.ItemsSource = Items;
                }
            }
                    
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NombresInicio());
        }

        public async void Volver(object sender, EventArgs e) {
            await Navigation.PopToRootAsync();
        }

        public  void Cambio(object sender, EventArgs e)
        {
            int ind = consulta.SelectedIndex;

            if (ind == 0)
            {
                BindingContext = resultado4TempViewModel = new Resultado4TempViewModel();
                ListaResultados.ItemsSource = resultado4TempViewModel.Items;
                if (resultado4TempViewModel.Items.Count == 0)
                    resultado4TempViewModel.LoadResultadoCommand.Execute(null);
            }else if( ind == 1)
            {
                BindingContext = resultadoViewModel = new ResultadoViewModel();
                ListaResultados.ItemsSource = resultadoViewModel.Items;
                if (resultadoViewModel.Items.Count == 0)
                    resultadoViewModel.LoadResultadoCommand.Execute(null);
            }

            //await Application.Current.MainPage.DisplayAlert("Mensaje de Error", "jajaja"+ind, "OK");
        }
    }
}
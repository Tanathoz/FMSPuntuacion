using FMSPuntuacion.Helpers;
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
	public partial class ConsultarNew : ContentPage
	{
        Resultado4TempViewModel resultadoViewModel;
		public ConsultarNew ()
		{
			InitializeComponent ();
            BindingContext = resultadoViewModel = new Resultado4TempViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (resultadoViewModel.Items.Count == 0)
                resultadoViewModel.LoadResultadoCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Resultado4Temp;
            if (item == null)
                return;

            await Navigation.PushAsync(new Resultado4TempDetail (new Item4TempVM(item)));
            // Manually deselect item
            ListaResultados.SelectedItem = null;
        }

        public async void EliminarRegistro(object sender, SelectableItemsView args)
        {
            var item = args.SelectedItem as Resultado4Temp;
            await Application.Current.MainPage.DisplayAlert("Mensaje de Error", "Estas seguro que quieres eliminar " + item.player1 + "vs"+item.player2, "OK");
        }

        private void SearchItem(object senderm, EventArgs e)
        {
            string keyword = SearchBar.Text.ToLower();
            ObservableRangeCollection<Resultado4Temp> Items = new ObservableRangeCollection<Resultado4Temp>();

            if (keyword.Length == 0)
            {
                ListaResultados.ItemsSource = resultadoViewModel.Items;
            }
            else
            {
                foreach (Resultado4Temp resul in resultadoViewModel.Items)
                {
                    if (resul.player1.ToLower().Contains(keyword) || resul.player2.ToLower().Contains(keyword))
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

        public async void Volver(object sender, EventArgs e)
        {

            await Navigation.PopToRootAsync();
        }



    }
}
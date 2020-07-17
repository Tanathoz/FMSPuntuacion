using FMSPuntuacion.Helpers;
using FMSPuntuacion.Tablas;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FMSPuntuacion.Models
{
    public class Resultado4TempViewModel: Base4Temp
    {
        public ObservableRangeCollection<Resultado4Temp> Items { get; set; }
        public Command LoadResultadoCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }

        public Resultado4TempViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<Resultado4Temp>();
            LoadResultadoCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteCommand = new Command<Resultado4Temp>(DeleteItem);
            AddCommand = new Command<Resultado4Temp>(AddItem);
        }

        public async void AddItem(Resultado4Temp item)
        {
            Items.Add(item);
            await DataStore.AddResultadoAsync(item);

        }

        private async void DeleteItem(Resultado4Temp item)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("Borrar registro", "¿Estás seguro?", "Borrar", "Cancelar");
            if (!confirm) return;
            await DataStore.DeleteResultadoAsync(item);
            await ExecuteLoadItemsCommand();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetResultadoAsync();
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "No sé puede cargar los resultados.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

   
}

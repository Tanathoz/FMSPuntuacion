using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FMSPuntuacion.Tablas;
using Xamarin.Forms;
using System.Diagnostics;

using FMSPuntuacion.Helpers;
using FMSPuntuacion.Vistas;

namespace FMSPuntuacion.Models
{
    public class ResultadoViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Resultados> Items { get; set; }
        public Command LoadResultadoCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public ResultadoViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<Resultados>();
            LoadResultadoCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteCommand = new Command<Resultados>(DelteItem);

            MessagingCenter.Subscribe<Resultado, Resultados>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Resultados;
                Items.Add(_item);
                await DataStore.AddResultadoAsync(_item);
            });
        }

        private async void DelteItem(Resultados item)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("Delete item", "Are you sure?", "Delete it", "Cancel");
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
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
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

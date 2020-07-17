using FMSPuntuacion.Helpers;
using FMSPuntuacion.Services;
using FMSPuntuacion.Tablas;
using System;
using System.Text;
using Xamarin.Forms;



namespace FMSPuntuacion.Models
{
    public class Base4Temp: Helpers.ObservableObject
    {
        public IDataStore<Resultado4Temp> DataStore => DependencyService.Get<IDataStore<Resultado4Temp>>();
        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

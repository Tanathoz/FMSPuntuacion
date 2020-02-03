using FMSPuntuacion.Services;
using FMSPuntuacion.Tablas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XLabs.Data;

namespace FMSPuntuacion.Models
{
    public class BaseViewModel:ObservableObject
    {
        public IDataStore<Resultados> DataStore => DependencyService.Get<IDataStore<Resultados>>();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMSPuntuacion.Models;
using FMSPuntuacion.Vistas;
using FMSPuntuacion.Vistas.Generador;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Feed : ContentPage
    {
        public Feed()
        {
            InitializeComponent();
        }
        async void OnCalificaClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Example
            //{
            //    BindingContext = new Criterios()
            //});
            await Navigation.PushAsync(new EasyMode
            {
                BindingContext = new Criterios()
             
             });
        }

        async void OnRegistrarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Example
            {
                BindingContext = new Criterios()
            });
        }

        async void OnConsultarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Consultar
            {
                
            });
        }

        async void OnEntrenaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Temporizador{
            });
        }
    }
}
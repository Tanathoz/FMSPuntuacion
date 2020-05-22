using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
using FMSPuntuacion.Vistas;
using FMSPuntuacion.Vistas.Generador;
using FMSPuntuacion.Vistas.Replica;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Feed : ContentPage
    {
        public Feed()
        {
           // NavigationPage.SetHasBackButton(this, false);
            
            InitializeComponent();
            
            
            //NavigationPage.SetHasNavigationBar(this, true);
        }
       

        async void OnCalificaClicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new NombresInicio
            {
                BindingContext = new Criterios()
            });
        }

        async void OnRegistrarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NombresInicio
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
            
            
            await Navigation.PushAsync(new Temporizador()
            {
                
            });
        }
    }
}
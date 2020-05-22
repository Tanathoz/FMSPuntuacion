using FMSPuntuacion.Controls;
using FMSPuntuacion.Helpers;
using FMSPuntuacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Opciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SeleccionaTema : ContentPage
	{
       
        public SeleccionaTema ()
		{
			InitializeComponent ();
            BindingContext = new TemaViewModel();        
        }

        private void SpainTheme(object sender, EventArgs e)
        {
            Settings.SetTheme(Helpers.Settings.Tema.Spain);
        }

        private void MexicoTeme (object sender, EventArgs e)
        {
            Settings.SetTheme(Helpers.Settings.Tema.Mexico);
        }

        private void DefaultTeme(object sender, EventArgs e)
        {
            Settings.SetTheme(Helpers.Settings.Tema.Defecto);
        }

       async void salir(object sender, EventArgs args)
        {
            //NavigationPage nav = new NavigationPage(new Feed() );
            //Application.Current.MainPage = navPage;
          
            await Navigation.PopAsync();

        }
    }
}
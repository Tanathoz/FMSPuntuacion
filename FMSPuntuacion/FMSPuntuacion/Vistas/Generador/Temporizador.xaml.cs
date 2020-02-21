using FMSPuntuacion.Models;
using FMSPuntuacion.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Generador
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Temporizador : ContentPage
	{
		public Temporizador ()
		{
			InitializeComponent ();
            BindingContext = new MyCountDownModel();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as BaseModel;
            await vm?.LoadAsync();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var vm = BindingContext as BaseModel;
            await vm?.UnloadAsync();
        }
	}
}
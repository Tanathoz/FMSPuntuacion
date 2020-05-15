using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultadoDetailPage : ContentPage
	{
        ItemDetailViewModel resultadoModel;
        
        IAdIntestitial adInterstitial = DependencyService.Get<IAdIntestitial>();
        public ResultadoDetailPage ()
		{
			InitializeComponent ();
           
        }

        public ResultadoDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = this.resultadoModel = viewModel;
        }

        async void Regresar(object sender, EventArgs e)
        {

            adInterstitial.showAd("ca-app-pub-3940256099942544/1033173712");
            await Navigation.PushAsync(new Consultar
            {

            });
        }
    }
}
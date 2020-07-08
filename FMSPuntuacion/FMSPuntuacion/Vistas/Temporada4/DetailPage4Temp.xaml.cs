using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
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
	public partial class DetailPage4Temp : ContentPage
	{
        ItemDetailViewModel resultadoModel;
        IAdIntestitial adInterstitial = DependencyService.Get<IAdIntestitial>();

        public DetailPage4Temp ()
		{
			InitializeComponent ();
		}

        public DetailPage4Temp(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.resultadoModel = viewModel;
        }

        async void Regresar(object sender, EventArgs e)
        {

            adInterstitial.showAd("ca-app-pub-6499029686626513/6617028712");
            await Navigation.PushAsync(new ConsultarNew
            {

            });
        }
    }
}
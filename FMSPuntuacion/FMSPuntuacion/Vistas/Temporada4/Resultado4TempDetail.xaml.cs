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
	public partial class Resultado4TempDetail : ContentPage
	{
        Item4TempVM resultModel;

	
        public Resultado4TempDetail(Item4TempVM item)
        {
            InitializeComponent();
            BindingContext = this.resultModel = item;
        }

        async void Regresar(object sender, EventArgs e)
        {

            //adInterstitial.showAd("ca-app-pub-6499029686626513/6617028712");
            await Navigation.PushAsync(new Consultar
            {

            });
        }
    }
}
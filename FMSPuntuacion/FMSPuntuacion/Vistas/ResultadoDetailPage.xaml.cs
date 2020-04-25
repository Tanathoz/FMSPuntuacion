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
        ResultadoViewModel resultadoViewModel;
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
            await Navigation.PushAsync(new Consultar
            {

            });
        }
    }
}
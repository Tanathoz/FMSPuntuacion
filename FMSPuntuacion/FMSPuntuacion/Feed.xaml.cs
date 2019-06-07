using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMSPuntuacion.Models;
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
            await Navigation.PushAsync(new EasyMode
            {
                BindingContext = new Criterios()
            });
        }
    }
}
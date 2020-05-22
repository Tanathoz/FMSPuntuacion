using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
using FMSPuntuacion.Models.Base;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace FMSPuntuacion.Vistas.Generador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Temporizador : ContentPage
	{
        public Command OnCheckedChanged { get; set; }
        public bool flagy;
    
        public bool Flagy
        {
            get
            {
                return flagy;
            }

            set
            {
                flagy = value;
            }
        }
        public Temporizador()
		{
			InitializeComponent ();
           
            BindingContext = new MyCountDownModel();       
            RadioBtn.ItemsSource = new[]
            {
                "5 Segundos", "10 Segundos"
            };

            RadioBtn.IsEnabled = false;          
            // OnCheckedChanged = new Command(OnCheckBoxChanged);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as BaseModel;
            
            
            //await vm?.LoadAsync();
        }

        protected override async void OnDisappearing()
        {
           // adInterstitial.showAd();
            base.OnDisappearing();
            var vm = BindingContext as BaseModel;
            await vm?.UnloadAsync();
        }

        //private void Seleccionar(object sender, int e)
        //{
        //    var radio = sender as CustomRadioButton;
        //    if (radio == null || radio.Id == -1)
        //    {
        //        return;
        //    }
        //}

        async void CambioBandera(object sender, EventArgs e)
        {

            if (palabras.Checked)
            {
                RadioBtn.IsEnabled = true;
                RadioBtn.Items[0].Checked = true;
            }       
            else
            {
                RadioBtn.IsEnabled = false;
                RadioBtn.Items[0].Checked = false;
                RadioBtn.Items[1].Checked = false;
            }
                
            // objCountDown.Restart();
        }


	}
}
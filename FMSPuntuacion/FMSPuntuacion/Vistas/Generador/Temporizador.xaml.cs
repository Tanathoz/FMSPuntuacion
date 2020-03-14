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
        public Temporizador ()
		{
			InitializeComponent ();
            BindingContext = new MyCountDownModel();
            flagy = true;
            RadioBtn.ItemsSource = new[]
            {
                "5 Segundos", "10 Segundos"
            };

             
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
            int iyn = RadioBtn.SelectedIndex;
            bool segu = RadioBtn.Items[1].Checked;
            if (RadioBtn.Items[0].Checked)
                Flagy = true;
            else
                Flagy = false;
            // objCountDown.Restart();
        }


	}
}
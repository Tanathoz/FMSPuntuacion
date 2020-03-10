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

        //public void OnCheckBoxChanged()
        //{
        //    MyCountDownModel objCountDown = new MyCountDownModel();
        //    if (palabras.Checked)
        //        objCountDown.Flag = true;
        //    else
        //        objCountDown.Flag = false;
        //}

        async void CambioBandera(object sender, EventArgs e)
        {
            MyCountDownModel objCount = new MyCountDownModel();
            bool fly = true;

            if (palabras.Checked)
                Flagy = true;
            else
                Flagy = false;

            // objCountDown.Restart();
        }


	}
}
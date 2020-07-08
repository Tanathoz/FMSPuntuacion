using System;

using FMSPuntuacion.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EasyMode : ContentPage
	{
        public int suma = 0;
        public int sumaP2 = 0;
		public EasyMode ()
		{
			InitializeComponent ();
		}

        async void OnCalificaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasyMode {
                BindingContext = new Criterios()
            });
        }

        public void OnAddNumber(object sender, EventArgs e)
        {
            Total.Text ="Total :";

            if (patron1.SelectedIndex >-1 && patron2.SelectedIndex>-1 && patron3.SelectedIndex>-1 && patron4.SelectedIndex>-1 && patron5.SelectedIndex>-1 && patron6.SelectedIndex>-1 && escena.SelectedIndex>-1 && skill.SelectedIndex > -1 && flow.SelectedIndex>-1) {
                suma = Convert.ToInt32(patron1.Items[patron1.SelectedIndex]) + Convert.ToInt32(patron2.Items[patron2.SelectedIndex]) + Convert.ToInt32(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToInt32(patron4.Items[patron4.SelectedIndex]) + Convert.ToInt32(patron5.Items[patron5.SelectedIndex]) + Convert.ToInt32(patron6.Items[patron6.SelectedIndex]) +
                                    Convert.ToInt32(escena.Items[escena.SelectedIndex]) + Convert.ToInt32(skill.Items[skill.SelectedIndex]) + Convert.ToInt32(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }
                       
        }

        public void EasyModeP2(object sender, EventArgs e)
        {
            TotalP2.Text = "Total : ";
            if (patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && escenaP2.SelectedIndex > -1 && skillP2.SelectedIndex > -1 && flowP2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToInt32(patron7.Items[patron7.SelectedIndex]) + Convert.ToInt32(patron8.Items[patron8.SelectedIndex]) + Convert.ToInt32(patron9.Items[patron9.SelectedIndex]) +
                    Convert.ToInt32(patron10.Items[patron10.SelectedIndex]) + Convert.ToInt32(patron11.Items[patron11.SelectedIndex]) + Convert.ToInt32(patron12.Items[patron12.SelectedIndex]) +
                    Convert.ToInt32(escenaP2.Items[escenaP2.SelectedIndex]) + Convert.ToInt32(skillP2.Items[skillP2.SelectedIndex]) + Convert.ToInt32(flowP2.Items[flowP2.SelectedIndex]);
                TotalP2.Text += sumaP2.ToString();
            }
        }

        async void GuardarEsayMode(object sender, EventArgs e)
        {
            var valores = new Criterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                suma = suma,
                sumaP2=sumaP2             
            };

            valores.lstCalificacionesP2.Add(suma);
            var hardMode = new HardMode();
            hardMode.BindingContext = valores;

            if (suma == 0 || sumaP2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");
            }//else 
            else if (valores.player1 == null || valores.player2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga Nombre", "OK");
            }
            else{
                await Navigation.PushAsync(hardMode);
            }
            //await Navigation.PushAsync(new HardMode(suma, sumaP2));
        }
	}
}
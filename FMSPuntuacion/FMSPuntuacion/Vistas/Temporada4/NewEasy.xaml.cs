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
	public partial class NewEasy : ContentPage
	{
        public double suma = 0;
        public double sumaP2 = 0;
		public NewEasy ()
		{
			InitializeComponent ();
		}

        public void OnAddNumber(object sender, EventArgs e)
        {
            Total.Text = "Total :";
            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron4.SelectedIndex > -1 && patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToDouble(patron1.Items[patron1.SelectedIndex]) + Convert.ToDouble(patron2.Items[patron2.SelectedIndex]) + Convert.ToDouble(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToDouble(patron4.Items[patron4.SelectedIndex]) + Convert.ToDouble(patron5.Items[patron5.SelectedIndex]) + Convert.ToDouble(patron6.Items[patron6.SelectedIndex]) +
                                    Convert.ToDouble(escena.Items[escena.SelectedIndex]) + Convert.ToDouble(skill.Items[skill.SelectedIndex]) + Convert.ToDouble(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }
        }

        public void EasyModeP2(object sender, EventArgs e)
        {
            TotalP2.Text = "Total : ";
            if (patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && escenaP2.SelectedIndex > -1 && skillP2.SelectedIndex > -1 && flowP2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToDouble(patron7.Items[patron7.SelectedIndex]) + Convert.ToDouble(patron8.Items[patron8.SelectedIndex]) + Convert.ToDouble(patron9.Items[patron9.SelectedIndex]) +
                    Convert.ToDouble(patron10.Items[patron10.SelectedIndex]) + Convert.ToDouble(patron11.Items[patron11.SelectedIndex]) + Convert.ToDouble(patron12.Items[patron12.SelectedIndex]) +
                    Convert.ToDouble(escenaP2.Items[escenaP2.SelectedIndex]) + Convert.ToDouble(skillP2.Items[skillP2.SelectedIndex]) + Convert.ToDouble(flowP2.Items[flowP2.SelectedIndex]);
                TotalP2.Text += sumaP2.ToString();
            }
        }

        async void GuardarEsayMode(object sender, EventArgs e)
        {
            var valores = new NewCriterios
            {
                player1 = Player1.Text,
                player2 = Player2.Text,
                sitio = Sitio.Text,
                suma = suma,
                sumaP2 = sumaP2
            };

           
            var hardMode = new HardModeNew();
            hardMode.BindingContext = valores;

            if (suma == 0 || sumaP2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga calificación en total", "OK");
            }//else 
            else if (valores.player1 == null || valores.player2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Verifica que ambos jugadores tenga Nombre", "OK");
            }
            else
            {
                await Navigation.PushAsync(hardMode);
            }
            //await Navigation.PushAsync(new HardMode(suma, sumaP2));
        }

    }
}
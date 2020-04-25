using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Replica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CuatroX4 : ContentPage
	{
        public int suma = 0;
        public int sumaP2 = 0;
        public int sumaVuelta2 = 0;
        public int sumaVuelta2P2 = 0;
        public CuatroX4 ()
		{
			InitializeComponent ();
		}

        void Nombre(Object sender, EventArgs e)
        {
            LNombre.Text = Player1.Text;
        }

        void Nombre2(Object sender, EventArgs e)
        {
           LabelN2.Text =  Player2.Text;
        }
      
        async void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";

            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 &&
                escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToInt32(patron1.Items[patron1.SelectedIndex]) + Convert.ToInt32(patron2.Items[patron2.SelectedIndex]) + Convert.ToInt32(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToInt32(patron4.Items[patron4.SelectedIndex]) + Convert.ToInt32(patron5.Items[patron5.SelectedIndex]) + Convert.ToInt32(patron6.Items[patron6.SelectedIndex]) +
                                    Convert.ToInt32(patron7.Items[patron7.SelectedIndex]) + Convert.ToInt32(patron8.Items[patron8.SelectedIndex])  +
                                    Convert.ToInt32(escena.Items[escena.SelectedIndex]) + Convert.ToInt32(skill.Items[skill.SelectedIndex]) + Convert.ToInt32(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }

        }

        async void SumaPuntosP2(object sender, EventArgs e)
        {
            Total2.Text = "Total : ";
            if (patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1
                && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && escena2.SelectedIndex > -1 && skill2.SelectedIndex > -1 && flow2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToInt32(patron9.Items[patron9.SelectedIndex]) + Convert.ToInt32(patron10.Items[patron10.SelectedIndex]) + Convert.ToInt32(patron11.Items[patron11.SelectedIndex]) +
                    Convert.ToInt32(patron12.Items[patron12.SelectedIndex]) + Convert.ToInt32(patron13.Items[patron13.SelectedIndex]) + Convert.ToInt32(patron14.Items[patron14.SelectedIndex]) +
                    Convert.ToInt32(patron15.Items[patron15.SelectedIndex]) + Convert.ToInt32(patron16.Items[patron16.SelectedIndex]) +
                    Convert.ToInt32(escena2.Items[escena2.SelectedIndex]) + Convert.ToInt32(skill2.Items[skill2.SelectedIndex]) + Convert.ToInt32(flow2.Items[flow2.SelectedIndex]);
                Total2.Text += sumaP2.ToString();
            }
        }

        async void salir(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

    }
}
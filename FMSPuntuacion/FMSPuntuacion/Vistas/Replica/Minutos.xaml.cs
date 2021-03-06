﻿using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion.Vistas.Replica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Minutos : ContentPage
	{
        public int suma = 0;
        public int sumaP2 = 0;
        public int sumaVuelta2 = 0;
        public int sumaVuelta2P2 = 0;
        public int respuestaP1 = 0;
        public int respuestaP2 = 0;
        public int sumaTotalP1 = 0;
        public int sumaTotalP2 = 0;
        public string ganadorr = string.Empty;
        IAdIntestitial adInterstitial = DependencyService.Get<IAdIntestitial>();
        public Minutos ()
		{
			InitializeComponent ();
		}

        public void SumaPuntosP1(object sender, EventArgs e)
        {
            Total.Text = "Total :";

            if (patron1.SelectedIndex > -1 && patron2.SelectedIndex > -1 && patron3.SelectedIndex > -1 && patron4.SelectedIndex > -1 && patron5.SelectedIndex > -1 && patron6.SelectedIndex > -1 && escena.SelectedIndex > -1 && skill.SelectedIndex > -1 && flow.SelectedIndex > -1)
            {
                suma = Convert.ToInt32(patron1.Items[patron1.SelectedIndex]) + Convert.ToInt32(patron2.Items[patron2.SelectedIndex]) + Convert.ToInt32(patron3.Items[patron3.SelectedIndex]) +
                                    Convert.ToInt32(patron4.Items[patron4.SelectedIndex]) + Convert.ToInt32(patron5.Items[patron5.SelectedIndex]) + Convert.ToInt32(patron6.Items[patron6.SelectedIndex]) +
                                    Convert.ToInt32(escena.Items[escena.SelectedIndex]) + Convert.ToInt32(skill.Items[skill.SelectedIndex]) + Convert.ToInt32(flow.Items[flow.SelectedIndex]);


                Total.Text += suma.ToString();
            }

        }

        public void SumaPuntosP2(object sender, EventArgs e)
        {
            TotalP2.Text = "Total : ";
            respuestaP2 = 0;
            if (patron7.SelectedIndex > -1 && patron8.SelectedIndex > -1 && patron9.SelectedIndex > -1 && patron10.SelectedIndex > -1 && patron11.SelectedIndex > -1 && patron12.SelectedIndex > -1 && escenaP2.SelectedIndex > -1 && skillP2.SelectedIndex > -1 && flowP2.SelectedIndex > -1)
            {
                sumaP2 = Convert.ToInt32(patron7.Items[patron7.SelectedIndex]) + Convert.ToInt32(patron8.Items[patron8.SelectedIndex]) + Convert.ToInt32(patron9.Items[patron9.SelectedIndex]) +
                    Convert.ToInt32(patron10.Items[patron10.SelectedIndex]) + Convert.ToInt32(patron11.Items[patron11.SelectedIndex]) + Convert.ToInt32(patron12.Items[patron12.SelectedIndex]) +
                    Convert.ToInt32(escenaP2.Items[escenaP2.SelectedIndex]) + Convert.ToInt32(skillP2.Items[skillP2.SelectedIndex]) + Convert.ToInt32(flowP2.Items[flowP2.SelectedIndex]);
                if (respuesta.Checked)
                    respuestaP2++;
                if (respuesta2.Checked)
                    respuestaP2++;
                if (respuesta3.Checked)
                    respuestaP2++;
                if (respuesta4.Checked)
                    respuestaP2++;
                if (respuesta5.Checked)
                    respuestaP2++;
                if (respuesta6.Checked)
                    respuestaP2++;
                TotalP2.Text += sumaP2.ToString() + "+ " + respuestaP2;
            }
        }

        public void SumaPuntosP2Vuelta2(object sender, EventArgs e)
        {
            Total3.Text = "Total :";
            if (patron13.SelectedIndex > -1 && patron14.SelectedIndex > -1 && patron15.SelectedIndex > -1 && patron16.SelectedIndex > -1 && patron17.SelectedIndex > -1 && patron18.SelectedIndex > -1 && escena3.SelectedIndex > -1 && skill3.SelectedIndex > -1 && flow3.SelectedIndex > -1)
            {
                sumaVuelta2P2 = Convert.ToInt32(patron13.Items[patron13.SelectedIndex]) + Convert.ToInt32(patron14.Items[patron14.SelectedIndex]) + Convert.ToInt32(patron15.Items[patron15.SelectedIndex]) +
                                    Convert.ToInt32(patron16.Items[patron16.SelectedIndex]) + Convert.ToInt32(patron17.Items[patron17.SelectedIndex]) + Convert.ToInt32(patron18.Items[patron18.SelectedIndex]) +
                                    Convert.ToInt32(escena3.Items[escena3.SelectedIndex]) + Convert.ToInt32(skill3.Items[skill3.SelectedIndex]) + Convert.ToInt32(flow3.Items[flow3.SelectedIndex]);
                Total3.Text += sumaVuelta2P2.ToString();
            }

        }

        public void SumaPuntosP1Vuelta2(object sender, EventArgs e)
        {
            Total4.Text = "Total :";
            respuestaP1 = 0;
            if (patron19.SelectedIndex > -1 && patron20.SelectedIndex > -1 && patron21.SelectedIndex > -1 && patron22.SelectedIndex > -1 && patron23.SelectedIndex > -1 && patron24.SelectedIndex > -1 && escena4.SelectedIndex > -1 && skill4.SelectedIndex > -1 && flow4.SelectedIndex > -1)
            {
                sumaVuelta2 = Convert.ToInt32(patron19.Items[patron19.SelectedIndex]) + Convert.ToInt32(patron20.Items[patron20.SelectedIndex]) + Convert.ToInt32(patron21.Items[patron21.SelectedIndex]) +
                                    Convert.ToInt32(patron22.Items[patron22.SelectedIndex]) + Convert.ToInt32(patron23.Items[patron23.SelectedIndex]) + Convert.ToInt32(patron24.Items[patron24.SelectedIndex]) +
                                    Convert.ToInt32(escena4.Items[escena4.SelectedIndex]) + Convert.ToInt32(skill4.Items[skill4.SelectedIndex]) + Convert.ToInt32(flow4.Items[flow4.SelectedIndex]);
                if (respuesta7.Checked)
                    respuestaP1++;
                if (respuesta8.Checked)
                    respuestaP1++;
                if (respuesta9.Checked)
                    respuestaP1++;
                if (respuesta10.Checked)
                    respuestaP1++;
                if (respuesta11.Checked)
                    respuestaP1++;
                if (respuesta12.Checked)
                    respuestaP1++;
                Total4.Text += sumaVuelta2.ToString() + "+ " + respuestaP1;
            }

            sumaTotalP1 = suma + sumaVuelta2+respuestaP1;
            sumaTotalP2 = sumaP2 + sumaVuelta2P2+respuestaP2;
            P1.Text = Player1.Text;
            P2.Text = LBN2.Text;
            TotalFinal.Text = sumaTotalP1.ToString();
            TotalFinalP2.Text = sumaTotalP2.ToString(); 

            if ((sumaTotalP1 - sumaTotalP2 ) > 4)
            {
                GanadorTexto.Text = Player1.Text;
            }else if ((sumaTotalP2 - sumaTotalP1) > 4)
            {
                GanadorTexto.Text = LBN2.Text;
            }else
            {
                GanadorTexto.Text = "Réplica, Diferencia de " + Math.Abs(sumaTotalP1 - sumaTotalP2) + " Puntos";
            }
            
        }

        async void GuardarSangre(object sender, EventArgs e)
        {
                adInterstitial.showAd("ca-app-pub-6499029686626513/6617028712");
                await Navigation.PopToRootAsync();        
        }

    }
}
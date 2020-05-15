using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FMSPuntuacion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //wait some time 
            await Task.Delay(2000);

            await Task.WhenAll(
                SplashGrid.FadeTo(0, 2000),
                notes.ScaleTo(10, 2000)
                );

            //await notes.ScaleTo(0.5, 500, Easing.CubicInOut);
            //var animationTasks = new[]{
            //notes.ScaleTo(100.0, 1000, Easing.CubicInOut),
            //notes.FadeTo(0, 700, Easing.CubicInOut)
            //};
            //await Task.WhenAll(animationTasks);
            //Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack[0]);
            //await Navigation.PopToRootAsync(false);
        }

    }
}

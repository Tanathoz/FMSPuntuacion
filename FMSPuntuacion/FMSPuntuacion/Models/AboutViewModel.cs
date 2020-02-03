using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FMSPuntuacion.Models
{
    public class AboutViewModel: BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://somostechies.com")));
        }

        public ICommand OpenWebCommand { get; }
    }
}

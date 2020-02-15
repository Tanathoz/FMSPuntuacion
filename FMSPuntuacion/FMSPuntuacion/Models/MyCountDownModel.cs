using System;
using System.Collections.Generic;
using System.Text;
using FMSPuntuacion.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace FMSPuntuacion.Models
{
    public class MyCountDownModel:BaseViewModel
    {
        private CountDown _countdown;
        private int _days;
        private int _hours;
        private int _minutes;
        private double _progress;

        public MyCountDownModel()
        {
            _countdown = new CountDown();
        }

        public int Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }

        public int Hours
        {
            get => _hours;
            set => SetProperty(ref _hours, value);
        }
        public int Minutes
        {
            get => _minutes;
            set => SetProperty(ref _minutes, value);
        }

        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        
    }
}

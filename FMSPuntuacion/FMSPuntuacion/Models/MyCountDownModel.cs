using System;
using System.Collections.Generic;
using System.Text;
using FMSPuntuacion.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using FMSPuntuacion.Models.Base;
namespace FMSPuntuacion.Models
{
    public class MyCountDownModel: BaseModel
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

        public ICommand RestartCommand => new Command(Restart);

        public override Task LoadAsync()
        {
            _countdown.EndDate = DateTime.Now.AddMinutes(1);
            _countdown.Start();
            _countdown.Ticked += OnCountdownTicked;
            _countdown.Completed += OnCountdownCompleted;

            return base.LoadAsync();
        }


        void OnCountdownTicked()
        {
            Days = _countdown.RemainTime.Days;
            Hours = _countdown.RemainTime.Hours;
            Minutes = _countdown.RemainTime.Minutes;
            var totalSeconds = (DateTime.Now.AddMinutes(1) - DateTime.Now).TotalSeconds;
            var remainSeconds = _countdown.RemainTime.TotalSeconds;
            Progress = remainSeconds / totalSeconds;
        }

        void OnCountdownCompleted()
        {
            Days = 0;
            Hours = 0;
            Minutes = 0;
            Progress = 0;
        }

        void Restart()
        {
            Debug.WriteLine("Restart");
        }

    }
}

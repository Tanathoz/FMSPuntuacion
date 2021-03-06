﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
namespace FMSPuntuacion.Models
{
    public class CountDown : BindableObject
    {
        TimeSpan _remainTime;
        public string _palabra;
     
        public event Action Completed;
        public event Action Ticked;
        public event Action Cancel;
        public DateTime EndDate { get; set; }
        public bool  cancelar;
        
        public bool Cancelar
        {
            get
            {
                return cancelar;
            }

            set
            {
                cancelar = value;
            }
        }


        public string Palabra
        {
            get { return Palabra; }
            private set
            {
                _palabra = value;
            }
        }

        public TimeSpan RemainTime
        {
            get { return _remainTime; }
            private set
            {
                _remainTime = value;
                OnPropertyChanged();
            }
        }

        public void Start(int seconds = 1)
        {      
            Device.StartTimer(TimeSpan.FromSeconds(seconds), () =>
            {
                RemainTime = (EndDate.AddSeconds(1) - DateTime.Now);
                var ticked = RemainTime.TotalSeconds >= 1;                              
                if (ticked)
                {                                  
                    Ticked?.Invoke();
                }
                else
                {
                    Completed?.Invoke();
                   // count = 0;
                }

                if (Cancelar)
                {
                    
                    ticked = false;
                    Cancel?.Invoke();
                }

                return ticked;
            });
        }
        
      
        
    }
}

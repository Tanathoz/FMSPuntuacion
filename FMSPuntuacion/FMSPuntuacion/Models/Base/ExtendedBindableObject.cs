using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace FMSPuntuacion.Models.Base
{
    public class ExtendedBindableObject : BindableObject
    {
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FMSPuntuacion.Models.Base;
using FMSPuntuacion.Helpers;
using Xamarin.Forms;

namespace FMSPuntuacion.Models
{
    class AppTema:BaseModel
    {
        public Settings.Tema Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource icon
        {
            get;
            set;
        }
        bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

    }
}

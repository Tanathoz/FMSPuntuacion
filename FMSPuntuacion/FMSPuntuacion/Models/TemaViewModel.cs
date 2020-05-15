using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FMSPuntuacion.Helpers;
using FMSPuntuacion.Models.Base;
using Xamarin.Forms;

namespace FMSPuntuacion.Models
{
    class TemaViewModel:BaseModel
    {

        public TemaViewModel()
        {

            //Initialize the List with the theme details, you want to add in the app
            Themes = new List<AppTema>()
            {
                new AppTema() { Id = Settings.Tema.Defecto, Title = "Predeterminado", Description = "Tema por defecto", icon="flag.png" },
                new AppTema() { Id = Settings.Tema.Spain, Title = "España", Description = "Tema con colores de la bandera ", icon="spain.png"},
                new AppTema() { Id = Settings.Tema.Mexico, Title = "Mexico", Description = "Tema con colores mexico", icon="mexico.png" },
                new AppTema() { Id = Settings.Tema.Argentina, Title = "Argentina", Description = "Tema con colores argentina", icon="Argflag.png" },
                new AppTema() { Id = Settings.Tema.Chile, Title = "Chile", Description = "Tema con colores de chile", icon="Chileflag.png" },
            };

            //Find the Current/Last selected theme, and set the IsSelected property for that specific theme item in the list.
            var selectedTheme = Themes.FirstOrDefault(x => x.Id == Settings.CurrentTheme());
            selectedTheme.IsSelected = true;
        }


        AppTema _selectedTheme;
        public AppTema SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                SetProperty(ref _selectedTheme, value);
                if (value != null) { OnThemeSelected(value); }
            }
        }


        List<AppTema> _themes;
        public List<AppTema> Themes
        {
            get { return _themes; }
            set { SetProperty(ref _themes, value); }
        }

        private void OnThemeSelected(AppTema selectedTheme)
        {
            foreach (var t in Themes)
            {
                t.IsSelected = t.Id == selectedTheme.Id;
            }
            Settings.SetTheme(selectedTheme.Id);

            //For Android we need some Platform specific twicks for Android Toolbar. 
            //Apply this platform specific change by invoking following DependencyService
            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    DependencyService.Get<INativeServices>().OnThemeChanged(selectedTheme.Id);
            //}
        }


    }
}

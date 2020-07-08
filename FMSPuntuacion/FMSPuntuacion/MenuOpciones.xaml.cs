
using FMSPuntuacion.Vistas.Opciones;
using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FMSPuntuacion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuOpciones : MasterDetailPage
	{
		public MenuOpciones ()
		{
			InitializeComponent ();
            MyMenu();
           
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //wait some time 
        //    await notes.ScaleTo(0.5, 500, Easing.CubicInOut);
        //    var animationTasks = new[]{
        //    notes.ScaleTo(100.0, 1000, Easing.CubicInOut),
        //    notes.FadeTo(0, 700, Easing.CubicInOut)
        //    };
        //    await Task.WhenAll(animationTasks);

        //}

        public void MyMenu()
        {
            Detail = new NavigationPage(new Feed());
            List<Menu> menu = new List<Menu>
            {
                //new Menu {Page = new Feed(),  MenuTitle = "My Profile", MenuDetail="Mi perfil", icon="User.png"},
                new Menu {Page = new Feed(), MenuTitle = "Menú", MenuDetail="Inicio", icon="home.png" },
                new Menu {Page = new SeleccionaTema(), MenuTitle="Personalizar", MenuDetail="Temas", icon="Mediapaint.png" },
                new Menu {Page = new About(), MenuTitle="Acerca de", MenuDetail="info", icon="info.png"}
            };
            
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }

        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }

            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
	}
}
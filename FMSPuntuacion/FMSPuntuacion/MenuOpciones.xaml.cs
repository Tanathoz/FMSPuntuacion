using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void MyMenu()
        {
            Detail = new NavigationPage(new Feed());
            List<Menu> menu = new List<Menu>
            {
                new Menu {Page = new Feed(),  MenuTitle = "My Profile", MenuDetail="Mi perfil", icon="User.png"},
                new Menu {Page = new Feed(), MenuTitle = "Messages", MenuDetail="Practicar", icon="clock.png" },
                new Menu {Page = new Feed(), MenuTitle="Ajustes", MenuDetail="Contactos", icon="Setting.png" },
                new Menu {Page = new Feed(), MenuTitle="Contactos", MenuDetail="Plao", icon="contacts.png"}
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
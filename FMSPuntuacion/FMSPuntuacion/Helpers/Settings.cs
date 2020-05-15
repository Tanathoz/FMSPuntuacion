using Xamarin.Forms;
using Plugin.Settings;
using FMSPuntuacion.Temas;

namespace FMSPuntuacion.Helpers
{
    


    
    

    public class Settings
    {
        public enum Tema
        {
            Defecto,
            Spain,
            Mexico,
            Argentina,
            Chile
        }

      
        public static void SetTheme(Tema tema)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {

               // mergedDictionaries.Clear();
                CrossSettings.Current.AddOrUpdateValue("SelectedTheme", (int)tema);
                switch (tema)
                {
                    case Tema.Spain:
                        mergedDictionaries.Add(new Spain());
                        break;
                    case Tema.Mexico:
                        mergedDictionaries.Add(new Mexico());
                        break;
                    case Tema.Argentina:
                        mergedDictionaries.Add(new Argentina());
                        break;
                    case Tema.Chile:
                        mergedDictionaries.Add(new Chile());
                        break;
                    default:
                        mergedDictionaries.Add(new Defecto());
                        break;
                }
            }
                //Device.BeginInvokeOnMainThread(() =>
                //{
                //    switch (tema)
                //    {
                //        case Tema.Spain:
                //            Application.Current.Resources.MergedDictionaries[(int)Tema.Spain]["other"];
                //            break;
                //        case Tema.Mexico:
                //            Application.Current.Resources.MergedWith = typeof(Mexico);
                //            break;
                //        default:
                //            break;
                //    }

                //});


        }

        public static void LoadTheme()
        {
            Tema currentTheme = CurrentTheme();
            
            SetTheme(currentTheme);
        }

        public static Tema CurrentTheme()
        {
            return (Tema)CrossSettings.Current.GetValueOrDefault("SelectedTheme", (int)Tema.Defecto);
        }
    }
}

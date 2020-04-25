using System;
using System.Collections.Generic;
using System.Text;
using FMSPuntuacion.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using FMSPuntuacion.Models.Base;
using FMSPuntuacion.Vistas.Generador;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Threading;

namespace FMSPuntuacion.Models
{
    public class MyCountDownModel: BaseModel
    {
        private CountDown _countdown;
        
        private int _frecuencia;
        private int _minutes;
        private int _segundos;
        private string _palabra;
        private double _progress;
        public int count = 0;
        public int frecuencia = 0;
        public bool flagPalabra;
        public bool activar;
        public bool activarCancelar;
        public string color;
        public string colorCancelar;
        public List<string> lstPalabra { get; set; }
        public List<int> lstSegundos10 = new List<int>() { 59, 49, 39, 29,19,9 };
        public List<int> lstSegundos5 = new List<int>() { 59,54, 49,44, 39,34, 29,24, 19,14 ,9,4 };

        //COMENTARIO ES MEJOR PASAR ACA LO DE LAS PALABRAS QUE EN LA CLASE COUNTDOWN
        public MyCountDownModel()
        {
            _countdown = new CountDown();
            _segundos = 59;
            activar = true;
            color = "#44c767";
            colorCancelar = "LightGray";
        }
       
        public int Frecuencia
        {
            get => _frecuencia;
            set => SetProperty(ref _frecuencia, value);
        }
        public int Minutes
        {
            get => _minutes;
            set => SetProperty(ref _minutes, value);
        }
        public int Segundos
        {
            get => _segundos;
            set => SetProperty(ref _segundos, value);
        }
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }
       
        public string Palabra
        {
            get => _palabra;
            set => SetProperty(ref _palabra, value);
        }

        public string Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }

        public string ColorCancelar
        {
            get => colorCancelar;
            set => SetProperty(ref colorCancelar, value);
        }

        public bool Flag
        {
            get => flagPalabra;
            set => SetProperty(ref flagPalabra, value);
        }

        public bool Activar
        {
            get => activar;
            set => SetProperty(ref activar, value);
        }
        
        public bool ActivarCancelar
        {
            get => activarCancelar;
            set => SetProperty(ref activarCancelar, value);
        }
        public ICommand RestartCommand => new Command<XLabs.Forms.Controls.BindableRadioGroup>(Restart);
        public ICommand CancelCommand => new Command(Cancel);

        public override Task LoadAsync()
        {         
            _countdown.EndDate = DateTime.Now.AddMinutes(1);
            _countdown.Start();
            _countdown.Ticked += OnCountdownTicked;
            _countdown.Completed += OnCountdownCompleted;
            _countdown.Cancel += OnCountdownCancel;
            return base.LoadAsync();
        }

        //public override Task UnloadAsync()
        //{
        //    _countdown.Ticked -= OnCountdownTicked;
        //    _countdown.Completed -= OnCountdownCompleted;
        //    return base.UnloadAsync();
        //}

        void OnCountdownTicked()
        {

            Minutes = _countdown.RemainTime.Minutes;
            Segundos = _countdown.RemainTime.Seconds;
            var totalSeconds = (DateTime.Now.AddMinutes(1) - DateTime.Now).TotalSeconds;
            var remainSeconds = _countdown.RemainTime.TotalSeconds;
            Progress = remainSeconds / totalSeconds;
            //La pantalla no se bloqueara hasta finalizado el tiempo
            DeviceDisplay.KeepScreenOn = true;
          
            if (frecuencia == 2)
            {              
                if (lstSegundos10.Contains(Segundos))
                {                  
                    Debug.WriteLine("sder"  +Segundos +"palabra" + lstPalabra[count]);
                    Palabra = Capitalizar(lstPalabra[count]);                    
                    count++;                  
                }                  
            }else if ( frecuencia == 1 )
            {
                if (lstSegundos5.Contains(Segundos))
                {
                    Debug.WriteLine("Segundos 5S" + Segundos + "palabra" + lstPalabra[count] + " COUNT " + count);
                    Palabra = Capitalizar(lstPalabra[count]);
                    count++;
                }
            }
           
        }

        void OnCountdownCompleted()
        {
           
            Minutes = 0;
            Segundos = 0;
            Progress = 0;
            count = 0;
            Palabra = "Tiempo!!";
           // lstPalabra.Clear();
            _countdown.Ticked -= OnCountdownTicked;
            _countdown.Completed -= OnCountdownCompleted;
            //después de acabar el tiempo la pantalla se bloqueara en 30 seg
            DeviceDisplay.KeepScreenOn = false;
            Activar = true;
            ActivarCancelar = false;                 
            Color = "#44c767";
            ColorCancelar = "LightGray";
            // UnloadAsync();
        }

        void OnCountdownCancel()
        {                   
            Minutes = 0;
            Segundos = 59;
            Progress = 0;
            Palabra = string.Empty;
            count = 0;
            _countdown.Ticked -= OnCountdownTicked;
            _countdown.Completed -= OnCountdownCompleted;
            ////después de acabar el tiempo la pantalla se bloqueara en 30 seg
            ////Utilizar el onCountDownCompleted pero disminuir los segundos para temrinar bien el proceso
            DeviceDisplay.KeepScreenOn = false;
            Activar = true;
            ActivarCancelar = false;
            Color = "#44c767";
            ColorCancelar = "LightGray";

        }

        public string[] LeerArchivo()
        {
          //  string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Palabras.txt");
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FMSPuntuacion.Recursos.arregloPalabras.txt";
            string result = string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                 result= reader.ReadToEnd();              
            }
            string[] words = result.Split(',');
            return words;
        }

        public void Restart(XLabs.Forms.Controls.BindableRadioGroup Opciones)
        {
            Palabra = string.Empty;
            if (Opciones.Items[1].Checked && Opciones.IsEnabled)
            {
                flagPalabra = true;
                frecuencia = 2;
                string[] palabras=LeerArchivo();
                lstPalabra=RandomNumber(palabras, 6);
            }else if(Opciones.Items[0].Checked && Opciones.IsEnabled)
            {            
                flagPalabra = false;
                frecuencia = 1;
                string[] palabras = LeerArchivo();
                lstPalabra = RandomNumber(palabras,12); 
            }else if (!Opciones.IsEnabled)
            {
                frecuencia = 0;
            }

            Activar = false;
            ActivarCancelar = true;
            Color = "LightGray";
            ColorCancelar = "#44c767";
            _countdown.Cancelar = false;
            LoadAsync();                
        }

        public void Cancel()
        {
            _countdown.Cancelar = true;
           // OnCountdownCancel();
        }

        private static List<string> RandomNumber(string[] palabras, int numero)
        {
            Random rnd = new Random();
            List<string> lstPalabras = new List<string>();          
            //DecimalFormat df = new DecimalFormat("#.00");
            for (int i =0; i<numero; i++)
            {
                int num = rnd.Next(0,900);
                lstPalabras.Add(palabras[num]);
            }

            return lstPalabras;
        }

        static string Capitalizar(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

    }
}

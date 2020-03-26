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
using FMSPuntuacion.Models.Base;

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
        public bool otroF;
        public List<string> lstPalabra { get; set; }
        public List<int> lstSegundos10 = new List<int>() { 58, 49, 39, 29,19,9 };
        public List<int> lstSegundos5 = new List<int>() { 58,54, 49,44, 39,34, 29,24, 19,14 ,9,4 };

        //COMENTARIO ES MEJOR PASAR ACA LO DE LAS PALABRAS QUE EN LA CLASE COUNTDOWN
        public MyCountDownModel()
        {
            _countdown = new CountDown();
           
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

        public bool Flag
        {
            get => flagPalabra;
            set => SetProperty(ref flagPalabra, value);
        }

        
        public ICommand RestartCommand => new Command<XLabs.Forms.Controls.BindableRadioGroup>(Restart);

        public override Task LoadAsync()
        {         
            _countdown.EndDate = DateTime.Now.AddMinutes(1);
            _countdown.Start();
            _countdown.Ticked += OnCountdownTicked;
            _countdown.Completed += OnCountdownCompleted;         
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
            if (flagPalabra)
            {              
                if (lstSegundos10.Contains(Segundos))
                {                  
                    Debug.WriteLine("sder"  +Segundos +"palabra" + lstPalabra[count]);
                   
                    Palabra = lstPalabra[count];
                    count++;                  
                }                  
            }else if ( otroF )
            {
                if (lstSegundos5.Contains(Segundos))
                {
                    Debug.WriteLine("Segundos 5S" + Segundos + "palabra" + lstPalabra[count] + " COUNT " + count);
                    Palabra = lstPalabra[count]; ;
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
            lstPalabra.Clear();
            _countdown.Ticked -= OnCountdownTicked;
            _countdown.Completed -= OnCountdownCompleted;
            // UnloadAsync();
        }

        public string[] LeerArchivo()
        {
          //  string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Palabras.txt");
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FMSPuntuacion.Recursos.Palabras.txt";
            string result = string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                 result= reader.ReadToEnd();              
            }
            string[] words = result.Split('\n');
            return words;
        }

        public void Restart(XLabs.Forms.Controls.BindableRadioGroup Opciones)
        {
            if (Opciones.Items[1].Checked && Opciones.IsVisible)
            {
                flagPalabra = true;
                otroF = false;
                frecuencia = 2;
                string[] palabras=LeerArchivo();
                lstPalabra=RandomNumber(palabras, 6);
            }else if(Opciones.Items[0].Checked && Opciones.IsVisible)
            {
                otroF = true;
                flagPalabra = false;
                frecuencia = 1;
                string[] palabras = LeerArchivo();
                lstPalabra = RandomNumber(palabras,12); 
            }
                
                LoadAsync();                
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


    }
}

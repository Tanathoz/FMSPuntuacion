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
        public bool flagPalabra;
        public List<string> lstPalabra { get; set; }

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

        public ICommand RestartCommand => new Command<int>(Restart);

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
           
            if (flagPalabra)
            {              
                if (Segundos == 58 || Segundos == 49 || Segundos == 39 || Segundos == 29 || Segundos == 19 || Segundos == 9)
                {                  
                    Debug.WriteLine("Segundos" + lstPalabra[count]);
                    Palabra = lstPalabra[count];
                    count++;                  
                }                  
            }
            Minutes = _countdown.RemainTime.Minutes;
            Segundos = _countdown.RemainTime.Seconds;
            var totalSeconds = (DateTime.Now.AddMinutes(1) - DateTime.Now).TotalSeconds;
            var remainSeconds = _countdown.RemainTime.TotalSeconds;          
            Progress = remainSeconds / totalSeconds;
        }

        void OnCountdownCompleted()
        {         
            Minutes = 0;
            Segundos = 0;
            Progress = 0;
            count = 0;
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

        public void Restart(int Opciones)
        {
            if (Opciones >=0)
            //if (flag)
            {
                flagPalabra = true;
                string[] palabras=LeerArchivo();
                lstPalabra=RandomNumber(palabras);
            }
            //else
            //    _countdown.Flag = false;
                LoadAsync();                
        }

        private static List<string> RandomNumber(string[] palabras)
        {
            Random rnd = new Random();
            List<string> lstPalabras = new List<string>();          
            //DecimalFormat df = new DecimalFormat("#.00");
            for (int i =0; i<6; i++)
            {
                int num = rnd.Next(0,900);
                lstPalabras.Add(palabras[num]);
            }

            return lstPalabras;
        }


    }
}

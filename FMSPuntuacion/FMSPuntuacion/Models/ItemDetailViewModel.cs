using FMSPuntuacion.Tablas;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMSPuntuacion.Models
{
    public class ItemDetailViewModel:BaseViewModel
    {
        public Resultados Resultado { get; set; }
        public ItemDetailViewModel(Resultados resultado = null)
        {
            Title = resultado.sitio;
            Resultado = resultado;
            
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}

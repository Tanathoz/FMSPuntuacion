using FMSPuntuacion.Tablas;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMSPuntuacion.Models
{
    public class Item4TempVM: Base4Temp
    {
        public Resultado4Temp Resultado4Temp { get; set; }

        public Item4TempVM(Resultado4Temp resultado = null)
        {
            Title = resultado.sitio;
            Resultado4Temp = resultado;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}

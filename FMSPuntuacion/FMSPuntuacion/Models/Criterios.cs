using System;
using System.Collections.Generic;
using System.Text;

namespace FMSPuntuacion.Models
{
    public class Criterios
    {
        public string player1 { get; set; }
        public string player2 { get; set; }
        public int suma { get; set; }
        public int sumaP2 { get; set; }
        public int sumaHardModeP1 { get; set; }
        public int sumaHardModep2 { get; set; }
        public int sumaTematicaP1 { get; set; }
        public int sumaTematicaP2 { get; set; }
        public int sumaPersonajesP1 { get; set; }
        public int sumaPersonajesP2 { get; set; }
        public int sumaSangreP1 { get; set; }
        public int sumaSangreP2 { get; set; }
        public int sumaDeluxeP1 { get; set; }
        public int sumaDeluxeP2 { get; set; }
        public int sumaTotalP1 { get; set; }
        public int sumaTotalP2 { get; set; }
        public int respuestasP1 { get; set; }
        public int respuestasP2 { get; set; }
        public string ganador { get; set; }
        public string sitio { get; set; }
        public int[] lstCalificacionesP1 = new int[5];
        public List<int> lstCalificacionesP2 = new List<int>();      
    }
}

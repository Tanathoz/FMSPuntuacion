using System;
using System.Collections.Generic;
using System.Text;

namespace FMSPuntuacion.Models
{
    public class NewCriterios
    {
        public string player1 { get; set; }
        public string player2 { get; set; }
        public double suma { get; set; }
        public double sumaP2 { get; set; }
        public double sumaHardModeP1 { get; set; }
        public double sumaHardModep2 { get; set; }
        public double sumaTematicaP1 { get; set; }
        public double sumaTematicaP2 { get; set; }
        public double sumaPersonajesP1 { get; set; }
        public double sumaPersonajesP2 { get; set; }
        public double sumaSangreP1 { get; set; }
        public double sumaSangreP2 { get; set; }
        public double sumaDeluxeP1 { get; set; }
        public double sumaDeluxeP2 { get; set; }
        public double sumaTotalP1 { get; set; }
        public double sumaTotalP2 { get; set; }
        public int respuestasP1 { get; set; }
        public int respuestasP2 { get; set; }
        public string ganador { get; set; }
        public string sitio { get; set; }
        public bool replica { get; set; }
    }
}

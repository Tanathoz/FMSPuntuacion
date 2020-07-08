using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMSPuntuacion.Tablas
{
    public class Resultado4Temp
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(255)]
        public string player1 { get; set; }
        [MaxLength(255)]
        public string player2 { get; set; }
        public double EasyTotalP1 { get; set; }
        public double EasyTotalP2 { get; set; }
        public double HardTotalP1 { get; set; }
        public double HardTotalP2 { get; set; }
        public double TematicaTotalP1 { get; set; }
        public double TematicaTotalP2 { get; set; }
        public double PersonajesTotalP1 { get; set; }
        public double PersonajesTotalP2 { get; set; }
        public double SangreTotalP1 { get; set; }
        public double SangreTotalP2 { get; set; }
        public double DeluxeTotalP1 { get; set; }
        public double DeluxeTotalP2 { get; set; }

        public double totalPlayer1 { get; set; }
        public double totalPlayer2 { get; set; }
        [MaxLength(255)]
        public string ganador { get; set; }
        [MaxLength(500)]
        public string sitio { get; set; }
        [MaxLength(200)]
        public string fecha { get; set; }
    }
}

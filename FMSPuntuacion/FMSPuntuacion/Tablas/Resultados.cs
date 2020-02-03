using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FMSPuntuacion.Tablas
{
    public class Resultados
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(255)]
        public string player1 { get; set; }
        [MaxLength(255)]
        public string player2 { get; set; }
        public int EasyTotalP1 { get; set; }
        public int EasyTotalP2 { get; set; }
        public int HardTotalP1 { get; set; }
        public int HardTotalP2 { get; set; }
        public int TematicaTotalP1 { get; set; }
        public int TematicaTotalP2 { get; set; }
        public int PersonajesTotalP1 { get; set; }
        public int PersonajesTotalP2 { get; set; }
        public int SangreTotalP1 { get; set; }
        public int SangreTotalP2 { get; set; }
        public int DeluxeTotalP1 { get; set; }
        public int DeluxeTotalP2 { get; set; }

        public int totalPlayer1 { get; set; }
        public int totalPlayer2 { get; set; }
        [MaxLength(255)]
        public string ganador { get; set; }
        [MaxLength(500)]
        public string sitio { get; set; }
        [MaxLength(200)]
        public string fecha { get; set;}


    }
}

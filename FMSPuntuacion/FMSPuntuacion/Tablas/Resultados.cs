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

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FMSPuntuacion.Tablas
{
    public class CalificacionRonda
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
    }
}

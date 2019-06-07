using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FMSPuntuacion.Tablas
{
    public interface ISQLTables
    {
        SQLiteAsyncConnection GetConnection();
    }
}

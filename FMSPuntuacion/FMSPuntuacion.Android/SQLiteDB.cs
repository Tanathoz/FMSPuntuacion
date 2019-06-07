using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMSPuntuacion.Droid;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FMSPuntuacion.Tablas;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SQLiteDB))]
namespace FMSPuntuacion.Droid
{
    public class SQLiteDB : ISQLTables
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentSpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentSpath, "BaseResultados.db3");
            return new SQLiteAsyncConnection(path);
        }


    }
}
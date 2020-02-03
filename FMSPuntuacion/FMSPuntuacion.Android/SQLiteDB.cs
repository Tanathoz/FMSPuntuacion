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
using System.Threading.Tasks;
using Environment = System.Environment;

[assembly: Dependency(typeof(SQLiteDB))]
namespace FMSPuntuacion.Droid
{
    public class SQLiteDB : ISQLTables
    {
        public SQLiteDB()
        {

        }

        private string GetPath()
        {
            var dbName = "BaseResultados.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return path;
        }
        //readonly SQLiteAsyncConnection _database;

        //public SQLiteDB(string dbPath)
        //{
        //    _database = new SQLiteAsyncConnection(dbPath);
        //    _database.CreateTableAsync<Resultados>().Wait();
        //}

        //public Task<List<Resultados>> GetResultadosAsync()
        //{
        //    return _database.Table<Resultados>().ToListAsync();
        //}

        //public Task<Resultados> GetResultado(int id)
        //{
        //    return _database.Table<Resultados>().
        //        Where(i => i.id == id).FirstOrDefaultAsync();
        //}

        //public Task<int> SaveResultadoAsync(Resultados resultado)
        //{
        //    if (resultado.id != 0)
        //    {
        //        return _database.UpdateAsync(resultado);
        //    }else
        //    {
        //        return _database.InsertAsync(resultado);
        //    }
        //}

        //public Task<int> DeleteResultadoAsync(Resultados resultado)
        //{
        //    return _database.DeleteAsync(resultado);
        //}

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public string GetDatabasePath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            return Path.Combine(path, "BaseResultados.db3");
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(GetPath());
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            const int length = 256;
            var buffer = new byte[length];
            var bytesRead = readStream.Read(buffer, 0, length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, length);
            }
            readStream.Close();
            writeStream.Close();
        }


    }
}
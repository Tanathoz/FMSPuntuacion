using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMSPuntuacion.Services;
using FMSPuntuacion.Tablas;
using FMSPuntuacion.Vistas;
using Xamarin.Forms;

[assembly: Dependency(typeof(FMSPuntuacion.Services.SQLDataStore))]
namespace FMSPuntuacion.Services
{
    public class SQLDataStore : IDataStore<Resultados>
    {
        private readonly ISQLTables _platform;
        public SQLDataStore(ISQLTables platform)
        {
            _platform = platform;
            var con = _platform.GetConnection();
            con.CreateTable<Resultados>();
            con.Close();
        }

        public SQLDataStore()
        {
            _platform = DependencyService.Get<ISQLTables>();
            var con = _platform.GetConnection();
            con.CreateTable<Resultados>();
            con.Close();
        }

        public async Task<bool> AddResultadoAsync(Resultados item)
        {
            return (await _platform.GetAsyncConnection().InsertAsync(item)) > 0;
        }

        public async Task<bool> UpdateResultadoAsync(Resultados item)
        {
            return (await _platform.GetAsyncConnection().UpdateAsync(item)) > 0;
        }

        public async Task<bool> DeleteResultadoAsync(Resultados item)
        {
            return (await _platform.GetAsyncConnection().DeleteAsync(item)) > 0;
        }

       

        public async Task<Resultados> GetResultadoAsync(int id)
        {
            return await _platform.GetAsyncConnection()
               .Table<Resultados>().Where(x => x.id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Resultados>> GetResultadoAsync()
        {
            return await _platform.GetAsyncConnection().Table<Resultados>().ToListAsync();
        }
      
       
    }
}
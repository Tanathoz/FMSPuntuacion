using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FMSPuntuacion.Services;
using FMSPuntuacion.Tablas;
using FMSPuntuacion.Vistas;
using Xamarin.Forms;

[assembly: Dependency(typeof(FMSPuntuacion.Services.DataStore4Temp))]
namespace FMSPuntuacion.Services
{
    public class DataStore4Temp : IDataStore<Resultado4Temp>
    {
        private readonly ISQLTables _platform;
        public DataStore4Temp(ISQLTables platform)
        {
            _platform = platform;
            var con = _platform.GetConnection();
            con.CreateTable<Resultado4Temp>();
            con.Close();
        }

        public DataStore4Temp()
        {
            _platform = DependencyService.Get<ISQLTables>();
            var con = _platform.GetConnection();
            con.CreateTable<Resultado4Temp>();
            con.Close();
        }

        public async Task<bool> AddResultadoAsync(Resultado4Temp item)
        {
            return (await _platform.GetAsyncConnection().InsertAsync(item)) > 0;
        }

        public async Task<bool> UpdateResultadoAsync(Resultado4Temp item)
        {
            return (await _platform.GetAsyncConnection().UpdateAsync(item)) > 0;
        }

        public async Task<bool> DeleteResultadoAsync(Resultado4Temp item)
        {
            return (await _platform.GetAsyncConnection().DeleteAsync(item)) > 0;
        }

        public async Task<Resultado4Temp> GetResultadoAsync(int id)
        {
            return await _platform.GetAsyncConnection()
               .Table<Resultado4Temp>().Where(x => x.id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Resultado4Temp>> GetResultadoAsync()
        {
            return await _platform.GetAsyncConnection().Table<Resultado4Temp>().ToListAsync();
        }
 
    }
}


using FMSPuntuacion.Tablas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FMSPuntuacion.Services
{
    public class Repository<T> where T:class, new()
    {
        private readonly ISQLTables _platform;

        public Repository(ISQLTables platform)
        {
            _platform = platform;
            var con = _platform.GetConnection();
            con.CreateTable<T>();
            con.Close();
        }

        public Repository()
        {
            _platform = DependencyService.Get<ISQLTables>();
            var con = _platform.GetConnection();
            con.CreateTable<T>();
            con.Close();

        }

        public async Task<bool> AddResultadoAsync(T item)
        {
            return (await _platform.GetAsyncConnection().InsertAsync(item)) > 0;
        }

        public async Task<bool> UpdateResultadoAsync(T item)
        {
            return (await _platform.GetAsyncConnection().UpdateAsync(item)) > 0;
        }

        public async Task<bool> DeleteItemAsync(T item)
        {
            return (await _platform.GetAsyncConnection().DeleteAsync(item)) > 0;
        }

        public async Task<IEnumerable<T>> GetResultadoAsync()
        {
            return await _platform.GetAsyncConnection().Table<T>().ToListAsync();
        }
    }
}

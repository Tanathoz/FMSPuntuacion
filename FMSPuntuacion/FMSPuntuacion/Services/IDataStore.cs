using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FMSPuntuacion.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddResultadoAsync(T item);
        Task<bool> UpdateResultadoAsync(T item);
        Task<bool> DeleteResultadoAsync(T item);
        Task<T> GetResultadoAsync(int id);
        Task<IEnumerable<T>> GetResultadoAsync();
    }
}

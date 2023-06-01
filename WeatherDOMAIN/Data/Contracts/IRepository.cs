using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDOMAIN.Data.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }
}

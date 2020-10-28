using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_database.interfaces
{
    public interface IStore<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> FindAllAsync();
        Task<TModel> FindAsync(object id);
        Task CreateAsync(TModel entity);
        Task DeleteAsync(object id);

    }
}

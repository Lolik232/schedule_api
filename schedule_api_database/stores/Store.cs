using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using schedule_api_database.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_database.stores
{
    public abstract class Store<TModel> : IStore<TModel> where TModel : class
    {
        protected readonly MsSqlContext _context;

        public Store(MsSqlContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TModel entity)
        {
            await _context.Set<TModel>().AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            TModel entity = await FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<TModel> FindAsync(object id)
        {
            return await _context.Set<TModel>().FindAsync(id);
        }

        public async Task<IEnumerable<TModel>> FindAllAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }
    }
}

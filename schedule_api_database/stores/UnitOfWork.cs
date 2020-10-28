using Microsoft.EntityFrameworkCore;
using schedule_api_database.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_database.stores
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlContext _context;
        public ISettingsStore SettingsStore { get; set; }

        public UnitOfWork(MsSqlContext context)
        {
            _context = context;
            SettingsStore = new SettingsStore(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(object entity)
        {
            await Task.Run(() => _context.Entry(entity).State = EntityState.Modified);
            return true;
        }

    }
}

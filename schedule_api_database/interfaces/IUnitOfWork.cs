using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_database.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ISettingsStore SettingsStore { get; set; }
        Task<bool> SaveChangesAsync();
        Task<bool> UpdateAsync(object entity);
    }
}

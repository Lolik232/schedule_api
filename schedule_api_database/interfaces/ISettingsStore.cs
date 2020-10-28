using schedule_api_database.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_database.interfaces
{
    public interface ISettingsStore : IStore<Settings>
    {
        public Task<Settings> FindByUserId(object userId);
    }
}

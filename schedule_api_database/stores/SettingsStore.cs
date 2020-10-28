using Microsoft.EntityFrameworkCore;
using schedule_api_database.interfaces;
using schedule_api_database.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_database.stores
{
    public class SettingsStore : Store<Settings>, ISettingsStore
    {
        public SettingsStore(MsSqlContext context) : base(context)
        {
        }

        public async Task<Settings> FindByUserId(object userId)
        {
            return await _context.Settings.FirstOrDefaultAsync(settings => Equals((string)userId, settings.GibbonAccountId));
        }
    }
}

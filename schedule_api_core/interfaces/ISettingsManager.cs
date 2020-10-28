using schedule_api_core.dto_s;
using schedule_api_core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_core.Interfaces
{
    public interface ISettingsManager
    {
        Task<(SettingsDto, Result)> FindSettingsForUSer(string access_token);
        Task<Result> CreateSettingsForUser(string access_token, SettingsDto settings);
    }
}

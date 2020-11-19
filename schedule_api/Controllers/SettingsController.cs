using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schedule_api_core.dto_s;
using schedule_api_core.Interfaces;

namespace schedule_api.Controllers
{
    [ApiController, Route("settings")]
    public class SettingsController : ControllerBase
    {

        private readonly ISettingsManager _settingsManager;

        public SettingsController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [Route("sync"), HttpPost]
        public async Task<IActionResult> SyncSettings([FromQuery] string access_token, [FromBody] SettingsDto settings)
        {
            var result = await _settingsManager.CreateSettingsForUser(access_token, settings);

            if (result.Succeeded)
                return Ok();
            return BadRequest(new { error = result.Error });
        }
        [Route("get"), HttpGet]
        public async Task<IActionResult> FindSettings(string access_token)
        {
            (var settings, var result) = await _settingsManager.FindSettingsForUSer(access_token);
            if (result.Succeeded)
                return Ok(new { response = new { settings } });
            return BadRequest(new { error = result.Error });
        }
    }
}

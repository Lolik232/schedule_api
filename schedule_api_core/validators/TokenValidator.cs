using Newtonsoft.Json.Linq;
using schedule_api_core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace schedule_api_core.Validators
{
    public class TokenValidator
    {
        public async Task<(string, Result)> ValidateAsync(HttpClient httpClient, string token)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var result = await httpClient.GetAsync($"/api/userinfo");
                if (result.IsSuccessStatusCode)
                {
                    var userinfo = JObject.Parse(await result.Content.ReadAsStringAsync()).GetValue("user");
                    var userId = userinfo.Value<string>("id");

                    return (userId, Result.Sucess);
                }

                var error = new Error(ErrorCodes.InvalidParam, "Invalid token.");
                return (string.Empty, Result.Failed(error));
            }
            catch (HttpRequestException)
            {
                return (string.Empty, Result.Failed());
            }
        }
    }
}

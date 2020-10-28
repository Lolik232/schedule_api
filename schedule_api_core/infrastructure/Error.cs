using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace schedule_api_core.Infrastructure
{
    [JsonObject("error")]
    public class Error
    {
        [JsonPropertyName("error_msg")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("error_code")]
        public byte ErrorCode { get; set; }

        internal Error(ErrorCodes code, string msg)
        {
            ErrorMessage = ErrorMessages.GetMessage(code) + msg;
            ErrorCode = (byte)code;
        }

        internal Error(ErrorCodes code)
        {
            ErrorMessage = ErrorMessages.GetMessage(code);
            ErrorCode = (byte)code;
        }
    }
}

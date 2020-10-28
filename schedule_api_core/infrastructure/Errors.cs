using System;
using System.Collections.Generic;
using System.Text;

namespace schedule_api_core
{
    enum ErrorCodes : byte
    {
        UndefinedError = 0,
        InvalidParam = 1,
        DataBaseError = 200,
        UserDontHaveSettings = 10
    }

    internal static class ErrorMessages
    {
        private readonly static IDictionary<ErrorCodes, string> _descriptions = new Dictionary<ErrorCodes, string>
        {
            { ErrorCodes.UndefinedError, "Undefined error. " },
            { ErrorCodes.InvalidParam, "One of the parameters is undefined or invalid. " },
            { ErrorCodes.DataBaseError, "Sorry,but our database thrown exception. " },
            { ErrorCodes.UserDontHaveSettings, "We don't have settings for this user, first sync settings with server. " }
        };

        internal static string GetMessage(ErrorCodes code)
        {
            return _descriptions[code];
        }

    }
}

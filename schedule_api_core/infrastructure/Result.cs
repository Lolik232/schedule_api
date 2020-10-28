using System;
using System.Collections.Generic;
using System.Text;

namespace schedule_api_core.Infrastructure
{
    public class Result 
    {
        private static readonly Result _sucess = new Result { Succeeded = true };
        public static Result Sucess => _sucess;

        private Error _error;
        public bool Succeeded { get; private set; }
        public Error Error => _error;

        public static Result Failed(Error error)
        {
            var result = new Result { Succeeded = false };
            if (error == null)
                return result;
            result._error = error;
            return result;
        }
        public static Result Failed()
        {
            var result = new Result { Succeeded = false, _error = new Error(ErrorCodes.UndefinedError) };
            return result;
        }
    }

}

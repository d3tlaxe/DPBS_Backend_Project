using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool _success, string _message) : this(_success)
        {
            Message = _message;
        }
        public Result(bool _success)
        {
            Success = _success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results
{
    public class Result<T> where T : class
    {
        public bool OK { get; } = true;

        public string Error { get; }

        public Exception Exception { get; }

        public T Data { get; }

        public Result(T data) : this(data,null,null)
        {

        }

        public Result(string error, Exception ex = null) : this(null,error, ex)
        {
            OK = false;
            Error = error;
        }

        public Result(Exception ex, string error = null) : this(null, error, ex)
        {
            OK = false;
            Exception = ex;
        }

        public Result(T data, string error, Exception ex)
        {
            if (data == null || !string.IsNullOrEmpty(error) || ex != null)
            {
                OK = false;
                Error = error;
                Exception = ex;
                return;
            }
            OK = true;
            Data = data;
        }
    }
}
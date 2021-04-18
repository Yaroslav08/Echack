using System;
using System.Collections;
namespace Ereceipt.Application.Results
{
    public class Result
    {
        public bool OK { get; }

        public string Error { get; }

        public Exception Exception { get; }

        public object Data { get; }

        public int CountOfData { get; }

        public Result(object data) : this(data, null, null)
        {

        }

        public Result(string error, Exception ex = null) : this(null, error, ex)
        {
            OK = false;
            Error = error;
        }

        public Result(Exception ex, string error = null) : this(null, error, ex)
        {
            OK = false;
            Exception = ex;
        }

        public Result(object data, string error, Exception ex)
        {
            if (data == null)
            {
                OK = false;
                Error = "Resourse not found";
                Exception = ex;
                CountOfData = 0;
                return;
            }
            if (!string.IsNullOrEmpty(error) || ex != null)
            {
                OK = false;
                Error = error;
                Exception = ex;
                CountOfData = 0;
                return;
            }
            OK = true;
            Data = data;
            if (Data is ICollection)
            {
                CountOfData = (Data as ICollection).Count;
                return;
            }
            CountOfData = 1;
        }
    }
}
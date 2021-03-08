using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Web.Responses
{
    public abstract class APIResponse
    {
        public bool OK { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeSpan { get; set; } = DateTime.Now;
        public object Data { get; set; }

        public APIResponse(bool ok, int statuscode, string message, string errormessage, object data)
        {
            OK = ok;
            StatusCode = statuscode;
            Message = message;
            ErrorMessage = errormessage;
            Data = data;
        }
    }

    public class APIOKResponse : APIResponse
    {
        public APIOKResponse(object Data = null, string Message = "Success") : base(true, 200, Message, null, Data)
        { }
    }

    public class APINotFoundResponse : APIResponse
    {
        public APINotFoundResponse(string errormessage = "Resource not found") : base(false, 404, null, errormessage, null)
        { }
    }

    public class APIInternalServerErrorResponse : APIResponse
    {
        public APIInternalServerErrorResponse() : base(false, 500, null, "Internal erver error", null)
        { }
    }
}

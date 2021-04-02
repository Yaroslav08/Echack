using System;

namespace Ereceipt.Web.Responses
{
    public abstract class APIResponse
    {
        public bool OK { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }

        public APIResponse(bool ok, string errormessage, object data)
        {
            OK = ok;
            ErrorMessage = errormessage;
            Data = data;
        }
    }

    public class APIOKResponse : APIResponse
    {
        public APIOKResponse(object Data = null) : base(true, null, Data)
        { }
    }

    public class APIBadRequestResponse : APIResponse
    {
        public APIBadRequestResponse(string error): base(false, error,null)
        { }
    }

    public class APINotFoundResponse : APIResponse
    {
        public APINotFoundResponse(string errormessage = "Resource not found") : base(false, errormessage, null)
        { }
    }

    public class APIInternalServerErrorResponse : APIResponse
    {
        public APIInternalServerErrorResponse() : base(false, "Internal erver error", null)
        { }
    }
}

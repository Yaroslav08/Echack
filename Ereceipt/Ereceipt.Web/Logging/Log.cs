using System;
namespace Ereceipt.Web.Logging
{
    public class Log
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Method { get; set; }
        public string Payload { get; set; }
        public string Response { get; set; }
        public string ResponseCode { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime RespondedOn { get; set; }
        public double RequestTime { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public Exception Exception { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
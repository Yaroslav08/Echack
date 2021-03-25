using System;
namespace Ereceipt.Web.AppSetting
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string Name { get; set; }
    }
}
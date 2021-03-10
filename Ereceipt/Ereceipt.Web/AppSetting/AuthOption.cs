using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Web.AppSetting
{
    public class AuthOption
    {
        public const string ISSUER = "EreceiptServer";
        public const string AUDIENCE = "EreceiptClient";
        const string KEY = "mysupersecret_secretkey!0803";
        public const int LIFETIMEDays = 15;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
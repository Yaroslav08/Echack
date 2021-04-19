using Ereceipt.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Web.AppSetting
{
    public class TokenResult : Result
    {
        public TokenResult(TokenResponse tokenResponse) : base(tokenResponse) { }

        public TokenResult(string error) : base(null, error) { }
    }
}

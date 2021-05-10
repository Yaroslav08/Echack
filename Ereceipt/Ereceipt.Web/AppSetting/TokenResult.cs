using Ereceipt.Application.Results;

namespace Ereceipt.Web.AppSetting
{
    public class TokenResult : Result
    {
        public TokenResult(TokenResponse tokenResponse) : base(tokenResponse) { }

        public TokenResult(string error) : base(null, error) { }
    }
}

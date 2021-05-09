using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Domain.Interfaces;
using Extensions;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Implementations
{
    public class UsernameService : IUsernameService
    {
        private readonly IUserRepository _userRepository;
        public UsernameService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GeneratingNewUsernameAsync(int length = 8)
        {
            string username = "";
            do
            {
                username = Generator.GetString(length);
            }
            while (await UsernameIsBusyAsync(username));
            return username;
        }

        public async Task<bool> UsernameIsBusyAsync(string username) 
            => await _userRepository.IsExistAsync(x => x.Username == username);
    }
}
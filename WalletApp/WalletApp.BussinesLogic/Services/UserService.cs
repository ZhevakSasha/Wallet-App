using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.BussinesLogic.Services.Interfaces;
using WalletApp.DataAccess.Repository;

namespace WalletApp.BussinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DoesUserExistAsync(Guid id)
        {
            return await _userRepository.DoesUserExistAsync(id);
        }
    }
}

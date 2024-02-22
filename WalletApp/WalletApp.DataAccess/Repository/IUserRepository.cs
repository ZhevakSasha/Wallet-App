using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.DataAccess.Entities;

namespace WalletApp.DataAccess.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserIdAsync(Guid userId);
    }
}

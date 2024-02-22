using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.BussinesLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> DoesUserExistAsync(Guid id);
    }
}

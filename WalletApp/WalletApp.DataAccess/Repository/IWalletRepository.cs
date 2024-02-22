using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.DataAccess.Entities;

namespace WalletApp.DataAccess.Repository
{
    public interface IWalletRepository
    {
        Task<decimal> GetCardBalance(Guid userId);
        Task<IList<Transaction>> GetLatestTransactions(Guid userId);
    }
}

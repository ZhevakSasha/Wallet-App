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
        Task<decimal> GetCardBalanceAsync(Guid userId);
        Task<IList<Transaction>> GetLatestTransactionsAsync(Guid userId);
        Task<Transaction> GetTransactionByIdAsync(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WalletApp.BussinesLogic.DtoModels;

namespace WalletApp.BussinesLogic.Services
{
    public interface IWalletService
    {
        Task<decimal> GetCardBalance(Guid userId);
        Task<IList<TransactionDto>> GetLatestTransactions(Guid userId);
        string GetDailyPoints(int dayOfSeason);
    }
}

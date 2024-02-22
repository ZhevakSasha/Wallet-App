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
        Task<UserBalanceDto> GetCardBalanceAsync(Guid userId);
        Task<IList<TransactionDto>> GetLatestTransactionsAsync(Guid userId);
        string GetDailyPoints(int dayOfSeason);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.BussinesLogic.DtoModels;
using WalletApp.DataAccess.Repository;

namespace WalletApp.BussinesLogic.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<UserBalanceDto> GetCardBalanceAsync(Guid userId)
        {
            var cardBalance = await _walletRepository.GetCardBalanceAsync(userId);
            var userBalanceDto = new UserBalanceDto(cardBalance);

            return userBalanceDto;
        }

        public string GetDailyPoints(int dayOfSeason)
        {
            if (dayOfSeason == 1 || dayOfSeason == 2)
                return dayOfSeason.ToString();

            var points = 3.0;
            var previousDayPoints = 2.0;

            for (int i = 2; i < dayOfSeason; i++)
            {
                var pointsBeforePreviousDayPoints = points;
                points = previousDayPoints + (0.6 * points);
                previousDayPoints = pointsBeforePreviousDayPoints;
            }

            if (points >= 1000)
                return (points / 1000).ToString("0K");

            return Math.Round(points).ToString();
        }

        public async Task<IList<TransactionDto>> GetLatestTransactionsAsync(Guid userId)
        {
            var transactions =  await _walletRepository.GetLatestTransactionsAsync(userId);

            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                TransactionName = t.TransactionName,
                TransactionType = t.TransactionType.ToString(),
                IsPending = t.IsPending,
                IconData = t.IconData,
                Date = t.Date,
            }).ToList();

            return transactionDtos;
        }
    }
}

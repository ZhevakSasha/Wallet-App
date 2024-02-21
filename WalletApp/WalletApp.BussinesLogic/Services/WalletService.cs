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

        public async Task<decimal> GetCardBalance(Guid userId)
        {
            var cardBalance = await _walletRepository.GetCardBalance(userId);

            return cardBalance;
        }

        public string GetCurrentMonth()
        {
            return DateTime.Now.ToString("MMMM");
        }

        public string GetDailyPoints()
        {
            var date = DateTime.Now;

            var seasonStarts = new DateTime[] {
            new DateTime(date.Year, 3, 1),
            new DateTime(date.Year, 6, 1),
            new DateTime(date.Year, 9, 1),
            new DateTime(date.Year, 12, 1)
            };

            int seasonIndex = 0;

            while (seasonIndex < seasonStarts.Length - 1 && date >= seasonStarts[seasonIndex + 1])
            {
                seasonIndex++;
            }

            if (date < seasonStarts[0])
            {
                seasonIndex = seasonStarts.Length - 1;
            }

            var totalDays = date - seasonStarts[seasonIndex];

            var  daysInSeason = 0;

            if (date.Month == 1 || date.Month == 2)
                daysInSeason = totalDays.Days + (DateTime.IsLeapYear(date.Year) ? 366 : 365);
            else
                daysInSeason = totalDays.Days + 1;

            if(daysInSeason == 1 || daysInSeason == 2)
                return daysInSeason.ToString();

            var points = 3.0;
            var previousDayPoints = 2.0;

            for (int i = 2; i < daysInSeason; i++)
            {
                var pointsBeforePreviousDayPoints = points;
                points = previousDayPoints + (0.6 * points);
                previousDayPoints = pointsBeforePreviousDayPoints;
            }

            if (points >= 1000)
                return (points / 1000).ToString("0K");

            return Math.Round(points).ToString();
        }

        public async Task<IList<TransactionDto>> GetLatestTransactions(Guid userId)
        {
            var transactions =  await _walletRepository.GetLatestTransactions(userId);

            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                TransactionName = t.TransactionName,
                TransactionType = t.TransactionType,
                IsPending = t.IsPending,
                Date = t.Date,
            }).ToList();

            return transactionDtos;
        }
    }
}

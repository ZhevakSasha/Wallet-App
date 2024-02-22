using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.DataAccess.Entities;

namespace WalletApp.DataAccess.Repository
{
    public class EFWalletRepository : IWalletRepository
    {
        private readonly AppDbContext _dbContext;

        public EFWalletRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<decimal> GetCardBalanceAsync(Guid userId)
        {
            var cardBalance = await _dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => u.CardBalance)
                .FirstOrDefaultAsync();

            return cardBalance;
        }

        public async Task<IList<Transaction>> GetLatestTransactionsAsync(Guid userId)
        {
            var transactions = await _dbContext.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .ToListAsync();

            return transactions;
        }

        public async Task<Transaction> GetTransactionByIdAsync(Guid id)
        {
            var transaction = await _dbContext.Transactions
                .Where(u => u.TransactionId == id)
                .FirstOrDefaultAsync();

            return transaction;
        }
    }
}

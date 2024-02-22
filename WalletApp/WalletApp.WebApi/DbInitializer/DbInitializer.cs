using WalletApp.DataAccess.Entities;
using WalletApp.DataAccess;
using WalletApp.DataAccess.Enums;
using System;
using System.Runtime.Intrinsics.X86;

namespace WalletApp.WebApi.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (!_context.Users.Any())
            {
                var user1 = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "TestUser1",
                    CardBalance = new Random().Next(0, 1501)
                };

                var user2 = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "TestUser2",
                    CardBalance = new Random().Next(0, 1501)
                };

                _context.Users.AddRange(user1, user2);
                _context.SaveChanges();

                GenerateTransactionsForUser(user1, 15);
                GenerateTransactionsForUser(user2, 15);

                _context.SaveChanges();
            }

        }

        private void GenerateTransactionsForUser(User user, int numberOfTransactions)
        {
            for (int i = 0; i < numberOfTransactions; i++)
            {
                var transaction = new Transaction
                {
                    TransactionId = Guid.NewGuid(),
                    TransactionName = $"Transaction{i + 1} for {user.UserName}",
                    TransactionType = (TransactionTypeEnum)new Random().Next(1, 3),
                    IsPending = false,
                    Date = DateTime.UtcNow.AddDays(-i),
                    AuthorizedUserName = user.UserName,
                    UserId = user.Id
                };

                _context.Transactions.Add(transaction);
            }
        }
    }
}

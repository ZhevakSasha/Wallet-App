using WalletApp.DataAccess.Entities;
using WalletApp.DataAccess;
using WalletApp.DataAccess.Enums;
using System;
using System.Runtime.Intrinsics.X86;
using System.Drawing;

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
                    TransactionName = $"Transaction{i + 1}",
                    TransactionText = $"Transaction text{i + 1}",
                    TransactionType = (TransactionTypeEnum)new Random().Next(1, 3),
                    IsPending = false,
                    Date = DateTime.UtcNow.AddDays(-i),
                    AuthorizedUserName = user.UserName,
                    Amount = new Random().Next(0, 1501),
                    IconData = IconToBytes(),
                    UserId = user.Id
                };

                _context.Transactions.Add(transaction);
            }
        }

        static Image CreateImage()
        {
            int imageSize = 64;

            using (Bitmap bitmap = new Bitmap(imageSize, imageSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.DarkSlateGray); 
                }

                return (Image)bitmap.Clone();
            }
        }

        private byte[] IconToBytes()
        {
            var icon = CreateImage();
            using (MemoryStream ms = new MemoryStream())
            {
                icon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}

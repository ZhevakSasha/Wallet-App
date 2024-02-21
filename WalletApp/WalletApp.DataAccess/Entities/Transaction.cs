using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.DataAccess.Enums;

namespace WalletApp.DataAccess.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public string TransactionName { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public bool IsPending { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public decimal CardBalance { get; set; }
        
        public IList<Transaction> Transactions { get; set; }
    }
}

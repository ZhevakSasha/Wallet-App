using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.DataAccess.Entities;
using WalletApp.DataAccess.Enums;

namespace WalletApp.BussinesLogic.DtoModels
{
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public string TransactionName { get; set; }
        public string TransactionText { get; set; }
        public string Amount { get; set; }
        public string TransactionType { get; set; }
        public string ?AuthorizedUserName { get; set; }
        public bool IsPending { get; set; }
        public byte[] IconData { get; set; }
        public string Date { get; set; }
    }
}

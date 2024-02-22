using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.BussinesLogic.DtoModels
{
    public class UserBalanceDto
    {
        public decimal CardBalance { get; private set; }
        public decimal Limit {  get; private set; }

        public UserBalanceDto(decimal cardBalance) 
        {
            CardBalance = cardBalance;
            Limit = 1500 - cardBalance;
        }
    }
}

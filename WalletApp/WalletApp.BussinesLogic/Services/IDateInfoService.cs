using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.BussinesLogic.Services
{
    public interface IDateInfoService
    {
        string GetCurrentMonth();

        int GetCurrentSeasonDay();
    }
}

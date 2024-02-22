using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WalletApp.BussinesLogic.DtoModels;
using WalletApp.BussinesLogic.Services;

namespace WalletApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IDateInfoService _dateInfoService;

        public WalletController(IWalletService walletService, IDateInfoService dateInfoService)
        {
            _walletService = walletService;
            _dateInfoService = dateInfoService;
        }

        [HttpGet("latest-transactions")]
        public async Task<IList<TransactionDto>> GetLatestTransactions(Guid userId)
        { 
            return await _walletService.GetLatestTransactions(userId);
        }

        [HttpGet("current-month")]
        public string GetCurrentMonth()
        {
            return _dateInfoService.GetCurrentMonth();
        }

        [HttpGet("daily-points")]
        public string GetDailyPoints()
        {
            var currentDayOfSeason = _dateInfoService.GetCurrentSeasonDay();
            return _walletService.GetDailyPoints(currentDayOfSeason);
        }

        [HttpGet("card-balance")]
        public async Task<decimal> GetCardBalance(Guid userId)
        {
            return await _walletService.GetCardBalance(userId);
        }
    }
}

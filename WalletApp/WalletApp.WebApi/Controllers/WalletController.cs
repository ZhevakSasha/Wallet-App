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
        private readonly IUserService _userService;

        public WalletController(IWalletService walletService, IDateInfoService dateInfoService, IUserService userService)
        {
            _walletService = walletService;
            _dateInfoService = dateInfoService;
            _userService = userService;
        }

        [HttpGet("latest-transactions")]
        public async Task<ActionResult<IList<TransactionDto>>> GetLatestTransactionsAsync(Guid userId)
        {
            var userExists = await _userService.DoesUserExistAsync(userId);

            if (!userExists)
            {
                return NotFound($"User with ID {userId} not found");
            }

            var transactions = await _walletService.GetLatestTransactionsAsync(userId);

            if (transactions == null)
            {
                return NotFound($"Transactions for user {userId} not found");
            }

            return Ok(transactions);
        }

        [HttpGet("payment-due")]
        public string PaymentDue()
        {
            var currentMonth = _dateInfoService.GetCurrentMonth();
            var massage = $"You’ve paid your {currentMonth} balance.";

            return massage;
        }

        [HttpGet("daily-points")]
        public string GetDailyPoints()
        {
            var currentDayOfSeason = _dateInfoService.GetCurrentSeasonDay();
            return _walletService.GetDailyPoints(currentDayOfSeason);
        }

        [HttpGet("card-balance")]
        public async Task<ActionResult<UserBalanceDto>> GetCardBalanceAsync(Guid userId)
        {
            var userExists = await _userService.DoesUserExistAsync(userId);

            if (!userExists)
            {
                return NotFound($"User with ID {userId} not found");
            }

            var userBalanceDto = await _walletService.GetCardBalanceAsync(userId);

            return Ok(userBalanceDto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.BussinesLogic.Services.Interfaces;

namespace WalletApp.BussinesLogic.Services
{
    public class DateInfoService : IDateInfoService
    {
        public string GetCurrentMonth()
        {
            DateTimeFormatInfo dtfi = new CultureInfo("en-US").DateTimeFormat;
            return DateTime.UtcNow.ToString("MMMM", dtfi);
        }

        public int GetCurrentSeasonDay()
        {
            var date = DateTime.UtcNow;

            var seasonStarts = new DateTime[] {
                new (date.Year, 3, 1),
                new (date.Year, 6, 1),
                new (date.Year, 9, 1),
                new (date.Year, 12, 1)
            };

            int seasonIndex = 0;

            while (seasonIndex < seasonStarts.Length - 1 && date >= seasonStarts[seasonIndex + 1])
            {
                seasonIndex++;
            }

            if (date < seasonStarts[0])
            {
                seasonIndex = seasonStarts.Length - 1;
            }

            var totalDays = date - seasonStarts[seasonIndex];

            if (date.Month == 1 || date.Month == 2)
                return totalDays.Days + (DateTime.IsLeapYear(date.Year) ? 366 : 365);
            
            return totalDays.Days + 1;
        }
    }
}

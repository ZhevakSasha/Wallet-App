using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.BussinesLogic.Services
{
    public class DateInfoService : IDateInfoService
    {
        public string GetCurrentMonth()
        {
            return DateTime.Now.ToString("MMMM");
        }

        public int GetCurrentSeasonDay()
        {
            var date = DateTime.Now;

            var seasonStarts = new DateTime[] {
            new DateTime(date.Year, 3, 1),
            new DateTime(date.Year, 6, 1),
            new DateTime(date.Year, 9, 1),
            new DateTime(date.Year, 12, 1)
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
